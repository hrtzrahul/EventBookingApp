using BookEventApp.Interfaces;
using BookEventApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookEventApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventPageService _eventPageService;
        public HomeController(IEventPageService eventPageService)
        {
            this._eventPageService = eventPageService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _eventPageService.GetEvents();
            return View(data);
        }
        //public ViewResult Login()
        //{
        //    return View();
        //}
        //public ViewResult Register()
        //{
        //    return View();
        //}
    }
}
