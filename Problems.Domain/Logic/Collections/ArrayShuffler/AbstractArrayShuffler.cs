using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Collections.ArrayShuffler
{
    /// <summary>
    /// https://leetcode.com/problems/shuffle-an-array/description/
    /// 384. Shuffle an Array
    /// Shuffle a set of numbers without duplicates.
    /// 
    /// Example:
    /// 
    /// // Init an array with set 1, 2, and 3.
    /// int[] nums = { 1, 2, 3 };
    /// Solution solution = new Solution(nums);
    /// 
    /// // Shuffle the array [1,2,3] and return its result. Any permutation of [1,2,3] must equally likely to be returned.
    /// solution.Shuffle();
    /// 
    /// // Resets the array back to its original configuration [1,2,3].
    /// solution.Reset();
    /// 
    /// // Returns the random shuffling of array [1,2,3].
    /// solution.Shuffle();
    /// 
    /// // Actual calls will be made this way:
    /// ConcreteArrayShuffler obj = new ConcreteArrayShuffler(nums);
    /// int[] param_1 = obj.Reset();
    /// int[] param_2 = obj.Shuffle();
    /// </summary>
    public abstract class AbstractArrayShuffler
    {
        protected AbstractArrayShuffler(int[] nums) { }
        public abstract int[] Reset();
        public abstract int[] Shuffle();
    }
}
