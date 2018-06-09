using System.Collections.Generic;

namespace Problems.Domain.Logic.Trees.BstSuccessorSearcher
{
    /// <summary>
    /// BST Successor Search.
    /// 
    /// In a Binary Search Tree (BST), an Inorder Successor of a node
    /// is defined as the node with the smallest key greater than
    /// the key of the input node (see examples below).
    /// 
    /// Would originally be callde IBinarySearchTree.
    /// </summary>
    public interface IBstSuccessorSearcher
    {
        /// <summary>
        /// Given a node inputNode in a BST, you’re asked
        /// to write a function FindInOrderSuccessor
        /// that returns the Inorder Successor of inputNode.
        /// 
        /// If inputNode has no Inorder Successor, return null.
        /// 
        /// Explain your solution and analyze its time and space complexities.
        /// 
        /// Example:
        /// 
        /// In the diagram above, for inputNode whose key = 11
        /// 
        /// Your function would return:
        /// 
        /// The Inorder Successor node whose key = 12
        /// 
        /// Constraints:
        /// 
        /// [time limit] 5000ms
        /// [input] Node inputNode
        /// [output] Node
        /// </summary>
        /// <param name="inputNode"></param>
        /// <returns></returns>
        Node FindInOrderSuccessor(Node inputNode);

        #region Auxiliary

        void Clear();

        void Insert(IEnumerable<int> keys);

        #endregion

        #region Given code

        Node GetNodeByKey(int key);
        void Insert(int key);

        #endregion
    }
}