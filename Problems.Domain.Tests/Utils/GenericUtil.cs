using Problems.Domain.Tests.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Domain.Tests.Utils
{
    public static class GenericUtil
    {
        public static ExecutionResult<TResult> Execute<TResult>(Func<TResult> action)
        {
            var start = DateTime.UtcNow;
            var result = action();
            var end = DateTime.UtcNow;

            return new ExecutionResult<TResult> { Result = result, TimeSpent = end - start };
        }
    }
}
