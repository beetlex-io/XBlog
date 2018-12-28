using System;
using System.Collections.Generic;
using System.Text;
using BeetleX.FastHttpApi;
namespace BeetleX.Blog.Controller
{
    [Controller]
    public class Rewrite : IController
    {
        [NotAction]
        public void Init(HttpApiServer server)
        {
            server.Options.StaticResurceCacheTime = 60 * 5;
            server.UrlRewrite.Add("/cate/{0}.html", "/index.html", "html")
                .Add("/search/{0}.html", "/index.html", "html")
                 .Add("/tag/{0}.html", "/index.html", "html")
                  .Add("/blog/{0}.html", "/blog.html", "html")
                 ;
            server.ResourceCenter.FileResponse += (request, e) =>
            {
                if (e.Request.Ext == "jpg" || e.Request.Ext == "png")
                {
                    if (!server.Options.Debug)
                    {
                        e.Response.Header.Add(HeaderTypeFactory.CACHE_CONTROL, "public, max-age=60000");
                    }
                }
            };
        }
    }
}
