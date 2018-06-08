using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Matrices.PathCounter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Domain.Tests.Logic.Matrices
{
    [TestClass]
    public class PathCounterTest
    {
        [TestMethod]
        public void StaticPathCounter_NumOfPathsToDest_Test()
        {
            // Arrange:
            var inputObjects = new[]
            {
                new { Input = 4, Output = 5, },
                new { Input = 5, Output = 14, },
                new { Input = 17, Output = 35357670 },

                new { Input = 0, Output = 0, },
                new { Input = 1, Output = 1, },
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var output = StaticPathCounter.NumOfPathsToDest(inputObject.Input);

                // Assert:
                Assert.AreEqual(inputObject.Output, output);
            }
        }
    }
}
