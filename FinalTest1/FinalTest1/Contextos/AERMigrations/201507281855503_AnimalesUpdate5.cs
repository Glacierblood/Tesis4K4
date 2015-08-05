namespace FinalTest1.Contextos.AERMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalesUpdate5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RegistroAccions", "usrId", c => c.String(nullable: false, maxLength: 128));
            //FK agregada
            AddForeignKey("dbo.RegistroAccions", "usrId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {//habilitar esta columna si presenta errores al hacer las migraciones
            //DropForeignKey("usrId");
            AlterColumn("dbo.RegistroAccions", "usrId", c => c.String());
        }
    }
}
