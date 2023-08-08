using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Repositories;
using Portal.Domain.Entities;
using Portal.Infrastructure;
using Portal.Web.ViewModel;
using ServiceStack;
using System.Diagnostics;

namespace Portal.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly private IEtkinlikWriteRepository _etkinlikWriteRepository;
        readonly private IEtkinlikReadRepository _etkinlikReadRepository;
        readonly private IUserReadRepository _userReadRepository;
        readonly private IUserWriteRepository _userWriteRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository, IEtkinlikWriteRepository etkinlikWriteRepository, IEtkinlikReadRepository etkinlikReadRepository)
        {
            _logger = logger;
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
            _etkinlikWriteRepository = etkinlikWriteRepository;
            _etkinlikReadRepository = etkinlikReadRepository;
        }

        //========================================================================================================================

        
        public IActionResult GetList()
        {

            var data = _etkinlikReadRepository.GetAll();


            return Json(data);
        }



        public IActionResult _mdletkinlikekleicerik()
        {

            return PartialView("~/Views/PartialView/_mdletkinlikekleicerik.cshtml");
        }

        public PartialViewResult PartialEtkinlikkaydet()
        {
            return PartialView();
        }



        //-------------------------------------------------------------

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(HomeIndexViewModel model)
        {
            if(string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password))
                return View(new HomeIndexViewModel { UserName = model.UserName, HasError = true, Error = "Kullanıcı adı ve şifre alanları boş olamaz!" });

            var datas = _userReadRepository.GetAll();
            var dataSearch = datas.Where(elm => elm.UserName == model.UserName && elm.Password == model.Password);

            if (dataSearch.Count() == 1)
            {
                model.Id = dataSearch.First().Id;
                //Console.WriteLine(model.Id);
                return RedirectToAction("Takvim");
            }

            return View(new HomeIndexViewModel { UserName = model.UserName, HasError = true, Error = "Kullanıcı Bulunamadı!" });
        }

        public IActionResult _Hata()
        {
            return PartialView("~/Views/PartialView/_Hata.cshtml");
        }

        public IActionResult Takvim() 
        { 
            return View();
        }


        //-------------------------------------------------------------

        public IActionResult Hata(UserInMemory model)
        {
            return Ok();
        }




        public IActionResult Testomer()
        {
            return View();
        }
        public IActionResult Test1()
        {

            return View();
        }
    }
        

   
       
    }
