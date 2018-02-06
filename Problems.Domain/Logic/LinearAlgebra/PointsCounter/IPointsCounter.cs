using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = Problems.Domain.Logic.LinearAlgebra.PointsCounter.Point2D;

namespace Problems.Domain.Logic.LinearAlgebra.PointsCounter
{
    /// <summary>
    /// Given n points on a 2D plane, find the maximum number of points that lie on the same straight line
    /// </summary>
    public interface IPointsCounter
    {
        int MaxPoints(Point[] points);
    }
}
