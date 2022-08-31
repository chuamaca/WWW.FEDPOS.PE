using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto.Areas.Admin.Controllers
{
    public class CodigoUbigeoSunatController : Controller
    {
        // GET: Admin/CodigoUbigeoSunat
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult leertxt(CodigoUbigeoSunat model, HttpPostedFileBase txt)
        {
            var rm = new ResponseModel();
            if (ModelState.IsValid)
            {
                rm = model.InsertarcodigosUbigeoSunat(txt);

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