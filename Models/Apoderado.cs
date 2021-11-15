using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoDevJr.Models
{
    public class Apoderado : Persona
    {
        public string ocupacion { get; set; }

        public Alumno alumno { get; set; }

    }
}