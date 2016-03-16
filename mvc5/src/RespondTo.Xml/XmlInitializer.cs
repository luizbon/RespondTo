using System.Collections.Specialized;
using System.Web.Mvc;

namespace RespondTo.Xml
{
    public class XmlInitializer : BaseInitializer
    {
        public override string Extension => "xml";

        public override ActionResult Execute(object model)
        {
            return new XmlResult
            {
                Data = model
            };
        }

        public override bool Accept(NameValueCollection headers)
        {
            var contentType = headers["Content-Type"];
            var accept = headers["accept"];

            return contentType == "application/xml" || accept == "application/xml";
        }
    }
}