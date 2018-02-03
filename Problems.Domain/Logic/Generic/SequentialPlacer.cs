using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Generic
{
    public class SequentialPlacer : IPlacer
    {
        public IEnumerable<int> GetPartIndices<T>(T[] input, IEnumerable<T[]> parts, T partWildcard = default(T))
        {
            var partsEnumeratior = parts.GetEnumerator();
            if (partsEnumeratior.MoveNext())
                for (int i = 0; i < input.Length; i++)
                {
                    if (partsEnumeratior.Current != null &&
                        IsExactMatch(input, i, partsEnumeratior.Current, partWildcard))
                    {
                        partsEnumeratior.MoveNext();
                        yield return i;
                    }
                }
        }

        public bool IsExactMatch<T>(T[] input, int firstInputElementIndex, T[] part, T partWildcard = default(T))
        {
            var nextAfterLastInputCharIndex = firstInputElementIndex + part.Length;
            if (nextAfterLastInputCharIndex > input.Length)
                return false;

            for (var inputCharIndex = firstInputElementIndex; inputCharIndex < nextAfterLastInputCharIndex; ++inputCharIndex)
            {
                var patternIndex = inputCharIndex - firstInputElementIndex;
                if (!EqualityComparer<T>.Default.Equals(part[patternIndex], input[inputCharIndex]) &&
                    (EqualityComparer<T>.Default.Equals(partWildcard, default(T)) ||
                    !EqualityComparer<T>.Default.Equals(part[patternIndex], partWildcard)))
                    return false;
            }

            return true;
        }
    }
}
