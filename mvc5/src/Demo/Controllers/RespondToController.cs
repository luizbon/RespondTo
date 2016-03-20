using System.Linq;
using System.Web.Mvc;
using Demo.Models;
using PagedList;
using Ploeh.AutoFixture;

namespace Demo.Controllers
{
    public class RespondToController : Controller
    {
        // GET: RespondTo
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var fixture = new Fixture();
            var list = fixture.CreateMany<string>(100);
            var paged = list.ToPagedList(page, pageSize);
            
            
            return View(new RespondToViewModel
            {
                Items = paged.ToList(),
                HasNextPage = paged.HasNextPage ? 1 :0,
                HasPrevPage = paged.HasPreviousPage ? 1 : 0,
                CurrentPage = paged.PageNumber,
                PageSize = paged.PageSize,
                TotalPages = paged.PageCount
            });
        }
    }
}