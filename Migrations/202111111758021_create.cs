namespace DemoDevJr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumnoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        rude = c.String(),
                        imagen = c.String(),
                        nombres = c.String(nullable: false),
                        apellidoPaterno = c.String(nullable: false),
                        apellidoMaterno = c.String(nullable: false),
                        sexo = c.String(nullable: false, maxLength: 1),
                        lugarNacimiento = c.String(),
                        fechaNacimiento = c.DateTime(nullable: false),
                        ci = c.String(nullable: false),
                        direccion = c.String(),
                        zona = c.String(),
                        telefono = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Apoderadoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ocupacion = c.String(),
                        nombres = c.String(nullable: false),
                        apellidoPaterno = c.String(nullable: false),
                        apellidoMaterno = c.String(nullable: false),
                        sexo = c.String(nullable: false, maxLength: 1),
                        lugarNacimiento = c.String(),
                        fechaNacimiento = c.DateTime(nullable: false),
                        ci = c.String(nullable: false),
                        direccion = c.String(),
                        zona = c.String(),
                        telefono = c.Int(nullable: false),
                        alumno_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Alumnoes", t => t.alumno_id)
                .Index(t => t.alumno_id);
            
            CreateTable(
                "dbo.Cursoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        grado = c.String(nullable: false),
                        paralelo = c.String(nullable: false, maxLength: 1),
                        nivel = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Inscripcions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        colegioProcedencia = c.String(),
                        tipoInscripcion = c.String(nullable: false),
                        porcentajeBeca = c.Double(nullable: false),
                        observacion1 = c.String(),
                        observacion2 = c.String(),
                        alumno_id = c.Int(),
                        curso_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Alumnoes", t => t.alumno_id)
                .ForeignKey("dbo.Cursoes", t => t.curso_id)
                .Index(t => t.alumno_id)
                .Index(t => t.curso_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inscripcions", "curso_id", "dbo.Cursoes");
            DropForeignKey("dbo.Inscripcions", "alumno_id", "dbo.Alumnoes");
            DropForeignKey("dbo.Apoderadoes", "alumno_id", "dbo.Alumnoes");
            DropIndex("dbo.Inscripcions", new[] { "curso_id" });
            DropIndex("dbo.Inscripcions", new[] { "alumno_id" });
            DropIndex("dbo.Apoderadoes", new[] { "alumno_id" });
            DropTable("dbo.Inscripcions");
            DropTable("dbo.Cursoes");
            DropTable("dbo.Apoderadoes");
            DropTable("dbo.Alumnoes");
        }
    }
}
