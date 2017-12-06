using Problems.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems.Domain.Logic.NaturalNumbers.PowersEquationSolver
{
    public class CtciPowersEquationSolver : IPowersEquationSolver
    {
        public IEnumerable<(int, int, int, int)> GetSolutions(int max)
        {
            var pairs = new Dictionary<long, List<(int, int)>>();

            for (int a = 1; a <= max; ++a)
                for (int b = 1; b <= a; ++b)
                {
                    var powSum = (long)(Math.Pow(a, 3) + Math.Pow(b, 3));

                    if (!pairs.TryGetValue(powSum, out List<(int, int)> currentPairs))
                        pairs.Add(powSum, currentPairs = new List<(int, int)>());

                    currentPairs.Add((a, b));

                    if (a != b)
                        currentPairs.Add((b, a));
                }

            foreach (var currentPairs in pairs)
                foreach (var pair1 in currentPairs.Value)
                    foreach (var pair2 in currentPairs.Value)
                        yield return (pair1.Item1, pair1.Item2, pair2.Item1, pair2.Item2);
        }
    }   
}
