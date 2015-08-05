namespace FinalTest1.Contextos.AERMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalesUpdate6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adopcions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        voluntarioId = c.String(maxLength: 128),
                        admId = c.String(maxLength: 128),
                        tipoAdopcionId = c.Int(nullable: false),
                        estadoAdopcionId = c.Int(nullable: false),
                        esTemporal = c.Boolean(nullable: false),
                        fechaAlta = c.DateTime(nullable: false),
                        fechaBaja = c.DateTime(nullable: false),
                        fechaConfirmacion = c.DateTime(nullable: false),
                        fechaCancelacion = c.DateTime(nullable: false),
                        fechaEntrega = c.DateTime(nullable: false),
                        fechaFin = c.DateTime(nullable: false),
                        importe = c.Single(nullable: false),
                        fechaFinColaboracion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EstadoAdopcions", t => t.estadoAdopcionId, cascadeDelete: true)
                .ForeignKey("dbo.TipoAdopcions", t => t.tipoAdopcionId, cascadeDelete: true)
                .Index(t => t.tipoAdopcionId)
                .Index(t => t.estadoAdopcionId);
            
            CreateTable(
                "dbo.EstadoAdopcions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoAdopcions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Adopcions", "tipoAdopcionId", "dbo.TipoAdopcions");
            DropForeignKey("dbo.Adopcions", "estadoAdopcionId", "dbo.EstadoAdopcions");
            DropIndex("dbo.Adopcions", new[] { "estadoAdopcionId" });
            DropIndex("dbo.Adopcions", new[] { "tipoAdopcionId" });
            DropTable("dbo.TipoAdopcions");
            DropTable("dbo.EstadoAdopcions");
            DropTable("dbo.Adopcions");
        }
    }
}
