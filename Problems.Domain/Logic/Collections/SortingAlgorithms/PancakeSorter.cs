using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Collections.SortingAlgorithms
{
    public class PancakeSorter : ISorter
    {
        /// <summary>
        /// Given an an unsorted array, sort the given array.
        /// You are allowed to do only the following operation to change items:
        /// Flip(items, i) : Reverse the items subarray from 0 to i
        /// 
        /// Unlike a traditional sorting algorithm, which attempts to sort with the fewest comparisons possible,
        /// the goal is to sort the sequence in as few reversals as possible.
        /// 
        /// The idea is to do something similar to Selection Sort. We place maximum (if ascending)
        /// elements one by one at the end and reduce the size of the unsorted subarray by one.
        /// 
        /// Total O(n) flips are performed. The overall time complexity is O(n^2).
        /// </summary>
        public void Sort<T>(IList<T> items, bool desc = false)
            where T : IComparable<T>
        {
            // last index of the unsorted subarray
            int li = items.Count - 1;

            for (; li > 0; --li)
            {
                var mi = GetIndexOfToMove(items, li, desc);

                // if the item to move is not on the last place,
                // move it to the last place
                if (mi < li)
                    MoveToEnd(items, li, mi);
            }
        }

        /// <summary>
        /// Sertches for min (if descending) or max (if ascending)
        /// </summary>
        /// <param name="items">Array to search in</param>
        /// <param name="li">Last index of items to search to</param>
        /// <param name="desc">ascending/descending</param>
        /// <returns>index of the max ofr min element</returns>
        private static int GetIndexOfToMove<T>(IList<T> items, int li,
            bool desc) where T : IComparable<T>
        {
            // index of an item to move
            var mi = 0;

            for (int i = 1; i <= li; ++i)
            {
                // check for equality to in order to return the last index of max
                // as it could be on the last place and than will be no need to flip
                if (desc
                        ? items[mi].CompareTo(items[i]) >= 0
                        : items[mi].CompareTo(items[i]) <= 0)
                    mi = i;
            }
            return mi;
        }

        private static void MoveToEnd<T>(IList<T> items, int li, int mi)
        {
            Flip(items, mi + 1);
            Flip(items, li + 1);
        }

        private static void Flip<T>(IList<T> items, int k)
        {
            for (int i = 0; i < k / 2; i++)
                Swap(items, i, k - i - 1);
        }

        private static void Swap<T>(IList<T> items, int i, int j)
        {
            var temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }
    }
}
