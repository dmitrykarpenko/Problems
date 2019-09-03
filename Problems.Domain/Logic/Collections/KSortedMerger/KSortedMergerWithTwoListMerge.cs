using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Collections.KSortedMerger
{
    public class KSortedMergerWithTwoListMerge : IKSortedMerger
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
            {
                return null;
            }

            if (lists.Length == 1)
            {
                return lists[0];
            }

            var currentLists = new LinkedList<ListNode>(lists);
            while (currentLists.Count > 1)
            {
                var first = currentLists.First;
                var current = MergeTwoLists(first.Value, first.Next.Value);
                currentLists.RemoveFirst();
                currentLists.RemoveFirst();
                currentLists.AddLast(current);
            }

            return currentLists.First.Value;
        }

        private static ListNode MergeTwoLists(ListNode listOne, ListNode listTwo)
        {
            ListNode current = CreateMinValListNode(ref listOne, ref listTwo);
            ListNode result = current;
            while (listOne != null || listTwo != null)
            {
                current.next = CreateMinValListNode(ref listOne, ref listTwo);
                current = current.next;
            }
            return result;
        }

        private static ListNode CreateMinValListNode(ref ListNode listOne, ref ListNode listTwo)
        {
            ListNode minValListNode;
            if (listOne != null &&
                (listTwo == null || listOne.val < listTwo.val))
            {
                minValListNode = new ListNode(listOne.val);
                listOne = listOne.next;
            }
            else if (listTwo != null)
            {
                minValListNode = new ListNode(listTwo.val);
                listTwo = listTwo.next;
            }
            else
            {
                minValListNode = null;
            }
            return minValListNode;
        }
    }
}
