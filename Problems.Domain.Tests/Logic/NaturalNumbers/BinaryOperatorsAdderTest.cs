using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.NaturalNumbers.BinaryOperatorsAdder;
using Problems.Domain.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.NaturalNumbers
{
    [TestClass]
    public class BinaryOperatorsAdderTest
    {
        [TestMethod]
        public void BinaryOperatorsAdder_AddOperators_Test()
        {
            // Arrange:

            //IBinaryOperatorsAdder binaryOperatorsAdder = new BinaryOperatorsAdder();

            var inputObjects = new[]
            {
                new { Num = "123", Target = 6, Output = new[] { "1+2+3", "1*2*3" } },
                new { Num = "232", Target = 8, Output = new[] { "2*3+2", "2+3*2" } },
                new { Num = "105", Target = 5, Output = new[] { "1*0+5", "10-5" } },
                new { Num = "00", Target = 0, Output = new[] { "0+0", "0-0", "0*0" } },
                new { Num = "3456237490", Target = 9191, Output = new[] { "0+0", "0-0", "0*0" } },
            };

            foreach (var inputObject in inputObjects)
            {
                //// Act:
                //var output = binaryOperatorsAdder.AddOperators(inputObject.Num, inputObject.Target);

                //// Assert:
                //AssertUtil.AssertCollection(
                //    inputObject.Output.OrderBy(o => o),
                //    output.OrderBy(o => o));
            }
        }
    }
}
