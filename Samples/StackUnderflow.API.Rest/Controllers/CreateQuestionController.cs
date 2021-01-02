using Access.Primitives.EFCore;
using Access.Primitives.IO;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using StackUnderflow.Domain.Core.Contexts.Questions;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateReply;
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
        public CreateQuestionController(IInterpreterAsync interpreter)
        {
            _interpreter = interpreter;
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateQuestionAsync(int questionId)
        {
            var questionWriteContext =
                new QuestionWriteContext(new EFList<Post>(_dbContext.Post));
            var expr = from questionResult in CreateQuestionDomain.CreateQuestion(questionId,"title of first question", "body of first question", "C# category")
                       select questionResult;

            CreateQuestionResult.ICreateQuestionResult result = await _interpreter.Interpret(expr, Unit.Default, new object());

           return result.Match(created => Ok(created),
                notCreated => BadRequest(notCreated),
                InvalidRequest => ValidationProblem()
                );
       
            return Ok();
        }
    }
}
