using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoDevJr.Models
{
    public abstract class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string nombres { get; set; }

        [Required]
        public string apellidoPaterno { get; set; }

        [Required]
        public string apellidoMaterno { get; set; }

        [Required]
        [StringLength(1)]
        public string sexo { get; set; }

        public string lugarNacimiento { get; set; }

        [Required]
        public DateTime fechaNacimiento { get; set; }

        [Required]
        public string ci { get; set; }

        public string direccion { get; set; }

        public string zona { get; set; }

        public int telefono { get; set; }

    }
}