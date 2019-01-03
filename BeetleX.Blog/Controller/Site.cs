using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeetleX.Blog.DBModules;
using BeetleX.Blog.ES;
using BeetleX.Elasticsearch.Search;
using BeetleX.FastHttpApi;
using Peanut;

namespace BeetleX.Blog.Controller
{
    [Controller]
    [ESExceptionFilter]
    public class Site : IController
    {
        [HttpCacheFilter(60 * 30)]
        [ActionCacehFilter("get_title_menus")]
        [SkipFilter(typeof(ESExceptionFilter))]
        public object GetTitleAndMenu()
        {
            string Version = typeof(Site).Assembly.GetName().Version.ToString();
            string Title = DBHelper.Default.Setting.Title.Value;
            var items = new Expression().List<Category>(Category.orderBy.Asc);
            var Menus = from a in items
                        select new { a.ID, a.Name };
            return new { Title, Menus, Version };
        }
        [HttpCacheFilter]
        [ActionCacehFilter("get_top_tags")]
        public object GetTags(int top)
        {
            top = 60;
            return ESHelper.Blog.Aggs<ESBlog>("group_by_tags", AggsType.terms, "Tags",
               t => t.Size(top));
        }
        [HttpCacheFilter]
        [ActionCacehFilter("get_all_tags")]
        public object GetAllTags()
        {
            int size = 1000;
            return ESHelper.Blog.Aggs<ESBlog>("group_by_tags", AggsType.terms, "Tags",
               t => t.Size(size));
        }
        [HttpCacheFilter(30)]
        [ActionCacehFilter("get_top_comment")]
        public object TopComment()
        {
            Expression exp = new Expression();
            var items = exp.List<TopComment>(new Region(0, 20), Comment.createTime.At().Desc);
            return from a in items select new { a.ID, a.NickName, a.Title, a.Content, CreateTime = a.CreateTime.ToString() };
        }
        [HttpCacheFilter]
        [ActionCacehFilter("get_top_blog")]
        public object TopBlog()
        {
            var items = ESHelper.Blog.Query<ESBlog>(q => q.OrderBy("CreateTime", OrderType.desc).Term("Top", "true"), 0, 15);
            return from a in items select new { a.ID, a.Title };
        }
        [HttpCacheFilter]
        [ActionCacehFilter("get_new_blog")]
        public object NewBlog()
        {
            var item = ESHelper.Blog.Query<ESBlog>(q => q.OrderBy("CreateTime", OrderType.desc), 0, 15);
            return from a in item select new { a.ID, a.Title };
        }

        [HttpCacheFilter]
        public object GetAbout()
        {
            return DBHelper.Default.Setting.About.Value;
        }

        public object ListCommint(long id)
        {
            var commints = (DBModules.Comment.blogID == id).List<DBModules.Comment>(DBModules.Comment.createTime.Asc);
            return from a in commints select new { a.NickName, a.Content, CreateTime = a.CreateTime.ToString() };
        }

        public object GetPhoto(int id)
        {
            var items = (PhotoItem.photoID == id).List<PhotoItem>();
            return from a in items select new { a.LargeUrl };
        }

        [HttpCacheFilter]
        public object ListPhoto(int index)
        {
            int size = 40;
            Expression expression = new Expression();
            int Count = expression.Count<Photo>();
            int Pages = Count / size;
            if (Count % size > 0)
                Pages++;
            var items = expression.List<Photo>(new Region(index, size), Photo.createTime.Desc);
            var Items = from a in items
                        select new
                        {
                            a.ID,
                            a.Title,
                            CreateTime = a.CreateTime.ToShortDateString(),
                            SmallUrl = Blog.Units.GetImageUrl(a.SmallUrl)
                        };
            return new { Count, Pages, Items };
        }

        [Post]
        public object Commint(long id, string nickName, string content, HttpRequest request, HttpResponse response)
        {
            string token = request.Cookies[COMMINT_TOKEN];
            if (token != Units.MD5Encrypt(id.ToString() + DateTime.Now.Date))
            {
                return new ActionResult(500, "凭证无效，无法提交数据!");
            }
            else
            {
                response.SetCookie("_nickName", nickName, DateTime.Now.AddYears(1));
                DBModules.Comment comment = new Comment();
                comment.BlogID = id;
                comment.NickName = nickName;
                comment.Content = content;
                comment.Save();
            }
            return true;
        }

        private const string COMMINT_TOKEN = "COMMINT_TOKEN";
        [HttpCacheFilter]
        public object GetBlog(long id, HttpResponse response, HttpRequest request)
        {
            DBModules.Blog blog = DBContext.Load<DBModules.Blog>(id);
            if (blog != null)
            {
                string token = Units.MD5Encrypt(id.ToString() + DateTime.Now.Date);
                response.SetCookie(COMMINT_TOKEN, token, DateTime.Now.AddMinutes(10));
                return new
                {
                    blog.ID,
                    blog.Title,
                    blog.Category,
                    blog.CategoryID,
                    blog.Content,
                    Tags = string.IsNullOrEmpty(blog.Tags) ? new string[0] : blog.Tags.Split(' ', StringSplitOptions.RemoveEmptyEntries),
                    blog.SourceUrl,
                    CreateTime = blog.CreateTime.ToString(),
                    NickName = request.Cookies["_nickName"]
                };
            }
            return new object();
        }
        [NotAction]
        public void Init(HttpApiServer server)
        {
            mServer = server;
        }

        private HttpApiServer mServer;
        [SkipFilter(typeof(ESExceptionFilter))]
        public object GetServerInfo()
        {
            if (mServer.ServerCounter != null)
                return mServer.ServerCounter.Next();
            return new object();
        }

        public object Search(long cate, string tag, string query, int index)
        {
            int size = 15;
            int start = size * index;
            int count = 0;
            IList<ESBlog> esItems;
            IQuery esQuery = ESHelper.Blog.CreateQuery();
            if (!string.IsNullOrEmpty(query))
            {
                var ws = ESHelper.Blog.Analyze(query, Elasticsearch.AnalyzerType.ik_smart);
                foreach (var k in ws)
                {
                    if (k.Length >= 2 || k.ToLower() == "c")
                    {
                        esQuery.Bool.Must.Term("Content", k);
                    }
                }
                //  esQuery.Bool.ShouldMatch(1);
                esQuery.Bool.Should.Terms("Title", ws);

            }
            else if (!string.IsNullOrEmpty(tag))
            {
                esQuery.Bool.Must.Term("Tags", tag);
                esQuery.OrderBy("CreateTime", OrderType.desc);
            }
            else if (cate > 0)
            {
                esQuery.Bool.Must.Term("CategoryID", cate.ToString());
                esQuery.OrderBy("CreateTime", OrderType.desc);
            }
            else
            {
                esQuery.OrderBy("CreateTime", OrderType.desc);
            }
            esItems = esQuery.List<ESBlog>(start, size, out count);
            int Pages = count / size;
            if (count % size > 0)
                Pages++;
            if (Pages > 100)
                Pages = 100;
            var Items = from a in esItems
                        select new
                        {
                            a.ID,
                            a.Title,
                            a.Summary,
                            a.SourceUrl,
                            Tags = string.IsNullOrEmpty(a.Tags) ? new string[0] : a.Tags.Split(' ', StringSplitOptions.RemoveEmptyEntries),
                            a.Category,
                            a.CategoryID,
                            CreateTime = a.CreateTime.ToString()

                        };
            return new { Pages, Items, Count = count };
        }


    }
}
