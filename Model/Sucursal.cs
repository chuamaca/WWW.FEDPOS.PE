

namespace Model
{

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    using Model;
    using Helper;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;
    using System.Data.Entity;

    [Table("Sucursal")]
    public class Sucursal
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idsucursal { get; set; }

        [StringLength(100)]
        public string NombreSucursal { get; set; }

        [StringLength(20)]
        public string Codigo { get; set; }

        [StringLength(100)]
        public string Direccion { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        [StringLength(100)]
        public string Observacion { get; set; }
        public int Estado { get; set; }

        public int Idempresa { get; set; }
        public virtual Empresa Empresa { get; set; }


        public Sucursal ObtenerSucursal(int id)
        {
            var sucursal = new Sucursal();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    sucursal = ctx.Sucursal.Where(x => x.Idsucursal == id)
                                             .SingleOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return sucursal;
        }

        public ResponseModel GuardarSucursal()
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    if (this.Idsucursal > 0) ctx.Entry(this).State = EntityState.Modified;
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

        public ResponseModel EliminarSucursal(int id)
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    this.Idsucursal = id;
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


        public AnexGRIDResponde ListarSucursal(AnexGRID grid)
        {
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;

                    grid.Inicializar();

                    var query = ctx.Sucursal.Where(x => x.Idsucursal > 0);

                    //Ordenamiento
                    if (grid.columna == "id")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Idsucursal)
                                                             : query.OrderBy(x => x.Idsucursal);
                    }

                    if (grid.columna == "Codigo")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Codigo)
                                                             : query.OrderBy(x => x.Codigo);
                    }

                    if (grid.columna == "NombreSucursal")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.NombreSucursal)
                                                             : query.OrderBy(x => x.NombreSucursal);
                    }

                    if (grid.columna == "Idempresa")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Idempresa)
                                                             : query.OrderBy(x => x.Idempresa);
                    }


                    var sucursales = query.Skip(grid.pagina)
                                          .Take(grid.limite)
                                          .ToList();

                    var total = query.Count();

                    grid.SetData(
                        from a in sucursales
                        select new
                        {
                            a.Idsucursal,
                            a.Codigo,
                            a.NombreSucursal,
                            a.Idempresa
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


        public List<Sucursal> ListarSucursal()
        {
            var listarsucursal = new List<Sucursal>();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    listarsucursal = ctx.Sucursal.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return listarsucursal;
        }

    }
}
