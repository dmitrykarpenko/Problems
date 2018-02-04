using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNode = Problems.Domain.Logic.Trees.BstValidator.BstValidatorTreeNode;

namespace Problems.Domain.Logic.Trees.BstValidator
{
    /// <summary>
    /// Given a binary tree, determine if it is a valid binary search tree (BST).
    /// 
    /// Assume a BST is defined as follows:
    /// 
    /// The left subtree of a node contains only nodes with keys less than the node's key.
    /// The right subtree of a node contains only nodes with keys greater than the node's key.
    /// Both the left and right subtrees must also be binary search trees.
    /// 
    /// Example 1:
    ///    2
    ///   / \
    ///  1   3
    /// Binary tree [2,1,3], return true.
    /// 
    /// Example 2:
    ///    1
    ///   / \
    ///  2   3
    /// Binary tree [1,2,3], return false.
    /// </summary>
    public interface IBstValidator
    {
        bool IsValidBST(TreeNode root);
    }
}
