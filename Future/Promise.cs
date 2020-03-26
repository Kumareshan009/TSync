using System.Threading;

namespace Future
{
    public class Promise<T> : PromiseBase<T>
    {
        protected override void Wait(object lockObject)
        {
            Monitor.Wait(lockObject);
        }
    }
}
