using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebCore.Core.UserManage;
using WebCore.Mouds;
using WebCore.Core.WebAPI;
using Microsoft.AspNetCore.Http;
//using WebCore.Core;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebCore.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult imagetest(string content)
        {
            if (content == null)
                return View();
            var so = Url.Action("Generate", "QRCOde", new { content = content });
            ViewData.Add("qrcode", so);
            return View();
        }
        public IActionResult Generate(string content)
        {
            var guid = UserManage.CreateUUID();
            return File(QRCode.CreateQRCode.CreateByteMap(content), "image/jpeg");
        }
        public IActionResult text()
        {
            return View("imagetest");
        }

        [HttpPost]
        public IActionResult text(TextViewModel model)
        {
            string str = model.inputText1;
            ViewBag.image=Url.Action("Generate", "QRCOde", new { content = str });
            return View("imagetest");
        }
    }
}
