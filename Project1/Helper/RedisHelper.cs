using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project1.Helper
{
    public static class RedisHelper
    {
        public static async Task WrirteToRedis<T>(this IDistributedCache cache,
            string recordId,
            T data,
            TimeSpan? expireTime =null,
            TimeSpan? unusedTime =null)
        {

            var options = new DistributedCacheEntryOptions();

            options.AbsoluteExpirationRelativeToNow = expireTime ?? TimeSpan.FromSeconds(60);
            options.SlidingExpiration = unusedTime;

            var jsonData = JsonSerializer.Serialize(data);
            await cache.SetStringAsync(recordId, jsonData, options);
        }
    }
}
