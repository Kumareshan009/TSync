using Future;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace FutureTest
{
    [TestClass]
    public class SingleTonPromiseCollectionTest
    {
        [TestMethod]
        public void SingleTonTest()
        {
            Assert.IsInstanceOfType(SingleTonPromiseCollection<int>.Instance, typeof(IPromiseCollection<int>));
            Assert.AreEqual(SingleTonPromiseCollection<int>.Instance, SingleTonPromiseCollection<int>.Instance);
        }

        [TestMethod]
        public void MulitThreadSingleTonTest()
        {
            Task[] t = new Task[5];
            for (int i = 0; i < 5; i++)
            {
                t[i] = Task.Run(() =>
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Assert.AreEqual(SingleTonPromiseCollection<int>.Instance, SingleTonPromiseCollection<int>.Instance);
                    }
                });
            }

            Task.WaitAll(t);

        }
    }
}
