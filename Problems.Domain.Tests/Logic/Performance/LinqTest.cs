using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Performance
{
    [TestClass]
    public class LinqTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void ToArrayVsToList_Scale1Count100_Test() =>
            ToArrayVsToListTest(1, 100);

        [TestMethod]
        public void ToArrayVsToList_Scale10Count100_Test() =>
            ToArrayVsToListTest(10, 100);

        [TestMethod]
        public void ToArrayVsToList_Scale100Count10_Test() =>
            ToArrayVsToListTest(100, 10);

        public void ToArrayVsToListTest(int itemsScale, int count)
        {
            var items = GenericUtil.CreateEnumerable((1, 10 * itemsScale), (2, 12 * itemsScale), (33, 31 * itemsScale));

            // idle run to perform all the runtime optimizations in advance
            GenericUtil.Execute(() => items.ToArray(), count);
            GenericUtil.Execute(() => items.ToList(), count);

            var toArrayResult = GenericUtil.Execute(() => items.ToArray(), count);
            var toListResult = GenericUtil.Execute(() => items.ToList(), count);

            TestContext.WriteLine($@"{toArrayResult.TimeSpent} : time of {nameof(toArrayResult)}");
            TestContext.WriteLine($@"{toListResult.TimeSpent} : time of {nameof(toListResult)}");

            AssertUtil.AssertRoughlyEqual(toArrayResult.TimeSpent, toListResult.TimeSpent, 1.5f);
        }
    }
}
