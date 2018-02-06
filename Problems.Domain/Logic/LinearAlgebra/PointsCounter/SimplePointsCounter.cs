using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = Problems.Domain.Logic.LinearAlgebra.PointsCounter.Point2D;

namespace Problems.Domain.Logic.LinearAlgebra.PointsCounter
{
    public class SimplePointsCounter : IPointsCounter
    {
        public int MaxPoints(Point[] points)
        {
            return MaxPointsOnLine(points);
        }

        private static int MaxPointsOnLine(Point[] points)
        {
            if (points?.Any() != true)
                return 0;
            if (points.Length <= 2)
                return 1; // by def ???

            var lines = new List<(Point, Point, Line2D)>();
            for (int i = 0; i < points.Length; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    lines.Add((points[i], points[j], new Line2D(points[i], points[j])));
                }
            }

            var grouping = lines
                .GroupBy(x => x.Item3.ToTuple());

            //if (!grouping.Any())
            //    return 0;

            var max = grouping
                .Max(x => x
                    .SelectMany(y => new[] { y.Item1, y.Item2 })
                    .Distinct().Count());

            return max;
        }
    }
}
