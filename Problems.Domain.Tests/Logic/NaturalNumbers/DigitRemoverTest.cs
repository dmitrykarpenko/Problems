using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.NaturalNumbers.DigitRemover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.NaturalNumbers
{
    [TestClass]
    public class DigitRemoverTest
    {
        [TestMethod]
        public void RemoveKdigitsTest()
        {
            // Arrange:
            IDigitRemover digitRemover = new SimpleDigitRemover();

            var inputObjects = new[]
            {
                new
                {
                    Input = "1432219",
                    CountToRemove = 3,
                    Output = "1219",
                },
                new
                {
                    Input = "10200",
                    CountToRemove = 1,
                    Output = "200",
                },
                new
                {
                    Input = "10200",
                    CountToRemove = 2,
                    Output = "0",
                },
                new
                {
                    Input = "102000000100",
                    CountToRemove = 2,
                    Output = "100",
                },
                new
                {
                    Input = "10000000100",
                    CountToRemove = 2,
                    Output = "0",
                },
                new
                {
                    Input = "100900",
                    CountToRemove = 2,
                    Output = "0",
                },
                new
                {
                    Input = "300900",
                    CountToRemove = 1,
                    Output = "900",
                },
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var output = digitRemover.RemoveKdigits(inputObject.Input, inputObject.CountToRemove);

                // Assert:
                Assert.AreEqual(inputObject.Output, output);
            }
        }
    }
}
