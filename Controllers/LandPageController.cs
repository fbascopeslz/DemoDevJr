using DemoDevJr.Context;
using DemoDevJr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoDevJr.Controllers
{
    public enum Sexo
    {
        M, F
    }

    public class LandPageController : Controller
    {
        private EscuelaContexto db = new EscuelaContexto();

        // GET: LandPage
        public ActionResult Index()
        {
            var datos = db.Alumno.Join(
                            db.Inscripcion,
                            alumno => alumno.alumnoId,
                            inscripcion => inscripcion.alumno.alumnoId,
                            (alumno, inscripcion) => new AlumnoInscripcion
                            {
                                id = alumno.alumnoId,
                                nombres =  alumno.nombres,
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

            //ViewBag.Message = datos;

            return View(datos);
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
        [HttpPost]
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
