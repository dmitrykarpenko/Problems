using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.IntegerReplacer
{
    public class RecursiveIntegerReplacer : IIntegerReplacer
    {
        public int IntegerReplacement(int n)
        {
            AddPowerOf2Counts(n);
            return CountIntegerReplacementsRecursive(n, 0);
        }

        /// <summary> key: k, value: stored <see cref="IntegerReplacement"/> of k </summary>
        private Dictionary<long, int> _nCounts = new Dictionary<long, int>();

        private int CountIntegerReplacementsRecursive(long n, int previousCount)
        {
            // min count of steps to turn n into 1 regardless of previousCount
            int nMinCount;
            if (!_nCounts.TryGetValue(n, out nMinCount))
            {
                nMinCount = int.MaxValue;

                // The idea is to do the division by 2 first,
                // as then we'll have to make 2 times less steps, e.g.:
                // 130 -> 129 -> 128 -> 64 ->  ... is one step longer than
                // 130 ->  65 ->  64 -> ...
                // Thus, we keep the [kMin, kMax] interval as narrow as possible,
                // which will be [n, n] is n is even and [n - 1, n + 1] if n is odd :
                long kMin, kMax;
                if (n % 2 == 0)
                {
                    kMin = n;
                    kMax = n;
                }
                else
                {
                    kMin = n - 1;
                    kMax = n + 1;
                }

                for (long k = kMin; k <= kMax; ++k)
                {
                    if (k % 2 == 0)
                    {
                        var nextPreviousCount = Math.Abs((int)(n - k)) + 1; // steps from n to k + division by 2 which is also a step
                        var kBy2Count = CountIntegerReplacementsRecursive(k / 2, nextPreviousCount);
                        if (kBy2Count < nMinCount)
                            nMinCount = kBy2Count;
                    }
                }

                if (nMinCount < int.MaxValue)
                    _nCounts[n] = nMinCount;
            }
            return nMinCount + previousCount;
        }
        
        private void AddPowerOf2Counts(long n)
        {
            _nCounts.Clear();
            long p = 1;
            int count = 0;
            while (p < n)
            {
                _nCounts.Add(p, count);
                p *= 2;
                ++count;
            }
            _nCounts.Add(p, count);
        }
    }
}
