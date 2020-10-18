using System;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlandArea.BL;

namespace Tests.Engine
{
    /// <summary>
    /// Summary description for TaskSchedulerTests
    /// </summary>
    [TestClass]
    public class TaskSchedulerTests
    {
        public TaskSchedulerTests()
        {
            
        }

        private void Task()
        {
            Console.WriteLine(DateTime.UtcNow.ToShortTimeString());
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            TaskScheduler.Instance.ScheduleTask(5000, 200, Task);

            while (true)
            {
                Console.WriteLine("Main " + DateTime.UtcNow.ToShortTimeString());
            }
        }
    }
}
