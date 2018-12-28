using System;
using System.Collections.Generic;
using System.Text;
using Peanut;
namespace BeetleX.Blog.ES
{
    public class ESHelper
    {
        public static bool Available { get; set; }

        public static Elasticsearch.ESDB DB { get; set; }

        public static Elasticsearch.Core.IESIndex Blog { get; set; }

        public static Exception InitError { get; set; }

        public static void ReCreateIndex()
        {
            DB.DeleteIndex("beetlex");
            Blog = DB.GetIndexAndCreate("beetlex");
            Blog.CreateType<ESBlog>();
        }

        public static void Init(string host)
        {

            try
            {
                Blog = null;
                Available = true;
                InitError = null;
                DB = new Elasticsearch.ESDB(host);
                DB.Status();
                Blog = DB.GetIndexAndCreate("beetlex");
                Blog.CreateType<ESBlog>();
                Available = true;
            }
            catch (Exception e_)
            {
                Available = false;
                InitError = e_;
            }
        }

        private static void OnSyncData(object state)
        {
            BeetleX.FastHttpApi.HttpApiServer server = (BeetleX.FastHttpApi.HttpApiServer)state;
            if (!Available)
                return;
            mSyncTimer.Change(-1, -1);
            try
            {
                foreach (var item in new Peanut.Expression().List<DBModules.RefreshBlog>())
                {
                    if (item.Status == 1)
                    {
                        DBModules.Blog blog = Peanut.DBContext.Load<DBModules.Blog>(item.BlogID);
                        if (blog != null)
                        {

                            ES.ESBlog eSBlog = new ESBlog();
                            eSBlog.ID = blog.ID.ToString();
                            eSBlog.CategoryID = blog.CategoryID;
                            eSBlog.Content = blog.Content;
                            eSBlog.CreateTime = blog.CreateTime;
                            eSBlog.SourceUrl = blog.SourceUrl;
                            eSBlog.Summary = blog.Summary;
                            eSBlog.Category = blog.Category;
                            eSBlog.Tags = blog.Tags;
                            eSBlog.Title = blog.Title;
                            eSBlog.Top = blog.Top;
                            Blog.Put(eSBlog);

                            (DBModules.RefreshBlog.blogID == blog.ID).Delete<DBModules.RefreshBlog>();
                            if (server.EnableLog(EventArgs.LogType.Info))
                                server.Log(EventArgs.LogType.Info, $"update blog {blog.Title} sync to elasticsearch  success");

                        }
                    }
                    else
                    {
                        (DBModules.RefreshBlog.blogID == item.BlogID).Delete<DBModules.RefreshBlog>();
                        try
                        {
                            Blog.Delete<ESBlog>(item.BlogID.ToString());
                            if (server.EnableLog(EventArgs.LogType.Info))
                                server.Log(EventArgs.LogType.Info, $"delete blog {item.BlogID} sync to elasticsearch  success");
                        }
                        catch (Exception e_)
                        {
                            if (server.EnableLog(EventArgs.LogType.Error))
                                server.Log(EventArgs.LogType.Error, $"delete blog {item.BlogID} sync to elasticsearch  error {e_.Message}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                if (server.EnableLog(EventArgs.LogType.Error))
                    server.Log(EventArgs.LogType.Error, $"blog sync to elasticsearch error {e.Message}");
            }
            finally
            {
                mSyncTimer.Change(5000, 5000);
            }
        }

        private static System.Threading.Timer mSyncTimer;

        public static void SyncData(BeetleX.FastHttpApi.HttpApiServer server)
        {
            mSyncTimer = new System.Threading.Timer(OnSyncData, server, 5000, 5000);
        }
    }
}
