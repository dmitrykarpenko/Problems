using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Strings.IsometricStringsFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Strings
{
    [TestClass]
    public class IsometricStringsFinderTest
    {
        [TestMethod]
        public void FindSubstringTest()
        {
            // Arrange:
            IIsometricStringsFinder isometricStringsFinder = new SimpleIsometricStringsFinder();

            var inputObjects = new[]
            {
                new
                {
                    Input = "wordgoodgoodgoodbestword",
                    Words = new[] { "word","good","best","good" },
                    Output = new[] { 8 },
                },
                new
                {
                    Input = "foofoobarman",
                    Words = new[] { "foo", "bar" },
                    Output = new[] { 3 },
                },
                new
                {
                    Input = "",
                    Words = new[] { "" },
                    Output = new int[] { 0 },
                },
                new
                {
                    Input = (string)null,
                    Words = new[] { "foo", "bar" },
                    Output = new int[0],
                },
                new
                {
                    Input = "",
                    Words = new[] { "foo", "bar" },
                    Output = new int[0],
                },
                new
                {
                    Input = "foo,barman",
                    Words = new[] { "foo", "bar" },
                    Output = new int[0],
                },
                new
                {
                    Input = "oobarman",
                    Words = new[] { "foo", "bar" },
                    Output = new int[0],
                },
                new
                {
                    Input = "barfoothefoobarman",
                    Words = new[] { "foo", "bar" },
                    Output = new[] { 0, 9 },
                },
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var output = isometricStringsFinder.FindSubstring(inputObject.Input, inputObject.Words);

                // Assert:
                foreach (var index in output)
                {
                    Assert.IsTrue(inputObject.Output.Contains(index));
                }
            }
        }
    }
}
