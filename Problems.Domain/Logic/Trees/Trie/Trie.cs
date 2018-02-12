using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Trees.Trie
{
    public class Trie<TNodeInfo>
    {
        private const char _start = '^';
        private const char _end = '$';

        private readonly TrieNode _root;

        public Trie()
        {
            _root = new TrieNode { Value = _start, Depth = 0, Parent = null };
        }

        public TrieNode GetPrefixEndNode(string s)
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

        /// <summary>
        /// Gets terminal nodes which represent words that start with prefix
        /// </summary>
        /// <param name="prefix">The beginning of the wanted words</param>
        /// <returns></returns>
        public IEnumerable<TrieNode<TNodeInfo>> GetTerminalNodes(string prefix)
        {
            var prefixEndNode = GetPrefixEndNode(prefix);
            if (prefixEndNode.Depth < prefix.Length)
                yield break;

            foreach (var terminalNode in prefixEndNode.FindChildNodeRecursive(_end))
                yield return (TrieNode<TNodeInfo>)terminalNode;
        }

        //public bool Search(string s)
        //{
        //    TrieNode<TNodeInfo> nodeInfo = null;
        //    return Search(s, ref nodeInfo);
        //}

        public bool Search(string s, ref TrieNode<TNodeInfo> terminalNode)
        {
            var prefixEndNode = GetPrefixEndNode(s);
            if (prefixEndNode.Depth < s.Length)
                return false;

            terminalNode = (TrieNode<TNodeInfo>)prefixEndNode.FindChildNode(_end);
            if (terminalNode == null)
                return false;

            return true;
        }

        public void InsertRange(string[] items, Func<string, int, TNodeInfo> getNodeInfo)
        {
            for (int i = 0; i < items.Length; ++i)
                Insert(items[i], s => getNodeInfo(s, i));
        }

        public void Insert(string s, Func<string, TNodeInfo> getNodeInfo)
        {
            var current = GetPrefixEndNode(s);

            for (var i = current.Depth; i < s.Length; i++)
            {
                var newNode = new TrieNode
                {
                    Value = s[i],
                    Depth = current.Depth + 1,
                    Parent = current,
                };
                current.AddChildNode(newNode);
                current = newNode;
            }

            current.AddOrUpdateChildNode(new TrieNode<TNodeInfo>
            {
                Value = _end,
                Depth = current.Depth + 1,
                Parent = current,
                Info = getNodeInfo(s),
            });
        }

        public void Delete(string s)
        {
            TrieNode<TNodeInfo> terminalNode = null;
            if (Search(s, ref terminalNode))
            {
                TrieNode node = terminalNode;
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
