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

        [TestMethod]
        public void TestQueue()
        {
            ArrayQueue<int> target = new ArrayQueue<int>(3);

            for(int i = 0;i < 10; i++)
            {
                target.Enqueue(i);
            }

            int size = target.getQueueSize();

            for(int i = 0;i < size; i++)
            {
                Assert.AreEqual(i, target.Dequeue());
            }
        }
    }
}
