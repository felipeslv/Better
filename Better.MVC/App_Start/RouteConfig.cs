using System.Web.Mvc;
using System.Web.Routing;

namespace Better.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Estacionamentos", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
