namespace Future
{
    public class SingleTonPromiseCollection<T> : PromiseCollection<T>
    {
        private static object lockObject = new object();
        private static IPromiseCollection<T> instance;

        public static IPromiseCollection<T> Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new SingleTonPromiseCollection<T>();
                        }
                    }
                }
                return instance;
            }
        }

    }
}
