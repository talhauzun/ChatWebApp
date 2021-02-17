using ChatWebApp.Helpers;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWebApp.Data
{
    public static class RedisCacheManager 
    {
      
        public static T Get<T>(this IDistributedCache distributedCache, string key)
        {
            var rValue =distributedCache.GetAsync(key);
            if (rValue.Result == null)
                return default(T);

            var result = Extention.Format<T>(Encoding.UTF8.GetString(rValue.Result));
            return result;
        }

        public static async Task SetDataAsync(this IDistributedCache distributedCache, string key, object data, int cacheTime)
        {
            var encodedData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
            var options = new DistributedCacheEntryOptions()
                            .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                            .SetAbsoluteExpiration(DateTime.Now.AddMinutes(cacheTime));

            await distributedCache.SetAsync(key, encodedData, options);
        }

      
      
    }
}
