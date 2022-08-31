using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Helper;

namespace proyecto.Areas.Admin.Controllers
{
    public class ClienteController : Controller
    {

        private Cliente cliente = new Cliente();
        // GET: Admin/Cliente
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarCliente(AnexGRID grid)
        {
            return Json(cliente.ListarCliente(grid));
        }

        public ActionResult crud(int id = 0)
        {
            return View(id == 0 ? new Cliente() : cliente.ObtenerCliente(id));

        }


        public JsonResult guardarcliente(Cliente model)
        {
            var rm = new ResponseModel();
            if (ModelState.IsValid)
            {
                rm = model.GuardarCliente();
                if (rm.response)
                {
                    rm.message = "Guardado Correctamente";
                    rm.href = Url.Content("~/admin/cliente");
                }
            }

            return Json(rm);
        }

        public JsonResult eliminarcliente(int id)
        {
            cliente.IdCliente = id;
            return Json(cliente.EliminarCliente(id));
        }

    }
}