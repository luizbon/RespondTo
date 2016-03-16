using System.Web.Mvc;

namespace RespondTo.Mvc5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new { teste = "Hello World" });
        }
    }
}