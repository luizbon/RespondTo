using System.Collections.Specialized;
using System.Web.Mvc;
using System.Web.Routing;

namespace RespondTo
{
    public interface IInitializer
    {
        string Extension { get; }
        void Initialize(RouteCollection routes);
        ActionResult Execute(object model);
        bool Accept(NameValueCollection headers);
    }
}