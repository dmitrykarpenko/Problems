using C5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Collections.KSortedMerger
{
    public class KSortedMergerWithSortedListWithDuplicates : IKSortedMerger
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
            {
                return null;
            }
            
            var nodes = new SortedList<ListNode, int>(
                new ListNodeComparer());

            foreach (var list in lists)
            {
                if (list != null)
                {
                    nodes.Add(list, list.val);
                }
            }

            ListNode current = null;
            ListNode result = null;
            while (nodes.Any())
            {
                var nodesMin = nodes.Keys[0];
                nodes.RemoveAt(0);

                if (nodesMin.next != null)
                {
                    nodes.Add(nodesMin.next, nodesMin.next.val);
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

        private class ListNodeComparer : IComparer<ListNode>
        {
            public int Compare(ListNode x, ListNode y)
            {
                if (x == null || y == null)
                    throw new ArgumentException("Cannot compare to null");

                if (x == y)
                {
                    return 0;
                }

                var result = x.val - y.val;

                // allows saving duplicates in a SortedSet collection
                if (result == 0)
                {
                    result = 1;
                }

                return result;
            }
        }
    }
}
