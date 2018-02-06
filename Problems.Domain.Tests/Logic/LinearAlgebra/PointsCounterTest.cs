using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.LinearAlgebra.PointsCounter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.LinearAlgebra
{
    [TestClass]
    public class PointsCounterTest
    {
        [TestMethod]
        public void MaxPointsTest()
        {
            // Arrange:
            IPointsCounter pointsCounter = new SimplePointsCounter();

            var inputObjects = new[]
            {
                new
                {
                    Input = new[]
                    {
                        new Point2D { x = 0, y = 0 },
                    },
                    Output = 1,
                },
                //new
                //{
                //    Input = new[]
                //    {
                //        new Point2D { x  = 1, y = 2 },
                //        new Point2D { x  = 2, y = 4 },
                //        new Point2D { x  = 4, y = 8 },
                //        new Point2D { x  = 5, y = 9 },
                //        new Point2D { x  = 0, y = -1 },
                //        new Point2D { x  = 10, y = 0 },
                //        new Point2D { x  = 0, y = 0 },
                //    },
                //    Output = 4,
                //},
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var output = pointsCounter.MaxPoints(inputObject.Input);

                // Assert:
                Assert.AreEqual(inputObject.Output, output);
            }
        }
    }
}
