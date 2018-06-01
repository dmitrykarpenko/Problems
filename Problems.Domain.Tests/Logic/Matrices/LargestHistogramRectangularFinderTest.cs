using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Matrices.LargestHistogramRectangularFinder;
using Problems.Domain.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Matrices
{
    [TestClass]
    public class LargestHistogramRectangularFinderTest
    {
        [TestMethod]
        public void LargestHistogramRectangularFinder_LargestRectangleArea_Test()
        {
            ILargestHistogramRectangularFinder largestHistogramRectangularFinder = new LargestHistogramRectangularFinder();

            // Arrange:
            var inputObjects = new[]
            {
                new { Input = new[] { 2, 1, 5, 6, 2, 3 }, Output = 10, },
                new { Input = new[] { 2, 1, 5, 6, 2, 3, 10 }, Output = 10, },
                new { Input = new[] { 2, 1, 5, 6, 5 }, Output = 15, },
                new { Input = new[] { 2 }, Output = 2, },
                new { Input = new int[0], Output = 0, },
                new { Input = (int[])null, Output = 0, },
                new { Input = GenericUtil.CreateArray((2, 100), (3, 200)), Output = 2*(100 + 200), },
                new { Input = GenericUtil.CreateArrayFromEnumerables((new[] { 2, 0 }, 100)), Output = 2*1, },
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var output = largestHistogramRectangularFinder.LargestRectangleArea(inputObject.Input);

                // Assert:
                Assert.AreEqual(inputObject.Output, output);
            }
        }
    }
}
