
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
        public void ArrayShuffler_FisherYates_Test()
        {
            var inputObjects = new[]
            {
                new
                {
                    Input = new ListNode[]
                    {
                        new ListNode(1) { next = new ListNode(4) { next = new ListNode(5) { next = null } } },
                        new ListNode(1) { next = new ListNode(3) { next = new ListNode(3) { next = null } } },
                        new ListNode(2) { next = new ListNode(6) { next = null } },
                    }
                },
            };

            foreach (var inputObject in inputObjects)
            {
                IKSortedMerger kSortedMerger = new KSortedMerger();

                kSortedMerger.MergeKLists(inputObject.Input);
            }
        }
    }
}
