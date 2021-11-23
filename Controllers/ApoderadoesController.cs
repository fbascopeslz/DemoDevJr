using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoDevJr.Context;
using DemoDevJr.Models;

namespace DemoDevJr.Controllers
{
    public class ApoderadoesController : Controller
    {
        private EscuelaContexto db = new EscuelaContexto();

        // GET: Apoderadoes
        public ActionResult Index()
        {
            var apoderado = db.Apoderado.Include(a => a.alumno);
            return View(apoderado.ToList());
        }

        // GET: Apoderadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apoderado apoderado = db.Apoderado.Find(id);
            if (apoderado == null)
            {
                return HttpNotFound();
            }
            return View(apoderado);
        }

        // GET: Apoderadoes/Create
        public ActionResult Create()
        {
            var alumnos = db.Alumno.Select(s => new
                                    {
                                        alumnoId = s.alumnoId,
                                        nombreCompleto = s.nombres + " " + s.apellidoPaterno + " " + s.apellidoMaterno
                                    })
                                    .ToList();
            ViewBag.alumnoId = new SelectList(alumnos, "alumnoId", "nombreCompleto");
            return View();
        }

        // POST: Apoderadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ocupacion,alumnoId,nombres,apellidoPaterno,apellidoMaterno,sexo,lugarNacimiento,fechaNacimiento,ci,direccion,zona,telefono")] Apoderado apoderado)
        {
            if (ModelState.IsValid)
            {
                db.Apoderado.Add(apoderado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.alumnoId = new SelectList(db.Alumno, "alumnoId", "nombres", apoderado.alumnoId);
            return View(apoderado);
        }

        // GET: Apoderadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apoderado apoderado = db.Apoderado.Find(id);
            if (apoderado == null)
            {
                return HttpNotFound();
            }

            var alumnos = db.Alumno.Select(s => new
                                    {
                                        alumnoId = s.alumnoId,
                                        nombreCompleto = s.nombres + " " + s.apellidoPaterno + " " + s.apellidoMaterno
                                    })
                                    .ToList();
            ViewBag.alumnoId = new SelectList(alumnos, "alumnoId", "nombreCompleto", apoderado.alumnoId);
            //ViewBag.alumnoId = new SelectList(db.Alumno, "alumnoId", "nombres", apoderado.alumnoId);
            return View(apoderado);
        }

        // POST: Apoderadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ocupacion,alumnoId,nombres,apellidoPaterno,apellidoMaterno,sexo,lugarNacimiento,fechaNacimiento,ci,direccion,zona,telefono")] Apoderado apoderado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apoderado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.alumnoId = new SelectList(db.Alumno, "alumnoId", "nombres", apoderado.alumnoId);
            return View(apoderado);
        }

        // GET: Apoderadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apoderado apoderado = db.Apoderado.Find(id);
            if (apoderado == null)
            {
                return HttpNotFound();
            }
            return View(apoderado);
        }

        // POST: Apoderadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Apoderado apoderado = db.Apoderado.Find(id);
            db.Apoderado.Remove(apoderado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
