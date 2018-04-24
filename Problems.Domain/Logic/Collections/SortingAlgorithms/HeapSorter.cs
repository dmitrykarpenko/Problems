using Problems.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Collections.SortingAlgorithms
{
    public class HeapSorter : ISorter
    {
        public void Sort<T>(IList<T> items, bool desc = false)
            where T : IComparable<T>
        {
            // Build max heap
            int heapSize = items.Count;
            for (int p = (heapSize - 1) / 2; p >= 0; --p)
                Heapify(items, heapSize, p, desc);

            for (int i = items.Count - 1; i > 0; --i)
            {
                items.Swap(0, i);

                --heapSize;
                Heapify(items, heapSize, 0, desc);
            }
        }

        private static void Heapify<T>(IList<T> items, int heapSize, int i, bool desc)
            where T : IComparable<T>
        {
            int iLeft = 2*i + 1;
            int iRight = iLeft + 1;
            int iLargest = i;

            if (WrongOrder(items, heapSize, iLeft, iLargest, desc))
                iLargest = iLeft;

            if (WrongOrder(items, heapSize, iRight, iLargest, desc))
                iLargest = iRight;

            if (iLargest != i)
            {
                items.Swap(iLargest, i);

                Heapify(items, heapSize, iLargest, desc);
            }
        }

        private static bool WrongOrder<T>(IList<T> items, int heapSize, int iDescendant, int iLargest, bool desc)
                where T : IComparable<T> =>
            iDescendant < heapSize &&
            (desc
                ? items[iDescendant].CompareTo(items[iLargest]) < 0
                : items[iDescendant].CompareTo(items[iLargest]) > 0);
    }
}
