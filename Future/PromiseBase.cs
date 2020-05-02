using System.Threading;
using System;

namespace Future
{
    public abstract class PromiseBase<T> : IPromise<T>
    {
        private object lockObject = new object();
        private T value;

        public bool IsValueReady
        {
            get;
            protected set;
        }
        public T Get()
        {
            lock (lockObject)
            {
                if (!IsValueReady)
                {
                    Wait(lockObject);
                }
                return value;
            }
        }

        public void Set(T value)
        {
            lock (lockObject)
            {
                if (IsValueReady)
                {
                    throw new Exception("Value cannot be set more than once");
                }
                else
                {
                    IsValueReady = true;
                    this.value = value;
                    Monitor.Pulse(lockObject);
                }
            }
        }

        protected abstract void Wait(object lockObject);

    }
}
