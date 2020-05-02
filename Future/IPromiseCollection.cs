using System.Collections.Generic;

namespace Future
{
    public interface IPromiseCollection<T> : ICollection<KeyValuePair<string, IPromise<T>>>, IEnumerable<KeyValuePair<string, IPromise<T>>>
    {
        void Add(string key, IPromise<T> promise);

        IPromise<T> this[string key] { get; set; }

        bool Remove(string key);

        bool ContainsKey(string key);

        IPromise<T> RemoveAndGet(string key);
    }
}
