using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion;
using StackUnderflow.Domain.Core.Contexts.Questions.VerifyCreateQuestion;
using System;
using System.Collections.Generic;
using System.Text;
using static PortExt;
using static StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion.CreateQuestionResult;
using static StackUnderflow.Domain.Core.Contexts.Questions.VerifyCreateQuestion.VerifyCreateQuestionResult;

namespace StackUnderflow.Domain.Core.Contexts.Questions
{
    public static class CreateQuestionDomain
    {
        public static Port<CreateQuestionResult.ICreateQuestionResult> CreateQuestion(CreateQuestionCmd command)
        {
            return NewPort<CreateQuestionCmd, ICreateQuestionResult>(command);
        }
        public static Port<IVerifyCreateQuestionResult> VerifyCreateQuestion(VerifyCreateQuestionCmd command) => NewPort<VerifyCreateQuestionCmd, IVerifyCreateQuestionResult>(command);
    }
}
