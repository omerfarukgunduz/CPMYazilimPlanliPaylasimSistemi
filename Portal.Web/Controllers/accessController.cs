using Microsoft.AspNetCore.Mvc;

namespace Portal.Web.Controllers
{
    public class accessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
