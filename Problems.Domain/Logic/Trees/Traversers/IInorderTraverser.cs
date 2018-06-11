using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Trees.Traversers
{
    public interface IInorderTraverser
    {
        /// <summary>
        /// Given a binary tree, return the inorder traversal of its nodes' values.
        /// 
        /// Example:
        /// 
        /// Input: [1,null,2,3]
        /// 1
        ///  \
        ///   2
        ///  /
        /// 3
        /// 
        /// Output: [1,3,2]
        /// 
        /// Follow up: Recursive solution is trivial, could you do it iteratively?
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        IList<int> InorderTraversal(TreeNode root);
    }
}
