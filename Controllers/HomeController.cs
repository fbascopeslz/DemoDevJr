using DemoDevJr.Context;
using DemoDevJr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoDevJr.Controllers
{
    public class HomeController : Controller
    {
        private EscuelaContexto db = new EscuelaContexto();

        public IEnumerable<DemoDevJr.Models.AlumnoInscripcion> datos()
        {
            IEnumerable<DemoDevJr.Models.AlumnoInscripcion> datos = db.Alumno.Join(
                db.Inscripcion,
                alumno => alumno.alumnoId,
                inscripcion => inscripcion.alumno.alumnoId,
                (alumno, inscripcion) => new { alumno, inscripcion }
            )
            .Join(
                db.Curso,
                combinedEntry => combinedEntry.inscripcion.cursoId,
                curso => curso.cursoId,                
                (combinedEntry, curso) => new AlumnoInscripcion
                {
                    id = combinedEntry.alumno.alumnoId,
                    nombres = combinedEntry.alumno.nombres,
                    apellidoPaterno = combinedEntry.alumno.apellidoPaterno,
                    apellidoMaterno = combinedEntry.alumno.apellidoMaterno,
                    //sexo = alumno.sexo,
                    lugarNacimiento = combinedEntry.alumno.lugarNacimiento,
                    fechaNacimiento = combinedEntry.alumno.fechaNacimiento.ToString(),
                    ci = combinedEntry.alumno.ci,
                    direccion = combinedEntry.alumno.direccion,
                    zona = combinedEntry.alumno.zona,
                    telefono = combinedEntry.alumno.telefono,
                    rude = combinedEntry.alumno.rude,
                    imagen = combinedEntry.alumno.imagen,
                    fechaInscripcion = combinedEntry.inscripcion.fecha.ToString(),
                    curso = curso.grado + " " + curso.paralelo + " " + curso.nivel
                }
            )
            .OrderByDescending(c => c.id)
            .Take(5)
            .ToList();
            return datos;
        }
        public ActionResult Index()
        {
            ViewBag.datos = this.datos();
            //return "HOLA";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,email,asunto,mensaje")] Contacto contacto)
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}