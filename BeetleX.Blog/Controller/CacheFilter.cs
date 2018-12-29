using System;
using System.Collections.Generic;
using System.Text;
using BeetleX.FastHttpApi;
namespace BeetleX.Blog.Controller
{
    public class HttpCacheFilter : FilterAttribute
    {
        public HttpCacheFilter(int seconds = 300)
        {
            Seconds = seconds;
        }

        public int Seconds { get; set; }

        public override void Executed(ActionContext context)
        {
            base.Executed(context);
            if (!context.HttpContext.Server.Options.Debug)
            {
                if (!context.HttpContext.WebSocket)
                {
                    context.HttpContext.Response.Header.Add(HeaderTypeFactory.CACHE_CONTROL, "public, max-age=" + Seconds);
                }
            }
        }
    }

    public class ActionCacehFilter : FilterAttribute
    {

        public ActionCacehFilter(string key, double seconds = 60)
        {
            Key = key;
            Seconds = seconds;
        }

        public string Key { get; set; }

        public double Seconds { get; set; }

        public override bool Executing(ActionContext context)
        {
            if (context.HttpContext.Server.Options.Debug)
                return true;
            object result = CacheHelper.Get(Key);
            if (result != null)
            {
                context.Result = result;
                return false;
            }
            return base.Executing(context);
        }

        public override void Executed(ActionContext context)
        {
            base.Executed(context);
            CacheHelper.Set(Key, context.Result, Seconds);
        }
    }

}
