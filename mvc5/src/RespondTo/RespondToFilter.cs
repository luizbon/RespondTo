using System.Diagnostics;
using System.Web.Mvc;

namespace RespondTo
{
    public class RespondToFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var extension = filterContext.RouteData.Values["format"] as string;
            if(extension != null)return;

            var formatter = Initializers.FindFormatter(filterContext.HttpContext.Request.Headers);
            if(formatter == null)return;

            filterContext.RouteData.Values["format"] = formatter.Extension;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var extension = filterContext.RouteData.Values["format"] as string;
            if (extension == null)
                return;

            var viewResult = filterContext.Result as ViewResult;
            if(viewResult == null)
                return;

            filterContext.Result = Initializers.Execute(extension, viewResult.Model);
        }
    }
}