using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DemoDevJr.Models
{
    public class Estudiante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string nombre { get; set; }

        public int edad { get; set; }

        [Display(Name = "Fecha Inscripcion")]
        public DateTime fechaInscripcion { get; set; }
    }
}