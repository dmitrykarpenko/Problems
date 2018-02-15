using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.NaturalNumbers.NextPermutationSequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.NaturalNumbers
{
    [TestClass]
    public class NextPermutationSequencerTest
    {
        [TestMethod]
        public void NextPermutationTest()
        {
            // Arrange:
            INextPermutationSequencer nextPermutationSequencer = new SequentialNextPermutationSequencer();

            var inputObjects = new[]
            {
                new { Input = new[] { 1 }, Output = new[] { 1 } },
                new { Input = new[] { 1, 2 }, Output = new[] { 2, 1 } },
                new { Input = new[] { 2, 1 }, Output = new[] { 1, 2 } },
                new { Input = new[] { 4, 3, 2, 1 }, Output = new[] { 1, 2, 3, 4 } },
                new { Input = new[] { 1, 2, 3, 4 }, Output = new[] { 1, 2, 4, 3 } },
                new { Input = new[] { 4, 2, 3, 1 }, Output = new[] { 4, 3, 1, 2 } },
                new { Input = new[] { 5, 4, 2, 3, 1 }, Output = new[] { 5, 4, 3, 1, 2 } },
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                nextPermutationSequencer.NextPermutation(inputObject.Input);

                for (int i = 0; i < inputObject.Input.Length; i++)
                {
                    // Assert:
                    Assert.AreEqual(inputObject.Output[i], inputObject.Input[i]);
                }
            }
        }
 
    }
}
