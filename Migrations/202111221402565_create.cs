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
                        alumnoId = c.Int(nullable: false, identity: true),
                        rude = c.String(),
                        imagen = c.String(),
                        nombres = c.String(nullable: false),
                        apellidoPaterno = c.String(nullable: false),
                        apellidoMaterno = c.String(nullable: false),
                        sexo = c.Int(nullable: false),
                        lugarNacimiento = c.String(),
                        fechaNacimiento = c.DateTime(nullable: false),
                        ci = c.String(nullable: false),
                        direccion = c.String(),
                        zona = c.String(),
                        telefono = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.alumnoId);
            
            CreateTable(
                "dbo.Apoderadoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ocupacion = c.String(),
                        alumnoId = c.Int(nullable: false),
                        nombres = c.String(nullable: false),
                        apellidoPaterno = c.String(nullable: false),
                        apellidoMaterno = c.String(nullable: false),
                        sexo = c.Int(nullable: false),
                        lugarNacimiento = c.String(),
                        fechaNacimiento = c.DateTime(nullable: false),
                        ci = c.String(nullable: false),
                        direccion = c.String(),
                        zona = c.String(),
                        telefono = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Alumnoes", t => t.alumnoId, cascadeDelete: true)
                .Index(t => t.alumnoId);
            
            CreateTable(
                "dbo.Inscripcions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        matricula = c.Int(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        colegioProcedencia = c.String(),
                        tipoInscripcion = c.Int(nullable: false),
                        observacion1 = c.String(),
                        observacion2 = c.String(),
                        alumnoId = c.Int(nullable: false),
                        cursoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Alumnoes", t => t.alumnoId, cascadeDelete: true)
                .ForeignKey("dbo.Cursoes", t => t.cursoId, cascadeDelete: true)
                .Index(t => t.alumnoId)
                .Index(t => t.cursoId);
            
            CreateTable(
                "dbo.Cursoes",
                c => new
                    {
                        cursoId = c.Int(nullable: false, identity: true),
                        grado = c.Int(nullable: false),
                        paralelo = c.Int(nullable: false),
                        nivel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.cursoId);
            
            CreateTable(
                "dbo.Contactoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        email = c.String(),
                        asunto = c.String(),
                        mensaje = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inscripcions", "cursoId", "dbo.Cursoes");
            DropForeignKey("dbo.Inscripcions", "alumnoId", "dbo.Alumnoes");
            DropForeignKey("dbo.Apoderadoes", "alumnoId", "dbo.Alumnoes");
            DropIndex("dbo.Inscripcions", new[] { "cursoId" });
            DropIndex("dbo.Inscripcions", new[] { "alumnoId" });
            DropIndex("dbo.Apoderadoes", new[] { "alumnoId" });
            DropTable("dbo.Contactoes");
            DropTable("dbo.Cursoes");
            DropTable("dbo.Inscripcions");
            DropTable("dbo.Apoderadoes");
            DropTable("dbo.Alumnoes");
        }
    }
}
