using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DemoDevJr.Models
{
    public class Contacto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string nombre { get; set; }

        public string email { get; set; }

        //public string telefono { get; set; }

        public string asunto { get; set; }

        public string mensaje { get; set; }

    }
}