using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Generic
{
    public class GfgBinarySearcher : IBinarySearcher
    {
        public int GetIndex<T>(IReadOnlyList<T> sortedItems, T x)
            where T : IComparable<T>
        {
            int l = 0, r = sortedItems.Count - 1;
            while (l <= r)
            {
                int m = (r + l) / 2;

                if (sortedItems[m].CompareTo(x) == 0)
                {
                    // if x is present at the middle
                    return m;
                }
                if (sortedItems[m].CompareTo(x) < 0)
                {
                    // if x is "greater", ignore the left half
                    l = m + 1;
                }
                else // if (sortedItems[m].CompareTo(x) > 0)
                {
                    // if x is "smaller", ignore the right half
                    r = m - 1;
                }
            }

            // if we reach here, then the x element is not in sortedItems
            return -1;
        }
    }
}
