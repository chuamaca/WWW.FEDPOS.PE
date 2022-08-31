namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductoyCategoria : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        IdCategoria = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        Descripcion = c.String(),
                        Defecto = c.String(),
                    })
                .PrimaryKey(t => t.IdCategoria);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        IdProducto = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Usa_inventarios = c.String(),
                        Stock = c.String(),
                        Precio_de_compra = c.Double(nullable: false),
                        Fecha_de_vencimiento = c.String(),
                        Precio_de_venta = c.Double(nullable: false),
                        Codigo = c.String(),
                        Se_vende_a = c.String(),
                        Impuesto = c.String(),
                        Stock_minimo = c.Double(nullable: false),
                        Precio_mayoreo = c.Double(nullable: false),
                        CodigoSunat = c.String(),
                        CodUm = c.String(),
                        A_partir_de = c.Double(nullable: false),
                        IdCategoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProducto)
                .ForeignKey("dbo.Categoria", t => t.IdCategoria)
                .Index(t => t.IdCategoria);
            
            CreateTable(
                "dbo.Experiencia",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Usuario_id = c.Int(nullable: false),
                        Tipo = c.Byte(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Titulo = c.String(nullable: false, maxLength: 50),
                        Desde = c.String(nullable: false, maxLength: 10),
                        Hasta = c.String(maxLength: 10),
                        Descripcion = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Usuario", t => t.Usuario_id)
                .Index(t => t.Usuario_id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 32),
                        Direccion = c.String(unicode: false, storeType: "text"),
                        Ciudad = c.String(maxLength: 50),
                        Pais_id = c.Int(),
                        Telefono = c.String(maxLength: 50),
                        Facebook = c.String(maxLength: 100),
                        Twitter = c.String(maxLength: 100),
                        YouTube = c.String(maxLength: 100),
                        Foto = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Habilidad",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Usuario_id = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Dominio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Usuario", t => t.Usuario_id)
                .Index(t => t.Usuario_id);
            
            CreateTable(
                "dbo.Testimonio",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Usuario_id = c.Int(nullable: false),
                        IP = c.String(nullable: false, maxLength: 50),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Comentario = c.String(nullable: false, unicode: false, storeType: "text"),
                        Fecha = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Usuario", t => t.Usuario_id)
                .Index(t => t.Usuario_id);
            
            CreateTable(
                "dbo.TablaDato",
                c => new
                    {
                        Relacion = c.String(nullable: false, maxLength: 20),
                        Valor = c.String(nullable: false, maxLength: 20),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        Orden = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Relacion, t.Valor });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Testimonio", "Usuario_id", "dbo.Usuario");
            DropForeignKey("dbo.Habilidad", "Usuario_id", "dbo.Usuario");
            DropForeignKey("dbo.Experiencia", "Usuario_id", "dbo.Usuario");
            DropForeignKey("dbo.Producto", "IdCategoria", "dbo.Categoria");
            DropIndex("dbo.Testimonio", new[] { "Usuario_id" });
            DropIndex("dbo.Habilidad", new[] { "Usuario_id" });
            DropIndex("dbo.Experiencia", new[] { "Usuario_id" });
            DropIndex("dbo.Producto", new[] { "IdCategoria" });
            DropTable("dbo.TablaDato");
            DropTable("dbo.Testimonio");
            DropTable("dbo.Habilidad");
            DropTable("dbo.Usuario");
            DropTable("dbo.Experiencia");
            DropTable("dbo.Producto");
            DropTable("dbo.Categoria");
        }
    }
}
