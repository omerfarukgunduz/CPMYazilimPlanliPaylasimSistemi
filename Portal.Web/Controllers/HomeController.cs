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
using System.IO;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Portal.Web.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        readonly private IAccessTokenReadRepository _accessTokenReadRepository;
        readonly private IAccessTokenWriteRepository _accessTokenWriteRepository;
        readonly private IEtkinlikWriteRepository _etkinlikWriteRepository;
        readonly private IEtkinlikReadRepository _etkinlikReadRepository;
        readonly private IUserReadRepository _userReadRepository;
        readonly private IUserWriteRepository _userWriteRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository, IEtkinlikWriteRepository etkinlikWriteRepository, IEtkinlikReadRepository etkinlikReadRepository, IWebHostEnvironment hostingEnvironment, IAccessTokenReadRepository accessTokenReadRepository, IAccessTokenWriteRepository accessTokenWriteRepository)
        {
            _logger = logger;
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
            _etkinlikWriteRepository = etkinlikWriteRepository;
            _etkinlikReadRepository = etkinlikReadRepository;
            _hostingEnvironment = hostingEnvironment;
            _accessTokenReadRepository = accessTokenReadRepository;
            _accessTokenWriteRepository = accessTokenWriteRepository;
        }

        //========================================================================================================================
        //Login Ekranı İşlemleri


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(HomeIndexViewModel model)
        {
            if(string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password))
                return View(new HomeIndexViewModel { UserName = model.UserName, HasError = true, Error = "Kullanıcı adı ve şifre alanları boş olamaz!" });

            var datas = _userReadRepository.GetAll();
            var dataSearch = datas.Where(elm => elm.UserName == model.UserName && elm.Password == model.Password);

            if (dataSearch.Count() == 1)
            {
                model.Role= (int)dataSearch.First().Role;
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,model.UserName),
                    new Claim(ClaimTypes.Role,model.Role.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties() { ExpiresUtc = DateTime.UtcNow.AddHours(1) };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                if (model.Role== 2)
                {
                    
                    return RedirectToAction("AdminKullaniciListesi");
                }

                //Console.WriteLine(model.Id)
                return RedirectToAction("Takvim");
            }

            return View(new HomeIndexViewModel { UserName = model.UserName, HasError = true, Error = "Kullanıcı Adı Veya Şifre Hatalı!" });
        }




        [Authorize]
        //-------------------------------------------------------------
        //Takvim sayfası işlemleri
        public IActionResult Takvim()
        {
            return View();
        }
        [Authorize]
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
            
            Dbe.Tekrar = e.Tekrar;
            Dbe.start = e.start;
            var start = e.start.ToString();
            DateTime end = DateTime.Parse(start);
            Dbe.end = end.AddDays(1);
            _etkinlikWriteRepository.AddAsync(Dbe).Wait();
            _etkinlikWriteRepository.SaveAsync().Wait();

            return RedirectToAction("Takvim");
        }
        [Authorize]
        public async Task<ActionResult> TiklananEtkinlik(string eventId)
        {
            Etkinlik etkinlik = await _etkinlikReadRepository.GetByIdAsync(eventId);
            

            return View(etkinlik);
        }
        [Authorize]
        public IActionResult GetList()
        {

            var data = _etkinlikReadRepository.GetAll();


            return Json(data);
        }
        [Authorize]
        public async Task<IActionResult> EtkinlikSil(string Id)
        {
            Etkinlik Dbe = await _etkinlikReadRepository.GetByIdAsync(Id);
            if (Dbe.image != null)
            {
                string wwwRootPath = _hostingEnvironment.WebRootPath;
                string yol = Path.Combine(wwwRootPath, "Images", Dbe.image);
                System.IO.File.Delete(yol);

                
            }

            _etkinlikWriteRepository.RemoveAsync(Id).Wait();
            _etkinlikWriteRepository.SaveAsync().Wait();



            return RedirectToAction("Takvim", "Home");
        }





        //-----------------------------------------------------------------------------------------------------------
        //Admin İşlemleri
        [Authorize]
        public async Task<ActionResult> KullaniciSil(string Id)
        {

            await _userWriteRepository.RemoveAsync(Id);
            await _userWriteRepository.SaveAsync();

            return RedirectToAction("AdminKullaniciListesi", "Home");

        }
        [Authorize]
        public async Task<ActionResult> KullaniciEdit(string Id)
        {
            User Dbu = await _userReadRepository.GetByIdAsync(Id);
            return View(Dbu);
        }
        [Authorize]
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

        [Authorize]
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
        [Authorize]
        public IActionResult _UserlistAdmin()
        {
            var item = _userReadRepository.Get();
            return PartialView("~/Views/PartialView/_UserlistAdmin.cshtml", item);
        }
        [Authorize]
        public IActionResult AdminKullaniciListesi()
        {
            var items = _userReadRepository.Get().ToList();
            var denem = new UserListPageViewModal { };

            denem.User = items;
            denem.SingleUser = items[0];

            return View(denem);
        }
        [Authorize]
        public IActionResult Api()
    {
            var datas = _accessTokenReadRepository.Get().ToList();
            var data = datas[0];
            return View(data);
    }
        [Authorize]
        [HttpPost]
       public async  Task<IActionResult> Api(AccessToken a)
        {
            var datas = _accessTokenReadRepository.Get().ToList();
            a.Id = datas[0].Id;
            a.TokenUsername = datas[0].TokenUsername;
            if(a.Token != null) 
            {
               await _accessTokenWriteRepository.RemoveAsync(datas[0].Id.ToString());
                

                
            }


            if(a.Token != datas[0].Token || a.Token != datas[0].TokenTitle)
            {
               await _accessTokenWriteRepository.AddAsync(a);
               await _accessTokenWriteRepository.SaveAsync();
            }
            

            return View();
        }

    }

}
