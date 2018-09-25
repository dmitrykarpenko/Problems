using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.BinaryOperatorsAdder
{
    public class BinaryOperatorsAdder : IBinaryOperatorsAdder
    {
        public IList<string> AddOperators(string num, int target)
        {
            _num = num;
            _numInts = new int[num.Length];
            for (int i = 0; i < _numInts.Length; i++)
                _numInts[i] = (int)char.GetNumericValue(num[i]);

            _target = target;
            _outputs.Clear();

            AddOperators();

            return _outputs;
        }

        private string _num;
        private int[] _numInts;
        private int _target;
        private List<string> _outputs = new List<string>();
        
        private void AddOperators()
        {
            var ops = GetOperationsPermutations("");
            foreach (var os in ops)
                if (IsTarget(os))
                    _outputs.Add(Zip(os));
        }

        // | - concatenation
        private const string operationChars = "|*+-";

        private IEnumerable<string> GetOperationsPermutations(string currentOperations)
        {
            if (currentOperations.Length < _numInts.Length - 1)
            {
                for (int i = 0; i < operationChars.Length; i++)
                    foreach (var op in GetOperationsPermutations(currentOperations + operationChars[i]))
                        yield return op;

                yield break;
            }

            yield return currentOperations;
        }

        private bool IsTarget(string os)
        {
            var nums = GetConcatedNums(os);

            // index of the second operand
            int i = 1;
            foreach (var o in os)
            {
                throw new NotImplementedException();

                if (o == '*')
                    nums[nums.Count - 1] *= nums[i++];
            }

            int targetCandidate = nums[0];
            i = 1;
            foreach (var o in os)
            {
                if (o == '+')
                    targetCandidate += nums[i++];
                else if (o == '-')
                    targetCandidate -= nums[i++];
            }

            return _target == targetCandidate;
        }

        private static IEnumerable<T> Where<T>(IEnumerable<T> items, Func<T, bool> predicate)
        {
            foreach (var item in items)
                if (predicate(item))
                    yield return item;
        }

        private List<int> GetConcatedNums(string os)
        {
            var concatedNums = new List<int>() { _numInts[0] };

            // index of the second operand
            int i = 1;
            foreach (var o in os)
            {
                if (o == '|')
                {
                    int iLast = concatedNums.Count - 1;
                    concatedNums[iLast] =
                        Concat(concatedNums[iLast], _numInts[i]);
                }
                else
                {
                    concatedNums.Add(_numInts[i]);
                }

                ++i;
            }

            return concatedNums;
        }

        private static T[] Copy<T>(T[] items)
        {
            var copiedItems = new T[items.Length];
            Array.Copy(items, copiedItems, items.Length);
            return copiedItems;
        }

        // TODO: optimize
        static int Concat(int a, int b) => int.Parse($"{a}{b}");
        //{
        //    int pow = 1;

        //    while (pow < b)
        //    {
        //        pow = ((pow << 2) + pow) << 1;
        //        a = ((a << 2) + a) << 1;
        //    }

        //    return a + b;
        //}

        private string Zip(string os)
        {
            var sb = new StringBuilder();

            var iLast = _num.Length - 1;
            for (int i = 0; i < iLast; i++)
            {
                if (os[i] == '|')
                {
                    if (_num[i] != 0)
                        sb.Append(_num[i]);

                    continue;
                }

                sb.Append(_num[i]).Append(os[i]);
            }
            sb.Append(_num[iLast]);

            return sb.ToString();
        }

        //private int NumsLength(int ifn) => _numInts.Length - ifn;

        //private IEnumerable<List<Operation>> _outputOperationsPermutations = new List<Operation>();

        //private class Operation
        //{
        //    public Func<int, int, int> Apply;
        //    public char Symbol;
        //}

        //private static Operation _m = new Operation { Apply = (l, r) => l * r, Symbol = '*' };
        //private static Operation _a = new Operation { Apply = (l, r) => l + r, Symbol = '+' };
        //private static Operation _s = new Operation { Apply = (l, r) => l - r, Symbol = '-' };
    }
}
