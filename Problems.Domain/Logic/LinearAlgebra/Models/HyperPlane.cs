using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.LinearAlgebra.Models
{
    public class HyperPlane
    {
        public HyperPlane(int dim)
        {
            AxisIntersects = new double?[dim];
        }

        private double?[] AxisIntersects { get; }
    }
}
