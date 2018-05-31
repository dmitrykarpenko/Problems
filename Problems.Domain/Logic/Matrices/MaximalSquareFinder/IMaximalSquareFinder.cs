using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Matrices.MaximalSquareFinder
{
    public interface IMaximalSquareFinder
    {
        /// <summary>
        /// https://leetcode.com/problems/maximal-square/description/
        /// 221. Maximal Square
        /// Given a 2D binary matrix filled with 0's and 1's,
        /// find the largest square containing only 1's and return its area.
        /// 
        /// Example:
        /// 
        /// Input: 
        /// 1 0 1 0 0
        /// 1 0 1 1 1 /-- 
        /// 1 1 1 1 1 \--
        /// 1 0 0 1 0
        ///      ^
        ///     / \     the arrows point to the largest 2x2 square
        ///     | |
        /// 
        /// Output: 4
        /// </summary>
        /// <param name="matrix">the input matrix of 0's and 1's</param>
        /// <returns>The largest square area</returns>
        int MaximalSquare(char[,] matrix);
    }
}
