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
        
        private Dictionary<int, int> _nCounts = new Dictionary<int, int>();

        private int CountIntegerReplacementsRecursive(int n, int previousCount)
        {
            // min count of steps to turn n into 1 regardless of previousCount
            int nMinCount;
            if (!_nCounts.TryGetValue(n, out nMinCount))
            {
                nMinCount = int.MaxValue;
                
                int closestPowerOf2Less = CountWithShiftsClosestPowerOf2LessThan(n);
                int closestPowerOf2Greater = closestPowerOf2Less;
                if (n > closestPowerOf2Less)
                    closestPowerOf2Greater *= 2;

                for (int k = closestPowerOf2Less; k <= closestPowerOf2Greater; ++k)
                {
                    if (k % 2 == 0)
                    {
                        int nextPreviousCount = Math.Abs(n - k) + 1; // steps from n to k + division by 2 which is also a step
                        int kBy2Count = CountIntegerReplacementsRecursive(k / 2, nextPreviousCount);
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

        /// at debug works with rougly the same speed as <see cref="CountWithMathClosestPowerOf2LessThan"/>
        private static int CountWithShiftsClosestPowerOf2LessThan(int n)
        {
            for (int p = 0; ; ++p)
                if (n >> p == 1)
                    return 1 << p;
        }

        // TODO: optimize with shifts or search
        private static int CountWithMathClosestPowerOf2LessThan(int n)
        {
            var logN = Math.Log(n, 2);
            var ceilingLogN = Math.Floor(logN);
            return (int)Math.Pow(2, ceilingLogN);
        }
    }
}
