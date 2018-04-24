using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Performance
{
    [TestClass]
    public class DelegateTest
    {
        [TestMethod]
        public void ClosureTest()
        {
            Action action, nestedAction1, nestedAction2;
            nestedAction1 = () => { };
            nestedAction2 = () => { };
            action = () =>
            {
                nestedAction2();
            };
            action();
        }
    }
}
