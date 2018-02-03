using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.NaturalNumbers.CoinCounter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.NaturalNumbers
{
    [TestClass]
    public class CoinCounterTest
    {
        [TestMethod]
        public void CoinChangeTest()
        {
            // Arrange:
            ICoinCounter coinCounter = new SimpleCoinCounter();

            var inputObjects = new[]
            {
                new
                {
                    Coins = new[] { 1, 2, 5 },
                    Amount = 11,
                    Output = 3,
                },
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var output = coinCounter.CoinChange(inputObject.Coins, inputObject.Amount);

                // Assert:
                Assert.AreEqual(inputObject.Output, output);
            }
        }
    }
}
