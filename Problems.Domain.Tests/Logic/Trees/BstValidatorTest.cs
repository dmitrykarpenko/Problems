using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Trees.BstValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Trees
{
    [TestClass]
    public class BstValidatorTest
    {
        [TestMethod]
        public void IsValidBSTTest()
        {
            // Arrange:
            IBstValidator bstValidator = new RecursiveBstValidator();

            var inputObjects = new[]
            {
                new
                {
                    Root = new BstValidatorTreeNode
                    {
                        val = 2,
                        left = new BstValidatorTreeNode { val = 1 },
                        right = new BstValidatorTreeNode { val = 3 },
                    },
                    IsValid = true,
                },
                new
                {
                    Root = new BstValidatorTreeNode(1)
                    {
                        val = 1,
                        left = new BstValidatorTreeNode { val = 2 },
                        right = new BstValidatorTreeNode { val = 3 },
                    },
                    IsValid = false,
                },
                new
                {
                    Root = new BstValidatorTreeNode(1)
                    {
                        val = 10,
                        left = new BstValidatorTreeNode { val = 5 },
                        right = new BstValidatorTreeNode
                        {
                            val = 15,
                            left = new BstValidatorTreeNode { val = 6 },
                            right = new BstValidatorTreeNode { val = 20 },
                        },
                    },
                    IsValid = false,
                },
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var isValid = bstValidator.IsValidBST(inputObject.Root);

                // Assert:
                Assert.AreEqual(inputObject.IsValid, isValid);
            }
        }
    }
}
