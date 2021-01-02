using CSharp.Choices;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CreateReply
{
    [AsChoice]
   public static partial class  CreateReplyResult
    {
        public interface ICreateReplyResult { }

        public class ReplyCreated : ICreateReplyResult 
        {
            public ReplyCreated(Post post)
            {
                Post = post;
            }

            public Post Post { get; }
        }

        public class ReplyNotCreated : ICreateReplyResult 
        {
            public ReplyNotCreated(String reason)
            {
                Reason = reason;
            }

            public string Reason { get; }
        }

        public class InvalidRequest : ICreateReplyResult 
        {
            public InvalidRequest(CreateReplyCmd cmd)
            {
                Cmd = cmd;
            }
           
            public CreateReplyCmd Cmd { get; }
        }
    }
}
