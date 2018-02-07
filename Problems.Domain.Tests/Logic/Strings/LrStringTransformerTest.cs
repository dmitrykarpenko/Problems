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
                    Initial = "XLLR",
                    Final = "LXLX",
                    Output = false,
                },
                new
                {
                    Initial = "RXXLRXRXL",
                    Final = "XRLXXRRLX",
                    Output = true,
                },
                new
                {
                    Initial = "RXXXXXXXXXXXRLXLXLRLRRXLXRLXRLRLLRXLXRLXRLXRLRLXXLLRLXLXLRLRLRXLRXLXRLRLRXLXRLXLXLRLLLLRXLLLXRLXRLRXLRLRLLRXLXRXRLRLRLRLRXXXXLXRXLRLXLXLXRLXLRXLRXLXRLLRXXLRLXRLRLRXXXXXXLRXRXLX",
                    Final = "RXXXXXXXXXXXRLXLXLRLRRXLXRLXRLRLLRXLXRLXRLXRLRLXXLLRLXLXLRLRLRXLRXLXRLRLRXLXRLXLXLRLLLLRXLLLXRLXRLRXLRLRLLRXLXRXRLRLRLRLRXXXXLXRXLRLXLXLXRLXLRXLRXLXRLLRXXLRLXRLRLRXXXXXXLRXRXLX",
                    Output = true,
                },
                new
                {
                    Initial = "RRXXXXXXXXXXXLXLXLRLRRXLXRLXRLRLLRXLXRLXRLXRLRLXXLLRLXLXLRLRLRXLRXLXRLRLRXLXRLXLXLRLLLLRXLLLXRLXRLRXLRLRLLRXLXRXRLRLRLRLRXXXXLXRXLRLXLXLXRLXLRXLRXLXRLLRXXLRLXRLRLRXXXXXXLRXRXLX",
                    Final = "RXXXXRXXXXXXXLXLXLRLRRXLXRLXRLRLLRXLXRLXRLXRLRLXXLLRLXLXLRLRLRXLRXLXRLRLRXLXRLXLXLRLLLLRXLLLXRLXRLRXLRLRLLRXXLRXRLRLRLRLRXXXXLXRXLRLXLXLXRLXLRXLRXLXRLLRXXLRLXRLRLRXXXXXXLXRRXLX",
                    Output = false,
                },
                new { Initial = "RXXLRXRXLX", Final = "XRLXXRRLX", Output = false, },
                new { Initial = "XXXXRXL", Final = "XXXRXLX", Output = false, },
                new { Initial = "X", Final = "", Output = false, },
                new { Initial = "", Final = "", Output = true, },
                new { Initial = "XXXXR", Final = "XXXRX", Output = false, },
                new { Initial = "XXXXL", Final = "XXXLX", Output = true, },
                new { Initial = "XXXXR", Final = "XXXXL", Output = false, },
                new { Initial = "L", Final = "L", Output = true, },
                new { Initial = "R", Final = "R", Output = true, },
                new { Initial = "X", Final = "X", Output = true, },
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
