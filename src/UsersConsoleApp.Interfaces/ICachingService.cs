namespace UsersConsoleApp.Interfaces
{
    public interface ICachingService
    {
        void Set(string key, object value);

        T Get<T>(string key);

        object Get(string key);

        void Invalidate(string key);
    }
}
