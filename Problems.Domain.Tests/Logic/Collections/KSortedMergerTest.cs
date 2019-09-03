
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Collections.ArrayShuffler;
using Problems.Domain.Logic.Collections.KSortedMerger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Collections
{
    [TestClass]
    public class KSortedMergerTest
    {
        [TestMethod]
        public void KSortedMergerWithC5PriorityQueue_MergeKLists_Test()
            => IKSortedMerger_MergeKLists_Test(new KSortedMergerWithC5PriorityQueue());

        [TestMethod]
        public void KSortedMergerWithSortedListWithDuplicates_MergeKLists_Test()
            => IKSortedMerger_MergeKLists_Test(new KSortedMergerWithSortedListWithDuplicates());

        [TestMethod]
        public void KSortedMergerWithSortedListWithDuplicateHashSets_MergeKLists_Test()
            => IKSortedMerger_MergeKLists_Test(new KSortedMergerWithSortedListWithDuplicateHashSets());

        [TestMethod]
        public void KSortedMergerWithTwoListMerge_MergeKLists_Test()
            => IKSortedMerger_MergeKLists_Test(new KSortedMergerWithTwoListMerge());

        public void IKSortedMerger_MergeKLists_Test(IKSortedMerger kSortedMerger)
        {
            // Arrange:
            var inputObjects = new[]
            {
                new
                {
                    Input = new ListNode[]
                    {
                        new ListNode(1) { next = new ListNode(4) { next = new ListNode(5) { next = null } } },
                        new ListNode(1) { next = new ListNode(3) { next = new ListNode(3) { next = null } } },
                        new ListNode(2) { next = new ListNode(6) { next = null } },
                    },
                    Count = 8,
                },
                new
                {
                    Input = new ListNode[]
                    {
                        new ListNode(0) { next = new ListNode(0) { next = null } },
                        new ListNode(1) { next = new ListNode(1) { next = new ListNode(30) { next = null } } },
                        (ListNode)null,
                    },
                    Count = 5,
                },
                new
                {
                    Input = new ListNode[]
                    {
                        new ListNode(1),
                        new ListNode(1),
                        (ListNode)null,
                        new ListNode(1),
                    },
                    Count = 3,
                },
                new
                {
                    Input = new ListNode[0],
                    Count = 0,
                },
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var output = kSortedMerger.MergeKLists(inputObject.Input);

                // Assert:
                if (inputObject.Input == null || inputObject.Input.Length == 0)
                {
                    Assert.IsNull(output);
                    continue;
                }

                var outputArray = output.ToArray();
                var orderedOutputArray = outputArray.OrderBy(i => i.val).ToArray();
                var pairs = outputArray.Zip(orderedOutputArray, (oi, si) => new { oi, si });
                foreach (var pair in pairs)
                {
                    Assert.AreEqual(inputObject.Count, outputArray.Length, "Output does not have all the elements: " + output);
                    Assert.AreEqual(pair.si?.val, pair.oi?.val, "Output is not sorted: " + output);
                }
            }
        }
    }
}
