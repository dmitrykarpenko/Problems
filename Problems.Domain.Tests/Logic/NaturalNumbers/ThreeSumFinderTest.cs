using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.NaturalNumbers.ThreeSumFinder;
using Problems.Domain.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.NaturalNumbers
{
    [TestClass]
    public class ThreeSumFinderTest
    {
        [TestMethod]
        public void ThreeSumTest()
        {
            // Arrange:
            IThreeSumFinder threeSumFinder = new ThreeSumFinder();

            var inputObjects = new[]
            {
                //new { Input = new[] { -1, 0, 1, 2, -1, -4 }, Output = new[] { new[] { -1, -1, 2 }, new[] { -1, 0, 1 } } },
                new { Input = new[] { -1, -1, 1, 2, -1, 2 }, Output = new[] { new[] { -1, -1, 2 } } },
                new { Input = new[] { 0, 0, 0, -1, 1 }, Output = new[] { new[] { -1, 0, 1 }, new[] { 0, 0, 0 } } },

                new { Input = new int[0], Output = new int[0][] },
                new { Input = (int[])null, Output = new int[0][] },
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var output = threeSumFinder.ThreeSum(inputObject.Input);

                // Assert:
                for (int i = 0; i < output.Count; ++i)
                    output[i] = output[i].OrderBy(t => t).ToList();

                AssertUtil.AssertCollection(inputObject.Output, output,
                    t => t[0],
                    t => t[1],
                    t => t[2]);
            }
        }
    }
}
