using System;
using System.Text;
using System.Web.Mvc;

namespace RespondTo.Xml
{
    public class XmlResult : ActionResult
    {
        public object Data { get; set; }

        public Encoding ContentEncoding { get; set; }

        public string ContentType { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            var response = context.HttpContext.Response;
            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "text/xml";
            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            context.HttpContext.Response.Write(Data.ToXml());
        }
    }
}