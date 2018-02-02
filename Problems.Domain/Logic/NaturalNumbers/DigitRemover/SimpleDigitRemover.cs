using System;
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

            //var indexOfZero = num.IndexOf(zero);

            //if (indexOfZero < 0 || indexOfZero > k)
            //    ;

            //var result = ToString(RemoveIf(num.ToCharArray(), (c, i) => c == zero, k));
            //return result;
        }

        private static string GetMinNum(string input, int k)
        {
            input = input.TrimStart(zero);
            if (input == string.Empty)
                return input + zero;
            if (k == 0)
                return input;

            var charInfos = GetCharInfos(input, true);
            var largestCharsIndices = charInfos
                //.OrderByDescending(ci => LossIfRemoved(input, ci.Index))
                .OrderBy(ci =>
                    new StringNaturalNumber(RemoveAt(input.ToCharArray(), ci.Index).ToArray()))
                .Take(1)
                .Select(ci => ci.Index);

            var result = ToString(RemoveAt(input.ToCharArray(), largestCharsIndices));
            return GetMinNum(result, k-1);
        }

        //private static NumberPart LossIfRemoved(string input, int index)
        //{
        //    var digit = (byte)char.GetNumericValue(input[index]);

        //    var loss = new NumberPart
        //    {
        //        Value = digit,
        //        QuanOfZeros = input.Length - index,
        //    };

        //    if (index > 0)
        //    {


        //        var previousIndex = index - 1;
        //        var replacingDigit = (byte)char.GetNumericValue(input[previousIndex]);
        //        loss -= new NumberPart
        //        {
        //            Value = replacingDigit,
        //            QuanOfZeros = input.Length - index,
        //        };
        //    }

        //    return loss;
        //}

        
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
