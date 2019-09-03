using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Collections.KSortedMerger
{
    public class KSortedMergerWithSortedListWithDuplicateHashSets : IKSortedMerger
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
            {
                return null;
            }
            
            var nodes = new SortedList<int, HashSet<ListNode>>();

            foreach (var list in lists)
            {
                if (list != null)
                {
                    Add(nodes, list);
                }
            }

            ListNode current = null;
            ListNode result = null;
            while (nodes.Any())
            {
                var nodesMin = RemoveFirst(nodes);
                if (nodesMin == null)
                {
                    continue;
                }

                if (nodesMin.next != null)
                {
                    Add(nodes, nodesMin.next);
                }

                if (current != null)
                {
                    current.next = new ListNode(nodesMin.val);
                    current = current.next;
                }
                else
                {
                    current = new ListNode(nodesMin.val);
                    if (result == null)
                    {
                        result = current;
                    }
                }
            }

            return result;
        }

        private static void Add(SortedList<int, HashSet<ListNode>> nodes, ListNode node)
        {
            HashSet<ListNode> existing;
            if (nodes.TryGetValue(node.val, out existing))
            {
                existing.Add(node);
            }
            else
            {
                nodes.Add(node.val, new HashSet<ListNode> { node });
            }
        }

        private static ListNode RemoveFirst(SortedList<int, HashSet<ListNode>> nodes)
        {
            var nodesMinSet = nodes.Values[0];
            var nodesMin = nodesMinSet.FirstOrDefault();
            if (nodesMin != null)
            {
                nodesMinSet.Remove(nodesMin);
            }
            else
            {
                // can leave the hash set, but need to store the current non-nullable then
                nodes.RemoveAt(0);
            }
            return nodesMin;
        }
    }
}
