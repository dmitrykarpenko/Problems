using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Matrices.MaximalRectangleFinder
{
    public class SimpleMaximalRectangleFinder : IMaximalRectangleFinder
    {
        private const char _significant = '1';

        private char[,] _matrix;
        private int _width;
        private int _height;

        public int MaximalRectangle(char[,] matrix)
        {
            _matrix = matrix;
            _width = _matrix.GetLength(0);
            _height = _matrix.GetLength(1);

            return CountMaximalRectangleArea();
        }

        private int CountMaximalRectangleArea()
        {
            for (int i = 0; i < _width; ++i)
            {
                for (int j = 0; j < _height; ++j)
                {

                }
            }
            return 0;
        }

        private IEnumerable<(int, int)> GetOppositeVertices((int, int) topLeftVertex)
        {
            var iMin = topLeftVertex.Item1;
            var jMin = topLeftVertex.Item2;

            var iMax = _width - 1;
            var jMax = _height - 1;

            for (int i = iMin; i <= iMax; ++i)
            {
                for (int j = jMin; j <= jMax; ++j)
                {
                    if (_matrix[i, j] != _significant)
                    {
                        jMax = j - 1;
                        if (jMin < jMax || iMin < i)
                        {
                            yield return (i, jMax);
                        }
                    }
                }
            }
        }
    }
}
