using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.NaturalNumbers.SpecialBinaryStringSorter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.NaturalNumbers
{
    [TestClass]
    public class SpecialBinaryStringSorterTest
    {
        [TestMethod]
        public void MakeLargestSpecialTest()
        {
            // Arrange:
            ISpecialBinaryStringSorter specialBinaryStringSorter = new SimpleSpecialBinaryStringSorter();

            var inputObjects = new[]
            {
                new { Input = "11011000", Output = "11100100" },
            };

            foreach (var inputObject in inputObjects)
            {
                //// Act:
                //var output = specialBinaryStringSorter.MakeLargestSpecial(inputObject.Input);

                //// Assert:
                //Assert.AreEqual(inputObject.Output, output);
            }
        }
    }
}
