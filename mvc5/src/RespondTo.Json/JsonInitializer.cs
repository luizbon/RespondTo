using System.Collections.Specialized;
using System.Web.Mvc;
using JsonResult = Newtonsoft.JsonResult.JsonResult;

namespace RespondTo.Json
{
    public class JsonInitializer : BaseInitializer
    {
        public override string Extension => "json";

        public override ActionResult Execute(object model)
        {
            return new JsonResult
            {
                Data = model,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public override bool Accept(NameValueCollection headers)
        {
            var contentType = headers["Content-Type"];
            var accept = headers["accept"];

            return contentType == "application/json" || accept == "application/json";
        }
    }
}