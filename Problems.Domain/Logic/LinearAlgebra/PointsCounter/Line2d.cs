using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = Problems.Domain.Logic.LinearAlgebra.PointsCounter.Point2D;

namespace Problems.Domain.Logic.LinearAlgebra.PointsCounter
{
    public class Line2D
    {
        public Line2D(Point p1, Point p2)
        {
            {
                var numerator = p2.y - p1.y;
                if (numerator == 0)
                {
                    A = 0;
                }
                else
                {
                    var denominator = p2.x - p1.x;
                    if (denominator != 0)
                        A = (double)numerator / denominator;
                }
            }
            {
                var numerator = p2.x* p1.y - p1.x * p2.y;
                if (numerator == 0)
                {
                    B = 0;
                }
                else
                {
                    var denominator = p2.x - p1.x;
                    if (denominator != 0)
                        B = (double)numerator / denominator;
                }
            }
        }

        //y = Ax + B
        public double? A { get; set; }
        public double? B { get; set; }

        public (double?, double?) ToTuple() => (A, B);

        public override bool Equals(object obj)
        {
            var item = obj as Line2D;
            if (item != null)
            {
                return A == item.A && B == item.B;
            }
            return false;
        }

        public override string ToString() => $"y = {A}x + {B}";
    }
}
