namespace FinalTest1.Contextos.AERMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalesUpdate9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Adopcions", "esTemporal", c => c.Boolean());
            AlterColumn("dbo.Adopcions", "fechaAlta", c => c.DateTime());
            AlterColumn("dbo.Adopcions", "fechaBaja", c => c.DateTime());
            AlterColumn("dbo.Adopcions", "fechaConfirmacion", c => c.DateTime());
            AlterColumn("dbo.Adopcions", "fechaCancelacion", c => c.DateTime());
            AlterColumn("dbo.Adopcions", "fechaEntrega", c => c.DateTime());
            AlterColumn("dbo.Adopcions", "fechaFin", c => c.DateTime());
            AlterColumn("dbo.Adopcions", "importe", c => c.Single());
            AlterColumn("dbo.Adopcions", "fechaFinColaboracion", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Adopcions", "fechaFinColaboracion", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Adopcions", "importe", c => c.Single(nullable: false));
            AlterColumn("dbo.Adopcions", "fechaFin", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Adopcions", "fechaEntrega", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Adopcions", "fechaCancelacion", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Adopcions", "fechaConfirmacion", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Adopcions", "fechaBaja", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Adopcions", "fechaAlta", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Adopcions", "esTemporal", c => c.Boolean(nullable: false));
        }
    }
}
