using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebCore.Core.UserManage;
//using WebCore.Core;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebCore.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult imagetest()
        {
            return View();
        }
        public IActionResult Generate() {
            var guid = UserManage.CreateUUID();
            return File(QRCode.CreateQRCode.CreateByteMap(guid), "image/jpeg");
        }

    }
}
