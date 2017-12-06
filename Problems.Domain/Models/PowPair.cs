using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Models
{
    public class PowPair
    {
        public (int, int) Pair { get; set; }
        public long Pow { get; set; }
    }
}
