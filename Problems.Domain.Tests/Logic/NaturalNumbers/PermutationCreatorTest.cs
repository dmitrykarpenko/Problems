﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.NaturalNumbers.PermutationCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.NaturalNumbers
{
    [TestClass]
    public class PermutationCreatorTest
    {
        [TestMethod]
        public void GetPermutationTest()
        {
            // Arrange:
            IPermutationCreator permutationCreator = new FactorizingPermutationCreator();

            var inputObjects = new[]
            {
                new { N = 1, K = 01, Output = "1" },
                new { N = 3, K = 01, Output = "123" },
                new { N = 4, K = 01, Output = "1234" },
                new { N = 4, K = 20, Output = "4132" },
                new { N = 4, K = 21, Output = "4213" },
                new { N = 4, K = 24, Output = "4321" },
                new { N = 5, K = 01, Output = "12345" },
                new { N = 9, K = 321123, Output = "896123547" },
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var output = permutationCreator.GetPermutation(inputObject.N, inputObject.K);

                // Assert:
                Assert.AreEqual(inputObject.Output, output);
            }
        }
    }
}
