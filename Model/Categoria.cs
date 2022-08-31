

namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    [Table("Categoria")]
    public class Categoria
    {

        public Categoria()
        {
            Producto = new HashSet<Producto>();
           
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategoria { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Defecto { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }

        public Categoria ObtenerCategoria(int id)
        {
            var categoria = new Categoria();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    categoria = ctx.Categoria.Where(x => x.IdCategoria == id)
                                             .SingleOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return categoria;
        }

        public ResponseModel GuardarCategoria()
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    if (this.IdCategoria > 0) ctx.Entry(this).State = EntityState.Modified;
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

        public ResponseModel EliminarCategoria(int id)
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    this.IdCategoria = id;
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
     

        public AnexGRIDResponde ListarCategoria(AnexGRID grid)
        {
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;

                    grid.Inicializar();

                    var query = ctx.Categoria.Where(x => x.IdCategoria > 0);

                    //Ordenamiento
                    if (grid.columna == "id")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.IdCategoria)
                                                             : query.OrderBy(x => x.IdCategoria);
                    }

                    if (grid.columna == "Codigo")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Codigo)
                                                             : query.OrderBy(x => x.Codigo);
                    }

                    if (grid.columna == "Descripcion")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Descripcion)
                                                             : query.OrderBy(x => x.Descripcion);
                    }

                    if (grid.columna == "Defecto")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Defecto)
                                                             : query.OrderBy(x => x.Defecto);
                    }


                    var categorias = query.Skip(grid.pagina)
                                          .Take(grid.limite)
                                          .ToList();

                    var total = query.Count();

                    grid.SetData(
                        from a in  categorias
                        select new 
                        { 
                            a.IdCategoria,
                            a.Codigo, 
                            a.Descripcion,
                            a.Defecto 
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


        public List<Categoria> ListarCategoria()
        {
            var listacategoria = new List<Categoria>();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    listacategoria = ctx.Categoria.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return listacategoria;
        }

        //public ResponseModel EliminarCategoria()
        //{
        //    var rm = new ResponseModel();

        //    try
        //    {
        //        using (var ctx = new ProyectoContext())
        //        {

        //            ctx.Entry(this).State = EntityState.Deleted;

        //            ctx.SaveChanges();
        //            rm.SetResponse(true);
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    return rm;
        //}
    }
}
