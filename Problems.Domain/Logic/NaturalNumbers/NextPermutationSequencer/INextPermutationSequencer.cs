using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.NextPermutationSequencer
{
    public interface INextPermutationSequencer
    {
        /// <summary>
        /// https://leetcode.com/problems/next-permutation/description/
        /// 31. Next Permutation
        /// 
        /// Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.
        /// 
        /// If such arrangement is not possible, it must rearrange it as the lowest possible order (i.e., sorted in ascending order).
        /// 
        /// The replacement must be in-place, do not allocate extra memory.
        /// 
        /// Here are some examples.Inputs are in the left-hand column and its corresponding outputs are in the right-hand column.
        /// 1,2,3 → 1,3,2
        /// 3,2,1 → 1,2,3
        /// 1,1,5 → 1,5,1
        /// </summary>
        /// <param name="nums">Given permutation</param>
        void NextPermutation(int[] nums);
    }
}
