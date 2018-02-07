using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Utils
{
    [TestClass]
    public class GenericUtilTest
    {
        [TestMethod]
        public void IsEqualTest()
        {
            // Arrange:
            var inputObjects = new[]
            {
                new
                {
                    Input = new
                    {
                        First = new int[0],
                        Second = new int[0],
                    },
                    Output = true,
                },
                new
                {
                    Input = new
                    {
                        First = new[] { 1 },
                        Second = new[] { 1 },
                    },
                    Output = true,
                },
                new
                {
                    Input = new
                    {
                        First = new[] { 0, 0, 1 },
                        Second = new[] { 0, 0, 1 },
                    },
                    Output = true,
                },
                new
                {
                    Input = new
                    {
                        First = new[] { 0, 0, -1 },
                        Second = new[] { 0, 0, 1 },
                    },
                    Output = false,
                },
                new
                {
                    Input = new
                    {
                        First = new[] { 0, 0, 1 },
                        Second = new[] { 0, 0, 0 },
                    },
                    Output = false,
                },
                new
                {
                    Input = new
                    {
                        First = new[] { 0, 0, 1, 0 },
                        Second = new[] { 0, 0, 1 },
                    },
                    Output = false,
                },
                new
                {
                    Input = new
                    {
                        First = new[] { 0, 0, 1 },
                        Second = new[] { 0, 0, 1, 0 },
                    },
                    Output = false,
                },
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var output = Domain.Utils.GenericUtil.IsEqual(inputObject.Input.First, inputObject.Input.Second);

                // Assert:
                Assert.AreEqual(inputObject.Output, output);
            }
        }
    }
}
