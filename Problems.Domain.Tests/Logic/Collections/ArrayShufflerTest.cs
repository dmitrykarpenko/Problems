using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Collections.ArrayShuffler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Collections
{
    [TestClass]
    public class ArrayShufflerTest
    {
        [TestMethod]
        public void ArrayShuffler_FisherYates_Test()
        {
            var inputObjects = new[]
            {
                new { Input = new[] { 1, 2, 3, 4, 5, } },
            };

            foreach (var inputObject in inputObjects)
            {
                AbstractArrayShuffler arrayShuffler = new FisherYatesArrayShuffler(inputObject.Input);

                arrayShuffler.Shuffle();
                arrayShuffler.Reset();
                arrayShuffler.Shuffle();

                // TODO: check whether items are uniformly distributed
            }
        }
    }
}
