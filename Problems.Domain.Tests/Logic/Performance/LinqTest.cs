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
        public void ToArrayVsToListTest()
        {
            var count = 100;
            var items = GenericUtil.CreateEnumerable((1, 10), (2, 12), (33, 301));

            // idle start to perform all the runtime optimizations in advance
            GenericUtil.Execute(() => items.ToArray(), count);
            GenericUtil.Execute(() => items.ToList(), count);

            var toArrayResult = GenericUtil.Execute(() => items.ToArray(), count);
            var toListResult = GenericUtil.Execute(() => items.ToList(), count);

            TestContext.WriteLine($@"{toArrayResult.TimeSpent} : time of {nameof(toArrayResult)}");
            TestContext.WriteLine($@"{toListResult.TimeSpent} : time of {nameof(toListResult)}");

            AssertUtil.AssertRoughlyEqual(toArrayResult.TimeSpent, toListResult.TimeSpent, 1.3f);
        }
    }
}
