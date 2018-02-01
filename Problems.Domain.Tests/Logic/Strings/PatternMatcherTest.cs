using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Strings.PatternMatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Strings
{
    [TestClass]
    public class PatternMatcherTest
    {
        [TestMethod]
        public void IsMatchTrueTest()
        {
            //Arrange:
            IPatternMatcher patternMatcher = new SplittingPatternMatcher();

            var pairs = new[]
            {
                // TODO: optimize performance
                //new
                //{
                //    Input = "abbabaaabbabbaababbabbbbbabbbabbbabaaaaababababbbabababaabbababaabbbbbbaaaabababbbaabbbbaabbbbababababbaabbaababaabbbababababbbbaaabbbbbabaaaabbababbbbaababaabbababbbbbababbbabaaaaaaaabbbbbaabaaababaaaabb",
                //    Pattern = "**aa*****ba*a*bb**aa*ab****a*aaaaaa***a*aaaa**bbabb*b*b**aaaaaaaaa*a********ba*bbb***a*ba*bb*bb**a*b*bb"
                //},
                new { Input = "abb", Pattern = "**??" },
                new { Input = "aaaa", Pattern = "***a" },
                new { Input = "", Pattern = "" },
                new { Input = "", Pattern = "*" },
                new { Input = "abcdefgh", Pattern = "ab?d*g?" },
                new { Input = "abcdefgh", Pattern = "a**g?" },
                new { Input = "abcdefgh", Pattern = "a*bcdefgh" },
                new { Input = "abcdefgh", Pattern = "abcdefg*h" },
                new { Input = "abcdefgh", Pattern = "*abcdefgh*" },
                new { Input = "abcdefgh", Pattern = "*a*" },
                new { Input = "abcdefgh", Pattern = "*d*" },
                new { Input = "abcdefgh", Pattern = "*h*" },
                new { Input = "abcdefgh", Pattern = "*????????*" },
                new { Input = "abcdefgh", Pattern = "?bcdefg?" },
                new { Input = "abcdefgh", Pattern = "abcd?fgh" },
                new { Input = "abcdefgh", Pattern = "a*h" },
                new { Input = "abcdefgh", Pattern = "a***h" },
                new { Input = "abcdefgh", Pattern = "a**************h" },
                new { Input = "abcdefgh", Pattern = "ab***gh" },
                new { Input = "abcdefgh", Pattern = "*ab***gh*" },
                new { Input = "abcdefgh", Pattern = "*a*b*c*d*e*f*g*h*" },
                new { Input = "abcdefgh", Pattern = "**a***b**c**d***e**f**g**h**" },
                new { Input = "?bcdefgh", Pattern = "?bcdefgh" },
                new { Input = "abcdefg?", Pattern = "abcdefg?" },
                new { Input = "abc?efg?", Pattern = "?bc?efg?" },
                new { Input = "?bc?efg?", Pattern = "*bc?efg*" },
                new { Input = "*", Pattern = "*" },
                new { Input = "*", Pattern = "***" },
                new { Input = "*", Pattern = "?" },
                new { Input = "?", Pattern = "?" },
                new { Input = "?*?", Pattern = "*" },
                new { Input = "?*?", Pattern = "*****" },
                new { Input = "??", Pattern = "*" },
                new { Input = "abc**efgh", Pattern = "abc??efgh" },
            };

            foreach (var pair in pairs)
            {
                //Act:
                var isMatch = patternMatcher.IsMatch(pair.Input, pair.Pattern);

                //Assert:
                Assert.IsTrue(isMatch, $"{nameof(pair.Input)} : '{pair.Input}' {nameof(pair.Pattern)} : '{pair.Pattern}'");
            }
        }
        [TestMethod]
        public void IsMatchFalseTest()
        {
            //Arrange:
            IPatternMatcher patternMatcher = new SplittingPatternMatcher();

            var pairs = new[]
            {
                new { Input = "*", Pattern = "" },
                new { Input = "?", Pattern = "" },
                new { Input = "", Pattern = "?" },
                new { Input = "", Pattern = "???" },
                new { Input = "??", Pattern = "???" },
                new { Input = "???", Pattern = "??" },
                new { Input = "abcdefgh", Pattern = "abcdefhg" },
                new { Input = "abcdefgh", Pattern = "??????hg" },
                new { Input = "abcdefgh", Pattern = "???????gh" },
                new { Input = "abcdefgh", Pattern = "????????hg" },
                new { Input = "abcdefgh", Pattern = "ab?d*g?h" },
                new { Input = "abcdefgh", Pattern = "*g" },
                new { Input = "abcdefgh", Pattern = "*f" },
                new { Input = "abcdefgh", Pattern = "a**g" },
                new { Input = "abcdefgh", Pattern = "*a*g" },
                new { Input = "abcdefgh", Pattern = "b*" },
                new { Input = "abcdefgh", Pattern = "b*g*" },
            };

            foreach (var pair in pairs)
            {
                //Act:
                var isMatch = patternMatcher.IsMatch(pair.Input, pair.Pattern);

                //Assert:
                Assert.IsFalse(isMatch, $"{nameof(pair.Input)} : '{pair.Input}' {nameof(pair.Pattern)} : '{pair.Pattern}'");
            }
        }
    }
}
