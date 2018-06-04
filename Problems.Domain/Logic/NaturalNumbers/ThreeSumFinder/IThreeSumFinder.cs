using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.ThreeSumFinder
{
    public interface IThreeSumFinder
    {
        /// <summary>
        /// https://leetcode.com/problems/3sum/description/
        /// 15. 3Sum
        /// Given an array nums of n integers, are there elements a, b, c in nums
        /// such that a + b + c = 0?
        /// Find all unique triplets in the array which gives the sum of zero.
        /// 
        /// Note:
        /// The solution set must not contain duplicate triplets.
        /// 
        /// Example:
        /// Given array nums = [-1, 0, 1, 2, -1, -4],
        /// A solution set is:
        /// [
        ///     [-1, 0, 1],
        ///     [-1, -1, 2]
        /// ]
        /// </summary>
        /// <param name="nums">The array nums of n integers</param>
        /// <returns>The array of triplet-arrays</returns>
        IList<IList<int>> ThreeSum(int[] nums);
    }
}
