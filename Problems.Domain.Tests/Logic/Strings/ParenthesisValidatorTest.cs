using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Strings.ParenthesisValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Strings
{
    [TestClass]
    public class ParenthesisValidatorTest
    {
        [TestMethod]
        public void CheckValidStringTest()
        {
            // Arrange:
            IParenthesisValidator parenthesisValidator = new SequentialParenthesisValidator();

            var inputObjects = new[]
            {
                new { Input = "(())((())()()(*)(*()(())())())()()((()())((()))(*", Output = false },
                new { Input = "", Output = true },
                new { Input = "()", Output = true },
                new { Input = "((*))", Output = true },
                new { Input = "(*))", Output = true },
                new { Input = "(*))", Output = true },
                new { Input = "(*()", Output = true },
                new { Input = "(*()", Output = true },
                new { Input = "*))", Output = false },
                new { Input = ")*()", Output = false },
                new { Input = Create(('(', 1000), ('*', 900), (')', 900)), Output = true },
                new { Input = Create(('(', 1000), ('*', 100), (')', 900)), Output = true },
                new { Input = Create(('*', 1000)), Output = true },
                new { Input = Create(('(', 1000), ('*', 99), (')', 900)), Output = false },
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var output = parenthesisValidator.CheckValidString(inputObject.Input);

                // Assert:
                Assert.AreEqual(inputObject.Output, output);
            }
        }

        private static string Create(params (char, int)[] chars) => Create((IEnumerable<(char, int)>)chars);
        private static string Create(IEnumerable<(char, int)> chars) => new string(CreateEnumerable(chars).ToArray());

        private static IEnumerable<char> CreateEnumerable(IEnumerable<(char, int)> chars)
        {
            foreach (var c in chars)
                for (int i = 0; i < c.Item2; ++i)
                    yield return c.Item1;
        }
    }
}
