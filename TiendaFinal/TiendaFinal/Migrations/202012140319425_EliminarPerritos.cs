namespace TiendaFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EliminarPerritos : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Perroes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Perroes",
                c => new
                    {
                        PerroId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20, unicode: false),
                        Raza = c.String(nullable: false, maxLength: 20, unicode: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sexo = c.String(nullable: false, maxLength: 1),
                        FechaDeNacimiento = c.String(nullable: false, maxLength: 8, unicode: false),
                    })
                .PrimaryKey(t => t.PerroId);
            
        }
    }
}
