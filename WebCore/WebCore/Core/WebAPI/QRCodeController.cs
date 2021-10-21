using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCore.Core.UserManage;
using WebCore.Mouds;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebCore.Core.WebAPI
{
    [Route("api/[controller]")]
    public class QRCodeController : Controller
    {
        [Route("create")]
        [HttpGet]
        public IActionResult Generate(string content)
        {
            return File(QRCode.CreateQRCode.CreateByteMap(content), "image/jpeg");
        }
        [Route("geturl")]
        [HttpPost]
        public string GetQRCodeUrl(string content)
        {
            return Url.ActionLink("Generate", "QRCode", new { content = content });
        }
        [HttpPost]
        public byte[] GetQRCodeByte(string content)
        {
            return QRCode.CreateQRCode.CreateByteMap(content);
        }
        [Route("getqrcode")]
        [HttpGet]
        public string getqr(QRCodeRequestModel qRCodeRequest)
        {
            System.Console.WriteLine(qRCodeRequest.content);
            var url = Url.ActionLink("Generate", "QRCode", new { content = qRCodeRequest.content });
            return url;
        }
        [Route("GetSiteInfo")]
        [HttpGet]
        public string[] GetSiteInfo(){
            string[] siteinfo=new string[]{"IFS","OCG","WIFC","瑞鑫","华润"};
            return siteinfo;
        }
    }
}
