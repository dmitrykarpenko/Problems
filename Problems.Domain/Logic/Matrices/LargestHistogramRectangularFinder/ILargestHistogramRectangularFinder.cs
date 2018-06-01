using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Matrices.LargestHistogramRectangularFinder
{
    public interface ILargestHistogramRectangularFinder
    {
        /// <summary>
        /// https://leetcode.com/problems/largest-rectangle-in-histogram/description/
        /// 84. Largest Rectangle in Histogram
        /// Given n non-negative integers representing the histogram's bar height
        /// where the width of each bar is 1, find the area of largest rectangle in the histogram.
        /// 
        /// Example:
        /// Suppose we have a histogram where width of each bar is 1, given heights are [2, 1, 5, 6, 2, 3].
        /// The largest rectangle in the area will have the area of 10, i.e.:
        /// Input: [2, 1, 5, 6, 2, 3]
        /// Output: 10
        /// </summary>
        /// <param name="heights">Heights of histagram columns</param>
        /// <returns>Largest area</returns>
        int LargestRectangleArea(int[] heights);
    }
}
