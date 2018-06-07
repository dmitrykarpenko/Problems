using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Trees.BinaryTreeInvertor
{
    public class RecursiveBinaryTreeInverter : IBinaryTreeInverter
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;

            SwapChildren(root);

            InvertTree(root.left);
            InvertTree(root.right);

            return root;
        }

        private static void SwapChildren(TreeNode node)
        {
            TreeNode temp = node.left;
            node.left = node.right;
            node.right = temp;
        }
    }
}
