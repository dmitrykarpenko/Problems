using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Strings.DecodeOptionsCounter
{
    public class RecursiveDecodeOptionsCounter : IDecodeOptionsCounter
    {
        public int NumDecodings(string s)
        {
            _minCharCode = GetCharCode('A');
            _maxCharCode = GetCharCode('Z');
            _maxCharCodeFirstDigit = _maxCharCode / 10;

            return CountDecodeOptions(s);
        }

        private int _minCharCode;
        private int _maxCharCode;

        private int _maxCharCodeFirstDigit;

        private Dictionary<string, int> _optionCounts = new Dictionary<string, int>();

        private int CountDecodeOptions(string input)
        {
            if (input == null || input.Length == 0)
                return 1;
            if (input.Length == 1)
                return 1;

            var firstCharCode = GetCharCode(input[0]);
            var secondCharCode = GetCharCode(input[1]);

            var number = firstCharCode * 10 + secondCharCode;
            if (number > _maxCharCode)
            {
                var nextInput = input.Substring(2);

                // * 1 - because have only one option to decode two first letters
                return GetOrAddCount(nextInput);
            }

            return GetOrAddCount(input.Substring(1)) + GetOrAddCount(input.Substring(2));
        }

        private int GetOrAddCount(string input)
        {
            int count;
            if (!_optionCounts.TryGetValue(input, out count))
            {
                count = CountDecodeOptions(input);
                _optionCounts.Add(input, count);
            }
            return count;
        }

        private static int GetCharCode(char c)
        {
            return (int)c - (int)('A') + 1;
        }
    }
}
