using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.NaturalNumbers.Pattern132Finder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.NaturalNumbers
{
    [TestClass]
    public class Pattern132FinderTest
    {
        [TestMethod]
        public void MaxPointsTest()
        {
            // Arrange:
            IPattern132Finder pattern132Finder = new SequentialPattern132Finder();

            var inputObjects = new[]
            {
                new { Input = new[] { 1, 4, 0, 2 }, Output = true },
            };

            foreach (var inputObject in inputObjects)
            {
                //// Act:
                //var output = pattern132Finder.Find132pattern(inputObject.Input);

                //// Assert:
                //Assert.AreEqual(inputObject.Output, output);
            }
        }
    }
}
