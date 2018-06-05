using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Collections.SortingAlgorithms
{
    public class InsertionSorter : ISorter
    {
        public void Sort<T>(IList<T> items, bool desc = false)
            where T : IComparable<T>
        {
            int il = items.Count;
            for (int i = 1; i < il; ++i)
            {
                T itemToMove = items[i];
                int j = i - 1;

                // Move elements of arr[0..i-1], that are
                // greater (for ascending) than itemToMove,
                // to one position ahead
                // of their current position
                while (
                    j >= 0 &&
                    (desc
                        ? items[j].CompareTo(itemToMove) < 0
                        : items[j].CompareTo(itemToMove) > 0))
                {
                    items[j + 1] = items[j];
                    --j;
                }
                items[j + 1] = itemToMove;
            }
        }
    }
}
