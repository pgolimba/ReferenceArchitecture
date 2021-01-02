using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using Access.Primitives.IO;
using System.Threading.Tasks;
using System.Linq;
using StackUnderflow.EF.Models;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion

{
    public class CreateQuestionAdapter : Adapter<CreateQuestionCmd, CreateQuestionResult.ICreateQuestionResult>
    {
        public override Task PostConditions(CreateQuestionCmd cmd, CreateQuestionResult.ICreateQuestionResult result, object state)
        {
            return Task.CompletedTask;
        }

        public override async Task<CreateQuestionResult.ICreateQuestionResult> Work(CreateQuestionCmd cmd, object state, object dependencies)
        {
            var random = new Random().Next(10, 1000);
            if (random % 2 == 0)
                return new CreateQuestionResult.QuestionCreated(new Post());
            else
                return new CreateQuestionResult.QuestionNotCreated("asta e");
        }
    }
}
