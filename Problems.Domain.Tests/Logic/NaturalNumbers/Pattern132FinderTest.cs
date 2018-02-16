using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.NaturalNumbers.Pattern132Finder;
using GU = Problems.Domain.Tests.Utils.GenericUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.NaturalNumbers
{
    [TestClass]
    public class Pattern132FinderTest
    {
        [TestMethod]
        public void Find132patternTest()
        {
            // Arrange:
            IPattern132Finder pattern132Finder = new SequentialPattern132Finder();

            var inputObjects = new[]
            {
                // TODO: fix
                //new { Input = new[] { 4, 6, -3, -1, 0 }, Output = false },
                new { Input = new[] { 3, 5, 0, 3, 4 }, Output = true },
                new { Input = new[] { 3, 1, 4, 2 }, Output = true },
                new { Input = new[] { 10, 1, -2, 5, 6, -1 }, Output = true },
                new { Input = new[] { -3, 1, 12, 14, 16, -1 }, Output = true },
                new { Input = new[] { 1, 4, 0, 2 }, Output = true },
                new { Input = new[] { 1, 4, -3, 2, -2 }, Output = true },
                new { Input = new[] { 1, 4, -3, 2, 3 }, Output = true },
                new { Input = new[] { 0, 1, 0, 1, 2, 1 }, Output = true },
                new { Input = new[] { 3, 1, -1, -5, -7 }, Output = false },
                new { Input = new[] { 1, 4, 0 }, Output = false },
                new { Input = new[] { 1, 4, 1 }, Output = false },
                new { Input = new[] { 1, 4, 5 }, Output = false },
                new { Input = new[] { 1, 4, 4 }, Output = false },
                new { Input = new[] { 1, 4, -3, 5, 6 }, Output = false },
                new { Input = new[] { 0, 0, 0, 0, 0 }, Output = false },
                new { Input = new[] { 0, 1, 0, 1, 2 }, Output = false },
                new { Input = GU.CreateArray((0, 1000), (1, 1000)), Output = false },
                new { Input = GU.CreateArrayFromEnumerables((new[] { 0, 1 }, 500), (new[] { 2, 3 }, 400)), Output = true },
                new { Input = GU.CreateArrayFromEnumerables((new[] { 0, 1 }, 500), (new[] { 2 }, 400)), Output = false },
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var output = pattern132Finder.Find132pattern(inputObject.Input);

                // Assert:
                Assert.AreEqual(inputObject.Output, output, $"[{inputObject.Input.Length}] {{ {inputObject.Input.First()} , ... }}");
            }
        }
    }
}
