using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoCoreWeb.Models;
using Microsoft.AspNetCore.Http;

namespace DemoCoreWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult test1()
        {
            int x = 2;
            int y = 5;
            int sum = x + y;
            ViewBag.n1 = x;
            ViewBag.n2 = y;
            ViewBag.sum = sum;
            return View();
        }

        [HttpGet]
        public IActionResult test2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult test2(IFormCollection fc)  //(string num1, string num2) will also work
        {
            int x = Int32.Parse(fc["num1"]);
            int y = Int32.Parse(fc["num2"]);
            int sum = x + y;
            ViewBag.sum = sum;
            return View();
        }

        public IActionResult user_registration()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
