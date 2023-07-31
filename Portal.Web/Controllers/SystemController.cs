using Microsoft.AspNetCore.Mvc;
using Portal.Application.Repositories;
using Portal.Infrastructure;

namespace Portal.Web.Controllers
{
    public class SystemController : Controller
    {
        

        public IActionResult Chose()
        {
            return View();
        }
    }
}
