namespace Future
{
    public interface IPromise<T>
    {
        void Set(T value);

        T Get();
    }
}
