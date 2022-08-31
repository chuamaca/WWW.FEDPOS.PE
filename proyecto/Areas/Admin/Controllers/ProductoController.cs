using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helper;
using Model;
using proyecto.Areas.Admin.Filters;

namespace proyecto.Areas.Admin.Controllers
{
    [Autenticado]
    public class ProductoController : Controller
    {

        private Producto producto = new Producto();
        private Categoria categoria = new Categoria();
        private UnidadMedida unidadmedida = new UnidadMedida();
        // GET: Admin/Producto
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarProducto(AnexGRID grid)
        {
            return Json(producto.ListarProducto(grid));
        }

        public ActionResult crud(int id = 0)
        {
            //PARA MOSTRAR LISTA DE CATEGORIAS AL MOMENTO DE REALIZAR UN CRUD
            ViewBag.micategoria = categoria.ListarCategoria();
            ViewBag.miunidadmedida = unidadmedida.ListarUnidadMedida();


            return View(id == 0 ? new Producto() : producto.ObtenerProducto(id));

        }


        public JsonResult guardarproducto(Producto model)
        {
            var rm = new ResponseModel();
            if (model.Fecha_de_vencimiento==null)
            {
                model.Fecha_de_vencimiento = "No Aplica";
            }

            if (model.Usa_inventarios == "NO")
            {
                model.Stock = "Ilimitado";
                model.Stock_minimo = 0;
            }

            if (ModelState.IsValid)
            {
                rm = model.GuardarProducto();
                if (rm.response)
                {
                    rm.message = "Guardado Correctamente";
                    rm.href = Url.Content("~/admin/producto");
                }
            }

            return Json(rm);
        }

        public JsonResult Eliminar(int id)
        {
            producto.IdProducto = id;
            
            return Json(producto.EliminarProducto(id));
        }

    }
}