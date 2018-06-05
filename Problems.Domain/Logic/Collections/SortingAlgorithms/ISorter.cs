using System;
using System.Collections.Generic;

namespace Problems.Domain.Logic.Collections.SortingAlgorithms
{
    public interface ISorter
    {
        /// <summary>
        /// Sorts items in-place.
        /// </summary>
        /// <typeparam name="T">Type of an item, should be an IComparable of T </typeparam>
        /// <param name="items">Array to sort</param>
        /// <param name="desc">False - ascending, true - descending</param>
        void Sort<T>(IList<T> items, bool desc = false) where T : IComparable<T>;
    }
}