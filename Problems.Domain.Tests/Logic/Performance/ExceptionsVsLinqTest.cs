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

        public TestContext TestContext { get; set; }

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

            TestContext.WriteLine($@"{exceptionResult.TimeSpent} : time of {nameof(exceptionResult)}");
            TestContext.WriteLine($@"{linqResult.TimeSpent} : time of {nameof(linqResult)}");
            TestContext.WriteLine($@"getting {nameof(exceptionResult)} was {
                exceptionResult.TimeSpent / linqResult.TimeSpent
                } times slower than {nameof(linqResult)}");

            AssertUtil.AssertMuchGreater(exceptionResult.TimeSpent, linqResult.TimeSpent);
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

            TestContext.WriteLine($@"{eighthLayerResult.TimeSpent} : time of {nameof(eighthLayerResult)}");
            TestContext.WriteLine($@"{fourthLayerResult.TimeSpent} : time of {nameof(fourthLayerResult)}");
            TestContext.WriteLine($@"{zeroLayerResult.TimeSpent} : time of {nameof(zeroLayerResult)}");

            AssertUtil.AssertRoughlyEqual(eighthLayerResult.TimeSpent, fourthLayerResult.TimeSpent);
            AssertUtil.AssertRoughlyEqual(fourthLayerResult.TimeSpent, zeroLayerResult.TimeSpent);
            AssertUtil.AssertRoughlyEqual(eighthLayerResult.TimeSpent, zeroLayerResult.TimeSpent);
            TestContext.WriteLine($@"getting {nameof(eighthLayerResult)} was {
                eighthLayerResult.TimeSpent / zeroLayerResult.TimeSpent
                } times slower than {nameof(zeroLayerResult)}");
        }

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
