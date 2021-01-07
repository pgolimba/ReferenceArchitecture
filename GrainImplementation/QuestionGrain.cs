using System;
using System.Collections.Generic;
using System.Text;

namespace GrainImplementation
{
    public class QuestionGrain: Orleans.Grain
    {
        public StackUnderflowContext _dbContext;
    }
}
