using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examples.Singleton;
using NUnit.Framework;

namespace Examples.Tests.Singleton
{
    [TestFixture]
    public class SingletonTests
    {
        [Test]
        public void SingletonCommonTest()
        {
            var db = SingletonDbExample.Instance;

            Assert.That(db.Sum(3, 12), Is.EqualTo(15));
        }
    }
}
