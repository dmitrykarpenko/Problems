using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Trees.Trie
{
    public class TrieNode<TInfo>
    {
        public char Value { get; set; }
        public List<TrieNode<TInfo>> Children { get; set; }
        public TrieNode<TInfo> Parent { get; set; }
        public int Depth { get; set; }

        public TInfo Info { get; set; }


        public TrieNode(char value, int depth, TrieNode<TInfo> parent)
            : this()
        {
            Value = value;
            Depth = depth;
            Parent = parent;
        }

        public TrieNode()
        {
            Children = new List<TrieNode<TInfo>>();
        }


        public bool IsLeaf()
        {
            return Children.Count == 0;
        }

        public TrieNode<TInfo> FindChildNode(char c)
        {
            foreach (var child in Children)
                if (child.Value == c)
                    return child;

            return null;
        }

        public void DeleteChildNode(char c)
        {
            for (var i = 0; i < Children.Count; i++)
                if (Children[i].Value == c)
                    Children.RemoveAt(i);
        }
    }
}
