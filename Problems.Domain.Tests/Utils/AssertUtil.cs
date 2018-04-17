using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Utils
{
    public static class AssertUtil
    {
        public const int _greaterOrder = 2;
        public static void AssertMuchGreater(TimeSpan greater, TimeSpan smaller)
        {
            AssertGreater(greater, smaller * _greaterOrder, "Is not much greater: ");
        }
        public static void AssertSlightlyGreater(TimeSpan greater, TimeSpan smaller)
        {
            AssertGreater(greater, smaller, "Is not greater: ");
            AssertGreater(smaller * _greaterOrder, greater, "Is greater but not slightly: ");
        }

        public const float _roughlyEqualOrder = 4;
        public static void AssertRoughlyEqual(TimeSpan first, TimeSpan second,
            float roughlyEqualOrder = _roughlyEqualOrder)
        {
            // e.g. "y > x / 4" and "y < 4 * x" wedge
            AssertGreater(first * roughlyEqualOrder, second);
            AssertGreater(second * roughlyEqualOrder, first);
        }

        public static void AssertGreater(TimeSpan greater, TimeSpan smaller, string errorStart = null) =>
            Assert.IsTrue(greater > smaller, GetAssertGreaterError(greater, smaller, errorStart));

        public static string GetAssertGreaterError(TimeSpan greater, TimeSpan smaller, string errorStart = null) =>
            $"{errorStart}{greater} should be greater than {smaller}";
    }
}
