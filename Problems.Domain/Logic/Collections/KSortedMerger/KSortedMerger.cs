using C5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Collections.KSortedMerger
{
    public class KSortedMerger : IKSortedMerger
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
            {
                return null;
            }

            IPriorityQueue<ListNode> nodes = new IntervalHeap<ListNode>(
                new ListNodeComparer());

            foreach (var list in lists)
            {
                if (list != null)
                {
                    nodes.Add(list);
                }
            }

            ListNode current = null;
            ListNode result = null;
            while (!nodes.IsEmpty)
            {
                var nodesMin = nodes.DeleteMin();
                if (nodesMin.next != null)
                {
                    nodes.Add(nodesMin.next);
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

                return x.val - y.val;
            }
        }

        //private class Node : IComparable<Node>
        //{
        //    public int Value { get; set; }
        //    public Node Next { get; set; }

        //    public int CompareTo(Node other)
        //    {
        //        if (other == null)
        //            throw new ArgumentException("Cannot compare to null");

        //        return this.Value - other.Value;
        //    }
        //}
    }
}
