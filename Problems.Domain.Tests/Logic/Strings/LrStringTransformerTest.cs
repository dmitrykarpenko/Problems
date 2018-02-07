using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Strings.LrStringTransformer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Strings
{
    [TestClass]
    public class LrStringTransformerTest
    {
        [TestMethod]
        public void CanTransformTest()
        {
            // Arrange:
            ILrStringTransformer lrStringTransformer = new SequentialLrStringTransformer();

            var inputObjects = new[]
            {
                new
                {
                    Initial = "RXXLRXRXL",
                    Final = "XRLXXRRLX",
                    Output = true,
                },
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var output = lrStringTransformer.CanTransform(inputObject.Initial, inputObject.Final);

                // Assert:
                Assert.AreEqual(inputObject.Output, output);
            }
        }
    }
}
