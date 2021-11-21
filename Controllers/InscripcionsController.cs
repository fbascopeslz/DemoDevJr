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
    public class InscripcionsController : Controller
    {
        private EscuelaContexto db = new EscuelaContexto();

        // GET: Inscripcions
        public ActionResult Index()
        {
            var inscripcion = db.Inscripcion.Include(i => i.alumno).Include(i => i.curso);
            return View(inscripcion.ToList());
        }

        // GET: Inscripcions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscripcion inscripcion = db.Inscripcion.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            return View(inscripcion);
        }

        // GET: Inscripcions/Create
        public ActionResult Create()
        {
            ViewBag.alumnoId = new SelectList(db.Alumno, "alumnoId", "nombres");
            ViewBag.cursoId = new SelectList(db.Curso, "cursoId", "grado");
            return View();
        }

        // POST: Inscripcions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,matricula,fecha,colegioProcedencia,tipoInscripcion,observacion1,observacion2,alumnoId,cursoId")] Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Inscripcion.Add(inscripcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.alumnoId = new SelectList(db.Alumno, "alumnoId", "nombres", inscripcion.alumnoId);
            ViewBag.cursoId = new SelectList(db.Curso, "cursoId", "grado", inscripcion.cursoId);
            return View(inscripcion);
        }

        // GET: Inscripcions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscripcion inscripcion = db.Inscripcion.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.alumnoId = new SelectList(db.Alumno, "alumnoId", "nombres", inscripcion.alumnoId);
            ViewBag.cursoId = new SelectList(db.Curso, "cursoId", "grado", inscripcion.cursoId);
            return View(inscripcion);
        }

        // POST: Inscripcions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,matricula,fecha,colegioProcedencia,tipoInscripcion,observacion1,observacion2,alumnoId,cursoId")] Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscripcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.alumnoId = new SelectList(db.Alumno, "alumnoId", "nombres", inscripcion.alumnoId);
            ViewBag.cursoId = new SelectList(db.Curso, "cursoId", "grado", inscripcion.cursoId);
            return View(inscripcion);
        }

        // GET: Inscripcions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscripcion inscripcion = db.Inscripcion.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            return View(inscripcion);
        }

        // POST: Inscripcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inscripcion inscripcion = db.Inscripcion.Find(id);
            db.Inscripcion.Remove(inscripcion);
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
