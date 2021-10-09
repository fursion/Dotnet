using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QRCode;
using System.Drawing;

namespace WebCore.Core.Authorization
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        [HttpGet]
        public Bitmap GetAccess_token()
        {
            return CreateQRCode.Create("http://web.fursion.cn/dutyinfo/Getinfo");
        }
        [Authorize(Roles ="admin")]
        [HttpGet]
        [Route("qrcode")]
        public Byte[] GetAccess_token_QRCode()
        {
            return CreateQRCode.CreateByteMap("http://web.fursion.cn/dutyinfo/Getinfo");
        }
        [HttpPost]
        public IActionResult Page(int id)
        {
            return View();
        }
    }
}
