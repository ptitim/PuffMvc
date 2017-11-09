using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using Service;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {

        private readonly IEventService eventService;

        public HomeController(IEventService eventService)
        {

        }

        public IActionResult Index()
        {
            var model = eventService.

            return View();
            //return "Hello world";
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
