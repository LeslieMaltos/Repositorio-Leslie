namespace TiendaFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Perritos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Perroes",
                c => new
                    {
                        PerroId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20, unicode: false),
                        Sexo = c.String(nullable: false, maxLength: 1),
                        FechaDeNacimiento = c.String(nullable: false, maxLength: 8, unicode: false),
                    })
                .PrimaryKey(t => t.PerroId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Perroes");
        }
    }
}
