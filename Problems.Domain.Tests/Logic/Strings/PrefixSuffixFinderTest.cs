using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Strings.PrefixSuffixFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Strings
{
    [TestClass]
    public class PrefixSuffixFinderTest
    {
        [TestMethod]
        public void WordFilterFTest()
        {
            // Arrange:
            var inputObjects = new[]
            {
                new
                {
                    Words = new[] { "cabbage", "apple" },
                    Searches = new[]
                    {
                        new
                        {
                            Prefix = "a",
                            Suffix = "e",
                            Output = 1,
                        },
                        new
                        {
                            Prefix = "ca",
                            Suffix = "e",
                            Output = 0,
                        },
                    },
                },
            };

            foreach (var inputObject in inputObjects)
            {
                IPrefixSuffixFinder prefixSuffixFinder = new WordFilter(inputObject.Words);

                foreach (var search in inputObject.Searches)
                {
                    // Act:
                    var output = prefixSuffixFinder.F(search.Prefix, search.Suffix);

                    // Assert:
                    Assert.AreEqual(search.Output, output);
                }
            }
        }
    }
}
