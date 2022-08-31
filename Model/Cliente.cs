

namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Table("Cliente")]
    public class Cliente
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }

        [Required]
        [DisplayName("Razon Social")]
        [StringLength(60)]
        public string NombreCliente { get; set; }


        [Required]
        [DisplayName("R.U.C")]
        [StringLength(11, MinimumLength = 8)]
        public string NroDocumento { get; set; }


        [Required]
        [DisplayName("Direccion")]
        [StringLength(100)]
        public string Direccion { get; set; }


        [Required]
        [DisplayName("Correo")]
        [StringLength(30)]
        public string Correo { get; set; }

        [Required]
        [DisplayName("Telefono")]
        [StringLength(15)]
        public string Telefono { get; set; }



        [DisplayName("Logo")]
        [StringLength(32)]
        public string Logocliente { get; set; }



        [DisplayName("Observacion")]
        [StringLength(100)]
        public string Observacion { get; set; }

        public double Saldo { set; get; }
        public string Tipodoc { set; get; }


        [DisplayName("Estado")]
        public int Estado { get; set; }



        public Cliente ObtenerCliente(int id)
        {
            var cliente = new Cliente();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    cliente = ctx.Cliente.Where(x => x.IdCliente == id)
                                             .SingleOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return cliente;
        }

        public ResponseModel GuardarCliente()
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    if (this.IdCliente > 0) ctx.Entry(this).State = EntityState.Modified;
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

        public ResponseModel EliminarCliente(int id)
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    this.IdCliente = id;
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
     

        public AnexGRIDResponde ListarCliente(AnexGRID grid)
        {
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;

                    grid.Inicializar();

                    var query = ctx.Cliente.Where(x => x.IdCliente > 0);

                    //Ordenamiento
                    if (grid.columna == "id")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.IdCliente)
                                                             : query.OrderBy(x => x.IdCliente);
                    }

                    if (grid.columna == "NombreCliente")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.NombreCliente)
                                                             : query.OrderBy(x => x.NombreCliente);
                    }

                    if (grid.columna == "NroDocuemnto")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.NroDocumento)
                                                             : query.OrderBy(x => x.NroDocumento);
                    }

                    if (grid.columna == "Estado")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Estado)
                                                             : query.OrderBy(x => x.Estado);
                    }


                    var clientes = query.Skip(grid.pagina)
                                          .Take(grid.limite)
                                          .ToList();

                    var total = query.Count();

                    grid.SetData(
                        from a in clientes
                        select new
                        {
                            a.IdCliente,
                            a.NombreCliente,
                            a.NroDocumento,
                            a.Estado
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
