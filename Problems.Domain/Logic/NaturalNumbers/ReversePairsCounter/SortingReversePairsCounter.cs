using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.ReversePairsCounter
{
    public class SortingReversePairsCounter : IReversePairsCounter
    {
        public int ReversePairs(int[] nums)
        {
            return CountReversePairsFromSorted(nums);
        }

        private static int CountReversePairsBF(int[] nums)
        {
            var count = 0;
            for (int i = 0; i < nums.Length - 1; ++i)
            {
                for (int j = i + 1; j < nums.Length; ++j)
                {
                    if (nums[i] > 2 * nums[j])
                    {
                        ++count;
                    }
                }
            }
            return count;
        }

        private class NumInfo
        {
            public int Num { get; set; }
            public int Index { get; set; }
        }

        private static int CountReversePairsFromSorted(int[] nums)
        {
            var index = 0;
            var sortedNumInfos = nums
                .Select(x => new NumInfo
                {
                    Num = x,
                    Index = index++,
                })
                .OrderByDescending(x => x.Num)
                .ThenBy(x => x.Index)
                .ToArray();

            var count = 0;
            foreach (var sortedNumInfo in sortedNumInfos)
            {
                DoForEachLessThan(sortedNumInfos, sortedNumInfo.Num / 2, ni =>
                {
                    if (ni.Index > sortedNumInfo.Index)
                        ++count;
                });
            }
            return count;
        }

        private static void DoForEachLessThan(NumInfo[] sortedNumInfos, int num, Action<NumInfo> action)
        {
            int numIndex = -1,
                indexOfStart = 0,
                indexOfEnd = sortedNumInfos.Length - 1;
            while (indexOfStart <= indexOfEnd)
            {
                numIndex = (indexOfStart + indexOfEnd) / 2;
                if (sortedNumInfos[numIndex].Num > num)
                {
                    indexOfStart = numIndex + 1;
                }
                else if (sortedNumInfos[numIndex].Num < num)
                {
                    indexOfEnd = numIndex - 1;
                }
                else
                {
                    break;
                }
            }

            var indexOfFirstMatch = GetNextIndexOfNotEqual(sortedNumInfos, sortedNumInfos[numIndex]);

            DoForEachAfter(sortedNumInfos, indexOfFirstMatch, action);
        }

        private static int GetNextIndexOfNotEqual(NumInfo[] sortedNumInfos, NumInfo numInfo)
        {
            for (int i = numInfo.Index + 1; i < sortedNumInfos.Length; ++i)
                if (sortedNumInfos[i].Num != numInfo.Num)
                    return i;

            return -1;
        }

        private static void DoForEachAfter(NumInfo[] sortedNumInfos, int indexOfFirstMatch, Action<NumInfo> action)
        {
            if (0 <= indexOfFirstMatch && indexOfFirstMatch < sortedNumInfos.Length)
                for (int i = indexOfFirstMatch; i < sortedNumInfos.Length; ++i)
                {
                    action(sortedNumInfos[i]);
                }
        }
    }
}
