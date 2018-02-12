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
    }

    public class TrieNode
    {
        public char Value { get; set; }
        public List<TrieNode> Children { get; set; }
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
