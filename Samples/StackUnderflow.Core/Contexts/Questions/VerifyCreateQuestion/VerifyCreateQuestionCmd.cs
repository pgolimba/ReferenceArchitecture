using EarlyPay.Primitives.ValidationAttributes;
using LanguageExt;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using Access.Primitives.IO;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.VerifyCreateQuestion
{
    public struct VerifyCreateQuestionCmd
    {
        [OptionValidator(typeof(RequiredAttribute))]
        public Option<User> AdminUser { get; }
        public VerifyCreateQuestionCmd(Option<User>adminUser)
        {
            AdminUser = adminUser;
        }
    }

    public enum VerifyCreateQuestionCmdInput
    {
        Valid,
        UserIsNone
    }
    public class VerifyCreateQuestionInputGen : InputGenerator<VerifyCreateQuestionCmd, VerifyCreateQuestionCmdInput>
    {
        public VerifyCreateQuestionInputGen()
        {
            mappings.Add(VerifyCreateQuestionCmdInput.Valid, () =>
                new VerifyCreateQuestionCmd(
                    Option<User>.Some(new User()
                    {
                        DisplayName = Guid.NewGuid().ToString(),
                        Email = $"{Guid.NewGuid()}@mailinator.com"
                    }))
            );

            mappings.Add(VerifyCreateQuestionCmdInput.UserIsNone, () =>
                new VerifyCreateQuestionCmd(
                    Option<User>.None
                    )
            );
        }
    }
}
