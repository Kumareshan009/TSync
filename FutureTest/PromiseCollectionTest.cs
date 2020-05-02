using Future;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FutureTest
{
    [TestClass]
    public class PromiseCollectionTest
    {
        [TestMethod]
        public void AddTest()
        {
            PromiseCollection<int> collection = new PromiseCollection<int>();
            collection.Add("first", new Promise<int>());
            Assert.AreEqual(1, collection.Count);
        }

        [TestMethod]
        public void IsReadonlyTest()
        {
            Assert.IsFalse(new PromiseCollection<int>().IsReadOnly);
        }

        [TestMethod]
        public void AddPairTest()
        {
            PromiseCollection<int> collection = GetCollection();
            Assert.AreEqual(1, collection.Count);
        }

        [TestMethod]
        public void ClearTest()
        {
            PromiseCollection<int> collection = GetCollection();
            collection.Clear();
            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        public void ContainsTest()
        {
            PromiseCollection<int> collection = GetCollection();
            Assert.IsTrue(collection.Contains(new KeyValuePair<string, IPromise<int>>("first", collection["first"])));
        }

        [TestMethod]
        public void ContainsKeyTest()
        {
            PromiseCollection<int> collection = GetCollection();
            Assert.IsTrue(collection.ContainsKey("first"));
        }

        [TestMethod]
        public void CopyToTest()
        {
            PromiseCollection<int> collection = GetCollection();
            KeyValuePair<string, IPromise<int>>[] array = new KeyValuePair<string, IPromise<int>>[1];
            collection.CopyTo(array, 0);
            Assert.AreEqual(collection.First(), array.First());
        }

        [TestMethod]
        public void GetEnumeratorTest()
        {
            PromiseCollection<int> collection = GetCollection();
            var obj = collection.GetEnumerator() as IEnumerator<KeyValuePair<string, IPromise<int>>>;
            Assert.IsNotNull(obj);
            IEnumerable e = collection;
            Assert.IsInstanceOfType(e.GetEnumerator(), typeof(IEnumerator));
        }

        [TestMethod]
        public void RemovePairTest()
        {
            PromiseCollection<int> collection = GetCollection();
            Assert.IsTrue(collection.Remove(new KeyValuePair<string, IPromise<int>>("first", collection["first"])));
            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        public void RemoveTest()
        {
            PromiseCollection<int> collection = GetCollection();
            Assert.IsTrue(collection.Remove("first"));
            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        public void RemoveAndGetTest()
        {
            PromiseCollection<int> collection = GetCollection();
            var pr = collection.RemoveAndGet("first");
            Assert.IsInstanceOfType(pr, typeof(IPromise<int>));
            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        public void IndexerTest()
        {
            PromiseCollection<int> collection = GetCollection();
            collection["second"] = new Promise<int>();
            var pr = collection["first"];
            Assert.IsInstanceOfType(pr, typeof(IPromise<int>));
            Assert.AreEqual(2, collection.Count);
        }

        [TestMethod]
        public void NotFoundExceptionTest()
        {
            PromiseCollection<int> collection = new PromiseCollection<int>();
            Assert.ThrowsException<Exception>(() => collection["f"]);
        }



        private PromiseCollection<int> GetCollection()
        {
            PromiseCollection<int> collection = new PromiseCollection<int>();
            collection.Add(new KeyValuePair<string, IPromise<int>>("first", new Promise<int>()));
            return collection;
        }
    }
}
