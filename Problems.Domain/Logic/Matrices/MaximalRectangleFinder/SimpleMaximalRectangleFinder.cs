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
        private int _height;
        private int _width;

        public int MaximalRectangle(char[,] matrix)
        {
            _matrix = matrix;
            _height = _matrix.GetLength(0);
            _width = _matrix.GetLength(1);

            return CountMaximalRectangleArea();
        }

        private int CountMaximalRectangleArea()
        {
			var rectangleCache = new RectangleCache();
			
            for (int i = 0; i < _height; ++i)
            {
                for (int j = 0; j < _width; ++j)
                {
					if (true || !rectangleCache.ContainsPoint(i, j))
					{
						var point = new PointModel { I = i, J = j };
                        // iterrating through all "opposite" vertices for each point is too complex
						var oppositeVertices = GetOppositeVertices(point)
                            .ToArray();
						foreach (var v in oppositeVertices)
						{
							rectangleCache.AddRectangle(new RectangleModel { P1 = point, P2 = v });
						}
					}
                }
            }
			
            return rectangleCache.MaximalArea;
        }

        private class PointModel
        {
            public int I;
            public int J;

            public override string ToString() => $"({I}, {J})";
        }

        private class RectangleModel
		{
			public PointModel P1;
			public PointModel P2;

            public int Area => (P2.I - P1.I + 1) * (P2.J - P1.J + 1);

            public bool Contains(RectangleModel r) =>
                P1.I <= r.P1.I && P1.J <= r.P1.J &&
                P2.I >= r.P2.I && P2.J >= r.P2.J;

            public bool ContainsPoint(int i, int j) =>
                P1.I <= i && P1.J <= j &&
                P2.I >= i && P2.J >= j;

            public override string ToString() => $"[{P1}, {P2}]";
        }
		
		private class RectangleCache
		{
			private readonly List<RectangleModel> _rectangles = new List<RectangleModel>();
			
            public int MaximalArea { get; private set; }
			
			public RectangleCache()
			{
				MaximalArea = 0;
			}

			public void AddRectangle(RectangleModel rectangle)
			{
				if (!_rectangles.Any(r => r.Contains(rectangle)))
				{
                    _rectangles.RemoveAll(r => rectangle.Contains(r));
                    _rectangles.Add(rectangle);

					var rectangleArea = rectangle.Area;
					if (MaximalArea < rectangleArea)
					{
						MaximalArea = rectangleArea;
					}
				}
			}
			
			public bool ContainsPoint(int i, int j) => _rectangles.Any(r => r.ContainsPoint(i, j));
        }
		
        private IEnumerable<PointModel> GetOppositeVertices(PointModel topLeftVertex)
        {
            var iMin = topLeftVertex.I;
            var jMin = topLeftVertex.J;

            return GetOppositeVertices(iMin, jMin);
        }

        private IEnumerable<PointModel> GetOppositeVertices(int iMin, int jMin)
        {
            var iTop = _height;
            var jTop = _width;

            int iCandidate;
            int jCandidate = jTop - 1;
            for (int i = iMin; i < iTop; ++i)
            {
                int j = GetMaxSignificantJ(i, jMin, jTop);

                if (j < jCandidate)
                {
                    iCandidate = i - 1;
                    if (iCandidate >= iMin)
                    {
                        yield return new PointModel { I = iCandidate, J = jCandidate };
                    }
                    if (j < 0)
                    {
                        yield break;
                    }
                    jTop = j + 1;
                    jCandidate = j;
                }
            }

            iCandidate = iTop - 1;
            if (_matrix[iCandidate, jCandidate] == _significant)
            {
                yield return new PointModel { I = iCandidate, J = jCandidate };
            }
        }

        private int GetMaxSignificantJ(int i, int jMin, int jTop)
		{
			if (_matrix[i, jMin] != _significant)
				return -1;
			
			for (int j = jMin + 1; j < jTop; ++j)
			{
				if (_matrix[i, j] != _significant)
				{
					return j - 1;
				}
			}

            return jTop - 1;
        }
    }
}
