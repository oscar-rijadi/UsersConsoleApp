using System;
using System.Runtime.Caching;

namespace UsersConsoleApp.Services.Cache
{
    public class MemoryCacheFactory
    {
        private static MemoryCacheFactory _instance;
        private MemoryCache Cache { get; set; }
        private static readonly object SyncObject = new object();
        private const string DefaultCacheName = "defaultMemoryCache";
        private string memoryCacheName;
        private MemoryCacheFactory Factory { get; set; }
        public static MemoryCacheFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new MemoryCacheFactory();
                        }
                    }
                }

                return _instance;
            }
        }

        public MemoryCache DefaultCache
        {
            get
            {
                return this.Cache ?? (this.Cache = this.GetCache());
            }
        }

        public static CacheItemPolicy MemoryCacheItemPolicy => new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10)
            };

        private string MemoryCacheName
        {
            get
            {
                if (!string.IsNullOrEmpty(this.memoryCacheName))
                {
                    return this.memoryCacheName;
                }
                
                if (string.IsNullOrEmpty(this.memoryCacheName))
                {
                    this.memoryCacheName = DefaultCacheName;
                }

                return this.memoryCacheName;
            }
        }

        private MemoryCache GetCache()
        {
            this.Cache = new MemoryCache(this.MemoryCacheName);
            return this.Cache;
        }
    }
}
