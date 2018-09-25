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

        //[TestInitialize]
        //public void Initialize()
        //{

        //}

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

            //// flaky
            //AssertUtil.AssertRoughlyEqual(toArrayResult.TimeSpent, toListResult.TimeSpent, 5);
        }

        [TestMethod]
        public void GetIntsWithTake_Test() =>
            GetIntsTest((ints, batchSize, processCurrentInts) =>
            {
                IReadOnlyCollection<int> currentInts;
                // WARNING: "Take" starts from the beginngin each time
                while ((currentInts = ints.Take(batchSize).ToArray()).Count > 0)
                {
                    processCurrentInts(currentInts);

                    ints = ints.Skip(batchSize);
                }
            });

        [TestMethod]
        public void GetIntsWithForeach_Test() =>
            GetIntsTest((ints, batchSize, processCurrentInts) =>
            {
                List<int> currentInts = new List<int>();
                foreach (var i in ints)
                {
                    currentInts.Add(i);
                    if (currentInts.Count >= batchSize)
                    {
                        processCurrentInts(currentInts);

                        currentInts.Clear();
                    }
                }

                if (currentInts.Count > 0)
                {
                    processCurrentInts(currentInts);
                }
            });

        private int _yieldsCount;
        private List<int> _yieldedIs;

        private const int _count = 105;

        private void GetIntsTest(
            Action<IEnumerable<int>, int, Action<IReadOnlyCollection<int>>> processInts)
        {
            // Arrange:
            _yieldsCount = 0;
            _yieldedIs = new List<int>();

            var ints = GetInts();

            const int batchSize = 10;

            int count = 0, sum = 0;

            // Act:
            processInts(
                ints, batchSize,
                currentInts =>
                {
                    {
                        count += currentInts.Count;
                        foreach (var currentInt in currentInts)
                        {
                            sum += currentInt;
                        }
                    }
                });

            // Assert:
            TestContext.WriteLine("yielded i(s): " + string.Join(", ", _yieldedIs));
            TestContext.WriteLine($"Looped through {nameof(GetInts)} iterrator: {_yieldsCount} times");

            Assert.AreEqual(_count, count);

            var properSum = GetInts().Sum();
            Assert.AreEqual(properSum, sum);
        }

        private static void ProcessIntsWithForeach(
            IEnumerable<int> ints, int batchSize,
            Action<IReadOnlyCollection<int>> processCurrentInts)
        {
            List<int> currentInts = new List<int>();
            foreach (var i in ints)
            {
                currentInts.Add(i);
                if (currentInts.Count >= batchSize)
                {
                    processCurrentInts(currentInts);
                    currentInts.Clear();
                }
            }
        }

        private IEnumerable<int> GetInts()
        {
            for (int i = 0; i < _count; i++)
            {
                ++_yieldsCount;
                System.Diagnostics.Debug.WriteLine($"i: {i}");

                _yieldedIs.Add(i);
                yield return i;
            }
        }
    }
}
