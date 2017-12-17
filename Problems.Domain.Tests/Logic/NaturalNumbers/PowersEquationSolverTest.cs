using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.NaturalNumbers.PowersEquationSolver;
using Problems.Domain.Tests.Models;
using Problems.Domain.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Problems.Domain.Tests.Logic.NaturalNumbers
{
    [TestClass]
    public class PowersEquationSolverTest
    {
        [TestMethod]
        public void GetSolutionsAllTest()
        {
            var max = 50;
          
            var results = new List<ExecutionResult<(int, int, int, int)[]>>();

            results.Add(GenericUtil.Execute(() => new BrutePowersEquationSolver().GetSolutions(max).ToArray()));
            results.Add(GenericUtil.Execute(() => new GroupingPowersEquationSolver().GetSolutions(max).ToArray()));
            results.Add(GenericUtil.Execute(() => new CtciPowersEquationSolver().GetSolutions(max).ToArray()));

            Assert.IsTrue(results[0].TimeSpent > results[1].TimeSpent);

            for (int i = 0; i < results.Count; i++)
                Debug.WriteLine(results[i], $"Result #{i} ");

            Assert.AreEqual(results[0].Result.Count(), results[1].Result.Count());
            Assert.AreEqual(results[1].Result.Count(), results[2].Result.Count());

            var count = results[0].Result.Count();

            var solutions1 = results[0].Result.Distinct().ToArray();
            var solutions2 = results[1].Result.Distinct().ToHashSet();
            var solutions3 = results[2].Result.Distinct().ToHashSet();

            Assert.AreEqual(count, solutions1.Count());
            Assert.AreEqual(count, solutions2.Count());
            Assert.AreEqual(count, solutions3.Count());

            foreach (var solution in solutions1)
            {
                Assert.IsTrue(solutions2.Contains(solution));
                Assert.IsTrue(solutions3.Contains(solution));
            }
        }

        [TestMethod]
        public void GetSolutionsOneTest()
        {
            var max = 100;

            var results = new List<ExecutionResult<(int, int, int, int)>>();
            
            results.Add(GenericUtil.Execute(() => new GroupingPowersEquationSolver().GetSolutions(max)
                .Skip(10)
                .Take(1)
                .FirstOrDefault()));
            results.Add(GenericUtil.Execute(() => new CtciPowersEquationSolver().GetSolutions(max)
                .Skip(10)
                .Take(1)
                .FirstOrDefault()));

            for (int i = 0; i < results.Count; i++)
                Debug.WriteLine(results[i], $"Result #{i} ");

            Assert.AreEqual(results[0].Result, results[1].Result);
        }
    }
}
