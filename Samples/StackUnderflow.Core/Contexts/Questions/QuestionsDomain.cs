using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateReply;
using System;
using System.Collections.Generic;
using System.Text;
using static PortExt;

namespace StackUnderflow.Domain.Core.Contexts.Questions
{
   public static class QuestionsDomain
    {
        public static Port<CreateReplyResult.ICreateReplyResult> CreateReply(int questionId, string reply)
            =>NewPort<CreateReplyCmd, CreateReplyResult.ICreateReplyResult>(new CreateReplyCmd(questionId, reply));
    }
}
