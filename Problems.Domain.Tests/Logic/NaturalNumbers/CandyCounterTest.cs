using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.NaturalNumbers.CandyCounter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.NaturalNumbers
{
    [TestClass]
    public class CandyCounterTest
    {
        [TestMethod]
        public void SlopeCandyCounterTest()
        {
            ICandyCounter candyCounter = new SlopeCandyCounter();

            var ratingArrays = new[]
            {
                new[] { 2, 1, 5, 7, 8, 7, 6, 5, 4, 3, 2, 1 },
                //new[] { 1, 2, 3, 3, 4, 5, 6, 4, 1, 9, 2 },
            };

            foreach (var ratings in ratingArrays)
            {
                var sum = candyCounter.Candy(ratings);
                // TODO: implement and add asserts
            }
        }

        [TestMethod]
        public void SimpleCandyCounterTest()
        {
            // Arrange:
            ICandyCounter candyCounter = new SimpleCandyCounter();

            var ratingObjects = new[]
            {
                new
                {
                    Ratings = new[] { 2, 1, 5, 7, 8, 7, 6, 5, 4, 3, 2, 1 },
                    ProperSum = 44,
                },
                new
                {
                    Ratings = new[] { 1, 2, 3, 3, 4, 5, 6, 4, 1, 9, 2 },
                    ProperSum = 22,
                },
                new
                {
                    Ratings = new[] { 5, 1, 1, 1, 10, 2, 1, 1, 1, 3 },
                    ProperSum = 15,
                },
            };

            foreach (var ratingObject in ratingObjects)
            {
                // Act:
                var sum = candyCounter.Candy(ratingObject.Ratings);

                // Assert:
                Assert.AreEqual(ratingObject.ProperSum, sum);
            }
        }
    }
}
