using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.WebAPI
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public string test()
        {
            return "test";
        }
    }
}
