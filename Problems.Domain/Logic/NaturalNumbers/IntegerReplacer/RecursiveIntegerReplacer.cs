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

        //private int count = 0;
        private Dictionary<int, int> _nCounts = new Dictionary<int, int>();

        private int CountIntegerReplacementsRecursive(int n, int previousCount)
        {
            // min count of steps to turn n into 1 regardless of previousCount
            int nMinCount;
            if (!_nCounts.TryGetValue(n, out nMinCount))
            {
                nMinCount = int.MaxValue;

                int closestPowerOf2Less = CountClosestPowerOf2LessThan(n);
                int closestPowerOf2Greater = closestPowerOf2Less * 2;
                for (int k = closestPowerOf2Less; k <= closestPowerOf2Greater; ++k)
                {
                    if (k % 2 == 0)
                    {
                        int nToK = Math.Abs(n - k); // steps from n to k
                        int kBy2Count = CountIntegerReplacementsRecursive(k / 2, nToK + 1); // division by 2 is also a step
                        if (kBy2Count < nMinCount)
                            nMinCount = kBy2Count;
                    }
                }

                if (nMinCount < int.MaxValue)
                    _nCounts[n] = nMinCount;
            }
            return nMinCount + previousCount;
        }
        
        private void AddPowerOf2Counts(int n)
        {
            _nCounts.Clear();
            var p = 1;
            var count = 0;
            while (p < n)
            {
                _nCounts.Add(p, count);
                p *= 2;
                ++count;
            }
            _nCounts.Add(p, count);
        }

        // TODO: optimize with shifts or search
        private int CountClosestPowerOf2LessThan(int n)
        {
            var logN = Math.Log(n, 2);
            var ceilingLogN = Math.Floor(logN);
            return (int)Math.Pow(2, ceilingLogN);
        }
    }
}
