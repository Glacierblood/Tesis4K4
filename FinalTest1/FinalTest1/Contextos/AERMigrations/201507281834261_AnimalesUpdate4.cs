namespace FinalTest1.Contextos.AERMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalesUpdate4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50),
                        descripcion = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RegistroAccions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fechaAlta = c.DateTime(nullable: false),
                        fechaBaja = c.DateTime(nullable: false),
                        esHabilitado = c.Boolean(nullable: false),
                        comentario = c.String(),
                        accionId = c.Int(nullable: false),
                        usrId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accions", t => t.accionId, cascadeDelete: true)
                
                .Index(t => t.accionId)
                ;
           
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegistroAccions", "accionId", "dbo.Accions");
            DropIndex("dbo.RegistroAccions", new[] { "accionId" });
            DropTable("dbo.RegistroAccions");
            DropTable("dbo.Accions");
        }
    }
}
