using System.Web.Mvc;
using System.Web.Routing;

namespace RespondTo.Mvc5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.Add(new System.Web.Routing.Route("{controller}/{action}/{id}.json", new RouteValueDictionary(new
            //{
            //    controller = "Home",
            //    action = "intex",
            //    id = UrlParameter.Optional
            //}), null));

            //routes.MapRoute("Default.json", "{controller}/{action}/{id}.json",
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //    );

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}