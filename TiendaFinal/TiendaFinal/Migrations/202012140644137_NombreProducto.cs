namespace TiendaFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NombreProducto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Productoes", "Nombre", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productoes", "Nombre", c => c.String(nullable: false, maxLength: 25, unicode: false));
        }
    }
}
