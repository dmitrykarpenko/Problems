using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Trees.Base
{
    public interface IBinaryTree<T>
    {
        IBinaryTreeNode<T> Root { get; }
        void Clear();

        void Insert(IEnumerable<T> values);
        void Insert(T value);

        IBinaryTreeNode<T> GetNode(T value);
    }
}
