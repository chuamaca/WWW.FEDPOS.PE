namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnidadMedida : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UnidadMedida",
                c => new
                    {
                        Idunidad = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Idunidad);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UnidadMedida");
        }
    }
}
