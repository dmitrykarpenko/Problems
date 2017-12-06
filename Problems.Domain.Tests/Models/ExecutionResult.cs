using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Domain.Tests.Models
{
    public class ExecutionResult<TResult>
    {
        public TimeSpan TimeSpent { get; set; }
        public TResult Result { get; set; }

        public override string ToString() => $"Result: {Result}; execution time: {TimeSpent}";
    }
}
