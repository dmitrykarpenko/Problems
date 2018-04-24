using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Collections.SortingAlgorithms;
using Problems.Domain.Tests.Utils;
using Problems.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Collections
{
    [TestClass]
    public class SortingAlgorithmsTest
    {
        [TestMethod]
        public void HeapSorterTest()
        {
            ISorter heapSorter = new HeapSorter();

            var inputObjects = new[]
            {
                new { Input = new[] { 1, 1, 3, 2, 9, 0 }, Output = new[] { 0, 1, 1, 2, 3, 9 } },
                new { Input = new[] { 1, 1, 3, 2, 9, 0 }, Output = new[] { 9, 3, 2, 1, 1, 0 } },
            };

            foreach (var inputObject in inputObjects)
            {
                heapSorter.Sort(inputObject.Input, inputObject.Output.IsDescending());
                AssertUtil.AssertCollection(inputObject.Output, inputObject.Input);
            }
        }
    }
}
