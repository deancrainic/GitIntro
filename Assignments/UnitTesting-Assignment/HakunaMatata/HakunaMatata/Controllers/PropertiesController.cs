﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HakunaMatata.Controllers
{
    public class PropertiesController : Controller
    {
        // GET: PropertiesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PropertiesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PropertiesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropertiesController/Create
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

        // GET: PropertiesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PropertiesController/Edit/5
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

        // GET: PropertiesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PropertiesController/Delete/5
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
    }
}
