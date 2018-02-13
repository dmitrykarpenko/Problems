﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Matrices.MaximalRectangleFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Matrices
{
    [TestClass]
    public class MaximalRectangleFinderTest
    {
        [TestMethod]
        public void MaximalRectangleTest()
        {
            // Arrange:
            IMaximalRectangleFinder maximalRectangleFinder = new SimpleMaximalRectangleFinder();

            var inputObjects = new[]
            {
                new
                {
                    Input = new [,]
                    {
                        { '1', '0', '1', '0', '0' },
                        { '1', '0', '1', '1', '1' },
                        { '1', '1', '1', '1', '1' },
                        { '1', '0', '0', '1', '0' },
                    },
                    Output = 6,
                },
            };

            foreach (var inputObject in inputObjects)
            {
                //// Act:
                //var output = maximalRectangleFinder.MaximalRectangle(inputObject.Input);

                //// Assert:
                //Assert.AreEqual(inputObject.Output, output);
            }
        }
    }
}