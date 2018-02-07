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
            return CountDecodeOptions(s);
        }

        private int _minCharCode = 1;
        private int _maxCharCode = 26;
        //private int _maxCharCodeFirstDigit = 2;

        private Dictionary<string, int> _optionCounts = new Dictionary<string, int>();

        private int CountDecodeOptions(string input)
        {
            if(input == null || input.Length == 0)
                return 0;
            if (input[0] == '0')
                return 0;

            return CountDecodeOptionsRecursive(input);
        }

        private int CountDecodeOptionsRecursive(string input)
        {
            if (input.Length == 0)
                return 0;
            if (input.Length == 1)
                if (input[0] == '0')
                    return 0;
                else
                    return 1;

            var firstCharCode = GetCharCode(input[0]);
            var secondCharCode = GetCharCode(input[1]);

            var number = firstCharCode * 10 + secondCharCode;

            if (number > _maxCharCode)
            {
                if (input.Length == 2)
                    if (input[0] != '0' && input[1] != '0')
                        return 1;
                    else
                        return 0;

                // * 1 - because have only one option to decode two first letters
                return GetOrAddCount(input.Substring(2));
            }

            if (number >= _minCharCode)
            {
                if (secondCharCode == 0)
                {
                    if (input.Length == 2)
                        return 1;

                    return GetOrAddCount(input.Substring(2));
                }

                if (input.Length == 2)
                    return 2;

                return GetOrAddCount(input.Substring(1)) + GetOrAddCount(input.Substring(2));
            }

            return 0;
        }

        private int GetOrAddCount(string input)
        {
            int count;
            if (!_optionCounts.TryGetValue(input, out count))
            {
                count = CountDecodeOptionsRecursive(input);
                _optionCounts.Add(input, count);
            }
            return count;
        }

        private const int _minAsciiCharCodeMinusOne = 'A' - 1;
        private static int GetCharCode(char c)
        {
            return c - '0';
        }
    }
}
