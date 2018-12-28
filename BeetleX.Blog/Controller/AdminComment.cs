using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeetleX.FastHttpApi;
using Peanut;
namespace BeetleX.Blog.Controller
{
    [Controller(BaseUrl = "/admin/comment")]
    [AdminFilter]
    public class AdminComment
    {
        public object List(int index)
        {
            int size = 15;
            Expression exp = new Expression();
            int Pages;
            int count = exp.Count<DBModules.Comment>();
            Pages = count / size;
            if (count % size > 0)
                Pages++;
            var items = exp.List<DBModules.TopComment>(new Region(index, size), DBModules.Comment.createTime.At().Desc);
            var Items = from a in items select new { a.ID, a.CommentID, a.Title, a.NickName, a.Content, CreateTime = a.CreateTime.ToString() };
            return new { Pages, Items };
        }

        public void Del(long[] id)
        {
            if (id != null && id.Length > 0)
            {
                (DBModules.Comment.iD == id).Delete<DBModules.Comment>();
            }
        }
    }
}
