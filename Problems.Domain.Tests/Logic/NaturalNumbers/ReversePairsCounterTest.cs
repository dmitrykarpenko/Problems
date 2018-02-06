using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.NaturalNumbers.DigitRemover;
using Problems.Domain.Logic.NaturalNumbers.ReversePairsCounter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.NaturalNumbers
{
    [TestClass]
    public class ReversePairsCounterTest
    {
        [TestMethod]
        public void ReversePairsTest()
        {
            // Arrange:
            IReversePairsCounter reversePairsCounter = new SortingReversePairsCounter();

            var inputObjects = new[]
            {
                //new
                //{
                //    Input = new[] { 1, 3, 2, 3, 1 },
                //    Output = 2,
                //},
                //new
                //{
                //    Input = new[] { 2, 4, 3, 5, 1 },
                //    Output = 3,
                //},
                new
                {
                    Input = new[] { 5, 4, 3, 2, 1 },
                    Output = 3,
                },
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var output = reversePairsCounter.ReversePairs(inputObject.Input);

                //// Assert:
                //Assert.AreEqual(inputObject.Output, output);
            }
        }
    }
}
