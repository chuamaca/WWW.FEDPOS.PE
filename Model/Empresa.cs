

namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;



    [Table("Empresa")]
    public  class Empresa
    {
        public Empresa()
        {
            Sucursal = new HashSet<Sucursal>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idempresa { get; set; }
        public string Logo { get; set; }
        public string Impuesto { get; set; }
        public double Porcentaje_impuesto { get; set; }
        public string SimboloMoneda { get; set; }
        public string Trabajas_con_impuestos { get; set; }
        public string Modo_de_busqueda { get; set; }
        public string Carpeta_para_copias_de_seguridad { get; set; }
        public string Correo_para_envio_de_reportes { get; set; }
        public string Ultima_fecha_de_copia_de_seguridad { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yy}")]
        public DateTime Ultima_fecha_de_copia_date { get; set; }
        public int Frecuencia_de_copias { get; set; }
        public string Estado { get; set; }
        public string Tipo_de_empresa { get; set; }
        public string Redondeo_de_total { get; set; }
        public string VersionUbl { get; set; }
        public string VersionEstDoc { get; set; }

        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string DireccionFiscal { get; set; }
        public string Ubigeo { get; set; }
        public string ConectarSunat { get; set; }
        public string Servidor { get; set; }
        public string CarpetaCertificado { get; set; }
        public string Passcertificado { get; set; }
        public string UserSecundario { get; set; }
        public string PassSecundario { get; set; }
        public string CodMoneda { get; set; }

        public virtual ICollection<Sucursal> Sucursal { get; set; }

        public Empresa ObtenerEmpresa(int id)
        {
            var empresa = new Empresa();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    empresa = ctx.Empresa.Where(x => x.Idempresa == id)
                                             .SingleOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return empresa;
        }

        public ResponseModel GuardarEmpresa()
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    if (this.Idempresa > 0) ctx.Entry(this).State = EntityState.Modified;
                    else ctx.Entry(this).State = EntityState.Added;

                    ctx.SaveChanges();
                    rm.SetResponse(true);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return rm;
        }

        public ResponseModel EliminarEmpresa(int id)
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    this.Idempresa = id;
                    ctx.Entry(this).State = EntityState.Deleted;

                    ctx.SaveChanges();
                    rm.SetResponse(true);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return rm;
        }


        public AnexGRIDResponde ListarEmpresa(AnexGRID grid)
        {
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;

                    grid.Inicializar();

                    var query = ctx.Empresa.Where(x => x.Idempresa > 0);

                    //Ordenamiento
                    if (grid.columna == "id")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Idempresa)
                                                             : query.OrderBy(x => x.Idempresa);
                    }

                    if (grid.columna == "RazonSocial")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.RazonSocial)
                                                             : query.OrderBy(x => x.RazonSocial);
                    }

                    if (grid.columna == "Trabajas_con_impuestos")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Trabajas_con_impuestos)
                                                             : query.OrderBy(x => x.Trabajas_con_impuestos);
                    }

                    if (grid.columna == "Estado")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Estado)
                                                             : query.OrderBy(x => x.Estado);
                    }

                    if (grid.columna == "ConectarSunat")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.ConectarSunat)
                                                             : query.OrderBy(x => x.ConectarSunat);
                    }


                    var empresas = query.Skip(grid.pagina)
                                          .Take(grid.limite)
                                          .ToList();

                    var total = query.Count();

                    grid.SetData(
                        from a in empresas
                        select new
                        {
                            a.Idempresa,
                            a.RazonSocial,
                            a.Trabajas_con_impuestos,
                            a.Estado,
                            a.ConectarSunat
                        },
                        total);
                }
            }
            catch (Exception E)
            {

                throw;
            }

            return grid.responde();
        }



    }
}
