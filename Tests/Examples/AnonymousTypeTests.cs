using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Examples
{
    [TestClass]
    public class AnonymousTypeTests
    {
        [TestMethod]
        public void AnonymousTypeTest()
        {

            var user = new { Name = "Tom", Age = 34 };

            var a = user.Name + " - ";
            var b = user.Age * 2;
        }
    }
}
