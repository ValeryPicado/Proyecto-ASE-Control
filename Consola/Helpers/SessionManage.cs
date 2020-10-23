using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consola.Helpers
{
    public class SessionManage : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext context = HttpContext.Current;

            if (HttpContext.Current.Session["US"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                {
                    {"action", "Login" },
                    {"controller", "Login"},
                    {"returnUrl", filterContext.HttpContext.Request.RawUrl }
                });
                return;
            }

            base.OnActionExecuting(filterContext);
        }

    }
}