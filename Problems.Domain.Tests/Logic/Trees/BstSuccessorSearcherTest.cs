using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Trees.BstSuccessorSearcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Trees
{
    [TestClass]
    public class BstSuccessorSearcherTest
    {
        private const int _emptyOutput = -1;

        [TestMethod]
        public void BstSuccessorSearcher_FindInOrderSuccessor_Test()
        {
            IBstSuccessorSearcher bstSuccessorSearcher = new BstSuccessorSearcher(); 

            // Arrange:
            var inputObjects = new[]
            {
                new
                {
                    Keys = new[] { 20, 9, 25, 5, 12, 11, 14},
                    Pairs = new []
                    {
                        new { Input = 9, Output = 11 },
                        new { Input = 11, Output = 12 },
                        new { Input = 20, Output = 25 },

                        new { Input = 25, Output = _emptyOutput },
                    }
                },
            };

            foreach (var inputObject in inputObjects)
            {
                // Arrange:
                bstSuccessorSearcher.Clear();
                bstSuccessorSearcher.Insert(inputObject.Keys);

                foreach (var pair in inputObject.Pairs)
                {
                    var inputNode = bstSuccessorSearcher.GetNodeByKey(pair.Input);

                    // Act:
                    var outputNode = bstSuccessorSearcher.FindInOrderSuccessor(inputNode);

                    // Assert:
                    Assert.AreEqual(pair.Output, outputNode?.key ?? _emptyOutput);
                }
            }
        }
    }
}
