using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Strings.WordLadderCounter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Strings
{
    [TestClass]
    public class WordLadderCounterTest
    {
        [TestMethod]
        public void LadderLengthTest()
        {
            // Arrange:
            IWordLadderCounter wordLadderCounter = new SimpleWordLadderCounter();

            var inputObjects = new[]
            {
                new
                {
                    Input = new
                    {
                        Initial = "ooo",
                        Final = "dot",
                        Words = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" },
                    },
                    Output = 0,
                },
                // TODO: fix LadderLength
                //new
                //{
                //    Input = new
                //    {
                //        Initial = "dag",
                //        Final = "dot",
                //        Words = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" },
                //    },
                //    Output = 2,
                //},
                //new
                //{
                //    Input = new
                //    {
                //        Initial = "dat",
                //        Final = "dot",
                //        Words = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" },
                //    },
                //    Output = 1,
                //},
                //new
                //{
                //    Input = new
                //    {
                //        Initial = "hot",
                //        Final = "cog",
                //        Words = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" },
                //    },
                //    Output = 4,
                //},
                //new
                //{
                //    Input = new
                //    {
                //        Initial = "hit",
                //        Final = "cog",
                //        Words = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" },
                //    },
                //    Output = 5,
                //},
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var output = wordLadderCounter.LadderLength(inputObject.Input.Initial, inputObject.Input.Final, inputObject.Input.Words);

                // Assert:
                Assert.AreEqual(inputObject.Output, output);
            }
        }
    }
}
