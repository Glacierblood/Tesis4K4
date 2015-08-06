namespace FinalTest1.Contextos.AERMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalesUpdate13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Adopcions", "animalId", "dbo.Animals");
            DropIndex("dbo.Adopcions", new[] { "animalId" });
            AlterColumn("dbo.Adopcions", "animalId", c => c.Int(nullable: false));
            CreateIndex("dbo.Adopcions", "animalId");
            AddForeignKey("dbo.Adopcions", "animalId", "dbo.Animals", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Adopcions", "animalId", "dbo.Animals");
            DropIndex("dbo.Adopcions", new[] { "animalId" });
            AlterColumn("dbo.Adopcions", "animalId", c => c.Int());
            CreateIndex("dbo.Adopcions", "animalId");
            AddForeignKey("dbo.Adopcions", "animalId", "dbo.Animals", "Id");
        }
    }
}
