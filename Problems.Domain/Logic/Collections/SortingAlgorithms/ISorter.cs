using System;
using System.Collections.Generic;

namespace Problems.Domain.Logic.Collections.SortingAlgorithms
{
    public interface ISorter
    {
        void Sort<T>(IList<T> items, bool desc = false) where T : IComparable<T>;
    }
}