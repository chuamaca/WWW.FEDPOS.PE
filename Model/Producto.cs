

namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    [Table("Producto")]
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }


        [DisplayName("Controlar Inventario")]
        public string Usa_inventarios { get; set; }
        public string Stock { get; set; }
        public double Precio_de_compra { get; set; }
        public string Fecha_de_vencimiento { get; set; }
        public double Precio_de_venta { get; set; }
        public string Codigo { get; set; }

        [DisplayName("Venta Por")]
        public string Se_vende_a { get; set; }
        public string Impuesto { get; set; }
        public double Stock_minimo { get; set; }
        public double Precio_mayoreo { get; set; }
        public string CodigoSunat { get; set; }
        public string CodUm { get; set; }
        public double A_partir_de { get; set; }
        
        public int IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }


        public Producto ObtenerProducto(int id)
        {
            var producto = new Producto();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    producto = ctx.Producto.Where(x => x.IdProducto == id)
                                             .SingleOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return producto;
        }

        public ResponseModel GuardarProducto()
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    if (this.IdProducto > 0) ctx.Entry(this).State = EntityState.Modified;
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

        public ResponseModel EliminarProducto(int id)
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    this.IdProducto = id;
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

        public AnexGRIDResponde ListarProducto(AnexGRID grid)
        {
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;

                    grid.Inicializar();

                    var query = ctx.Producto.Where(x => x.IdProducto > 0);

                    //Ordenamiento
                    if (grid.columna == "id")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.IdProducto)
                                                             : query.OrderBy(x => x.IdProducto);
                    }

                    if (grid.columna == "Descripcion")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Descripcion)
                                                             : query.OrderBy(x => x.Descripcion);
                    }
                    if (grid.columna == "Stock")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Stock)
                                                             : query.OrderBy(x => x.Stock);
                    }

                    if (grid.columna == "Precio_de_venta")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Precio_de_venta)
                                                             : query.OrderBy(x => x.Precio_de_venta);
                    }

                    if (grid.columna == "Precio_de_compra")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Precio_de_compra)
                                                             : query.OrderBy(x => x.Precio_de_compra);
                    }


                    var categorias = query.Skip(grid.pagina)
                                          .Take(grid.limite)
                                          .ToList();

                    var total = query.Count();

                    grid.SetData(
                        from a in categorias
                        select new
                        {
                            a.IdProducto,
                            a.Descripcion,
                            a.Stock,
                            a.Precio_de_venta,
                            a.Precio_de_compra
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
