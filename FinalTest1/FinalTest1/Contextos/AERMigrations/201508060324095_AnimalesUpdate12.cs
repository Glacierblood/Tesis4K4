namespace FinalTest1.Contextos.AERMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalesUpdate12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Adopcions", "tipoAdopcionId", "dbo.TipoAdopcions");
            DropIndex("dbo.Adopcions", new[] { "tipoAdopcionId" });
            AlterColumn("dbo.Adopcions", "tipoAdopcionId", c => c.Int());
            CreateIndex("dbo.Adopcions", "tipoAdopcionId");
            AddForeignKey("dbo.Adopcions", "tipoAdopcionId", "dbo.TipoAdopcions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Adopcions", "tipoAdopcionId", "dbo.TipoAdopcions");
            DropIndex("dbo.Adopcions", new[] { "tipoAdopcionId" });
            AlterColumn("dbo.Adopcions", "tipoAdopcionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Adopcions", "tipoAdopcionId");
            AddForeignKey("dbo.Adopcions", "tipoAdopcionId", "dbo.TipoAdopcions", "Id", cascadeDelete: true);
        }
    }
}
