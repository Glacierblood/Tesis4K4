namespace FinalTest1.Contextos.AERMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalesUpdate14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adopcions", "nombreVoluntario", c => c.String());
            AddColumn("dbo.Adopcions", "nombreAdm", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adopcions", "nombreAdm");
            DropColumn("dbo.Adopcions", "nombreVoluntario");
        }
    }
}
