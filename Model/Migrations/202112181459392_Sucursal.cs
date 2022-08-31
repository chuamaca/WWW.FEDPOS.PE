namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sucursal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sucursal",
                c => new
                    {
                        Idsucursal = c.Int(nullable: false, identity: true),
                        NombreSucursal = c.String(maxLength: 100),
                        Codigo = c.String(maxLength: 20),
                        Direccion = c.String(maxLength: 100),
                        Telefono = c.String(maxLength: 20),
                        Observacion = c.String(maxLength: 100),
                        Estado = c.Int(nullable: false),
                        Idempresa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Idsucursal)
                .ForeignKey("dbo.Empresa", t => t.Idempresa)
                .Index(t => t.Idempresa);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sucursal", "Idempresa", "dbo.Empresa");
            DropIndex("dbo.Sucursal", new[] { "Idempresa" });
            DropTable("dbo.Sucursal");
        }
    }
}
