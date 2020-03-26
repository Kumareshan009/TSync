using Future;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FutureTest
{
    [TestClass]
    public class TimedPromiseTest
    {
        [TestMethod]
        public void GetWithinTimeOutTest()
        {
            TimedPromise<int> promise = new TimedPromise<int>(TimeSpan.FromSeconds(5));
            new Task(() =>
            {
                Thread.Sleep(100);
                promise.Set(34);
            }).Start();
            Assert.AreEqual(34, promise.Get());
        }

        [TestMethod]
        public void TimeOutExceptionTest()
        {
            TimedPromise<int> promise = new TimedPromise<int>(TimeSpan.FromMilliseconds(100));
            Assert.ThrowsException<TimeoutException>(() => promise.Get());
        }
    }
}
