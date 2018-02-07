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

            return IsTransformPossible(ToLrCharInfos(initial), ToLrCharInfos(final));
        }

        private static IEnumerable<LrCharInfo> ToLrCharInfos(IEnumerable<char> chars)
        {
            var index = 0;
            foreach (var c in chars)
            {
                if (IsCharLr(c))
                {
                    yield return new LrCharInfo
                    {
                        Char = c,
                        Index = index,
                    };
                }
                ++index;
            }
        }

        private static bool IsCharLr(LrCharInfo ci) => IsCharLr(ci.Char);
        private static bool IsCharLr(char c) => c == 'L' || c == 'R';

        private static bool IsTransformPossible(IEnumerable<LrCharInfo> initial, IEnumerable<LrCharInfo> final)
        {
            var initialEnumerator = initial.GetEnumerator();
            var finalEnumerator = final.GetEnumerator();

            var initialHasNext = initialEnumerator.MoveNext();
            var finalHasNext = finalEnumerator.MoveNext();

            while (initialHasNext && finalHasNext)
            {
                if (initialEnumerator.Current.Char != finalEnumerator.Current.Char)
                    return false;

                if (initialEnumerator.Current.Char == 'L' && initialEnumerator.Current.Index < finalEnumerator.Current.Index)
                    return false;

                if (initialEnumerator.Current.Char == 'R' && initialEnumerator.Current.Index > finalEnumerator.Current.Index)
                    return false;

                initialHasNext = initialEnumerator.MoveNext();
                finalHasNext = finalEnumerator.MoveNext();
            }
            
            return !initialHasNext && !finalHasNext;
        }
    }
}
