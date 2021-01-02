using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions
{
    class CreateQuestionWriteContext
    {
        public CreateQuestionWriteContext(ICollection<Post> posts)
        {
            Posts = posts;
        }

        public ICollection<Post> Posts { get; }
    }
}
