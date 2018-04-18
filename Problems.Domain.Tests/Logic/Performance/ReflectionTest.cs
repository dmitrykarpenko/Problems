﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            var order = 5;
            //// used this asserts on debug:
            //AssertUtil.AssertGreater(getTypeResult.TimeSpent, typeofResult.TimeSpent,
            //    $"{nameof(getTypeResult)} used to be slower than {nameof(typeofResult)}: ");
            //AssertUtil.AssertGreater(getTypeResult.TimeSpent, dereferencingResult.TimeSpent,
            //    $"{nameof(getTypeResult)} used to be slower than {nameof(dereferencingResult)}: ");
            AssertUtil.AssertRoughlyEqual(typeofResult.TimeSpent, dereferencingResult.TimeSpent, order);
            AssertUtil.AssertRoughlyEqual(getTypeResult.TimeSpent, dereferencingResult.TimeSpent, order);
            AssertUtil.AssertRoughlyEqual(typeofResult.TimeSpent, dereferencingResult.TimeSpent, order);
        }
    }
}
