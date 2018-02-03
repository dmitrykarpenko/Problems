using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Strings.PalindromeCombiner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Strings
{
    [TestClass]
    public class PalindromeCombinerTest
    {
        [TestMethod]
        public void PalindromePairsTest()
        {
            //Arrange:
            IPalindromeCombiner palindromeCombiner = new MatchingPalindromeCombiner();

            var inputObjects = new[]
            {
                new
                {
                    Words = new[] { "bat", "tab", "cat" },
                    Output = new List<List<int>>
                    {
                        new List<int> { 0, 1 },
                        new List<int> { 1, 0 },
                    }
                },
                new
                {
                    Words = new[] { "abcd", "dcba", "lls", "s", "sssll" },
                    Output = new List<List<int>>
                    {
                        new List<int> { 0, 1 },
                        new List<int> { 1, 0 },
                        new List<int> { 3, 2 },
                        new List<int> { 2, 4 },
                    }
                },
            };

            foreach (var inputObject in inputObjects)
            {
                //Act:
                var output = palindromeCombiner.PalindromePairs(inputObject.Words);

                //Assert:
                AssertListEquality(inputObject.Output, output);
            }
        }

        private static void AssertListEquality(List<List<int>> properLists, IList<IList<int>> lists)
        {
            Assert.AreEqual(properLists.Count, lists.Count);
            foreach (var pair in lists)
            {
                var properPair = properLists
                    .Single(pl => pl.First() == pair.First() && pl.Last() == pair.Last());
                AssertPairEquality(properPair, pair);
            }
        }

        private static void AssertPairEquality(List<int> properPair, IList<int> pair)
        {
            Assert.AreEqual(2, properPair.Count);
            Assert.AreEqual(2, pair.Count);
            for (int j = 0; j < pair.Count; ++j)
            {
                Assert.AreEqual(properPair[j], pair[j]);
            }
        }
    }
}
