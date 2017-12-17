using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.NaturalNumbers.PermutationsCounter;
using Problems.Domain.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.PowersEquationSolver
{
    [TestClass]
    public class PowersEquationSolverTest
    {
        [TestMethod]
        public void GetPermutationsTest()
        {
            IPermutationsCounter<char> counter = new RecursionPermutationsCounter<char>();

            var item = "abcde";
            var properPermutationsCount = Util.Factorial(item.Length);

            var result = GenericUtil.Execute(() => counter.GetPermutations(item).ToArray());
            var permutations = result.Result;

            var itemIndex = -1;
            for (int i = 0; i < permutations.Length; ++i)
            {
                var permutetionString = new string(permutations[i].ToArray());
                if (item == permutetionString)
                    itemIndex = i;

                // to watch the debug values more easy
                permutations[i] = permutetionString;
            }

            Assert.AreEqual(properPermutationsCount, permutations.Count());
            Assert.IsTrue(itemIndex >= 0);
        }
    }
}
