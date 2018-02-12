using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Matrices.MaximalRectangleFinder
{
    public interface IMaximalRectangleFinder
    {
        /// <summary>
        /// https://leetcode.com/problems/maximal-rectangle/description/
        /// 85. Maximal Rectangle
        /// 
        /// Given a 2D binary matrix filled with 0's and 1's, find the largest rectangle containing only 1's and return its area.
        /// 
        /// For example, given the following matrix:
        /// 
        /// 1 0 1 0 0
        /// 1 0 1 1 1
        /// 1 1 1 1 1
        /// 1 0 0 1 0
        /// 
        /// Return 6.
        /// </summary>
        /// <param name="matrix">given matrix</param>
        /// <returns></returns>
        int MaximalRectangle(char[,] matrix);
    }
}
