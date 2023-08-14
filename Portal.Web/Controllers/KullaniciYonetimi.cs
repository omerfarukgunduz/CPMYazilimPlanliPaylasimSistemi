using Microsoft.AspNetCore.Mvc;
using Portal.Application.Repositories;
using Portal.Domain.Entities;

namespace Portal.Web.Controllers
{
    public class KullaniciYonetimi : Controller
    {
      
            readonly private IUserReadRepository _userReadRepository;

        public KullaniciYonetimi(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
        }

        readonly private IUserWriteRepository _userWriteRepository;

            public IActionResult Index()
        {
            return View();
        }

       

    }
}
