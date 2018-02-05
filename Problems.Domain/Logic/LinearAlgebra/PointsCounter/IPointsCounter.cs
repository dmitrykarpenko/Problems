using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = Problems.Domain.Logic.LinearAlgebra.PointsCounter.Point2D;

namespace Problems.Domain.Logic.LinearAlgebra.PointsCounter
{
    public interface IPointsCounter
    {
        int MaxPoints(Point[] points);
    }
}
