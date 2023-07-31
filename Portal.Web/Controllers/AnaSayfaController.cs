using Microsoft.AspNetCore.Mvc;
using Portal.Application.Repositories;
using Portal.Infrastructure;

namespace Portal.Web.Controllers
{
    public class AnaSayfaController : Controller
    {
        readonly private IUserReadRepository _userReadRepository;
        readonly private IUserWriteRepository _userWriteRepository;

        readonly private ICelebrationDayReadRepository _celebrationDayReadRepository;
        readonly private ICelebrationDayWriteRepository _celebrationDayWriteRepository;

        public AnaSayfaController(IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository, ICelebrationDayReadRepository celebrationDayReadRepository, ICelebrationDayWriteRepository celebrationDayWriteRepository)
        {
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
            _celebrationDayReadRepository = celebrationDayReadRepository;
            _celebrationDayWriteRepository = celebrationDayWriteRepository;
        }


        public IActionResult AnaSayfa()
        {
            return View();
        }
        public IActionResult feedback() 
        { 
            return View();
        }
        public IActionResult Login() 
        {
            return View();
        }
        public IActionResult Apply(UserInMemory model)
        {
            var datas = _userReadRepository.GetAll();
            foreach (var data in datas)
            {
                if (data.UserName == model.UserName)
                {
                    if (data.Password == model.Password)
                    {
                        return RedirectToAction("AnaSayfa");
                    }

                }
            }
            return View("feedback");
        }
    }
}
