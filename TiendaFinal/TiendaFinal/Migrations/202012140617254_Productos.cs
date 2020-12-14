namespace TiendaFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Productos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        ProductoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 25, unicode: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Proveedor = c.String(nullable: false, maxLength: 50),
                        CantidadStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Productoes");
        }
    }
}
