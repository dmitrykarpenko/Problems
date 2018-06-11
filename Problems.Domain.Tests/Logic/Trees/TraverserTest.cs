using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Trees.Base;
using Problems.Domain.Logic.Trees.Traversers;
using Problems.Domain.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Trees
{
    [TestClass]
    public class TraversersTest
    {
        [TestMethod]
        public void RecursiveTraverser_InorderTraversal_Test()
        {
            // Arrange:
            IInorderTraverser inorderTraverser = new RecursiveTraverser();

            var root = new TreeNode(20);
            root.left = new TreeNode(9);
            root.right = new TreeNode(25);
            root.left.left = new TreeNode(5);
            root.left.right = new TreeNode(12);
            root.left.right.left = new TreeNode(11);
            root.left.right.right = new TreeNode(14);

            var values = inorderTraverser.InorderTraversal(root);

            AssertUtil.AssertCollection(new[] { 5, 9, 11, 12, 14, 20, 25 }, values);
        }
    }
}
