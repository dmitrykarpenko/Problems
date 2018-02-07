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
                // TODO: fix NumDecodings 
                //new
                //{
                //    Input = "301",
                //    Output = 0,
                //},
                new
                {
                    Input = "230",
                    Output = 0,
                },
                new
                {
                    Input = "100",
                    Output = 0,
                },
                new
                {
                    Input = "111",
                    Output = 3,
                },
                new
                {
                    Input = "011",
                    Output = 0,
                },
                new
                {
                    Input = "001",
                    Output = 0,
                },
                new
                {
                    Input = "01",
                    Output = 0,
                },
                new
                {
                    Input = "0",
                    Output = 0,
                },
                new
                {
                    Input = "",
                    Output = 0,
                },
                new
                {
                    Input = "1212",
                    Output = 5,
                },
                new
                {
                    Input = "11",
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
