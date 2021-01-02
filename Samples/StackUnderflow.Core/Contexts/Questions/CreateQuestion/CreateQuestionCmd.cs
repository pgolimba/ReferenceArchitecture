using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion
{
    public class CreateQuestionCmd
    {
        public CreateQuestionCmd(int questionId, string title, string body, string category)
        {
            QuestionId = questionId;
            Title = title;
            Body = body;
            Category = category;
        }

        public int QuestionId { get; }
        public string Title { get; }
        public string Body { get; }
        public string Category { get; }
    }
}
