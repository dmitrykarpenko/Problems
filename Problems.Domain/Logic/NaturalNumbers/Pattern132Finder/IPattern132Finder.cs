using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.Pattern132Finder
{
    public interface IPattern132Finder
    {
        /// <summary>
        /// https://leetcode.com/problems/132-pattern/description/
        /// 456. 132 Pattern
        /// 
        /// Given a sequence of n integers a1, a2, ..., an, a 132 pattern
        /// is a subsequence ai, aj, ak such that "i greater than j greater than k" and "ai greater than ak greater than aj".
        /// Design an algorithm that takes a list of n numbers as input and checks whether there is a 132 pattern in the list.
        /// 
        /// Note: n will be less than 15,000.
        /// 
        /// Example 1:
        /// Input: [1, 2, 3, 4]
        /// Output: False
        /// Explanation: There is no 132 pattern in the sequence.
        /// 
        /// Example 2:
        /// Input: [3, 1, 4, 2]
        /// Output: True
        /// Explanation: There is a 132 pattern in the sequence: [1, 4, 2].
        /// 
        /// Example 3:
        /// Input: [-1, 3, 2, 0]
        /// Output: True
        /// 
        /// Explanation: There are three 132 patterns in the sequence: [-1, 3, 2], [-1, 3, 0] and[-1, 2, 0].
        /// </summary>
        /// <param name="nums">given sequence of n integers</param>
        /// <returns>Does the sequence have a 132 pattern</returns>
        bool Find132pattern(int[] nums);
    }
}
