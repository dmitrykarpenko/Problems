using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Matrices.LargestHistogramRectangularFinder
{
    public class LargestHistogramRectangularFinder : ILargestHistogramRectangularFinder
    {
        /// <summary>
        /// Finds maximum rectangular area under a given histogram.
        /// Time Complexity: O(n) since every bar is pushed and popped only once. 
        /// </summary>
        /// <param name="_heights">The given histogram</param>
        /// <returns></returns>
        public int LargestRectangleArea(int[] heights)
        {
            if (heights == null)
                return 0;

            Initialize(heights);

            FillLargestRectangleArea();

            return _maxArea;
        }

        private void FillLargestRectangleArea()
        {
            // Run through all bars of the given histogram
            while (_i < _heights.Length)
            {
                if (!_indices.Any() || _heights[_indices.Peek()] <= _heights[_i])
                {
                    // if this bar is higher than the bar on the top of the stack, push it to the stack
                    _indices.Push(_i++);
                }
                else
                {
                    // else, if this bar is lower than the top of the stack, calculate the area of the rectangle 
                    // with the stack top as the smallest (or "minimum height") bar.
                    PopIndexAndCalculateArea();
                }
            }

            // Now pop the remaining bars from stack and calculate area with every
            // popped bar as the smallest bar
            while (_indices.Any())
            {
                PopIndexAndCalculateArea();
            }
        }

        /// <summary> The given histogram </summary>
        private int[] _heights;
        /// <summary> 
        /// The stack holds indices of <see cref="_heights"/> array
        /// The bars stored in the stack are always in
        /// increasing order of their heights
        /// (would have been popped otherwise).
        /// </summary>
        private Stack<int> _indices;
        /// <summary> The current index </summary>
        private int _i;
        /// <summary> The wanted max area </summary>
        private int _maxArea;

        private void Initialize(int[] heights)
        {
            _heights = heights;
            _indices = new Stack<int>();
            _i = 0;
            _maxArea = 0;
        }

        private void PopIndexAndCalculateArea()
        {
            // _i is the 'right index' for the top and the element before the top in the stack is the 'left index'

            // Top of the stack.
            // Store the top index and POP the top:
            int indicesTop = _indices.Pop();

            // CALCULATE the area with heights[indicesTop] stack as the smallest bar:

            var areaHeight = _heights[indicesTop];
            var areaWidth = !_indices.Any()
                ? _i // no _indices, so the area "goes" right to the start of the histogram
                : _i - _indices.Peek() - 1; // _indices have an index, so the area "stops" before the index 
                                            // (i.e. "stops" at the popped _indicesTop index)
                                            
            // Area with the top bar as the smallest bar
            int areaWithTop = areaHeight * areaWidth;

            // Update max area, if needed:
            if (_maxArea < areaWithTop)
                _maxArea = areaWithTop;
        }
    }
}
