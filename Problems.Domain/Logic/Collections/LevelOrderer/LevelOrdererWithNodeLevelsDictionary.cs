using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Collections.LevelOrderer
{
    public class LevelOrdererWithNodeLevelsDictionary : ILevelOrderer
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            if (root == null)
            {
                return new List<IList<int>>();
            }

            var nodes = new Queue<TreeNode>();
            nodes.Enqueue(root);

            var nodeLevels = new Dictionary<TreeNode, int> { { root, 0 } };

            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();
                var nodeLevel = nodeLevels[node];

                if (node.left != null)
                {
                    nodes.Enqueue(node.left);
                    nodeLevels.Add(node.left, nodeLevel + 1);
                }
                if (node.right != null)
                {
                    nodes.Enqueue(node.right);
                    nodeLevels.Add(node.right, nodeLevel + 1);
                }
            }

            // can be optimised by filling the result collection in the while loop
            var result = (IList<IList<int>>)nodeLevels
                .GroupBy(nl => nl.Value)
                .Select(g => (IList<int>)g.Select(nl => nl.Key.val).ToList())
                .ToList();

            return result;
        }
    }
}
