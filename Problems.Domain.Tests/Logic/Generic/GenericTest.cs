using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Generic
{
    [TestClass]
    public class GenericTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void GfgBinarySearcher_GetIndex_Test()
        {
            // Arrange:
            IBinarySearcher binarySearcher = new GfgBinarySearcher();

            var inputObjects = new[]
            {
                new { Input = new[] { 0, 1, 3, 4, 9, 10 }, X = 3, Output = 2 },
                new { Input = new[] { 0, 1, 3, 4, 9, 10 }, X = 10, Output = 5 },
                new { Input = new[] { -2, 1, 3, 4, 9, 10 }, X = -2, Output = 0 },

                new { Input = new[] { -2, 1, 3, 4, 9, 10 }, X = 0, Output = -1 },
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var output = binarySearcher.GetIndex(inputObject.Input, inputObject.X);

                // Assert:
                Assert.AreEqual(inputObject.Output, output);
            }
        }

        [TestMethod]
        public void EqualityComparerDefault_Test()
        {
            // Arrange, act, assert:

            Assert.AreEqual(true, Equals(1, 1));
            Assert.AreEqual(true, Equals((object)1, (object)1));
            Assert.AreEqual(true, Equals(100_000_000_000, 100_000_000_000));
            Assert.AreEqual(true, Equals(100_000_000_000, (double)100_000_000_000));
            Assert.AreEqual(true, Equals((long?)null, (double?)null));
            Assert.AreEqual(true, Equals("one", "one"));
            Assert.AreEqual(true, Equals(null, null));
            Assert.AreEqual(true, Equals(new Tuple<string, short>("seventeen", 42), new Tuple<string, short>("seventeen", 42)));
            Assert.AreEqual(true, Equals(new Tuple<int, int>(17, 42), new Tuple<int, int>(17, 42)));
            Assert.AreEqual(true, Equals((object)new Tuple<int, int>(17, 42), (object)new Tuple<int, int>(17, 42)));
            Assert.AreEqual(true, Equals((17, 42), (17, 42)));
            Assert.AreEqual(true, Equals((object)(17, 42), (object)(17, 42)));
            Assert.AreEqual(true, Equals(new { Number = 52 }, new { Number = 52 }));
            Assert.AreEqual(true, Equals((object)new { Number = 52 }, (object)new { Number = 52 }));

            Assert.AreEqual(false, Equals(1, 2));
            Assert.AreEqual(false, Equals("one", "one1"));
            Assert.AreEqual(false, Equals(new object(), new object()));
            Assert.AreEqual(false, Equals(new Tuple<int, int>(17, 42), new Tuple<long, short>(17, 42)));
            Assert.AreEqual(false, Equals(new Tuple<int, int>(17, 42), new Tuple<int, int>(17, 43)));
            Assert.AreEqual(false, Equals(new Tuple<int, int>(17, 42), new Tuple<int, int>(18, 42)));
            Assert.AreEqual(false, Equals((17, 42), (17, 43)));
            Assert.AreEqual(false, Equals((17, 42), (18, 42)));
            Assert.AreEqual(false, Equals(new { Number = 52 }, new { Number = 53 }));
            Assert.AreEqual(false, Equals(new { Number = 52 }, new { Num = 52 }));

            var oldTuple = new Tuple<int, int>(17, 42);
            var newTuple = (17, 42);
            // sad but false:
            Assert.AreEqual(false, Equals(oldTuple, newTuple));
        }

        private static bool Equals<T>(T first, T second) =>
            EqualityComparer<T>.Default.Equals(first, second);

        [TestMethod]
        public void GetHashCode_Collision_Test()
        {
            var random = new Random();
            var hashCodes = new HashSet<int>();
            var collisionsCount = 0;

            var counts = new[] { 1e4, 1e5,/* 1e6, 1e7*/ };

            foreach (var count in counts)
            {
                for (int i = 0; i < count; ++i)
                {
                    var next = random.Next().ToString();
                    var hashCode = next.GetHashCode();

                    if (!hashCodes.Contains(hashCode))
                    {
                        hashCodes.Add(hashCode);
                    }
                    else
                    {
                        ++collisionsCount;
                    }
                }

                var collisionProbability = (double)collisionsCount / count;
                var oneCollisionProbability = collisionProbability / count;

                TestContext.WriteLine($@"One collision probability is {
                    oneCollisionProbability } and collision probability is {
                    collisionProbability } when count is { count }");
            }
        }

        [TestMethod]
        public void GetHashCode_SequentialCollision_Test()
        {
            var random = new Random();
            var collisionsCount = 0;

            const int count = 100_000;

            for (var i = 0; i < count; ++i)
            {
                var firstNext = random.Next().ToString();
                var firstHashCode = firstNext.GetHashCode();

                var secondNext = random.Next().ToString();
                var secondHashCode = secondNext.GetHashCode();

                if (firstHashCode == secondHashCode)
                {
                    ++collisionsCount;
                }
            }

            var collisionProbability = (double)collisionsCount / count;

            TestContext.WriteLine($@"Sequential collision probability is {
                collisionProbability } when count is { count }");
        }
    }
}
