using System;
using System.Collections.Generic;

namespace Problems.Domain.Logic.Generic
{
    public interface IBinarySearcher
    {
        int GetIndex<T>(IReadOnlyList<T> sortedItems, T x)
            where T : IComparable<T>;
    }
}