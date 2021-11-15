using DemoDevJr.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoDevJr.Context
{
    public class EscuelaContexto : DbContext
    {
        public EscuelaContexto() : base("EscuelaConexion")
        {

        }

        public DbSet<Alumno> Alumno { get; set; }

        public DbSet<Apoderado> Apoderado { get; set; }

        public DbSet<Curso> Curso { get; set; }

        public DbSet<Inscripcion> Inscripcion { get; set; }

    }
}