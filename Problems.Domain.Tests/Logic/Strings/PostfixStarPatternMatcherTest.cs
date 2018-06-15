using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Strings.PostfixStarPatternMatcher;
using Problems.Domain.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Strings
{
    [TestClass]
    public class PostfixStarPatternMatcherTest
    {
        [TestMethod]
        public void PostfixStarPatternMatcher_IsMatch_Test()
        {
            //Arrange:
            IPostfixStarPatternMatcher patternMatcher = new PostfixStarPatternMatcher();

            var largeAxbc = GenericUtil.CreateString(('a', 100), ('x', 2), ('b', 200), ('c', 300));
            var inputObjects = new[]
            {
                new { Input = "", Pattern = "", Output = true },
                new { Input = "aa", Pattern = "aa", Output = true },
                new { Input = "", Pattern = "a*", Output = true },
                new { Input = "bb", Pattern = "bb", Output = true },
                new { Input = "bb", Pattern = "bb", Output = true },
                new { Input = "aba", Pattern = "a.a", Output = true },
                new { Input = "abbb", Pattern = "ab*", Output = true },
                new { Input = "acd", Pattern = "ab*c.", Output = true },
                new { Input = "abaa", Pattern = "a.*a*", Output = true },
                new { Input = "aa", Pattern = "a*", Output = true },
                new { Input = "aa", Pattern = "a*a", Output = true },
                new { Input = "ab", Pattern = ".*", Output = true },
                new { Input = "aab", Pattern = "c*a*b", Output = true },
                new { Input = "aaaaaabbbbbbzzzbbbacccccc", Pattern = "a*b*.*.cccc*", Output = true },
                new { Input = "aaaabbbbzzbbbacccccc", Pattern = ".*", Output = true },
                new { Input = largeAxbc, Pattern = ".*", Output = true },
                new { Input = largeAxbc, Pattern = "..*..", Output = true },
                new { Input = largeAxbc, Pattern = "a.*c", Output = true },
                new { Input = largeAxbc, Pattern = "a*..b*c*", Output = true },

                new { Input = "aa", Pattern = "a", Output = false },
                new { Input = "abbdbb", Pattern = "ab*d", Output = false },
                new { Input = "mississippi", Pattern = "mis*is*p*.", Output = false },
                new { Input = "a", Pattern = ".*..a*", Output = false },
                new { Input = "aaaabbbbzzbbbacccccc", Pattern = "a*b*.*.cccc*y", Output = false },
                new { Input = "aaaabbbbzzbbbacccccc", Pattern = "a*b*.*.ccfcc*", Output = false },
                new { Input = "aaaabbbbzzbbbacccccc", Pattern = "z.*", Output = false },
                new { Input = largeAxbc, Pattern = "a*.b*c*", Output = false },
                new { Input = largeAxbc, Pattern = "a*b*c*", Output = false },
                new { Input = largeAxbc, Pattern = ".*x", Output = false },
            };

            foreach (var inputObject in inputObjects)
            {
                //Act:
                var output = patternMatcher.IsMatch(inputObject.Input, inputObject.Pattern);

                //Assert:
                Assert.AreEqual(inputObject.Output, output,
                    $@"{nameof(inputObject.Input)} : '{inputObject.Input
                    }' {nameof(inputObject.Pattern)} : '{inputObject.Pattern}'");
            }
        }
    }
}
