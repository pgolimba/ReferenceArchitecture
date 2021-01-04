using CSharp.Choices;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.VerifyCreateQuestion
{
    [AsChoice]
    public static partial class VerifyCreateQuestionResult
    {
        public interface IVerifyCreateQuestionResult { }

        public class QuestionCreateVerified : IVerifyCreateQuestionResult
        {
            public User AdminUser { get; }
            public string VerifyCode { get; }

            public string VerifyCreateQuestionAcknowlwedgement { get; set; }

            public QuestionCreateVerified(User adminUser, string verifyCode, string verifyCreateQuestionAcknowlwedgement)
            {
                AdminUser = adminUser;
                VerifyCode = verifyCode;
                VerifyCreateQuestionAcknowlwedgement = verifyCreateQuestionAcknowlwedgement;

            }
        }
        public class QuestionCreateNotVerified : IVerifyCreateQuestionResult
        {
            
        }

        public class InvalidRequest : IVerifyCreateQuestionResult
        {
            public string Message { get; }

            public InvalidRequest(string message)
            {
                Message = message;
            }

        }
    }
}
