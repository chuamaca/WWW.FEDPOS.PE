using proyecto.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Helper;
using Model;

namespace proyecto.Areas.Admin.Controllers
{

    [Autenticado]
    public class CategoriaController : Controller
    {

        private Categoria categoria = new Categoria();
        // GET: Admin/Categoria
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarCategoria(AnexGRID grid)
        {
            return Json(categoria.ListarCategoria(grid));
        }

        public ActionResult crud(int id=0) 
        {
            return View(id == 0 ? new Categoria() : categoria.ObtenerCategoria(id));
        
        }


        public JsonResult guardarcategoria(Categoria model)
        {
            var rm = new ResponseModel();
            if (ModelState.IsValid)
            {
                rm = model.GuardarCategoria();
                if (rm.response)
                {
                    rm.message= "Guardado Correctamente";
                    rm.href = Url.Content("~/admin/categoria");
                }
            }

            return Json(rm);
        }

        public JsonResult eliminarcategoria(int id)
        {
            categoria.IdCategoria = id;
            

            return Json(categoria.EliminarCategoria(id));
        }


    }
}