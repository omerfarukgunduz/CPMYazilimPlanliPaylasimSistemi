﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Repositories;
using Portal.Domain.Entities;
using Portal.Infrastructure;
using System.Diagnostics;

namespace Portal.Web.Controllers
{
    public class HomeController : Controller
    {

        readonly private IUserReadRepository _userReadRepository;
        readonly private IUserWriteRepository _userWriteRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository)
        {
            _logger = logger;
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
        }

        public IActionResult _mdletkinlikekleicerik()
        {

            return PartialView("~/Views/PartialView/_mdletkinlikekleicerik.cshtml");
        }

        public IActionResult Testomer()
        {
            
            return View();
        }

        public IActionResult Test1()
        {

            return View();
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult feedback()
        {
            return View();
        }

        public IActionResult Takvim() 
        { 
            return View();
        }

        public PartialViewResult PartialEtkinlikkaydet()
        {
            return PartialView();
        }



        public IActionResult  Hata(UserInMemory model) 
        {
            var datas = _userReadRepository.GetAll();
            foreach (var data in datas)
            {
                if (data.UserName == model.UserName)
                {
                    if (data.Password == model.Password)
                    {

                        model.Id = data.Id;
                        Console.WriteLine(model.Id);
                        return RedirectToAction("Takvim");
                    }

                }
            }
            return View("feedback");
        }
    }
        

   
       
    }
