namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Empresa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        Idempresa = c.Int(nullable: false, identity: true),
                        Logo = c.String(),
                        Impuesto = c.String(),
                        Porcentaje_impuesto = c.Double(nullable: false),
                        SimboloMoneda = c.String(),
                        Trabajas_con_impuestos = c.String(),
                        Modo_de_busqueda = c.String(),
                        Carpeta_para_copias_de_seguridad = c.String(),
                        Correo_para_envio_de_reportes = c.String(),
                        Ultima_fecha_de_copia_de_seguridad = c.String(),
                        Ultima_fecha_de_copia_date = c.DateTime(nullable: false),
                        Frecuencia_de_copias = c.Int(nullable: false),
                        Estado = c.String(),
                        Tipo_de_empresa = c.String(),
                        Redondeo_de_total = c.String(),
                        VersionUbl = c.String(),
                        VersionEstDoc = c.String(),
                        Ruc = c.String(),
                        RazonSocial = c.String(),
                        DireccionFiscal = c.String(),
                        Ubigeo = c.String(),
                        ConectarSunat = c.String(),
                        Servidor = c.String(),
                        CarpetaCertificado = c.String(),
                        Passcertificado = c.String(),
                        UserSecundario = c.String(),
                        PassSecundario = c.String(),
                        CodMoneda = c.String(),
                    })
                .PrimaryKey(t => t.Idempresa);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Empresa");
        }
    }
}
