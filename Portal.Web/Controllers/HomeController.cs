using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Portal.Application.Repositories;
using Portal.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Portal.Web.ViewModel;
using ServiceStack;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using System.Reflection;
using static System.Net.WebRequestMethods;

namespace Portal.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        readonly private IEtkinlikWriteRepository _etkinlikWriteRepository;
        readonly private IEtkinlikReadRepository _etkinlikReadRepository;
        readonly private IUserReadRepository _userReadRepository;
        readonly private IUserWriteRepository _userWriteRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository, IEtkinlikWriteRepository etkinlikWriteRepository, IEtkinlikReadRepository etkinlikReadRepository, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
            _etkinlikWriteRepository = etkinlikWriteRepository;
            _etkinlikReadRepository = etkinlikReadRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        //========================================================================================================================
        //Login Ekranı İşlemleri


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
                model.Role= (int)dataSearch.First().Role;
                

				if (model.Role== 2)
                {
					return RedirectToAction("AdminKullaniciListesi");
                }

                //Console.WriteLine(model.Id)
                return RedirectToAction("Takvim");
            }

            return View(new HomeIndexViewModel { UserName = model.UserName, HasError = true, Error = "Kullanıcı Adı Veya Şifre Hatalı!" });
        }





        //-------------------------------------------------------------
        //Takvim sayfası işlemleri
        public IActionResult Takvim()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Tahvim([FromForm] EtkinlikEkleViewModel e)
        {
            Etkinlik Dbe = new Etkinlik();
            if (e.image != null)
            {
                string dosyaadi = "photoId." + Guid.NewGuid().ToString();
                string uzanti = Path.GetExtension(e.image.FileName);
                string wwwRootPath = _hostingEnvironment.WebRootPath;
                string yol = Path.Combine(wwwRootPath, "Images", dosyaadi + uzanti);
                using (var stream = new FileStream(yol, FileMode.Create))
                {
                    e.image.CopyTo(stream);
                }

                Dbe.image = dosyaadi+uzanti;

            }
            Dbe.title = e.title;
            Dbe.description = e.description;
            Dbe.whatsapp = e.whatsapp;
            Dbe.linkedin = e.linkedin;
            Dbe.start = e.start;
            var start = e.start.ToString();
            DateTime end = DateTime.Parse(start);
            Dbe.end = end.AddDays(1);
            _etkinlikWriteRepository.AddAsync(Dbe).Wait();
            _etkinlikWriteRepository.SaveAsync().Wait();

            return RedirectToAction("Takvim");
        }

        public async Task<ActionResult> TiklananEtkinlik(string eventId)
        {
            Etkinlik etkinlik = await _etkinlikReadRepository.GetByIdAsync(eventId);
            

            return View(etkinlik);
        }

        public IActionResult GetList()
        {

            var data = _etkinlikReadRepository.GetAll();


            return Json(data);
        }

        public IActionResult EtkinlikSil(string Id)
        {
            _etkinlikWriteRepository.RemoveAsync(Id).Wait();
            _etkinlikWriteRepository.SaveAsync().Wait();
            return RedirectToAction("Takvim", "Home");
        }





        //-----------------------------------------------------------------------------------------------------------
        //Admin İşlemleri

        public async Task<ActionResult> KullaniciSil(string Id)
        {

            await _userWriteRepository.RemoveAsync(Id);
            await _userWriteRepository.SaveAsync();

            return RedirectToAction("AdminKullaniciListesi", "Home");

        }

        public async Task<ActionResult> KullaniciEdit(string Id)
        {
            User Dbu = await _userReadRepository.GetByIdAsync(Id);
            return View(Dbu);
        }
        [HttpPost]
        public async Task<IActionResult> KullaniciEdit([FromForm]User u)
        {
            string Id = u.Id.ToString();
            User Dbu = await _userReadRepository.GetByIdAsync(Id);
            Dbu = u;
            await _userWriteRepository.RemoveAsync(Id);
            await _userWriteRepository.AddAsync(Dbu);
            await _userWriteRepository.SaveAsync();
            return RedirectToAction("AdminKullaniciListesi");
        }
        

        public IActionResult KullanıcıEkle(UserListPageViewModal u)
        {
            User Dbu = new User { };
            Dbu.UserName = u.SingleUser.UserName;
            Dbu.Password = u.SingleUser.Password;
            Dbu.Role = u.SingleUser.Role;

            _userWriteRepository.AddAsync(Dbu).Wait();
            _userWriteRepository.SaveAsync().Wait();

            return RedirectToAction("AdminKullaniciListesi");
        }
        public IActionResult _UserlistAdmin()
        {
            var item = _userReadRepository.Get();
            return PartialView("~/Views/PartialView/_UserlistAdmin.cshtml", item);
        }
        public IActionResult AdminKullaniciListesi()
        {
            var items = _userReadRepository.Get().ToList();
            var denem = new UserListPageViewModal { };

            denem.User = items;
            denem.SingleUser = items[0];

            return View(denem);
        }
    }




}
