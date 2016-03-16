using System.Web.Mvc;
using System.Web.Routing;

namespace RespondTo
{
    public static class Route
    {
        private static Builder _builder;

        public static Builder RespondTo => _builder ?? (_builder = new Builder(RouteTable.Routes, GlobalFilters.Filters));
    }
}