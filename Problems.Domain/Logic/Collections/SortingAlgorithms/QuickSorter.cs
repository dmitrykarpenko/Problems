using Problems.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Collections.SortingAlgorithms
{
    public class QuickSorter : ISorter
    {
        public void Sort<T>(IList<T> items, bool desc = false)
            where T : IComparable<T>
        {
            QuickSortLomuto(items, 0, items.Count - 1, desc);
        }

        /// <summary>
        /// The main function that implements QuickSort()
        /// </summary>
        /// <param name="items">Array to be sorted</param>
        /// <param name="low">Starting index</param>
        /// <param name="high">Ending index</param>
        /// <param name="desc">false - ascending, true - descending</param>
        private static void QuickSortLomuto<T>(IList<T> items, int low, int high,
            bool desc) where T : IComparable<T>
        {
            if (low < high)
            {
                // if pi is partitioning index,
                // items[pi] is now at the right place
                int pi = PartitionLomuto(items, low, high,
                    desc);

                // Recursively sort elements before
                // partition and after partition
                QuickSortLomuto(items, low, pi - 1,
                    desc);
                QuickSortLomuto(items, pi + 1, high,
                    desc);
            }
        }

        /// <summary>
        /// This function takes the LAST element as a pivot,
        /// places the pivot element at its correct
        /// position in the sorted array, and places all
        /// smaller (smaller than the pivot) elements to the left of the
        /// pivot and all greater elements to the right
        /// of the pivot.
        /// 
        /// The Lomuto partition algorithm is used. 
        /// 
        /// The Lomuto algorithm constructs a list of "smaller" (than the pivot) items at the beginning 
        /// (unlike the Hoare algorithm, which constructs a list of "smaller" items at the beginning and "larger" items at the end).
        /// It checks each item, from first to last, to see if the item goes to the "smaller" list.
        /// Those items that do not go into the "smaller" list will remain at the end, thus end up in the large list.
        /// 
        /// The algorithm uses two indices:
        /// one to the end of the small list (i) and
        /// one to the last item that has been checked (j).
        /// As each item is checked, if it is small, then it is placed in the "smaller" list (using a swap operation),
        /// and the index of the end element of the "smaller" list (ie) is moved up (i.e. swapped with the pivot).
        /// 
        /// The terms small and smaller are used considerind the ascending sort order.
        /// </summary>
        private static int PartitionLomuto<T>(IList<T> items, int low, int high,
            bool desc) where T : IComparable<T>
        {
            T pivot = items[high];

            // index of the end of the "smaller" list
            int i = low - 1;
            // index of the last item that has being checked
            int j = low;
            for (; j < high; ++j)
            {
                // If current element items[j]
                // is smaller than or equal to pivot
                // (for ascending)
                if (desc
                    ? items[j].CompareTo(pivot) >= 0
                    : items[j].CompareTo(pivot) <= 0)
                {
                    ++i;
                    // insert smaller (for ascending) element to the end
                    // of the "smaller" list - i.e. insert from j to i;
                    // here i <= j always
                    Swap(items, i, j);
                }
            }

            // "i end" (ie) - index after the last index of the "smaller" list
            int ie = i + 1;
            // as i <= j < high, items[high] wasn't touched;
            // therefore, here items[high] still holds the pivot value here
            Swap(items, ie, high);

            return ie;
        }

        private static void Swap<T>(IList<T> items, int i, int j)
        {
            T temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }
    }
}
