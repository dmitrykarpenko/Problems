using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Trees.BinaryTreeInvertor
{
    public interface IBinaryTreeInverter
    {
        /// <summary>
        /// https://leetcode.com/problems/invert-binary-tree/description/
        /// 226. Invert Binary Tree
        /// 
        /// Invert a binary tree.
        /// 
        /// Example:
        /// 
        /// Input:
        /// 
        ///      4
        ///    /   \
        ///   2     7
        ///  / \   / \
        /// 1   3 6   9
        /// 
        /// Output:
        /// 
        ///      4
        ///    /   \
        ///   7     2
        ///  / \   / \
        /// 9   6 3   1
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        TreeNode InvertTree(TreeNode root);
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
