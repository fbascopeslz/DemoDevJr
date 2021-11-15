using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoDevJr.Models
{
    public class Inscripcion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public DateTime fecha { get; set; }
       
        public string colegioProcedencia { get; set; }

        [Required]
        public string tipoInscripcion { get; set; }

        public double porcentajeBeca { get; set; }

        public string observacion1 { get; set; }

        public string observacion2 { get; set; }

        public Alumno alumno { get; set; }

        public Curso curso { get; set; }        

    }
}