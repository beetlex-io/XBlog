using System;
using System.Collections.Generic;
using System.Text;
using BeetleX.FastHttpApi;
using Peanut;
using BeetleX.Blog.DBModules;
using System.Linq;
namespace BeetleX.Blog.Controller
{
    [Controller(BaseUrl = "/admin/blog")]
    [AdminFilter]
    public class AdminBlog
    {
        [Post]
        public void Modify(long id, string title, bool top, string tag, long category, string sourceUrl, string content,
            string summary)
        {
            DBModules.Blog item;
            if (id > 0)
            {
                item = DBContext.Load<DBModules.Blog>(id);
            }
            else
            {
                item = new DBModules.Blog();
            }
            if (item != null)
            {
                item.Title = title;
                item.Top = top;
                item.Tags = tag;
                item.CategoryID = category;
                Category cate = DBContext.Load<Category>(category);
                if (cate != null)
                    item.Category = cate.Name;
                item.SourceUrl = sourceUrl;
                item.Content = content;
                item.Summary = summary;
                item.Save();
                RefreshBlog refreshBlog = new RefreshBlog();
                refreshBlog.BlogID = item.ID;
                refreshBlog.Status = 1;
                refreshBlog.Save();
            }
        }

        public void AllSyncToES()
        {
            foreach (DBModules.Blog item in new Expression().List<DBModules.Blog>())
            {
                RefreshBlog refreshBlog = new RefreshBlog();
                refreshBlog.BlogID = item.ID;
                refreshBlog.Status = 1;
                refreshBlog.Save();
            }
        }

        [Post]
        public void Delete(long[] id)
        {
            if (id != null && id.Length > 0)
            {
                (DBModules.Blog.iD == id).Delete<DBModules.Blog>();
                (DBModules.Comment.blogID == id).Delete<DBModules.Comment>();
                foreach (var item in id)
                {
                    RefreshBlog refreshBlog = new RefreshBlog();
                    refreshBlog.BlogID = item;
                    refreshBlog.Status = 0;
                    refreshBlog.Save();
                }
            }
        }

        public object Get(long id)
        {
            var item = DBContext.Load<DBModules.Blog>(id);
            if (item != null)
                return new { item.ID, item.Title, item.Content, item.CategoryID, item.SourceUrl, item.Tags, item.Top };
            return new object();
        }

        public Object List(long category, int index)
        {
            int size = 15;
            Expression exp = new Expression();
            if (category > 0)
                exp &= DBModules.Blog.categoryID == category;
            int count = exp.Count<DBModules.Blog>();
            int pages = count / size;
            if (count % size > 0)
                pages++;
            var datas = exp.List<DBModules.Blog>(new Region(index, size), DBModules.Blog.createTime.Desc);
            var items = from a in datas select new { a.ID, a.Title, a.Category, a.Top, CreateTime = a.CreateTime.ToString() };
            return new { Index = index, Pages = pages, Items = items };
        }
    }
}
