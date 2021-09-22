using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoDutyInfo.Core;

namespace WebServer.Controllers
{
    public class DutyInfoController : Controller
    {
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
            DutyInfo.Init();
        }
    }
}
