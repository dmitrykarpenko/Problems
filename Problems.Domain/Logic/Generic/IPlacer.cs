using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Generic
{
    public interface IPlacer
    {
        IEnumerable<int> GetPartIndices<T>(T[] input, IEnumerable<T[]> parts, T partWildcard = default(T));
        bool IsExactMatch<T>(T[] input, int firstInputElementIndex, T[] part, T partWildcard = default(T));
    }
}
