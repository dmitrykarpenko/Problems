using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Utils
{
    public static class GenericUtil
    {
        public static void Swap<T>(this IList<T> items, int i, int j)
        {
            T temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }

        public static bool IsDescending<T>(this IEnumerable<T> items)
            where T : IComparable<T> => IsMonotonic(items, true);

        public static bool IsMonotonic<T>(this IEnumerable<T> items, bool desc)
                where T : IComparable<T> =>
            items
                .Zip(items.Skip(1),
                    (curr, next) => desc
                        ? curr.CompareTo(next) >= 0
                        : curr.CompareTo(next) <= 0)
                .All(x => x);

        public static IEnumerable<T> RemoveAt<T>(T[] input, int index)
        {
            return RemoveIf(input, (t, i) => i == index);
        }

        public static IEnumerable<T> RemoveAt<T>(T[] input, IEnumerable<int> indices)
        {
            var indicesSet = new HashSet<int>(indices);
            return RemoveIf(input, (t, i) => indicesSet.Contains(i));
        }

        public static IEnumerable<T> RemoveIf<T>(T[] input, Func<T, int, bool> condition,
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

        public static bool IsEqual<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();

            var firstHasNext = firstEnumerator.MoveNext();
            var secondHasNext = secondEnumerator.MoveNext();

            while (firstHasNext && secondHasNext)
            {
                if (!EqualityComparer<T>.Default.Equals(firstEnumerator.Current, secondEnumerator.Current))
                    return false;

                firstHasNext = firstEnumerator.MoveNext();
                secondHasNext = secondEnumerator.MoveNext();
            }

            return !firstHasNext && !secondHasNext;
        }
    }
}
