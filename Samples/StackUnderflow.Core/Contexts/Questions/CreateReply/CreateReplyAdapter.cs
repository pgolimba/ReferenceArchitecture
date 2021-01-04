using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using Access.Primitives.IO;
using System.Threading.Tasks;
using System.Linq;
using StackUnderflow.EF.Models;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CreateReply
{
    public class CreateReplyAdapter : Adapter<CreateReplyCmd, CreateReplyResult.ICreateReplyResult>
    {
        public override Task PostConditions(CreateReplyCmd cmd, CreateReplyResult.ICreateReplyResult result, object state)
        {
            return Task.CompletedTask;
        }

        public override async Task<CreateReplyResult.ICreateReplyResult> Work(CreateReplyCmd cmd, object state, object dependencies)
        {
            var questionWriteContext = (CreateQuestionWriteContext)state;
            if (!questionWriteContext.Posts.Any(p => p.PostId == cmd.QuestionId))
                return new CreateReplyResult.ReplyNotCreated($"Cannot find a question with id {cmd.QuestionId}");

           Post question = questionWriteContext.Posts.First(p => p.PostId == cmd.QuestionId);

            var reply = new Post()
            {
               PostText = cmd.Reply
            };
            question.InversePostNavigation.Add(reply);
           return new CreateReplyResult.ReplyCreated(reply);
        }
    }
}
