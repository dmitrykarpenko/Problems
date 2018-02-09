using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Trees.Trie
{
    public class Trie<TNodeInfo>
    {
        private readonly TrieNode<TNodeInfo> _root;

        public Trie()
        {
            _root = new TrieNode<TNodeInfo> { Value = '^', Depth = 0, Parent = null };
        }

        public TrieNode<TNodeInfo> Prefix(string s)
        {
            var currentNode = _root;
            var result = currentNode;

            foreach (var c in s)
            {
                currentNode = currentNode.FindChildNode(c);
                if (currentNode == null)
                    break;
                result = currentNode;
            }

            return result;
        }

        public bool Search(string s)
        {
            var prefix = Prefix(s);
            return prefix.Depth == s.Length && prefix.FindChildNode('$') != null;
        }

        public void InsertRange(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
                Insert(items[i]);
        }

        public void Insert(string s)
        {
            var commonPrefix = Prefix(s);
            var current = commonPrefix;

            for (var i = current.Depth; i < s.Length; i++)
            {
                var newNode = new TrieNode<TNodeInfo> { Value = s[i], Depth = current.Depth + 1, Parent = current };
                current.Children.Add(newNode);
                current = newNode;
            }

            current.Children.Add(new TrieNode<TNodeInfo> { Value = '$', Depth = current.Depth + 1, Parent = current });
        }

        public void Delete(string s)
        {
            if (Search(s))
            {
                var node = Prefix(s).FindChildNode('$');

                while (node.IsLeaf())
                {
                    var parent = node.Parent;
                    parent.DeleteChildNode(node.Value);
                    node = parent;
                }
            }
        }

    }
}
