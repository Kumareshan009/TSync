using Future;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FutureTest
{
    [TestClass]
    public class PromiseTest
    {
        [TestMethod]
        public void SetAndGetTest()
        {
            Promise<int> promise = new Promise<int>();
            promise.Set(10);
            Assert.AreEqual(10, promise.Get());
        }

        [TestMethod]
        public void DuplicateSetException()
        {
            Promise<int> promise = new Promise<int>();
            promise.Set(10);
            Assert.ThrowsException<Exception>(() => promise.Set(3));
        }

        [TestMethod]
        public void GetAndSetTest()
        {
            Promise<int> promise = new Promise<int>();
            object lockObject = new object();
            new Task(() =>
            {
                Thread.Sleep(100);
                promise.Set(20);

            }).Start();
            Assert.AreEqual(20, promise.Get());
        }
    }
}
