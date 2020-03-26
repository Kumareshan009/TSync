using System;
using System.Threading;

namespace Future
{
    public class TimedPromise<T> : PromiseBase<T>
    {
        private TimeSpan t;

        public TimedPromise(TimeSpan t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("Timespan expected to be not null");
            }
            this.t = t;
        }
        protected override void Wait(object lockObject)
        {
            Monitor.Wait(lockObject, t);
            if (!IsValueReady)
            {
                throw new TimeoutException("Value was not set with in specified time");
            }
        }
    }
}
