using GrainInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrainImplementation
{
    public class EmailSenderGrain : Orleans.Grain, IEmailSender
    {
        private StackUnderflowContext _dbContext;
        private QuestionGrain state;

        public EmailSenderGrain(StackUnderflowContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<string> SendEmailAsync(string message)
        {
            //todo send e-mail

            return Task.FromResult(message);
        }
    }

    public class StackUnderflowContext
    {
    }
}
