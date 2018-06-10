using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Trees.BstSuccessorSearcher
{
    public class Node
    {
        public int key;
        public Node left;
        public Node right;
        public Node parent;

        public Node(int key)
        {
            this.key = key;
            left = null;
            right = null;
            parent = null;
        }
    }
    
    public class BstSuccessorSearcher : IBstSuccessorSearcher
    {
        private Node _root;

        public Node FindInOrderSuccessor(Node inputNode)
        {
            if (inputNode == null)
            {
                return null;
            }

            int init = inputNode.key;
            Node res = null;

            if (inputNode.parent != null)
            {
                if (inputNode.parent.key > init)
                {
                    res = inputNode.parent;
                }

                TraverseUp(inputNode, init, ref res);
            }

            if (inputNode.right != null)
            {
                if (res == null)
                {
                    res = inputNode.right;
                }

                TraverseDown(inputNode.right, init, ref res);
            }

            return res;
        }

        private static void TraverseUp(Node currentNode, int init, ref Node res)
        {
            var next = currentNode.parent;
            if (next == null)
                return;

            // TODO: consider returning if it's impossible to find a solution
            // higher (e.g. when the parent is more right than the current node)

            if (init < next.key && (res == null || next.key < res.key))
            {
                res = next;
            }

            if (next.parent == null || next.parent.key > next.key)
                return;

            TraverseUp(next.parent, init, ref res);
        }

        private static void TraverseDown(Node currentNode, int init, ref Node res)
        {
            var next = currentNode.left;
            if (next == null)
                return;

            if (init < next.key && next.key < res.key)
            {
                res = next;
            }

            if (next.left == null)
                return;

            TraverseDown(next.left, init, ref res);
        }

        #region Auxiliary

        public void Clear() => _root = null;

        public void Insert(IEnumerable<int> keys)
        {
            foreach (var key in keys)
                Insert(key);
        }

        #endregion

        #region Given code

        //  Given a binary search tree and a number, inserts a new node
        //  with the given number in the correct place in the tree
        public void Insert(int key)
        {
            // 1. If the tree is empty, create the root
            if (_root == null)
            {
                _root = new Node(key);
                return;
            }

            // 2) Otherwise, create a node with the key
            //    and traverse down the tree to find where to
            //    to insert the new node
            Node currentNode = _root;
            Node newNode = new Node(key);

            while (currentNode != null)
            {
                if (key < currentNode.key)
                {
                    if (currentNode.left == null)
                    {
                        currentNode.left = newNode;
                        newNode.parent = currentNode;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.left;
                    }
                }
                else
                {
                    if (currentNode.right == null)
                    {
                        currentNode.right = newNode;
                        newNode.parent = currentNode;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.right;
                    }
                }
            }
        }

        // Return a reference to a node in the BST by its key.
        // Use this method when you need a node to test your 
        // FindInOrderSuccessor method on
        public Node GetNodeByKey(int key)
        {
            Node currentNode = _root;

            while (currentNode != null)
            {
                if (key == currentNode.key)
                {
                    return currentNode;
                }

                if (key < currentNode.key)
                {
                    currentNode = currentNode.left;
                }
                else
                {
                    currentNode = currentNode.right;
                }
            }

            return null;
        }

        #endregion
    }
}