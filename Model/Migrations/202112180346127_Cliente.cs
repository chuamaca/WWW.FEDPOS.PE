namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        NombreCliente = c.String(nullable: false, maxLength: 60),
                        NroDocumento = c.String(nullable: false, maxLength: 11),
                        Direccion = c.String(nullable: false, maxLength: 100),
                        Correo = c.String(nullable: false, maxLength: 30),
                        Telefono = c.String(nullable: false, maxLength: 15),
                        Logocliente = c.String(maxLength: 32),
                        Observacion = c.String(maxLength: 100),
                        Saldo = c.Double(nullable: false),
                        Tipodoc = c.String(),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCliente);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cliente");
        }
    }
}
