using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Strings.ParenthesisValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GU = Problems.Domain.Tests.Utils.GenericUtil;

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
                new { Input = GU.CreateString(('(', 1000), ('*', 900), (')', 900)), Output = true },
                new { Input = GU.CreateString(('(', 1000), ('*', 100), (')', 900)), Output = true },
                new { Input = GU.CreateString(('*', 1000)), Output = true },
                new { Input = GU.CreateString(('(', 1000), ('*', 99), (')', 900)), Output = false },
            };

            foreach (var inputObject in inputObjects)
            {
                // Act:
                var output = parenthesisValidator.CheckValidString(inputObject.Input);

                // Assert:
                Assert.AreEqual(inputObject.Output, output);
            }
        }
    }
}
