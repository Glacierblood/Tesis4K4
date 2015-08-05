namespace FinalTest1.Contextos.AERMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalesUpdate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animals", "fechaBaja", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Animals", "fechaBaja", c => c.DateTime(nullable: false));
        }
    }
}
