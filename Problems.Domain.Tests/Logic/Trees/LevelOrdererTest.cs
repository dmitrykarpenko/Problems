using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Collections.LevelOrderer;
using Problems.Domain.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Trees
{
    [TestClass]
    public class LevelOrdererTest
    {
        [TestMethod]
        public void LevelOrderer_LevelOrder_Test()
        {
            // Arrange:
            ILevelOrderer levelOrderer = new LevelOrdererWithNodeLevelsDictionary();

            var inputObjects = new[]
            {
                new
                {
                    Root = new TreeNode
                    {
                        val = 2,
                        left = new TreeNode { val = 1 },
                        right = new TreeNode { val = 3 },
                    },
                    Output = (IList<IList<int>>)new List<IList<int>>
                    {
                        new List<int> { 2 },
                        new List<int> { 1, 3 },
                    },
                },
                new
                {
                    Root = new TreeNode
                    {
                        val = 1,
                        left = new TreeNode { val = 2 },
                        right = new TreeNode { val = 3 },
                    },
                    Output = (IList<IList<int>>)new List<IList<int>>
                    {
                        new List<int> { 1 },
                        new List<int> { 2, 3 },
                    },
                },
                new
                {
                    Root = new TreeNode
                    {
                        val = 10,
                        left = new TreeNode { val = 5 },
                        right = new TreeNode
                        {
                            val = 15,
                            left = new TreeNode { val = 6 },
                            right = new TreeNode { val = 20 },
                        },
                    },
                    Output = (IList<IList<int>>)new List<IList<int>>
                    {
                        new List<int> { 10 },
                        new List<int> { 5, 15 },
                        new List<int> { 6, 20 },
                    },
                },
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var output = levelOrderer.LevelOrder(inputObject.Root);

                // Assert:
                var pairs = inputObject.Output.Zip(output,
                    (e, a) => new { Expected = e, Actual = a });
                foreach (var pair in pairs)
                {
                    AssertUtil.AssertCollection(pair.Expected, pair.Actual);
                }
            }
        }
    }
}
