namespace FinalTest1.Contextos.AERMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalesUpdate3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Razas", "nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Razas", "descripcion", c => c.String(maxLength: 150));
            AlterColumn("dbo.Especies", "nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Especies", "descripcion", c => c.String(maxLength: 150));
            AlterColumn("dbo.Tamanios", "nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Tamanios", "descripcion", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tamanios", "descripcion", c => c.String());
            AlterColumn("dbo.Tamanios", "nombre", c => c.String());
            AlterColumn("dbo.Especies", "descripcion", c => c.String());
            AlterColumn("dbo.Especies", "nombre", c => c.String());
            AlterColumn("dbo.Razas", "descripcion", c => c.String());
            AlterColumn("dbo.Razas", "nombre", c => c.String());
        }
    }
}
