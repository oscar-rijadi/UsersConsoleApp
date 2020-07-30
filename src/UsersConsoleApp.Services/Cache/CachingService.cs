using System.Runtime.Caching;
using UsersConsoleApp.Interfaces;

namespace UsersConsoleApp.Services.Cache
{
    public class CachingService : ICachingService
    {
        private static object locker = new object();

        public CachingService(MemoryCache cache)
        {
            Cache = cache;
        }

        private MemoryCache Cache { get; set; }

        public void Set(string key, object value)
        {
            if (value == null)
            {
                return;
            }

            if (this.Get(key) == null)
            {
                lock (locker)
                {
                    if (this.Get(key) == null)
                    {
                        this.Cache.Add(key, value, MemoryCacheFactory.MemoryCacheItemPolicy);
                        return;
                    }
                }
            }

            this.Cache.Add(key, value, MemoryCacheFactory.MemoryCacheItemPolicy);
        }

        public T Get<T>(string key)
        {
            return (T)this.Get(key);
        }

        public object Get(string key)
        {
            var result = this.Cache.Get(key);

            return result;
        }

        public void Invalidate(string key)
        {
            this.Cache.Remove(key);
        }
    }
}
