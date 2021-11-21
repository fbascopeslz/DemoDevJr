using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DemoDevJr.Models
{
    public class Apoderado : Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string ocupacion { get; set; }

        public int alumnoId { get; set; }
        public virtual Alumno alumno { get; set; }

    }
}