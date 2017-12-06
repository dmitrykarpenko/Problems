using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Domain.Logic.NaturalNumbers.PowersEquationSolver
{
    public class BrutePowersEquationSolver : IPowersEquationSolver
    {
        public IEnumerable<(int, int, int, int)> GetSolutions(int max)
        {
            for (int a = 1; a <= max; ++a)
                for (int b = 1; b <= max; ++b)
                    for (int c = 1; c <= max; ++c)
                        for (int d = 1; d <= max; ++d)
                            if (Math.Pow(a, 3) + Math.Pow(b, 3) == Math.Pow(c, 3) + Math.Pow(d, 3))
                                yield return (a, b, c, d);
        }
    }
}
