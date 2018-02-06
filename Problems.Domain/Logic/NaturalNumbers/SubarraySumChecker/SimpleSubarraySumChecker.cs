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
            return CheckSubarrayWithSumDivByWithLoops(nums, k);
        }

        private static bool CheckSubarrayWithSumDivByWithLoops(int[] nums, int k)
        {
            if (nums == null || nums.Length <= 1)
                return false;
            if (k == 0)
                return nums.All(n => n == 0);
            if (Math.Abs(k) == 1)
                return true;

            var numSums = new List<int>() { nums[0] };
            for (int i = 1; i < nums.Length; i++)
            {
                var sum = numSums[i - 1] + nums[i];
                if (sum % k == 0)
                    return true;
                numSums.Add(sum);
            }

            for (int i = 2; i < numSums.Count; ++i)
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
