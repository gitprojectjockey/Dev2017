using System;
using System.Runtime.Caching;
using OnlineShoppingStore.Domain.Abstract;

namespace OnlineShoppingStore.Domain.Concrete
{

    // Cache handler uses generics and System.Runtime memory cacheing API to cache any object to memory for the specified duration in milliseconds.
    // The class constaint only allows reference types and not primitive types to be cached.
    // If cache result returns null then the anonymous call back function is executed to fill or refill the cache.

    public class InMemoryCache : ICacheService
    {
        private readonly double _cacheDurationMilliseconds;
        public InMemoryCache(double cacheDurationMilliseconds)
        {
            _cacheDurationMilliseconds = cacheDurationMilliseconds;
        }

        public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;
            if (item == null)
            {
                item = getItemCallback();
                MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMilliseconds(_cacheDurationMilliseconds));
            }
            return item;
        }
    }
}
