namespace DemoDevJr.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DemoDevJr.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DemoDevJr.Context.EscuelaContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }                

        protected override void Seed(DemoDevJr.Context.EscuelaContexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            Alumno alum1 = new Alumno { 
                nombres = "Marcelo",
                apellidoPaterno = "Tinelli",
                apellidoMaterno = "Catacora",
                sexo = Sexo.M,
                lugarNacimiento = "Santa Cruz",
                fechaNacimiento = new DateTime(1990, 5, 23),
                ci = "1234567",
                direccion = "Calle Los Tusequis",
                zona = "Norte",
                telefono = 6483920,
                rude = "597384792384",
                imagen = "https://image.freepik.com/foto-gratis/chico-guapo-atractivo-joven-parece-encantado-contento-asombrado_295783-533.jpg"
            };
            Alumno alum2 = new Alumno
            {
                nombres = "Pedro",
                apellidoPaterno = "Garcia",
                apellidoMaterno = "Cortez",
                sexo = Sexo.M,
                lugarNacimiento = "Tarija",
                fechaNacimiento = new DateTime(1999, 3, 8),
                ci = "7654321",
                direccion = "Calle Las Petas",
                zona = "Sur",
                telefono = 75432680,
                rude = "958694383",
                imagen = "https://image.freepik.com/foto-gratis/retrato-hombre-joven-camisa-cuadros-laptop_171337-16080.jpg"
            };
            Alumno alum3 = new Alumno
            {
                nombres = "Maria",
                apellidoPaterno = "Choque",
                apellidoMaterno = "Morales",
                sexo = Sexo.F,
                lugarNacimiento = "La Paz",
                fechaNacimiento = new DateTime(1993, 11, 18),
                ci = "1237890",
                direccion = "Calle Murillo",
                zona = "Este",
                telefono = 7392816,
                rude = "1234567890",
                imagen = "https://image.freepik.com/foto-gratis/chica-atractiva-joven-segura-que-sonrie-garantiza-calidad-recomienda-producto-felicita-eleccion-perfecta_176420-25467.jpg"
            };
            context.Alumno.AddOrUpdate(
                alum1,
                alum2,
                alum3
                );

            Apoderado apod1 = new Apoderado
            {
                nombres = "Julio",
                apellidoPaterno = "Iglesias",
                apellidoMaterno = "Rodriguez",
                sexo = Sexo.M,
                lugarNacimiento = "La Paz",
                fechaNacimiento = new DateTime(1984, 5, 12),
                ci = "1232985",
                direccion = "Calle Murillo",
                zona = "Este",
                telefono = 7495876,
                ocupacion = "carpintero",
                alumno = alum1
            };
            Apoderado apod2 = new Apoderado
            {
                nombres = "Julia",
                apellidoPaterno = "Gonzales",
                apellidoMaterno = "Merida",
                sexo = Sexo.F,
                lugarNacimiento = "Cochabamba",
                fechaNacimiento = new DateTime(1983, 3, 1),
                ci = "1212480",
                direccion = "Calle Murillo",
                zona = "Este",
                telefono = 7097874,
                ocupacion = "ama de casa",
                alumno = alum1
            };
            Apoderado apod3 = new Apoderado
            {
                nombres = "Rosario",
                apellidoPaterno = "Pacheco",
                apellidoMaterno = "Trujillo",
                sexo = Sexo.F,
                lugarNacimiento = "Sucre",
                fechaNacimiento = new DateTime(1978, 5, 14),
                ci = "3252789",
                direccion = "Calle Europa",
                zona = "Sur",
                telefono = 7496841,
                ocupacion = "secretaria",
                alumno = alum2
            };
            context.Apoderado.AddOrUpdate(
                apod1,
                apod2,
                apod3
                );

            Curso cur1 = new Curso
            {
                grado = Grado.Primero,
                paralelo = Paralelo.A,
                nivel = Nivel.Secundaria
            };
            Curso cur2 = new Curso
            {
                grado = Grado.Segundo,
                paralelo = Paralelo.B,
                nivel = Nivel.Primaria
            };
            Curso cur3 = new Curso
            {
                grado = Grado.Primero,
                paralelo = Paralelo.B,
                nivel = Nivel.Secundaria
            };
            context.Curso.AddOrUpdate(
                cur1,
                cur2,
                cur3
                );

            Inscripcion ins1 = new Inscripcion
            {
                matricula = 111,
                fecha = DateTime.Today,
                colegioProcedencia = "Colegio Rio Nuevo",
                tipoInscripcion = TipoInscripcion.Traspaso,
                observacion1 = "Falta la documentacion",
                curso = cur1,
                alumno = alum1
            };
            Inscripcion ins2 = new Inscripcion
            {
                matricula = 222,
                fecha = DateTime.Today,               
                tipoInscripcion = TipoInscripcion.Repitente,
                curso = cur1,
                alumno = alum2
            };
            Inscripcion ins3 = new Inscripcion
            {
                matricula = 333,
                fecha = DateTime.Today,
                tipoInscripcion = TipoInscripcion.Becado,               
                curso = cur1,
                alumno = alum3
            };            
            context.Inscripcion.AddOrUpdate(
                ins1,
                ins2,
                ins3              
                );

            context.SaveChanges();

        }
    }
}
