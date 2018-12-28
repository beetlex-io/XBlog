using System;
using System.Collections.Generic;
using System.Text;
using BeetleX.FastHttpApi;

namespace BeetleX.Blog.Controller
{
    public class TokenFilter : FastHttpApi.FilterAttribute
    {
        public override bool Executing(ActionContext context)
        {
            var user = JWTHelper.Default.GetUserInfo(context.HttpContext.Request);
            if (user == null)
            {
                var result = new ActionResult(403, "没限操作资源");
                result.Data = "/admin/login.html";
                context.Result = result;
                return false;
            }
            else
            {
                context.HttpContext.Data.SetValue("_userName", user.Name);
                context.HttpContext.Data.SetValue("_userRole", user.Role);
            }
            return true;
        }
    }

    public class AdminFilter : TokenFilter
    {
        public override bool Executing(ActionContext context)
        {
            if (base.Executing(context))
            {
                string name = context.HttpContext.Data["_userRole"];
                if (name != "admin")
                {
                    var result = new ActionResult(403, "没限操作资源");
                    result.Data = "/admin/login.html";
                    context.Result = result;
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
