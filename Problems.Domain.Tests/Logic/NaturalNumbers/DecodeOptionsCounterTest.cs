using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Strings.DecodeOptionsCounter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.NaturalNumbers
{
    [TestClass]
    public class DecodeOptionsCounterTest
    {
        [TestMethod]
        public void NumDecodingsTest()
        {
            // Arrange:
            IDecodeOptionsCounter decodeOptionsCounter = new RecursiveDecodeOptionsCounter();

            var inputObjects = new[]
            {
                new
                {
                    Input = "ABAB",
                    Output = 5,
                },
                new
                {
                    Input = "AB",
                    Output = 2,
                },
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var output = decodeOptionsCounter.NumDecodings(inputObject.Input);

                // Assert:
                Assert.AreEqual(inputObject.Output, output,
                    $"{inputObject.Input} should have {inputObject.Output} ways of decoding");
            }
        }
    }
}
