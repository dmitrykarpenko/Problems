using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Strings.PostfixStarPatternMatcher;
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
                new { Input = "ab", Pattern = ".*", Output = true },
                new { Input = "aab", Pattern = "c*a*b", Output = true },

                new { Input = "aa", Pattern = "a", Output = false },
                new { Input = "abbdbb", Pattern = "ab*d", Output = false },
                new { Input = "mississippi", Pattern = "mis*is*p*.", Output = false },
                new { Input = "a", Pattern = ".*..a*", Output = false },
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
