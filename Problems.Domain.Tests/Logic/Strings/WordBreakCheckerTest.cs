using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Strings.WordBreakChecker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Strings
{
    [TestClass]
    public class WordBreakCheckerTest
    {
        [TestMethod]
        public void WordBreakTest()
        {
            // Arrange:
            IWordBreakChecker wordBreakChecker = new SimpleWordBreakChecker();

            var inputObjects = new[]
            {
                new { Input = "coolcode", Words = new List<string> { "cool", "code" }, Output = true },
            };

            foreach (var inputObject in inputObjects)
            {
                //// Act:
                //var output = wordBreakChecker.WordBreak(inputObject.Input, inputObject.Words);

                //// Assert:
                //Assert.AreEqual(inputObject.Output, output);
            }
        }
    }
}
