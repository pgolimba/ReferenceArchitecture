using Access.Primitives.EFCore;
using Access.Primitives.IO;
using GrainInterfaces;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using Orleans;
using StackUnderflow.Domain.Core.Contexts.Questions;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateReply;
using StackUnderflow.Domain.Core.Contexts.Questions.VerifyCreateQuestion;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackUnderflow.API.AspNetCore.Controllers
{
   [ApiController]
   [Route("questions")]
    public class CreateQuestionController : ControllerBase
    {
        private readonly IInterpreterAsync _interpreter;
        private readonly StackUnderflowContext _dbContext;
        private readonly IClusterClient _client;

        public CreateQuestionController(IInterpreterAsync interpreter, StackUnderflowContext dbContext)
        {
            _interpreter = interpreter;
            _dbContext = dbContext;
        }



        [HttpPost("create")]
       // public async Task<IActionResult> CreateTenantAsyncAndInviteAdmin([FromBody] CreateTenantCmd createTenantCmd)
        public async Task<IActionResult> CreateQuestionAsync(int questionId, [FromBody] CreateQuestionCmd createQuestionCmd)
        {
            //data
            CreateQuestionWriteContext ctx = new CreateQuestionWriteContext(

              new EFList<Tenant>(_dbContext.Tenant),
              new EFList<TenantUser>(_dbContext.TenantUser),
              new EFList<User>(_dbContext.User),
              new EFList<Post>(_dbContext.Post)

               );

            var dependencies = new QuestionDependencies();
            dependencies.GenerateCodeVerificationToken = () => Guid.NewGuid().ToString();
            dependencies.SendVerifyEmail = SendEmail;

            var expr = from createQuestionResult in CreateQuestionDomain.CreateQuestion(createQuestionCmd)
                       let user = createQuestionResult.SafeCast<CreateQuestionResult.QuestionCreated>().Select(p => p.Author)
                       let confirmationQuestionCmd = new ConfirmationQuestionCmd(user)
                       from ConfirmationQuestionResult in CreateQuestionDomain.ConfirmQuestion(confirmationQuestionCmd)
                       select new { createQuestionResult, ConfirmationQuestionResult };

            //var expr1 = from questionResult in CreateQuestionDomain.CreateQuestion(questionId,"title of first question", "body of first question", "C# category")
                       //select questionResult;

            CreateQuestionResult.ICreateQuestionResult result = await _interpreter.Interpret(expr, Unit.Default, new object());

           return result.Match(created => Ok(created),
                notCreated => BadRequest(notCreated),
                InvalidRequest => ValidationProblem()
                );

                   
        }
        private TryAsync<VerifyAcknowledgement> SendEmail(VerifyLetter letter)
         => async () =>
         {
             var emialSender = _client.GetGrain<IEmailSender>(0);
             await emialSender.SendEmailAsync(letter.Letter);
             return new VerifyAcknowledgement(Guid.NewGuid().ToString());
         };
    }
}
