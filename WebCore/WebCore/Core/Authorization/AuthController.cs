﻿using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        [Route("qrcode")]
        public Bitmap GetAccess_token_QRCode()
        {
            return CreateQRCode.Create("http://web.fursion.cn/dutyinfo/Getinfo");
        }
    }
}
