using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;

namespace BeetleX.Blog
{
    public class CacheHelper
    {

        private static ConcurrentDictionary<string, CacheItem> mCache = new ConcurrentDictionary<string, CacheItem>();

        public static object Get(string key)
        {
            if (mCache.TryGetValue(key, out CacheItem item))
            {
                if (TimeWatch.GetTotalSeconds() > item.ActiveTime)
                {
                    return null;
                }
                return item.Data;
            }
            return null;
        }

        public static T Get<T>(string key)
        {
            return (T)Get(key);
        }

        public static void Set(string key, object data, double seconds = 60)
        {
            CacheItem item = new CacheItem();
            item.Data = data;
            item.ActiveTime = TimeWatch.GetTotalSeconds() + seconds;
            mCache[key] = item;
        }

        class CacheItem
        {
            public object Data { get; set; }

            public double ActiveTime { get; set; }
        }
    }
}
