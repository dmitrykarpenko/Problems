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
            ICoinCounter coinCounter = new RecursiveCoinCounter();

            var inputObjects = new[]
            {
                new
                {
                    Coins = new[] { 186, 419, 83, 408 },
                    Amount = 6249,
                    Output = 20,
                },
                new
                {
                    Coins = new[] { 2147483647 },
                    Amount = 2,
                    Output = -1,
                },
                new
                {
                    Coins = new[] { 227, 99, 328, 299, 42, 322 },
                    Amount = 9847,
                    Output = 31,
                },
                new
                {
                    Coins = new[] { 411, 377, 14, 456, 434 },
                    Amount = 6892,
                    Output = 16,
                },
                new
                {
                    Coins = new[] { 3, 7, 405, 436 },
                    Amount = 8839,
                    Output = 25,
                },
                new
                {
                    Coins = new[] { 1, 2, 5 },
                    Amount = 11,
                    Output = 3,
                },
                new
                {
                    Coins = new[] { 2 },
                    Amount = 3,
                    Output = -1,
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
