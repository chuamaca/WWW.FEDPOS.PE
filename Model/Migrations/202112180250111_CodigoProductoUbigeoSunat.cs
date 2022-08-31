namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodigoProductoUbigeoSunat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CodigoProductoSunat",
                c => new
                    {
                        codigo = c.String(nullable: false, maxLength: 128),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.codigo);
            
            CreateTable(
                "dbo.CodigoUbigeoSunat",
                c => new
                    {
                       
                        Departamento = c.String(),
                        Provincia = c.String(),
                        Distrito = c.String(),
                        Ubigeo = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Ubigeo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CodigoUbigeoSunat");
            DropTable("dbo.CodigoProductoSunat");
        }
    }
}
