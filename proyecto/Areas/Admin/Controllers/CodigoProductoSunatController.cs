using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace proyecto.Areas.Admin.Controllers
{
    public class CodigoProductoSunatController : Controller
    {
        // GET: Admin/CodigoSunat
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult leertxt(CodigoProductoSunat model, HttpPostedFileBase txt)
        {
            var rm = new ResponseModel();
            if (ModelState.IsValid)
            {
                rm = model.InsertarcodigosProductosSunat(txt);

                if (rm.response)
                {
                    rm.message = "Guardado Correctamente";
                    rm.href = Url.Content("~/admin/categoria");
                }
            }

            return Json(rm);
        }
    }
}