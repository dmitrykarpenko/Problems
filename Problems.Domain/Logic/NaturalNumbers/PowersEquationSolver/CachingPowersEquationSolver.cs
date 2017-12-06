using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems.Domain.Logic.NaturalNumbers.PowersEquationSolver
{
    public class CachingPowersEquationSolver : IPowersEquationSolver
    {
        public IEnumerable<(int, int, int, int)> GetSolutions(int max)
        {
            var pairs = GetPowPairs(max);

            var groups = pairs
                .GroupBy(x => x.Pow);

            foreach (var g in groups)
                foreach (var e1 in g)
                    foreach (var e2 in g)
                        yield return (e1.Pair.Item1, e1.Pair.Item2, e2.Pair.Item1, e2.Pair.Item2);
        }

        private IEnumerable<PowPair> GetPowPairs(int max)
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

        private class PowPair
        {
            public (int, int) Pair { get; set; }
            public long Pow { get; set; }
        }
    }   
}
