using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebCore.Core.Authorization
{
    public class AuthorizeCheck : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            //foreach(var item in )
            var _request = context.Filters;
        }
    }
}
