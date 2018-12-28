using System;
using System.Collections.Generic;
using System.Text;
using BeetleX.FastHttpApi;
namespace BeetleX.Blog.Controller
{
    public class ESExceptionFilter : FilterAttribute
    {
        public override bool Executing(ActionContext context)
        {
            if (ES.ESHelper.Blog == null)
            {
                context.Result = new ActionResult(500, "检测不到Elastic search服务，请在管理中配置相关服务地址！");
                return false;
            }
            return base.Executing(context);
        }
    }
}
