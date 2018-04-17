using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Tests.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Performance
{
    [TestClass]
    public class ExceptionsVsLinqTest
    {
        private static readonly Random _random = new Random();
        private string GetStringRandom => _random.Next(0, 2_000_000_000).ToString();

        [TestMethod]
        public void ExceptionsVsLinqSimpleTest()
        {
            var exceptionResult = GenericUtil.Execute(() =>
                CountEven(() => ThrowAndGetMessage(GetStringRandom)));

            var linqResult = GenericUtil.Execute(() =>
                CountEven(() =>
                {
                    // use concurrent collection in order not to use the fastest collection
                    var errors = new ConcurrentStack<string>();
                    errors.Push(GetStringRandom);
                    var error = errors.FirstOrDefault();
                    return error;
                }));

            AssertMuchGreater(exceptionResult.TimeSpent, linqResult.TimeSpent);
        }

        private int CountEven(Func<string> getValue)
        {
            var count = 100;
            var evenCount = 0;
            for (int i = 0; i < count; ++i)
            {
                var value = getValue();
                var valueInt = int.Parse(value);
                if (valueInt % 2 == 0)
                    ++evenCount;
            }
            return evenCount;
        }

        [TestMethod]
        public void ExceptionsOnDifferentLayersTest()
        {
            var count = 100;

            var eighthLayerResult = GenericUtil.Execute(ThrowFrom8thLayer, count);
            var fourthLayerResult = GenericUtil.Execute(ThrowFrom4thLayer, count);
            var zeroLayerResult = GenericUtil.Execute(ThrowAndGetMessage, count);

            AssertRoughlyEqual(eighthLayerResult.TimeSpent, fourthLayerResult.TimeSpent);
            AssertRoughlyEqual(fourthLayerResult.TimeSpent, zeroLayerResult.TimeSpent);
            AssertRoughlyEqual(eighthLayerResult.TimeSpent, zeroLayerResult.TimeSpent);
        }

        private const int _greaterOrder = 2;
        private void AssertMuchGreater(TimeSpan greater, TimeSpan smaller)
        {
            AssertGreater(greater, smaller * _greaterOrder, "Is not much greater: ");
        }
        private void AssertSlightlyGreater(TimeSpan greater, TimeSpan smaller)
        {
            AssertGreater(greater, smaller, "Is not greater: ");
            AssertGreater(smaller * _greaterOrder, greater, "Is greater but not slightly: ");
        }

        private const int _roughlyEqualOrder = 4;
        private void AssertRoughlyEqual(TimeSpan first, TimeSpan second)
        {
            // e.g. "y > x / 4" and "y < 4 * x" wedge
            AssertGreater(first * _roughlyEqualOrder, second);
            AssertGreater(second * _roughlyEqualOrder, first);
        }

        private void AssertGreater(TimeSpan greater, TimeSpan smaller, string errorStart = null) =>
            Assert.IsTrue(greater > smaller, GetAssertGreaterError(greater, smaller, errorStart));

        private string GetAssertGreaterError(TimeSpan greater, TimeSpan smaller, string errorStart = null) =>
            $"{errorStart}{greater} should be greater than {smaller}";

        private string ThrowFrom8thLayer() =>
            ThrowFrom7thLayer();

        private string ThrowFrom7thLayer() =>
            ThrowFrom6thLayer();

        private string ThrowFrom6thLayer() =>
            ThrowFrom5thLayer();

        private string ThrowFrom5thLayer() =>
            ThrowFrom4thLayer();

        private string ThrowFrom4thLayer() =>
            ThrowFrom3rdLayer();

        private string ThrowFrom3rdLayer() =>
            ThrowFrom2ndLayer();

        private string ThrowFrom2ndLayer() =>
            ThrowFrom1stLayer();

        private string ThrowFrom1stLayer() =>
            ThrowAndGetMessage();

        private string ThrowAndGetMessage() =>
            ThrowAndGetMessage("dummy message");

        private string ThrowAndGetMessage(string message)
        {
            // use the simplest exception and the shortest try-catch
            try
            {
                throw new Exception(message);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
