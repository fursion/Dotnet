using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebCore.Core.WebAPI
{
    [Route("api/[controller]")]
    public class UploadController : Controller
    {
        private IWebHostEnvironment environment;
        public UploadController(IWebHostEnvironment he)
        {
            environment = he;
        }
        [HttpPost]
        [Consumes("application/json", "multipart/form-data")]
        public async Task<IActionResult> Upfile(IFormFile file)
        {
            WebCore.Core.SQL.IO.PossingFile(this.HttpContext);
            Console.WriteLine(environment.WebRootPath);
            var formfile = Request.Form.Files.FirstOrDefault();
            if (formfile == null)
            {
                throw new Exception("文件不能为空");
            }
            var uploads = Path.Combine(environment.WebRootPath, "file");
            var filepath = Path.Combine(uploads, formfile.FileName);
            using (var fileStream = System.IO.File.Create(filepath))
            {
                await file.CopyToAsync(fileStream);
            }
            return Ok(new { success = true });
        }
        [HttpPost]
        [Route("OnPostUploadAsync")]
        public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.Combine(environment.WebRootPath, "TempFile", formFile.FileName);
                    Console.WriteLine(filePath);
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            return Ok(new { count = files.Count, size });
        }
        [HttpDelete]
        public async void DeleteFile(int id)
        {

        }

    }
}

