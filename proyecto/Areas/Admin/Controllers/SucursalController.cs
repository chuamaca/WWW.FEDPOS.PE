using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Helper;

namespace proyecto.Areas.Admin.Controllers
{
    public class SucursalController : Controller
    {
        private Sucursal sucursal = new Sucursal();
        // GET: Admin/Categoria
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarSucursal(AnexGRID grid)
        {
            return Json(sucursal.ListarSucursal(grid));
        }

        public ActionResult crud(int id = 0)
        {
            return View(id == 0 ? new Sucursal() : sucursal.ObtenerSucursal(id));

        }


        public JsonResult guardarsucursal(Sucursal model)
        {
            var rm = new ResponseModel();
            if (ModelState.IsValid)
            {
                rm = model.GuardarSucursal();
                if (rm.response)
                {
                    rm.message = "Guardado Correctamente";
                    rm.href = Url.Content("~/admin/sucursal");
                }
            }

            return Json(rm);
        }

        public JsonResult eliminarcategoria(int id)
        {
            sucursal.Idsucursal = id;
            return Json(sucursal.EliminarSucursal(id));
        }

    }
}