using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ODS;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestTemplate
    {
        public TestContext TestContext { set; get; }

        [TestMethod]
        [TestCase(10, 100)]
        public void TestCaseMethod()
        {
            TestContext.Run((int input, int except) =>
            {
                Assert.AreEqual(except, Math.Pow(input, 2));
            });
        }
    }
}
