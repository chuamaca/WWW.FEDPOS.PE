using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Helper;

namespace proyecto.Areas.Admin.Controllers
{
    public class EmpresaController : Controller
    {
        private Empresa empresa = new Empresa();
        // GET: Admin/Cliente
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarEmpresa(AnexGRID grid)
        {
            return Json(empresa.ListarEmpresa(grid));
        }

        public ActionResult crud(int id = 0)
        {
            return View(id == 0 ? new Empresa() : empresa.ObtenerEmpresa(id));

        }


        public JsonResult guardarempresa(Empresa model)
        {
            var rm = new ResponseModel();
            if (ModelState.IsValid)
            {
                rm = model.GuardarEmpresa();
                if (rm.response)
                {
                    rm.message = "Guardado Correctamente";
                    rm.href = Url.Content("~/admin/empresa");
                }
            }

            return Json(rm);
        }

        public JsonResult eliminarempresa(int id)
        {
            empresa.Idempresa = id;
            return Json(empresa.EliminarEmpresa(id));
        }
    }
}