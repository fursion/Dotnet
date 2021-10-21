using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using WebCore.Core;
using WebCore.Models;

namespace WebCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DutyInfoController : ControllerBase
    {
        private IWebHostEnvironment _he;
        public DutyInfoController(IWebHostEnvironment he)
        {
            _he = he;
        }
        [Route("GetInfo")]
        [HttpPost]
        public List<string> Getinfo(PersonOnDutyInfoModel model)
        {
            List<string> datainfo = new List<string>();
            var dutyfile_path = string.Format("/file/{0}duty.xlsx",model.Location);
            string str = _he.ContentRootPath + dutyfile_path;
            DutyInfo.Init(_he.ContentRootPath);
            DataTable table = ExcelTools.ReadExcel(str, "IFS班表", true);
            string temph = _he.ContentRootPath + "/file/TempHeader.txt";
            string tempend = _he.ContentRootPath + "/file/TempEnd.txt";
            if (System.IO.File.Exists(temph))
            {
                var header = System.IO.File.ReadAllLines(temph);
                foreach (var item in header)
                    datainfo.Add(item);
            }
            else throw new Exception();
            var TodayDutyinfo = ExcelTools.Traversal_duty_Table(table, model.SelectTime);
            foreach (var item in TodayDutyinfo)
                datainfo.Add(item);
            if (System.IO.File.Exists(tempend))
            {
                var end = System.IO.File.ReadAllLines(tempend);
                foreach (var item in end)
                    datainfo.Add(item);
            }
            else throw new Exception();
            return datainfo;
        }
    }
}
