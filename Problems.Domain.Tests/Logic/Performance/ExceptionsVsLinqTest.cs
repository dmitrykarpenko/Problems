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
        public void SimpleExceptionsVsLinqTest()
        {
            var exceptionResult = GenericUtil.Execute(() =>
                CountEven(() =>
                {
                    // use the simplest exception and the shortest try-catch
                    try
                    {
                        throw new Exception(GetStringRandom);
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }));

            var linqResult = GenericUtil.Execute(() =>
                CountEven(() =>
                {
                    // use concurrent collection in order not to use the fastest collection
                    var errors = new ConcurrentStack<string>();
                    errors.Push(GetStringRandom);
                    var error = errors.FirstOrDefault();
                    return error;
                }));

            Assert.IsTrue(exceptionResult.TimeSpent > linqResult.TimeSpent);
        }

        private int CountEven(Func<string> getValue)
        {
            var evenCount = 0;
            var count = 242;
            for (int i = 0; i < count; ++i)
            {
                var value = getValue();
                var valueInt = int.Parse(value);
                if (valueInt % 2 == 0)
                    ++evenCount;
            }
            return evenCount;
        }
    }
}
