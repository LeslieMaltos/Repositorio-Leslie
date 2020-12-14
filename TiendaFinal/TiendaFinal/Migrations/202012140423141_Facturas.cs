namespace TiendaFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Facturas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        FacturaId = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 200, unicode: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FacturaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Facturas");
        }
    }
}
