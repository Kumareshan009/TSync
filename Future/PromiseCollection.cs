using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Future
{
    public class PromiseCollection<T> : IPromiseCollection<T>
    {
        private IDictionary<string, IPromise<T>> collections = new ConcurrentDictionary<string, IPromise<T>>();

        public IPromise<T> this[string key]
        {
            get
            {
                if (!collections.ContainsKey(key))
                {
                    throw new System.Exception("Promise not found for the key " + key);
                }
                return collections[key];
            }
            set
            {
                collections[key] = value;
            }
        }

        public int Count => collections.Count;

        public bool IsReadOnly => collections.IsReadOnly;

        public void Add(string key, IPromise<T> promise)
        {
            collections.Add(key, promise);
        }

        public void Add(KeyValuePair<string, IPromise<T>> item)
        {
            collections.Add(item);
        }

        public void Clear()
        {
            collections.Clear();
        }

        public bool Contains(KeyValuePair<string, IPromise<T>> item)
        {
            return collections.Contains(item);
        }

        public bool ContainsKey(string key)
        {
            return collections.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, IPromise<T>>[] array, int arrayIndex)
        {
            collections.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<string, IPromise<T>>> GetEnumerator()
        {
            return collections.GetEnumerator();
        }

        public bool Remove(KeyValuePair<string, IPromise<T>> item)
        {
            return collections.Remove(item);
        }

        public bool Remove(string key)
        {
            return collections.Remove(key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return collections.GetEnumerator();
        }

        public IPromise<T> RemoveAndGet(string key)
        {
            var item = this[key];
            Remove(key);
            return item;
        }

    }
}
