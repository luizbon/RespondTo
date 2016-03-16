using System.Web.Mvc;
using System.Web.Routing;

namespace RespondTo
{
    public class Builder
    {
        private readonly GlobalFilterCollection _filters;
        private readonly RouteCollection _routes;

        public Builder(RouteCollection routes, GlobalFilterCollection filters)
        {
            _routes = routes;
            _filters = filters;
        }

        public void Register()
        {
            foreach (var initializer in Initializers.All)
            {
                initializer.Initialize(_routes);
            }

            _filters.Add(new RespondToFilter());
        }
    }
}