using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.EF.Models;
using static StackUnderflow.Domain.Core.Contexts.Questions.VerifyCreateQuestion.VerifyCreateQuestionResult;

namespace StackUnderflow.Domain.Core.Contexts.Questions.VerifyCreateQuestion
{
    public partial class VerifyCreateQuestionAdapter : Adapter<VerifyCreateQuestionCmd, IVerifyCreateQuestionResult, QuestionWriteContext, QuestionDependencies>
    {
        public VerifyCreateQuestionAdapter() { }

        public override async Task<IVerifyCreateQuestionResult> Work(VerifyCreateQuestionCmd command, QuestionWriteContext state, QuestionDependencies dependencies)
        {
            var wf = from isValid in command.TryValidate()
                     from user in command.AdminUser.ToTryAsync()
                     let token = dependencies.GenerateCodeVerificationToken()
                     let letter = GenerateVerifyLetter(user, token)
                     from verifyAck in dependencies.SendVerifyEmail(letter)
                     select (user, token, verifyAck);

            return await wf.Match(
                Succ: r => new QuestionCreateVerified(r.user, r.token, r.verifyAck.Receipt),
                Fail: ex => (IVerifyCreateQuestionResult)new InvalidRequest(ex.ToString()));
        }

        private VerifyLetter GenerateVerifyLetter(User user, string token)
        {
            var link = $"https://stackunderflow/invite/{token}";
            var letter = @$"Dear {user.DisplayName}Please click on {link}";
            return new VerifyLetter(user.Email, letter, new Uri(link));
        }

        public override Task PostConditions(VerifyCreateQuestionCmd cmd, IVerifyCreateQuestionResult result, QuestionWriteContext state)
        {
            return Task.CompletedTask;
        }
    }

}
