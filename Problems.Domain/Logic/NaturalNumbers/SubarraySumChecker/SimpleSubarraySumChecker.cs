using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.SubarraySumChecker
{
    public class SimpleSubarraySumChecker : ISubarraySumChecker
    {
        public bool CheckSubarraySum(int[] nums, int k)
        {
            return CheckSubarrayWithSumDivByKLoops(nums, k);
        }

        //private struct NumInfo
        //{
        //    public int Num;
        //    public int Info;
        //}

        private static bool CheckSubarrayWithSumDivByKWithHashSet(int[] nums, int k)
        {
            if (nums == null || nums.Length <= 1 || k < 1)
                return false;

            var numSums = new List<int>() { nums[0] };
            for (int i = 1; i < nums.Length; i++)
            {
                numSums.Add(numSums[i - 1] + nums[i]);
            }
            var numSumsHashSet = new HashSet<int>(numSums);
            var numsSum = numSums[numSums.Count - 1];

            for (int i = 0; i < numSums.Count; ++i)
            {
                var lMax = (numsSum - numSums[i]) / k;
                for (int l = 1; l <= lMax; ++l)
                {
                    if (numSumsHashSet.Contains(numSums[i] + k * l))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool CheckSubarrayWithSumDivByKLoops(int[] nums, int k)
        {
            if (nums == null || nums.Length <= 1)
                return false;

            var numSums = new List<int>() { nums[0] };
            for (int i = 1; i < nums.Length; i++)
            {
                var sum = numSums[i - 1] + nums[i];
                if (sum % k == 0)
                    return true;
                numSums.Add(sum);
            }

            for (int i = 2; i < numSums.Count - 1; ++i)
            {
                for (int j = 0; j < numSums.Count - i; ++j)
                {
                    if ((numSums[i + j] - numSums[j]) % k == 0)
                        return true;
                }
            }

            return false;
        }
    }
}
