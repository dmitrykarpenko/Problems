using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Strings.LrStringTransformer
{
    public class SequentialLrStringTransformer : ILrStringTransformer
    {
        public bool CanTransform(string start, string end)
        {
            return IsTransformPossible(start, end);
        }

        private class LrCharInfo
        {
            public char Char;
            public int Index;
        }

        public static bool IsTransformPossible(string initial, string final)
        {
            if (initial == null || final == null || initial.Length != final.Length)
                return false;

            int initialLrCharIndex = 0,
                finalLrCharIndex = 0;
            return IsTransformPossible(
                initial
                    .Select(c => new LrCharInfo
                    {
                        Char = c,
                        Index = initialLrCharIndex++
                    })
                    .Where(IsCharLr),
                final
                    .Select(c => new LrCharInfo
                    {
                        Char = c,
                        Index = finalLrCharIndex++
                    })
                    .Where(IsCharLr));
        }

        private static bool IsCharLr(LrCharInfo ci) => IsCharLr(ci.Char);
        private static bool IsCharLr(char c) => c == 'L' || c == 'R';

        private static bool IsTransformPossible(IEnumerable<LrCharInfo> first, IEnumerable<LrCharInfo> second)
        {
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();

            while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
            {
                if (firstEnumerator.Current.Char != secondEnumerator.Current.Char)
                    return false;

                if (firstEnumerator.Current.Char == 'L' && firstEnumerator.Current.Index < secondEnumerator.Current.Index)
                    return false;

                if (firstEnumerator.Current.Char == 'R' && firstEnumerator.Current.Index > secondEnumerator.Current.Index)
                    return false;
            }

            return !firstEnumerator.MoveNext() && !secondEnumerator.MoveNext();
        }
    }
}
