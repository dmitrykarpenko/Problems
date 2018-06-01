using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Strings.AnagramSubstringSearcher;
using Problems.Domain.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Strings
{
    [TestClass]
    public class AnagramSubstringSearcherTest
    {
        [TestMethod]
        public void AnagramSubstringSearcher_GetIndices_Test()
        {
            // Arrange:
            IAnagramSubstringSearcher anagramSubstringSearcher = new AnagramSubstringSearcher();

            var largeString = new string(GenericUtil.CreateArrayFromEnumerables((new[] { 'x', 'y' }, 2), (new[] { 'A', 'B' }, 198), (new[] { 'C', 'D' }, 100)));

            var inputObjects = new[]
            {
                new { Input = new { Txt = "BACDGABCDA", Pat = "ABCD" }, Output = new [] { 0, 5, 6 } },
                new { Input = new { Txt = "BACDGABCDA", Pat = "CDAB" }, Output = new [] { 0, 5, 6 } },
                new { Input = new { Txt = "AAABABAA", Pat = "AABA" }, Output = new [] { 0, 1, 4 } },
                //new { Input = new { Txt = "cbaebabacd", Pat = "abc" }, Output = new [] { 0, 6 } },
                //new { Input = new { Txt = "abab", Pat = "ab" }, Output = new [] { 0, 1, 2 } },
                new { Input = new { Txt = largeString, Pat = "ABCD" }, Output = new [] { 398 } },
                new { Input = new { Txt = largeString, Pat = "ABDC" }, Output = new [] { 398 } },
                new { Input = new { Txt = largeString, Pat = "DCAB" }, Output = new [] { 398 } },
                new { Input = new { Txt = largeString, Pat = "ABDCAB" }, Output = new [] { 396 } },
                new { Input = new { Txt = largeString, Pat = "xyx" }, Output = new [] { 0 } },
                new { Input = new { Txt = largeString, Pat = "xy" }, Output = new [] { 0, 1, 2 } },
                new { Input = new { Txt = largeString, Pat = "yx" }, Output = new [] { 0, 1, 2 } },

                new { Input = new { Txt = "BAC", Pat = "ABCD" }, Output = new int[0] },
                new { Input = new { Txt = (string)null, Pat = (string)null }, Output = new int[0] },
                new { Input = new { Txt = "", Pat = (string)null }, Output = new int[0] },
                new { Input = new { Txt = (string)null, Pat = "" }, Output = new int[0] },
                new { Input = new { Txt = "", Pat = "" }, Output = new int[0] },
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var output = anagramSubstringSearcher.GetIndices(inputObject.Input.Txt, inputObject.Input.Pat);

                // Assert:
                AssertUtil.AssertCollection(inputObject.Output, output);
            }
        }
    }
}
