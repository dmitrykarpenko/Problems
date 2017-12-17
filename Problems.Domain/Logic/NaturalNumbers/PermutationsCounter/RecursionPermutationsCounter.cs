using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.PermutationsCounter
{
    public class RecursionPermutationsCounter<T> : IPermutationsCounter<T>
    {
        public IEnumerable<IEnumerable<T>> GetPermutations(IEnumerable<T> item)
        {
            return GetPermutations(item, new T[0]);
        }

        public IEnumerable<IEnumerable<T>> GetPermutations(IEnumerable<T> item, IEnumerable<T> prefix)
        {
            if (item?.Any() != true)
            {
                yield return prefix;
            }
            else
            {
                var i = 0;
                foreach (var el in item)
                {
                    var rem = item.Take(i).Concat(item.Skip(i + 1));
                    var subPermutations = GetPermutations(rem, prefix.Append(item.ElementAt(i++)));

                    foreach (var subPermutation in subPermutations)
                        yield return subPermutation;
                }
            }
        }
    }
}
