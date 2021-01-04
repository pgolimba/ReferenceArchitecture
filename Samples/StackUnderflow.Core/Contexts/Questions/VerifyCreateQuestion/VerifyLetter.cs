using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.VerifyCreateQuestion
{
    public class VerifyLetter
    {
        public string Email { get; private set; }

        public string Letter { get; private set; }
        public Uri VerifyLink { get; private set; }

        public VerifyLetter(string email, string letter, Uri link)
        {
            Email = email;
            Letter = letter;
            VerifyLink = link;
        }
    }
}
