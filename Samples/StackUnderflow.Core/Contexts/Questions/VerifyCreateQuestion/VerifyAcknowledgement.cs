using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.VerifyCreateQuestion
{
   public  class VerifyAcknowledgement
    {
        public string Receipt { get; private set; }

        public VerifyAcknowledgement(string receipt)
        {
        Receipt = receipt;
        }
    }
}
