using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Text.Json;
using WebCore.Core;
using WebCore.Core.Config;
using WebCore.Models;

namespace WebCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DutyInfoController : ControllerBase
    {
        private IWebHostEnvironment _he;
        public DutyInfoController(IWebHostEnvironment he)
        {
            _he = he;
        }
        [Route("GetInfo")]
        [HttpPost]
        public PersonOnDutyInfoModel Getinfo(PersonOnDutyInfoModel model)
        {
            List<string> datainfo = new List<string>();
            //1.核对对应的配置文件是否齐全
            //2.读对应的文件和班表。
            //3.生成在班信息表
            //4.回复客户端
            var pathlist = new List<string>();
            string ps = Path.Combine(ConfigCore.WebRootPath, ConfigCore.GetConfigItem<DutyConfig>("DutyConfig").SavePath, ConfigCore.GetConfigItem<DutyConfig>("DutyConfig").FolderPath, model.Location, ConfigCore.GetConfigItem<DutyConfig>("DutyConfig").TemplatePath);
            string temphs = Path.Combine(ConfigCore.WebRootPath, ConfigCore.GetConfigItem<DutyConfig>("DutyConfig").SavePath, ConfigCore.GetConfigItem<DutyConfig>("DutyConfig").FolderPath, model.Location, ConfigCore.GetConfigItem<DutyConfig>("DutyConfig").TempHeader);
            string tempends = Path.Combine(ConfigCore.WebRootPath, ConfigCore.GetConfigItem<DutyConfig>("DutyConfig").SavePath, ConfigCore.GetConfigItem<DutyConfig>("DutyConfig").FolderPath, model.Location, ConfigCore.GetConfigItem<DutyConfig>("DutyConfig").TempTail);
            var dutylocationpath = Path.Combine(ConfigCore.WebRootPath, ConfigCore.GetConfigItem<DutyConfig>("DutyConfig").SavePath, ConfigCore.GetConfigItem<DutyConfig>("DutyConfig").FolderPath, model.Location, $"{model.Location}duty.xlsx");//生成班表文件路径
            pathlist.Add(ps);
            pathlist.Add(temphs);
            pathlist.Add(tempends);
            pathlist.Add(dutylocationpath);
            string Msg = "";
            WebCore.Core.DutyInfos.DutyInfoComputeHander computeHander = new(model);
            //return model;
            if (Checkfile(pathlist, ref Msg))
            {
                DataTable table = ExcelTools.ReadExcel(dutylocationpath, $"{model.Location}班表", true);
                //业务逻辑
                DutyInfo.Init(Path.Combine(ConfigCore.WebRootPath, ConfigCore.GetConfigItem<DutyConfig>("DutyConfig").SavePath, ConfigCore.GetConfigItem<DutyConfig>("DutyConfig").FolderPath, model.Location));
                //读取模板头
                if (System.IO.File.Exists(temphs))
                {
                    var header = System.IO.File.ReadAllLines(temphs);
                    foreach (var item in header)
                        datainfo.Add(item);
                }
                else throw new Exception();
                //Content
                var TodayDutyinfo = ExcelTools.Traversal_duty_Table(table, model.SelectTime);
                foreach (var item in TodayDutyinfo)
                    datainfo.Add(item);
                //读取模板尾
                if (System.IO.File.Exists(tempends))
                {
                    var end = System.IO.File.ReadAllLines(tempends);
                    foreach (var item in end)
                        datainfo.Add(item);
                }
                else throw new Exception();
                model.Infos = datainfo;
            }
            else
            {
                //返回客户端状态码
                model.Message = Msg;
                return model;
            } 
            return model;
            //返回结果

        }
        /// <summary>
        /// 检查服务端是否存在对应的文件
        /// </summary>
        /// <param name="pathlist"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool Checkfile(List<string> pathlist, ref string message)
        {
            bool temp = true;
            foreach (var path in pathlist)
            {
                if (!System.IO.File.Exists(path))
                {
                    message += $"服务端还没有：{path}文件，请上传！\n";
                    temp = false;
                }
            }
            return temp;
        }
        [Route("GetSiteInfo")]
        [HttpGet]
        public string[] GetSiteInfo()
        {
            var str = System.IO.File.ReadAllText(Path.Combine(ConfigCore.TempFilePath, "DutyInfo/Sites.json"));
            var siteinfo = JsonSerializer.Deserialize<string[]>(str);
            return siteinfo;
        }
    }
}
