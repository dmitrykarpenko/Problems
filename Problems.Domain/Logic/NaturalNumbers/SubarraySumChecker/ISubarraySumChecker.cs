using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.SubarraySumChecker
{
    /// <summary>
    /// https://leetcode.com/problems/continuous-subarray-sum/description/
    /// 523. Continuous Subarray Sum
    /// Given a list of non-negative numbers and a target integer k,
    /// write a function to check if the array has a continuous subarray
    /// of size at least 2 that sums up to the multiple of k,
    /// that is, sums up to n*k where n is also an integer.
    /// 
    /// Example 1:
    /// Input: [23, 2, 4, 6, 7],  k=6
    /// Output: True
    /// Explanation: Because[2, 4] is a continuous subarray of size 2 and sums up to 6.
    /// 
    /// Example 2:
    /// Input: [23, 2, 6, 4, 7],  k=6
    /// Output: True
    /// Explanation: Because[23, 2, 6, 4, 7] is an continuous subarray of size 5 and sums up to 42.
    /// </summary>
    public interface ISubarraySumChecker
    {
        bool CheckSubarraySum(int[] nums, int k);
    }
}
