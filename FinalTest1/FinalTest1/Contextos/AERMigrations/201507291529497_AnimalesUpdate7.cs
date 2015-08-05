namespace FinalTest1.Contextos.AERMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalesUpdate7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EstadoAdopcions", "nombre", c => c.String(nullable: false, maxLength: 50));
            AddForeignKey("dbo.Adopcions", "admId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Adopcions", "voluntarioId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EstadoAdopcions", "nombre", c => c.String());
        }
    }
}
