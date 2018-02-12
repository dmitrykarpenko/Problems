using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Trees.Trie
{
    public class TrieNode<TInfo> : TrieNode
    {
        public TInfo Info { get; set; }
        public int Count { get; set; }
    }

    public class TrieNode
    {
        private List<TrieNode> Children { get; }

        public char Value { get; set; }
        public TrieNode Parent { get; set; }
        public int Depth { get; set; }


        public TrieNode(char value, int depth, TrieNode parent)
            : this()
        {
            Value = value;
            Depth = depth;
            Parent = parent;
        }

        public TrieNode()
        {
            Children = new List<TrieNode>();
        }


        public bool IsLeaf()
        {
            return Children.Count == 0;
        }

        public TrieNode FindChildNode(char c)
        {
            foreach (var child in Children)
                if (child.Value == c)
                    return child;

            return null;
        }

        public void AddChildNode(TrieNode node)
        {
            TrieNode existingNode;
            AddChildNode(node, out existingNode);
        }

        private void AddChildNode(TrieNode node, out TrieNode existingNode)
        {
            existingNode = FindChildNode(node.Value);
            if (existingNode == null)
            {
                Children.Add(node);
            }
        }

        public void AddOrUpdateChildNode<TInfo>(TrieNode<TInfo> node, Func<TrieNode<TInfo>, bool> assignInfo = null)
        {
            TrieNode existingNode;
            AddChildNode(node, out existingNode);

            if (existingNode != null)
            {
                var existingNodeWithInfo = existingNode as TrieNode<TInfo>;
                if (existingNodeWithInfo != null)
                {
                    ++existingNodeWithInfo.Count;
                    if (assignInfo == null || assignInfo(existingNodeWithInfo))
                    {
                        existingNodeWithInfo.Info = node.Info;
                    }
                }
            }
            // else if node exists and not terminal - leave as it is for now
            // (it should not happen as TrieNode<TInfo> are only terminal nodes for now)
        }

        /// <summary>
        /// Finds nodes containing char c among children, subchildren etc. Used e.g. to find terminal symbol nodes.
        /// </summary>
        /// <param name="c">char to find among children nodes</param>
        /// <returns></returns>
        public IEnumerable<TrieNode> FindChildNodeRecursive(char c)
        {
            foreach (var child in Children)
            {
                if (child.Value == c)
                    yield return child;

                foreach (var subChild in child.FindChildNodeRecursive(c))
                    yield return subChild;
            }
        }

        public void DeleteChildNode(char c)
        {
            for (var i = 0; i < Children.Count; i++)
                if (Children[i].Value == c)
                    Children.RemoveAt(i);
        }
    }
}
