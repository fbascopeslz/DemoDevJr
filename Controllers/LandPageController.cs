using DemoDevJr.Context;
using DemoDevJr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoDevJr.Controllers
{  
    public class LandPageController : Controller
    {
        

        // GET: LandPage
        public ActionResult Index()
        {            
            
            //ViewBag.swContacto = 0;

            return View();
            //return View();
        }

        // GET: LandPage/Details/5
        public ActionResult Details(int id)
        {            
            return View();
        }

        // GET: LandPage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LandPage/Create
        /*[HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/
        

        // GET: LandPage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LandPage/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LandPage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LandPage/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
