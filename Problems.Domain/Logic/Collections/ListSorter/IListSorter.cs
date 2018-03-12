using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Collections.ListSorter
{
    /// <summary>
    /// Definition for singly-linked list.
    /// </summary>
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public interface IListSorter
    {
        /// <summary>
        /// Sort a linked list in O(n log n) time using constant space complexity.
        /// </summary>
        /// <param name="head">list's head node</param>
        /// <returns></returns>
        ListNode SortList(ListNode head);
    }
}
