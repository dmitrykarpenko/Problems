using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Collections.SortingAlgorithms
{
    public class MergeBottomUpSorter : ISorter
    {
        public void Sort<T>(IList<T> items, bool desc = false)
            where T : IComparable<T>
        {
            MergeSortBottomUp(items, desc);
        }

        private static void MergeSortBottomUp<T>(IList<T> items,
            bool desc) where T : IComparable<T>
        {
            // items length (il) - i.e. N from O(Nlog(N))
            int il = items.Count;

            // auxiliary items
            var auxs = new T[il];

            // Outer loop determines the size of the sub-arrays and 
            // doubles them with each pass. This can only happen log(N) times.
            for (int sz = 1; sz < il; sz = 2 * sz)
            {
                // Inner loop runs from beginning to end of the array
                // in increments of sz.

                // il - sz :
                // makes sure that the final lo starts at the beginning
                // of the first of two final subarray to merge and
                // the second array will have at least one element
                // to merge with the first one (which is of size sz).

                // lo += 2 * sz :
                // move to the next pair of items' subarrays to merge,
                // each of those is of size sz except probably for the very last subarray
                for (int lo = 0; lo < il - sz; lo += 2 * sz)
                {
                    // the last elemenet of the first array (of size sz) to merge,
                    // i.e. items[lo, mid] == items[lo, lo + sz - 1]
                    int mid = lo + sz - 1;

                    // the last array could be shorter than sz,
                    // so hi could be at the items last element items[il - 1]
                    // and the second array will be shorter in this case
                    int hi = Math.Min(mid + sz, il - 1);

                    Merge(items, auxs, lo, mid, hi, desc);
                }
            }
        }

        private static void Merge<T>(IList<T> items, IList<T> auxs, int lo, int mid, int hi,
            bool desc) where T : IComparable<T>
        {
            // items[lo, mid] and items[mid + 1, hi] should be sorted at this point

            // COPY current subarrays from items to auxs:

            for (int k = lo; k <= hi; k++)
                auxs[k] = items[k];

            // first index of the left subarray ("lefts")
            int il = lo;
            // first index of the right subarray ("rights")
            int ir = mid + 1;
            // first index of the chosen result (written into items)
            int i = lo;

            // MERGE the "lefts" and "rights" subarrays:

            for (; i <= hi; ++i)
            {
                if (il > mid)
                {
                    // no "lefts" remain, copy all the remaining "rights" to items
                    items[i] = auxs[ir++];
                }
                else if (ir > hi)
                {
                    // no "rights" remain, copy all the remaining "lefts" to items
                    items[i] = auxs[il++];
                }
                else
                {
                    // some "lefts" and "rights" remain,
                    // copy to items which of auxs[ir] and auxs[il]
                    // is smaller (for ascending)
                    if (desc
                            ? auxs[ir].CompareTo(auxs[il]) > 0
                            : auxs[ir].CompareTo(auxs[il]) < 0)
                        items[i] = auxs[ir++];
                    else
                        items[i] = auxs[il++];
                }
            }

            // items[lo, hi] should be sorted at this point
        }
    }
}
