using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.NaturalNumbers.PowersEquationSolver;
using Problems.Domain.Tests.Utils;
using System;
using System.Diagnostics;
using System.Linq;

namespace Problems.Domain.Tests.Logic.NaturalNumbers
{
    [TestClass]
    public class PowersEquationSolverTest
    {
        [TestMethod]
        public void GetSolutionsTest()
        {
            var max = 50;
          
            var result1 = GenericUtil.Execute(() => new BrutePowersEquationSolver().GetSolutions(max).ToArray());
            var result2 = GenericUtil.Execute(() => new CachingPowersEquationSolver().GetSolutions(max).ToArray());

            Assert.IsTrue(result1.TimeSpent > result2.TimeSpent);

            Assert.AreEqual(result1.Result.Count(), result2.Result.Count());

            var count = result1.Result.Count();

            var solutions1 = result1.Result.Distinct().ToArray();
            var solutions2 = result2.Result.Distinct().ToHashSet();

            Assert.AreEqual(count, solutions1.Count());
            Assert.AreEqual(count, solutions2.Count());

            foreach (var solution in solutions1)
                Assert.IsTrue(solutions2.Contains(solution));
        }
    }
}
