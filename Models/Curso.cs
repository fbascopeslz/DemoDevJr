using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoDevJr.Models
{
    public class Curso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string grado { get; set; }        

        [Required]
        [StringLength(1)]
        public string paralelo { get; set; }

        [Required]
        public string nivel { get; set; }
        
    }
}