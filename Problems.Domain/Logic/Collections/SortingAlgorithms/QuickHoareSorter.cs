using Problems.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Collections.SortingAlgorithms
{
    public class QuickHoareSorter : ISorter
    {
        public void Sort<T>(IList<T> items, bool desc = false)
            where T : IComparable<T>
        {
            QuickSortHoare(items, 0, items.Count - 1, desc);
        }

        /// <summary>
        /// The main function that implements the quick sort
        /// </summary>
        /// <param name="items">Array to be sorted</param>
        /// <param name="low">Starting index</param>
        /// <param name="high">Ending index</param>
        /// <param name="desc">false - ascending, true - descending</param>
        private static void QuickSortHoare<T>(IList<T> items, int low, int high,
            bool desc) where T : IComparable<T>
        {
            if (low < high)
            {
                // if pi is partitioning index,
                // items[pi] is smaller than or equal to the current pivot
                int pi = PartitionHoare(items, low, high,
                    desc);

                // Here the index of the pivot is either pi or pi + 1,
                // thus could be moved later on;
                // so, include both of those to further sorting

                // Recursively sort elements before
                // partition and after partition
                QuickSortHoare(items, low, pi,
                    desc);
                QuickSortHoare(items, pi + 1, high,
                    desc);
            }
        }

        /// <summary>
        /// This function takes the FIRST element as a pivot,
        /// places the pivot element at its correct
        /// position in the sorted array, and places all
        /// smaller (smaller than the pivot) elements to the left of the
        /// pivot and all greater elements to the right
        /// of the pivot.
        /// 
        /// The Hoare partition algorithm is used. 
        /// 
        /// The Hoare algorithm constructs lists of:
        /// "smaller" items at the beginning and
        /// "larger" items at the end.
        /// It uses a pointer to the end of the "smaller" list (il) and one to the begining of the "larger" list (ir).
        /// 
        /// The pointers are moved inward until each meets an item that does not belong in its list.
        /// Then the items are swapped, and the iteration continues.
        /// 
        /// 1.  Hoare’s scheme is more efficient than Lomuto’s partition scheme
        ///     because it does three times fewer swaps on average,
        ///     and it creates efficient partitions even when all values are equal.
        /// 2.  Like Lomuto’s partition scheme, Hoare partitioning also causes Quicksort to degrade to O(n^2)
        ///     when the input array is already sorted, it also doesn’t produce a stable sort.
        /// 3.  Note that in this scheme, the pivot’s final location is not necessarily at the index that was returned,
        ///     and the next two segments that the main algorithm recurs on are
        ///     (lo..p) and (p+1..hi) as opposed to
        ///     (lo..p-1) and (p+1..hi) as in Lomuto’s scheme.
        /// 
        /// The terms small, smaller, larger, etc. are used considerind the ascending sort order.
        /// </summary>
        /// <typeparam name="T">Type of an item</typeparam>
        /// <param name="items">Items array</param>
        /// <param name="low">First index of a sorted subarray</param>
        /// <param name="high">Lasst (included) index of a sorted subarray</param>
        /// <param name="desc">Sorting order</param>
        /// <returns>
        /// The index of the rightmost element that's less than or equal to the pivot.
        /// Thus, it's either
        /// the index of the pivot-value element or
        /// the index of the closest lower than the pivot element.
        /// </returns>
        private static int PartitionHoare<T>(IList<T> items, int low, int high,
            bool desc) where T : IComparable<T>
        {
            // shouldn't necessarily be the first element
            T pivot = items[low];

            // index of the leftmost (thus il) element to be greater than or equal to pivot
            int il = low - 1;
            // index of  the rightmost (thus ir) element to be smaller than or equal to pivot
            int ir = high + 1;

            while (true)
            {
                // find the leftmost element greater than or equal to pivot
                // by skipping all the smaller ones by incleasing il
                // while  items[il] < pivot (for ascending)
                do il++;
                while (desc
                    ? items[il].CompareTo(pivot) > 0
                    : items[il].CompareTo(pivot) < 0);

                // find the rightmost element smaller than or equal to pivot
                // by skipping all the greater ones by incleasing ir
                // while items[ir] > pivot (for ascending)
                do ir--;
                while (desc
                    ? items[ir].CompareTo(pivot) < 0
                    : items[ir].CompareTo(pivot) > 0);

                // if two indices met, return ir, that should be either
                // the index of the pivot-value element or
                // the index of the closest lower than the pivot element here
                if (il >= ir)
                    return ir;

                // else, if il and ir are not yet met, swap the respective items
                Swap(items, il, ir);
            }
        }

        private static void Swap<T>(IList<T> items, int i, int j)
        {
            T temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }
    }
}
