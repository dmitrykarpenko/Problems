using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Utils
{
    public class GenericUtil
    {
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
    }
}
