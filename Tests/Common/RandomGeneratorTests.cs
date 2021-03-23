using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlandAreaCommon.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlandAreaCommon.Common.Tests
{
    [TestClass()]
    public class RandomGeneratorTests
    {
        [TestMethod()]
        public void GetIntegerTest()
        {

            var result = RandomGenerator.GetInteger(-10, -1);

            Assert.IsTrue(result < 0);

        }
    }
}