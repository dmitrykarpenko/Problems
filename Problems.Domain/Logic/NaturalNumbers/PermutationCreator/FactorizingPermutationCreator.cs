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

        private int[] _factorialProgression;

        public string CreatePermutation(int n, int k)
        {
            var kIndex = k - 1;
            _factorialProgression = GetFactorialProgression(n - 1);

            var coefficients = GetCoefficients(kIndex, _factorialProgression)
                .ToArray();

            var ascendingNumbers = Create(n).ToList();

            var sb = new StringBuilder();

            foreach (var coefficient in coefficients)
            {
                var number = ascendingNumbers[coefficient];
                sb.Append(number);
                ascendingNumbers.RemoveAt(coefficient);
            }

            return sb.ToString();

            //var addedCoefficients = new SortedSet<int>();
            //addedCoefficients.
            //var coefficientsList = coefficients.ToList();
            //var iTop = coefficientsList.Count;

            //for (int i = 0; i < iTop; i++)
            //{
            //    coefficientsList[i]
            //    sb.Append();
            //}
        }

        //private static SortedList<int, int> CreateSorted(int n)
        //{
        //    var numbers = Create(n);
        //    foreach (var number in numbers)
        //    {

        //    }
        //}

        private static IEnumerable<int> Create(int n)
        {
            for (int i = 1; i <= n; i++)
                yield return i;
        }

        private static IEnumerable<int> GetCoefficients(int number, int[] descendingValues, int skipLast = 0)
        {
            for (int i = 0; i < descendingValues.Length - skipLast; ++i)
            {
                var coefficient = number / descendingValues[i];
                yield return coefficient;
                number -= coefficient * descendingValues[i];
            }
        }

        private static int[] GetFactorialProgression(int number)
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
