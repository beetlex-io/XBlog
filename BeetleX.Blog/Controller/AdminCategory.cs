using BeetleX.FastHttpApi;
using System;
using System.Collections.Generic;
using System.Text;
using BeetleX.Blog.DBModules;
using System.Linq;
using Peanut;
namespace BeetleX.Blog.Controller
{
    [Controller(BaseUrl = "/admin/category")]
    [AdminFilter]
    public class AdminCategory
    {
        [Post]
        public void Add(string name, string remark)
        {
            if ((Category.name == name).Count<Category>() == 0)
            {
                Category category = new Category();
                category.Name = name;
                category.Remark = remark;
                category.Save();
            }
        }

        public void Order(long id, bool up)
        {
            Category item = DBContext.Load<Category>(id);
            if (item != null)
            {
                if (up)
                    item.OrderBy -= 1;
                else
                    item.OrderBy += 1;
                item.Save();
            }
        }

        public void Del(long id)
        {
            (Category.iD == id).Delete<Category>();
        }

        public object List()
        {
            var items = new Expression().List<Category>(Category.orderBy.Asc);
            return from a in items
                   select new { a.ID, a.Name, a.Remark };
        }
    }
}
