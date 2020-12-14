namespace TiendaFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiosPerros : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Perroes", "Raza", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AddColumn("dbo.Perroes", "Precio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Perroes", "Precio");
            DropColumn("dbo.Perroes", "Raza");
        }
    }
}
