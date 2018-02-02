using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.CandyCounter
{
    public interface ICandyCounter
    {
        int Candy(int[] ratings);
    }
}
