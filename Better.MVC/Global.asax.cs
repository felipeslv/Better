using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Better.MVC.AutoMapper;

namespace Better.MVC
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            AutoMapperConfig.RegisterMappings();
        }
    }
}
