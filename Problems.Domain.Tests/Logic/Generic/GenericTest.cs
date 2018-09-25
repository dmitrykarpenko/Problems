using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Generic
{
    [TestClass]
    public class GenericTest
    {
        [TestMethod]
        public void GfgBinarySearcher_GetIndex_Test()
        {
            // Arrange:
            IBinarySearcher binarySearcher = new GfgBinarySearcher();

            var inputObjects = new[]
            {
                new { Input = new[] { 0, 1, 3, 4, 9, 10 }, X = 3, Output = 2 },
                new { Input = new[] { 0, 1, 3, 4, 9, 10 }, X = 10, Output = 5 },
                new { Input = new[] { -2, 1, 3, 4, 9, 10 }, X = -2, Output = 0 },

                new { Input = new[] { -2, 1, 3, 4, 9, 10 }, X = 0, Output = -1 },
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var output = binarySearcher.GetIndex(inputObject.Input, inputObject.X);

                // Assert:
                Assert.AreEqual(inputObject.Output, output);
            }
        }
    }
}
