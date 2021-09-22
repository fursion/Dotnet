using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoDutyInfo.Core;
using System.Data;
using System.IO;

namespace WebServer.Controllers
{
    public class DutyInfoController : Controller
    {
        private IWebHostEnvironment _he;
        public DutyInfoController(IWebHostEnvironment he)
        {
            _he = he;
        }
        // GET: DutyInfoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DutyInfoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DutyInfoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DutyInfoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DutyInfoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DutyInfoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DutyInfoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DutyInfoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Getinfo()
        {
            List<string> datainfo = new List<string>();
            string str = _he.ContentRootPath + "/Config/duty.xlsx";
            DutyInfo.Init(_he.ContentRootPath);
            DataTable table = ExcelTools.ReadExcel(str, "IFS班表", true);
            string temph = _he.ContentRootPath + "/Config/TempHeader.txt";
            string tempend = _he.ContentRootPath + "/Config/TempEnd.txt";
            if (System.IO.File.Exists(temph))
            {
                var header = System.IO.File.ReadAllLines(temph);
                foreach (var item in header)
                    datainfo.Add(item);
            }
            else throw new Exception();        
            var TodayDutyinfo = ExcelTools.Traversal_duty_Table(table, DateTime.Now);
            foreach (var item in TodayDutyinfo)
                datainfo.Add(item);
            if (System.IO.File.Exists(tempend))
            {
                var end = System.IO.File.ReadAllLines(tempend);
                foreach (var item in end)
                    datainfo.Add(item);
            }
            else throw new Exception();
            ViewData["TodayDuty"] = datainfo;
            return View();
        }
    }
}
