using JobMarketPlace.Application.Common.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace JobMarketPlace.Infrastructure.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _cache;

        public RedisCacheService(
            IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T?> GetAsync<T>(
            string key)
        {
            var cached =
                await _cache.GetStringAsync(key);

            if (string.IsNullOrEmpty(cached))
                return default;

            return JsonSerializer.Deserialize<T>(
                cached);
        }

        public async Task SetAsync<T>(
            string key,
            T value,
            TimeSpan expiration)
        {
            var options =
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow =
                        expiration
                };

            var json =
                JsonSerializer.Serialize(value);

            await _cache.SetStringAsync(
                key,
                json,
                options);
        }

        public async Task RemoveAsync(
            string key)
        {
            await _cache.RemoveAsync(key);
        }
    }
}
