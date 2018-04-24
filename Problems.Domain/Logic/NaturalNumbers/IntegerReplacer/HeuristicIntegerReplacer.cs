using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.IntegerReplacer
{
    public class HeuristicIntegerReplacer : IIntegerReplacer
    {
        public int IntegerReplacement(int n)
        {
            return CountIntegerReplacements(n);
        }

        public static int CountIntegerReplacements(int n)
        {
            var logN = Math.Log(n);
            var ceilingLogN = Math.Ceiling(logN);

            if (ceilingLogN == logN)
                return (int)ceilingLogN;

            var splittingCeiling = Math.Log(2*n/3);

            if (logN <= splittingCeiling)
            {

            }

            // interval [2^k; 2^(k+1)] also grows exponentially
            // TODO: find the "ladder"
            // of interchanging additions/subtractions
            // and divisions
            throw new NotImplementedException();

            return 0;
        }
    }
}
