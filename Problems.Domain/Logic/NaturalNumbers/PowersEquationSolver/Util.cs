using Problems.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.PowersEquationSolver
{
    public static partial class Util
    {
        public static IEnumerable<PowPair> GetPowPairs(int max)
        {
            for (int a = 1; a <= max; ++a)
                for (int b = 1; b <= a; ++b)
                {
                    var powSum = (long)(Math.Pow(a, 3) + Math.Pow(b, 3));
                    yield return new PowPair { Pair = (a, b), Pow = powSum };

                    if (a != b)
                        yield return new PowPair { Pair = (b, a), Pow = powSum };
                }
        }
    }
}
