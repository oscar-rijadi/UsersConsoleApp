using NUnit.Framework;
using UsersConsoleApp.Services.Cache;
using System.Runtime.Caching;

namespace UsersConsoleApp.Services.Tests
{
    [TestFixture(Category = "Unit")]
    public class CachingServiceFixture
    {
        private CachingService _cachingService;
        private MemoryCache _memoryCache;

        [SetUp]
        public void SetUp()
        {
            _memoryCache = new MemoryCache("testMemoryCache");
            _cachingService = new CachingService(_memoryCache);
        }

        [Test]
        public void Get_WillReturnNullIfNoCacheBasedOnThatKey()
        {
            // arrange
            var key = "testKey";

            // act
            var result = _cachingService.Get(key);

            // assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void Get_WillReturnValueIfCacheFoundBasedOnThatKey()
        {
            // arrange
            var key = "testKey";
            var cacheValue = "testValue";
            _cachingService.Set(key, cacheValue);

            // act
            var result = _cachingService.Get(key);

            // assert
            Assert.AreEqual(cacheValue, result);
        }
    }
}
