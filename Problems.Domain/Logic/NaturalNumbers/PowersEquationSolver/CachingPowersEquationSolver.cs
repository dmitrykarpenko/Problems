using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems.Domain.Logic.NaturalNumbers.PowersEquationSolver
{
    public class GroupingPowersEquationSolver : IPowersEquationSolver
    {
        public IEnumerable<(int, int, int, int)> GetSolutions(int max)
        {
            var pairs = Util.GetPowPairs(max);

            var groups = pairs
                .GroupBy(x => x.Pow);

            foreach (var g in groups)
                foreach (var e1 in g)
                    foreach (var e2 in g)
                        yield return (e1.Pair.Item1, e1.Pair.Item2, e2.Pair.Item1, e2.Pair.Item2);
        }
    }   
}
