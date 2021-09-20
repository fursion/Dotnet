using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.WebAPI
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("GET")]
        public string GetToken()
        {
            return "adhajh7_qe3e2th456y4";
        }
    }
}
