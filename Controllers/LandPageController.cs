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
        private EscuelaContexto db = new EscuelaContexto();

        public IEnumerable<DemoDevJr.Models.AlumnoInscripcion> datos()
        {
            IEnumerable<DemoDevJr.Models.AlumnoInscripcion> datos = db.Alumno.Join(
                db.Inscripcion,
                alumno => alumno.alumnoId,
                inscripcion => inscripcion.alumno.alumnoId,
                (alumno, inscripcion) => new AlumnoInscripcion
                {
                    id = alumno.alumnoId,
                    nombres = alumno.nombres,
                    apellidoPaterno = alumno.apellidoPaterno,
                    apellidoMaterno = alumno.apellidoMaterno,
                    //sexo = alumno.sexo,
                    lugarNacimiento = alumno.lugarNacimiento,
                    fechaNacimiento = alumno.fechaNacimiento.ToString(),
                    ci = alumno.ci,
                    direccion = alumno.direccion,
                    zona = alumno.zona,
                    telefono = alumno.telefono,
                    rude = alumno.rude,
                    imagen = alumno.imagen,
                    fechaInscripcion = inscripcion.fecha.ToString()
                }
            )
            .OrderByDescending(c => c.id)
            .Take(5)
            .ToList();
            return datos;
        }

        // GET: LandPage
        public ActionResult Index()
        {            
            ViewBag.datos = this.datos();
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,email,telefono,asunto,mensaje")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                db.Contacto.Add(contacto);
                db.SaveChanges();
                ViewBag.swContacto = 1;
                ViewBag.datos = this.datos();
                //return RedirectToAction("Index");
                return View("Index");                
            }
            ViewBag.swContacto = 0;
            ViewBag.datos = this.datos();
            return View("Index");
            //return View(contacto);
            //return RedirectToAction("Index");            
        }

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
