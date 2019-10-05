using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Potlucky.Models;

namespace Potlucky.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Welcome to Potlucky. Plan your next Potluck here.";
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }

        public IActionResult People()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Schedule()
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
