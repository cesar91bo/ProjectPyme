using System.Web.Mvc;
using VideoCableWeb.Filters;

namespace VideoCableWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
            filters.Add(new SessionExpireFilterAttribute());
        }
    }
}
