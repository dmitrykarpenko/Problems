using Problems.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.PermutationsCounter
{
    public static partial class Util
    {
        public static long Factorial(int n)
        {
            if (n < 0)
                return -1;
            if (n == 0 || n == 1)
                return 1;

            var factorial = 1L;
            for (int i = 2; i <= n; i++)
                factorial *= i;

            return factorial;
        }
    }
}
