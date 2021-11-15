using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoDevJr.Models
{
    public class Alumno : Persona
    {        
        public string rude { get; set; }

        public string imagen { get; set; }

        //public ICollection<Apoderado> apoderado { get; set; }

    }
}