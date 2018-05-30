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
            return CountIntegerReplacementsRecursive(n, 0);
            //return count;
        }

        //private int count = 0;
        private Dictionary<int, int> counts = new Dictionary<int, int>();

        private int CountIntegerReplacementsRecursive(int n, int previousCount)
        {
            if (n == 1)
                return previousCount;

            int minCount;
            if (!counts.TryGetValue(n, out minCount))
            {
                minCount = int.MaxValue;
                int currentCount = 0;

                int closestPowerOf2Less = CountClosestPowerOf2LessThan(n);
                for (int k = n; k >= closestPowerOf2Less; --k, ++currentCount)
                {
                    if (k % 2 == 0)
                    {
                        int kBy2Count = CountIntegerReplacementsRecursive(k / 2, ++currentCount);
                        if (kBy2Count < minCount)
                            minCount = kBy2Count;
                    }
                }

                //// TODO: consider up-and-then-down movenment
                //currentCount = 0;
                //int closestPowerOf2Greater = closestPowerOf2Less * 2;
                //for (int k = n; k <= closestPowerOf2Greater; ++k, ++currentCount)
                //{
                //    if (k % 2 == 0)
                //    {
                //        int kBy2Count = CountIntegerReplacementsRecursive(k / 2, ++currentCount);
                //        if (kBy2Count < minCount)
                //            minCount = kBy2Count;
                //    }
                //}

                if (minCount < int.MaxValue)
                    counts[n] = minCount;
            }
            return minCount + previousCount;
        }

        // TODO: optimize with shifts
        private int CountClosestPowerOf2LessThan(int n)
        {
            var logN = Math.Log(n);
            var ceilingLogN = Math.Ceiling(logN);
            return (int)Math.Pow(2, ceilingLogN);
        }
    }
}
