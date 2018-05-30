using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.LinearAlgebra.PointsCounter;
using Problems.Domain.Logic.NaturalNumbers.IntegerReplacer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.NaturalNumbers
{
    [TestClass]
    public class IntegerReplacerTest
    {
        [TestMethod]
        public void IntegerReplacementTest()
        {
            // Arrange:
            IIntegerReplacer integerReplacer = new RecursiveIntegerReplacer();

            var inputObjects = new[]
            {
                new { Input = 8, Output = 3 },
                new { Input = 7, Output = 4 },
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var output = integerReplacer.IntegerReplacement(inputObject.Input);

                // Assert:
                Assert.AreEqual(inputObject.Output, output);
            }
        }
    }
}
