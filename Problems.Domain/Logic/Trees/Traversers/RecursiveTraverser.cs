using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Trees.Traversers
{
    public class RecursiveTraverser : IInorderTraverser
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            _value = new List<int>();
            InorderTraverse(root);
            return _value;
        }

        private IList<int> _value;

        private void DoWithValue(int value) => _value.Add(value);

        private void InorderTraverse(TreeNode node)
        {
            if (node == null)
                return;
            
            InorderTraverse(node.left);

            DoWithValue(node.val);
            
            InorderTraverse(node.right);
        }
    }
}
