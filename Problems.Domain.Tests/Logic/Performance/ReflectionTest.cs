using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Tests.Models;
using Problems.Domain.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Performance
{
    [TestClass]
    public class ReflectionTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TypeofVsGetTypeVsDereferencingTest()
        {
            int count = 100000;
            var emptyResult = new ExecutionResult<object> { Result = new object() };
            object dummyObject;
            Type dummyType;

            // idle run to perform all the runtime optimizations in advance
            var typeofResult = GenericUtil.Execute(() => dummyType = typeof(ExecutionResult<object>), count);
            var getTypeResult = GenericUtil.Execute(() => dummyType = emptyResult.GetType(), count);
            var dereferencingResult = GenericUtil.Execute(() => dummyObject = emptyResult.Result, count);

            typeofResult = GenericUtil.Execute(() => typeof(ExecutionResult<object>), count);
            getTypeResult = GenericUtil.Execute(() => emptyResult.GetType(), count);
            dereferencingResult = GenericUtil.Execute(() => emptyResult.Result, count);

            TestContext.WriteLine($@"{typeofResult.TimeSpent} : time of {nameof(typeofResult)}");
            TestContext.WriteLine($@"{getTypeResult.TimeSpent} : time of {nameof(getTypeResult)}");
            TestContext.WriteLine($@"{dereferencingResult.TimeSpent} : time of {nameof(dereferencingResult)}");

            //var order = 5;
            //// used this asserts on debug:
            //AssertUtil.AssertGreater(getTypeResult.TimeSpent, typeofResult.TimeSpent,
            //    $"{nameof(getTypeResult)} used to be slower than {nameof(typeofResult)}: ");
            //AssertUtil.AssertGreater(getTypeResult.TimeSpent, dereferencingResult.TimeSpent,
            //    $"{nameof(getTypeResult)} used to be slower than {nameof(dereferencingResult)}: ");

            //// flaky
            //AssertUtil.AssertRoughlyEqual(typeofResult.TimeSpent, dereferencingResult.TimeSpent, order);
            //AssertUtil.AssertRoughlyEqual(getTypeResult.TimeSpent, dereferencingResult.TimeSpent, order);
            //AssertUtil.AssertRoughlyEqual(typeofResult.TimeSpent, dereferencingResult.TimeSpent, order);
        }

        [TestMethod]
        public void DefaultVsNullCompareTest()
        {
            var items = GenericUtil.CreateArray((new ExecutionResult<object>(), 1000));
            var count = 1500;

            // idle run to perform all the runtime optimizations in advance
            var defaultCompareResult = GenericUtil.Execute(
                () => items = items.Where(i => i != default(ExecutionResult<object>)).ToArray(),
                count);
            var nullCompareResult = GenericUtil.Execute(
                () => items = items.Where(i => i != null).ToArray(),
                count);

            defaultCompareResult = GenericUtil.Execute(
                () => items = items.Where(i => i != default(ExecutionResult<object>)).ToArray(),
                count);
            nullCompareResult = GenericUtil.Execute(
                () => items = items.Where(i => i != null).ToArray(),
                count);

            // usually the ratio is slightly greater than one 
            TestContext.WriteLine($@"getting {nameof(defaultCompareResult)} was {
                defaultCompareResult.TimeSpent / nullCompareResult.TimeSpent
                } times slower than {nameof(nullCompareResult)}");

            var order = 5;
            AssertUtil.AssertRoughlyEqual(defaultCompareResult.TimeSpent, nullCompareResult.TimeSpent, order);
        }
    }
}
