namespace TiendaFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20, unicode: false),
                        ApellidoPaterno = c.String(nullable: false, maxLength: 14),
                        ApellidoMaterno = c.String(nullable: false, maxLength: 14),
                        Telefono = c.String(nullable: false, maxLength: 250),
                        Direccion = c.String(nullable: false, maxLength: 250),
                        CorreoElectronico = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clientes");
        }
    }
}
