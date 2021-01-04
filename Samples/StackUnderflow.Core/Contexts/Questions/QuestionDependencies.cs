using LanguageExt;
using StackUnderflow.Domain.Core.Contexts.Questions.VerifyCreateQuestion;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions
{
    public class QuestionDependencies
    {
        public Func<string> GenerateCodeVerificationToken { get; set; }
        public Func<VerifyLetter, TryAsync<VerifyAcknowledgement>> SendVerifyEmail { get; set; }
    }
}
