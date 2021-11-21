using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DemoDevJr.Models
{
    public class Alumno : Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int alumnoId { get; set; }

        public string rude { get; set; }

        public string imagen { get; set; }

        public virtual ICollection<Apoderado> apoderado { get; set; }

        public virtual ICollection<Inscripcion> inscripcion { get; set; }

    }
}