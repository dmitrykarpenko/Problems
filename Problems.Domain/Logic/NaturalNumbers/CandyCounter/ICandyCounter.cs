using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.CandyCounter
{
    /// <summary>
    /// There are N children standing in a line. Each child is assigned a rating value.
    /// You are giving candies to these children subjected to the following requirements:
    /// Each child must have at least one candy.
    /// Children with a higher rating get more candies than their neighbors.
    /// What is the minimum candies you must give?
    /// </summary>
    public interface ICandyCounter
    {
        int Candy(int[] ratings);
    }
}
