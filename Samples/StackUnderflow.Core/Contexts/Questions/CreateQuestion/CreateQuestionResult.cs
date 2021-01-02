using CSharp.Choices;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion
{   
    [AsChoice]
    public static partial class CreateQuestionResult
    {
        public interface ICreateQuestionResult { }

        public class QuestionCreated: ICreateQuestionResult
        {
            public QuestionCreated(Post post)
            {
                Post = post;
            }

            public Post Post { get; }
        }

        public class QuestionNotCreated: ICreateQuestionResult
        {
            public QuestionNotCreated(String reason)
            {
                Reason = reason;
            }

            public string Reason { get; }
        }

        public class InvalidRequest : ICreateQuestionResult
        {
            public InvalidRequest(CreateQuestionCmd cmd)
            {
                Cmd = cmd;
            }

            public object Cmd { get; }
        }
    }
}
