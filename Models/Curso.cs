using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoDevJr.Models
{
    public enum Grado
    {
        Primero, Segundo, Tercero, Cuarto, Quinto, Sexto
    }

    public enum Paralelo
    {
        A, B, C, D, E
    }

    public enum Nivel
    {
        Primaria, Secundaria
    }

    public class Curso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cursoId { get; set; }

        [Required]
        public Grado grado { get; set; }        

        [Required]        
        public Paralelo paralelo { get; set; }

        [Required]
        public Nivel nivel { get; set; }

        public virtual ICollection<Inscripcion> inscripcion { get; set; }

    }
}