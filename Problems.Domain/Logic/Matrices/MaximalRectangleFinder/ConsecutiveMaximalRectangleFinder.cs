using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Matrices.MaximalRectangleFinder
{
    public class ConsecutiveMaximalRectangleFinder : IMaximalRectangleFinder
    {
        private const char _significant = '1';

        private char[,] _matrix;
        private int _height;
        private int _width;

        public int MaximalRectangle(char[,] matrix)
        {
            _matrix = matrix;
            _height = _matrix.GetLength(0);
            _width = _matrix.GetLength(1);

            return CountMaximalRectangleArea();
        }

        private int _maximalArea = 0;
        private List<VerticalRectangleModel> _currentRectangles;

        private int CountMaximalRectangleArea()
        {
            for (int i = 0; i < _height; ++i)
            {
                var horizontalLines = GetHorizontalLines(i);

                for (int j = 0; j < _width; ++j)
                {
                    //...
                }
            }

            return 0;
        }

        private IEnumerable<HorizontalLineModel> GetHorizontalLines(int i)
        {
            int jMax = _width - 1;
            int jFirst = GetFirstSignificantJ(i, 0);
            if (jFirst < 0)
            {
                yield break;
            }
            if (jFirst >= jMax)
            {
                yield return new HorizontalLineModel { I = i, J1 = 0, J2 = jMax };
                yield break;
            }

            int j = jFirst + 1;
            for (; j < _width; ++j)
            {
                if (_matrix[i, j] != _significant || j == jMax)
                {
                    yield return new HorizontalLineModel { I = i, J1 = jFirst, J2 = j - 1 };
                    jFirst = GetFirstSignificantJ(i, j + 1);
                    if (jFirst < 0)
                    {
                        yield break;
                    }
                    j = jFirst;
                }
            }
        }

        private int GetFirstSignificantJ(int i, int jMin)
        {
            for (int j = jMin; j < _width; ++j)
                if (_matrix[i, j] == _significant)
                    return j;

            return -1;
        }

        private class PointModel
        {
            public int I;
            public int J;

            public override string ToString() => $"({I}, {J})";
        }

        private class HorizontalLineModel : Line1D
        {
            public int I;

            public HorizontalLineModel Intersect(Line1D line)
            {
                var j1 = Math.Max(J1, line.J1);
                var j2 = Math.Min(J2, line.J2);
                return j1 <= j2 ? new HorizontalLineModel { I = I, J1 = j1, J2 = j2 } : null;
            }

            public override string ToString() => $"[{base.ToString()} on {I}]";
        }

        private class Line1D
        {
            public int J1;
            public int J2;

            public int Length => J2 - J1 + 1;

            public bool Contains(Line1D line) => J1 <= line.J1 && line.J2 <= J2;

            public override string ToString() => $"[{J1}, {J2}]";
        }

        private class VerticalRectangleModel
		{
			public HorizontalLineModel TopLine;
			public int Height;

            public int Area => TopLine.Length * Height;

            public override string ToString() => $"{TopLine} * {Height}";
        }

        private class CurrentRectangleCache
        {
            private readonly List<VerticalRectangleModel> _verticalRectangles = new List<VerticalRectangleModel>();

            public int MaximalArea { get; private set; }

            public CurrentRectangleCache()
            {
                MaximalArea = 0;
            }

            public void GrowRectangles(IEnumerable<Line1D> lines)
            {
                int rMin = 0;
                foreach (var line in lines)
                {
                    for (int r = rMin; r < _verticalRectangles.Count; ++r)
                    {
                        var intersection = _verticalRectangles[r].TopLine.Intersect(line);
                        if (intersection != null)
                        {
                            // ...
                        }
                    }
                }
            }
        }
    }
}
