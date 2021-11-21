using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoDevJr.Models
{
    public class AlumnoInscripcion
    {
        public enum Sexo
        {
            M, F
        }
        /*
        public AlumnoInscripcion(
            int id, 
            string nombres,
            string apellidoPaterno,
            string apellidoMaterno,
            //Sexo sexo,
            string lugarNacimiento,
            string fechaNacimiento,
            string ci,
            string direccion,
            string zona,
            int telefono,
            string rude,
            string imagen,
            string fechaInscripcion
        )
        {
            this.id = id;
            this.nombres = nombres;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            //this.sexo = sexo;
            this.lugarNacimiento = lugarNacimiento;
            this.fechaNacimiento = fechaNacimiento;
            this.ci = ci;
            this.direccion = direccion;
            this.zona = zona;
            this.telefono = telefono;
            this.rude = rude;
            this.imagen = imagen;
            this.fechaInscripcion = fechaInscripcion;
        }
        */
        public int id { get; set; }
        public string nombres { get; set; }        
        public string apellidoPaterno { get; set; }        
        public string apellidoMaterno { get; set; }        
        //public Sexo sexo { get; set; }
        public string lugarNacimiento { get; set; }        
        public string fechaNacimiento { get; set; }        
        public string ci { get; set; }
        public string direccion { get; set; }
        public string zona { get; set; }
        public int telefono { get; set; }
        
        public string rude { get; set; }
        public string imagen { get; set; }

        public string fechaInscripcion { get; set; }
    }
}