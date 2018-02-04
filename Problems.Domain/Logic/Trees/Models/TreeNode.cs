using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Trees.Models
{
    public class BinaryTreeNode<T>
    {
        //public TreeNode(T x)
        //{
        //    Value = x;
        //}

        public T Value { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
    }
}
