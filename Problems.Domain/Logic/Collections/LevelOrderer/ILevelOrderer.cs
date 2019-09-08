using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Collections.LevelOrderer
{
    public interface ILevelOrderer
    {
        /// <summary>
        /// https://leetcode.com/problems/binary-tree-level-order-traversal/
        /// 102. Binary Tree Level Order Traversal
        /// Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).
        /// For example:
        /// Given binary tree[3, 9, 20, null, null, 15, 7],
        ///     3
        ///    / \
        ///   9  20
        ///     /  \
        ///    15   7
        /// return its level order traversal as:
        /// [
        ///   [3],
        ///   [9,20],
        ///   [15,7]
        /// ]
        /// </summary>
        IList<IList<int>> LevelOrder(TreeNode root);
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }

        // Custom:
        public TreeNode() { }
    }
}
