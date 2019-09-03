using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Collections.KSortedMerger
{
    public interface IKSortedMerger
    {
        /// <summary>
        /// https://leetcode.com/problems/merge-k-sorted-lists/
        /// 23. Merge k Sorted Lists
        /// Merge k sorted linked lists and return it as one sorted list.Analyze and describe its complexity.
        /// Example:
        /// Input:
        /// [
        ///   1->4->5,
        ///   1->3->4,
        ///   2->6
        /// ]
        /// Output: 1->1->2->3->4->4->5->6
        /// </summary>
        ListNode MergeKLists(ListNode[] lists);
    }

    public class ListNode : IEnumerable<ListNode>
    {
        public ListNode(int x)
        {
            val = x;
        }

        public int val;
        public ListNode next;

        #region Custom

        public override string ToString()
        {
            const string arrow = " -> ";
            var sb = new StringBuilder();
            var current = this;
            while (current != null)
            {
                sb.Append(current.val).Append(arrow);
                current = current.next;
            }
            sb.Length -= arrow.Length;
            return sb.ToString();
        }

        public IEnumerator<ListNode> GetEnumerator()
        {
            var current = this;
            while (current != null)
            {
                yield return current;
                current = current.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
