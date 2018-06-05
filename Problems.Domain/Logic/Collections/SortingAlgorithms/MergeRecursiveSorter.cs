using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Collections.SortingAlgorithms
{
    /// <summary>
    /// Implements the classic merge sort algorithm
    /// </summary>
    public class MergeRecursiveSorter : ISorter
    {
        public void Sort<T>(IList<T> items, bool desc = false)
            where T : IComparable<T>
        {
            MergeSortRecursive(items, 0, items.Count - 1, desc);
        }

        /// <summary>
        /// Main sorting function that sorts the items[l..r] subarray
        /// with <see cref="Merge"/> 
        /// </summary>
        void MergeSortRecursive<T>(IList<T> items, int l, int r,
            bool desc) where T : IComparable<T>
        {
            if (l < r)
            {
                // Find the middle point
                int m = (l + r) / 2;

                // Sort first and second halves
                MergeSortRecursive(items, l, m,
                    desc);
                MergeSortRecursive(items, m + 1, r,
                    desc);

                // Merge the sorted halves
                Merge(items, l, m, r,
                    desc);
            }
        }

        /// <summary>
        /// Merges two subarrays of items[].
        /// First subarray is items[l..m].
        /// Second subarray is items[m+1..r].
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="l">First index of the first subarray</param>
        /// <param name="m">Last (included) index of the first subarray</param>
        /// <param name="r">Last (included) index of the last subarray</param>
        void Merge<T>(IList<T> items, int l, int m, int r,
            bool desc) where T : IComparable<T>
        {
            // Find lengths of two subarrays to be merged:
            // lefts array length
            int leftsLength = m - l + 1;
            // rights array length
            int rightsLength = r - m;

            // Create temp arrays
            T[] lefts = new T[leftsLength];
            T[] rights = new T[rightsLength];

            // index left (il)
            int il;
            // index right (ir)
            int ir;

            // COPY data to the temp arrays:

            for (il = 0; il < leftsLength; ++il)
                lefts[il] = items[l + il];

            for (ir = 0; ir < rightsLength; ++ir)
                rights[ir] = items[m + 1 + ir];

            // MERGE the temp arrays:

            // reinitialize indices of the subarrays
            il = 0;
            ir = 0;

            // initial index of the merged subarry array,
            // i.e. items index (i)
            int i = l;

            while (il < leftsLength && ir < rightsLength)
            {
                // if equal - prefer the left (first-half) ones
                if (desc
                    ? lefts[il].CompareTo(rights[ir]) >= 0
                    : lefts[il].CompareTo(rights[ir]) <= 0)
                {
                    items[i] = lefts[il];
                    il++;
                }
                else
                {
                    items[i] = rights[ir];
                    ir++;
                }
                i++;
            }

            // COPY the remaining elements ...

            // ... of lefts[] if any
            while (il < leftsLength)
            {
                items[i] = lefts[il];
                il++;
                i++;
            }

            // ... of rights[] if any
            while (ir < rightsLength)
            {
                items[i] = rights[ir];
                ir++;
                i++;
            }
        }
    }
}
