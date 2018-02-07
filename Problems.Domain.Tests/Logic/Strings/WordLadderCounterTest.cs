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
        public void MaxPointsTest()
        {
            // Arrange:
            IWordLadderCounter wordLadderCounter = new SimpleWordLadderCounter();

            var inputObjects = new[]
            {
                new
                {
                    Input = new
                    {
                        Initial = "hit",
                        Final = "cog",
                        Words = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" },
                    },
                    Output = 1,
                },
            };

            foreach (var inputObject in inputObjects)
            {
                //// Act:
                //var output = wordLadderCounter.LadderLength(inputObject.Input.Initial, inputObject.Input.Final, inputObject.Input.Words);

                //// Assert:
                //Assert.AreEqual(inputObject.Output, output);
            }
        }
    }
}
