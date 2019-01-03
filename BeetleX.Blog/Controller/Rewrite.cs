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
                  .Add("/photos/{0}.html", "/photos.html", "html")
                 ;
            server.ResourceCenter.FileResponse += (request, e) =>
            {
                if (e.Request.Ext == "jpg" || e.Request.Ext == "png")
                {
                    if (!server.Options.Debug)
                    {
                        e.Response.Header.Add(HeaderTypeFactory.CACHE_CONTROL, "public, max-age=600000");
                    }
                }

            };

            #region init imagepath
            Units.ImagePath = server.Options.StaticResourcePath;
            if (Units.ImagePath[Units.ImagePath.Length - 1] != System.IO.Path.DirectorySeparatorChar)
                Units.ImagePath += System.IO.Path.DirectorySeparatorChar;
            Units.ImagePath += "images" + System.IO.Path.DirectorySeparatorChar;
            if (!System.IO.Directory.Exists(Units.ImagePath))
                System.IO.Directory.CreateDirectory(Units.ImagePath);
            for (int i = 0; i < 10; i++)
            {
                string subpath = Units.ImagePath + i.ToString("00");
                if (!System.IO.Directory.Exists(subpath))
                    System.IO.Directory.CreateDirectory(subpath);
            }
            #endregion
        }
    }
}
