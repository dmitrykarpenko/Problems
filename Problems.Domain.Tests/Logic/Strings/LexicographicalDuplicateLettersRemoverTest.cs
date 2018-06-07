using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Strings.LexicographicalDuplicateLettersRemover;
using Problems.Domain.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Strings
{
    [TestClass]
    public class LexicographicalDuplicateLettersRemoverTest
    {
        [TestMethod]
        public void LexicographicalDuplicateLettersRemover_RemoveDuplicateLetters_Test()
        {
            // Arrange:
            ILexicographicalDuplicateLettersRemover lexicographicalDuplicateLettersRemover =
                new LexicographicalDuplicateLettersRemover();

            var largeString = new string(GenericUtil.CreateArrayFromEnumerables(
                (new[] { 'x', 'y' }, 2), (new[] { 'a', 'b' }, 198), (new[] { 'c', 'd' }, 100)));

            var inputObjects = new[]
            {
                new { Input = "bacdgabcda", Output = "acdgb" },
                new { Input = "bxbbbbbbccccsaaaaaabc", Output = "bxcsa" },
                new { Input = "aaababaa", Output = "ab" },
                new { Input = "cbaebabacdx", Output = "aebcdx" },
                new { Input = "czbaebabacdx", Output = "czaebdx" },
                new { Input = largeString, Output = "xyabcd" },

                new { Input = "", Output = "" },
                new { Input = (string)null, Output = (string)null },
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var output = lexicographicalDuplicateLettersRemover.RemoveDuplicateLetters(inputObject.Input);

                // Assert:
                Assert.AreEqual(inputObject.Output, output);
            }
        }
    }
}
