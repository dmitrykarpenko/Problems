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
                new { Input = 2147483647, Output = 32 },
                new { Input = 1245412, Output = 25 },
                new { Input = 124541, Output = 23 },
                new { Input = 1245, Output = 14 },
                new { Input = 127, Output = 8 },
                new { Input = 129, Output = 8 },
                new { Input = 130, Output = 8 },
                new { Input = 260, Output = 9 },
                new { Input = 119, Output = 9 },
                new { Input = 8, Output = 3 },
                new { Input = 7, Output = 4 },
                new { Input = 3, Output = 2 },
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
