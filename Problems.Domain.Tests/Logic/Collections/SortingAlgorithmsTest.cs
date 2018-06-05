using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Collections.SortingAlgorithms;
using Tu = Problems.Domain.Tests.Utils;
using TuGu = Problems.Domain.Tests.Utils.GenericUtil;
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
        public void Sorter_Heap_Test() =>
            SorterTest(new HeapSorter());

        [TestMethod]
        public void Sorter_Quick_Lomuto_Test() =>
            SorterTest(new QuickLomutoSorter());

        [TestMethod]
        public void Sorter_Quick_Hoare_Test() =>
            SorterTest(new QuickHoareSorter());

        [TestMethod]
        public void Sorter_Merge_Recursive_Test() =>
            SorterTest(new MergeRecursiveSorter());

        [TestMethod]
        public void Sorter_Merge_BottomUp_Test() =>
            SorterTest(new MergeBottomUpSorter());

        public void SorterTest(ISorter sorter)
        {
            var largeInputPart = TuGu.CreateArrayFromEnumerables(new[] { (1, 2), (2, 1), (3, 1) });
            var scale = 400;
            Func<int[]> getLargeInput = () => TuGu.CreateArrayFromEnumerables((largeInputPart, scale));
            Func<int[]> getLargeOutput = () => TuGu.CreateArray((1, 2*scale), (2, scale), (3, scale));

            var largeSameItemsInput = TuGu.CreateArray((5, scale));

            var inputObjects = new[]
            {
                new { Input = new[] { 1, 1, 3, 2, 9, 0 }, Output = new[] { 0, 1, 1, 2, 3, 9 } },
                new { Input = new[] { 1, 1, 3, 2, 9, 0 }, Output = new[] { 9, 3, 2, 1, 1, 0 } },
                new { Input = new[] { 1, 2, 3, 4, 5 }, Output = new[] { 1, 2, 3, 4, 5 } },
                new { Input = new[] { 1, 2, 3, 4, 5 }, Output = new[] { 5, 4, 3, 2, 1 } },
                new { Input = new[] { 0 }, Output = new[] { 0 } },
                new { Input = getLargeInput(), Output = getLargeOutput() },
                new { Input = getLargeOutput(), Output = getLargeOutput() },
                new { Input = largeSameItemsInput, Output = largeSameItemsInput.ToArray() },
            };

            foreach (var inputObject in inputObjects)
            {
                sorter.Sort(inputObject.Input, inputObject.Output.IsDescending());
                Tu.AssertUtil.AssertCollection(inputObject.Output, inputObject.Input);
            }
        }
    }
}
