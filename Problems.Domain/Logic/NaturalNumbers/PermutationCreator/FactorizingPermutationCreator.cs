using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.PermutationCreator
{
    public class FactorizingPermutationCreator : IPermutationCreator
    {
        public string GetPermutation(int n, int k)
        {
            return CreatePermutation(n, k);
        }

        private string CreatePermutation(int n, int k)
        {
            var kIndex = k - 1;
            var factorialProgression = GetDescendingFactorialProgression(n - 1);

            var coefficients = GetCoefficients(kIndex, factorialProgression);
            var ascendingNumbers = Create(n).ToList();

            var sb = new StringBuilder();

            foreach (var coefficient in coefficients)
            {
                var number = ascendingNumbers[coefficient];
                sb.Append(number);
                ascendingNumbers.RemoveAt(coefficient);
            }

            return sb.ToString();
        }

        private static IEnumerable<int> Create(int n)
        {
            for (int i = 1; i <= n; i++)
                yield return i;
        }

        private static IEnumerable<int> GetCoefficients(int number, int[] descendingValues)
        {
            for (int i = 0; i < descendingValues.Length; ++i)
            {
                var coefficient = number / descendingValues[i];
                yield return coefficient;
                number -= coefficient * descendingValues[i];
            }
        }

        private static int[] GetDescendingFactorialProgression(int number)
        {
            var current = 1;
            var list = new List<int> { current };
            for (int i = 1; i <= number; i++)
            {
                list.Add(current *= i);
            }
            list.Reverse();
            return list.ToArray();
        }
    }
}
