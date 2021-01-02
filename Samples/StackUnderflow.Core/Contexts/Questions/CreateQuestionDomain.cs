using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion;
using System;
using System.Collections.Generic;
using System.Text;
using static PortExt;

namespace StackUnderflow.Domain.Core.Contexts.Questions
{
    public static class CreateQuestionDomain
    {
        public static Port<CreateQuestionResult.ICreateQuestionResult> CreateQuestion(int questionId, string title, string body, string category)
            => NewPort<CreateQuestionCmd, CreateQuestionResult.ICreateQuestionResult>(new CreateQuestionCmd(questionId, title, body, category));
    }
}
