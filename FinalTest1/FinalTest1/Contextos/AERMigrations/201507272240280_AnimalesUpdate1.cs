namespace FinalTest1.Contextos.AERMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalesUpdate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animals", "nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Animals", "caracteristicas", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Animals", "caracteristicas", c => c.String());
            AlterColumn("dbo.Animals", "nombre", c => c.String());
        }
    }
}
