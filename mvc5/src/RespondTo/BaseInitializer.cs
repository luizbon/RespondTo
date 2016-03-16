using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;

namespace RespondTo
{
    public abstract class BaseInitializer : IInitializer
    {
        public abstract string Extension { get; }

        public virtual void Initialize(RouteCollection routes)
        {
            var newRoutes = new Dictionary<int, System.Web.Routing.Route>();

            var index = 0;

            foreach (var routeBase in routes)
            {
                var route = routeBase as System.Web.Routing.Route;
                if (route != null && !route.Url.Contains("format"))
                {
                    try
                    {
                        var url = $"{route.Url}.{{format}}";
                        var constraints = new RouteValueDictionary(route.Constraints) {{"format", Extension}};
                        newRoutes.Add(index, new System.Web.Routing.Route(url, route.Defaults, constraints,
                            route.DataTokens,
                            route.RouteHandler));
                        index++;
                    }
                    catch (Exception e)
                    {
                        Debug.Print("Can't create route: {0}{1}\nwith error {2}", route.Url, Extension, e.Message);
                    }
                }
                index++;
            }

            foreach (var newRoute in newRoutes)
            {
                routes.Insert(newRoute.Key, newRoute.Value);
            }
        }

        public abstract ActionResult Execute(object model);
        public abstract bool Accept(NameValueCollection headers);
    }
}