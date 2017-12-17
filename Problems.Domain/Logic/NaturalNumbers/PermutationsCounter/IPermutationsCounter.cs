using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.PermutationsCounter
{
    public interface IPermutationsCounter<T>
    {
        IEnumerable<IEnumerable<T>> GetPermutations(IEnumerable<T> item);
    }
}
