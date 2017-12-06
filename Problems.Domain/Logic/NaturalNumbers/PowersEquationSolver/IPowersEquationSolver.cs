using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Domain.Logic.NaturalNumbers.PowersEquationSolver
{
    public interface IPowersEquationSolver
    {
        IEnumerable<(int, int, int, int)> GetSolutions(int max);
    }
}
