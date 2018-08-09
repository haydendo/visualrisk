using Risk.Models;
using System.Web.Mvc;

namespace Risk.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            var model = new NpvInputModel();
            return View(model);
        }
    }
}
