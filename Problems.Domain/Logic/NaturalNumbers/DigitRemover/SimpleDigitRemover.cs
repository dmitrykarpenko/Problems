using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.DigitRemover
{
    public class SimpleDigitRemover : IDigitRemover
    {
        private const char zero = '0';

        public string RemoveKdigits(string num, int k)
        {
            return GetMinNum(num, k);
        }

        private static string GetMinNum(string input, int k)
        {
            input = input.TrimStart(zero);
            if (input == string.Empty)
                return input + zero;
            if (k == 0)
                return input;

            IEnumerable<int> largestCharsIndices;
            var inputCharArray = input.ToCharArray();

            var charInfos = GetCharInfos(input, true);
            var nonZeroCharInfos = charInfos.Where(ci => ci.Item != zero);
            if (nonZeroCharInfos.Count() == k)
                largestCharsIndices = nonZeroCharInfos
                    .Select(ci => ci.Index);
            else
                largestCharsIndices = charInfos
                    .OrderBy(ci =>
                        new StringNaturalNumber(RemoveAt(inputCharArray, ci.Index)))
                    .Take(k)
                    .Select(ci => ci.Index);

            var result = ToString(RemoveAt(input.ToCharArray(), largestCharsIndices));

            result = result.TrimStart(zero);
            if (result == string.Empty)
                return result + zero;

            return result;
        }
        
        private class CharDigitInfo : ItemInfo<Char>
        {
            public byte Digit => (byte)char.GetNumericValue(Item);
        }
        private class ItemInfo<T>
        {
            public T Item { get; set; }
            public int Index { get; set; }
        }

        private static IEnumerable<CharDigitInfo> GetCharInfos(string input, bool removeLeadingZeros)
        {
            var isInputStart = true;
            for (int i = 0; i < input.Length; ++i)
            {
                if (!removeLeadingZeros || !isInputStart || input[i] != zero)
                {
                    isInputStart = false;
                    yield return new CharDigitInfo
                    {
                        Item = input[i],
                        Index = i,
                    };
                }
            }
        }

        private static string ToString(IEnumerable<char> chars)
        {
            return new string(chars.ToArray());
        }


        private static char[] RemoveAt(char[] input, int index)
        {
            return RemoveIf(input, (t, i) => i == index).ToArray();
        }
        private static IEnumerable<T> RemoveAt<T>(T[] input, int index)
        {
            return RemoveIf(input, (t, i) => i == index);
        }

        private static IEnumerable<T> RemoveAt<T>(T[] input, IEnumerable<int> indices)
        {
            var indicesSet = new HashSet<int>(indices);
            return RemoveIf(input, (t, i) => indicesSet.Contains(i));
        }

        private static IEnumerable<T> RemoveIf<T>(T[] input, Func<T, int, bool> condition,
            int maxRemovedCount = int.MaxValue)
        {
            var removedCount = 0;
            for (int i = 0; i < input.Length; ++i)
            {
                if (!condition(input[i], i) || removedCount >= maxRemovedCount)
                    yield return input[i];
                else
                    ++removedCount;
            }
        }
    }
}
