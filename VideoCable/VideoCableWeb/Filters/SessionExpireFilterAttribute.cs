using System.Web.Mvc;
using System.Web.Security;

namespace VideoCableWeb.Filters
{
    public class SessionExpireFilterAttribute : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {

            //RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();

            var context = filterContext.HttpContext;
            if (context.Session != null)
            {
                if (context.Session.IsNewSession)
                {
                    string sessionCookie = context.Request.Headers["Cookie"];

                    if ((sessionCookie != null) && (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        FormsAuthentication.SignOut();
                        string redirectTo = "~/Account/Login";
                        if (!string.IsNullOrEmpty(context.Request.RawUrl) && context.Request.RawUrl != "/Account/Login")
                        {
                            filterContext.Result = new RedirectResult(redirectTo);
                        }

                    }
                }

            }

            base.OnActionExecuting(filterContext);

        }

    }
}