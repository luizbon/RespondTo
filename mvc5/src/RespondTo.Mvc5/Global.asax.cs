using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RespondTo.Mvc5
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Route.RespondTo.Json().Xml().Register();
        }
    }
}