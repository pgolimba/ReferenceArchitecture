using Access.Primitives.EFCore;
using Access.Primitives.IO;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using StackUnderflow.Domain.Core.Contexts.Questions;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateReply;
using Access.Primitives.Extensions.ObjectExtensions;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Orleans;
using GrainInterfaces;

namespace StackUnderflow.API.AspNetCore.Controllers
{
    [ApiController]
    [Route("questions")]
    public class QuestionsController : ControllerBase
    {
        private readonly IInterpreterAsync _interpreter;
        private readonly StackUnderflowContext _dbContext;
        public QuestionsController(IInterpreterAsync interpreter, StackUnderflowContext dbContext)
        {
            _interpreter = interpreter;
        }
        

        [HttpPost("{questionId}/reply")]
        public async Task<IActionResult> CreateReply(int questionId)
        {
            //load from db
            var questionWriteContext = 
                new CreateQuestionWriteContext(new EFList<Post>(_dbContext.Post));

            var expr = from replyResult in QuestionsDomain.CreateReply(questionId, "123")
                       select replyResult;

          
            CreateReplyResult.ICreateReplyResult  result = await _interpreter.Interpret(expr, 
              questionWriteContext, new object());

            return result.Match(created => Ok(created),
                notCreated => BadRequest(notCreated),
                invalidRequest => ValidationProblem()
                );

           //return Ok();
        }
    }
}
