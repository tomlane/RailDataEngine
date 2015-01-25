using System.Web.Mvc;

namespace RailDataEngine.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToActionPermanent("Index", "Help");
        }
    }
}
