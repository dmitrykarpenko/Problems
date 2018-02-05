using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.LinearAlgebra.PointsCounter
{
    public class Point2D
    {
        public Point2D()
        {
            x = 0;
            y = 0;
        }
        public Point2D(int a, int b)
        {
            x = a;
            y = b;
        }
        public int x { get; set; }
        public int y { get; set; }
    }
}
