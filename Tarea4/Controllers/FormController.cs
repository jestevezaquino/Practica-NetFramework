using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tarea4.Models;
using System.Web.Mvc;

namespace Tarea4.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Curriculum cv)
        {
            if (ModelState.IsValid)
            {
                string fileName = cv.Foto.FileName;
                if (fileName != null)
                {
                    cv.Foto.SaveAs(Server.MapPath("/src/img/" + fileName));
                    ViewBag.picture = fileName;
                }
                string archivo = cv.pdf.FileName;

                if (archivo != null)
                {
                    cv.pdf.SaveAs(Server.MapPath("/src/pdf/" + archivo));
                    ViewBag.curriculum = archivo;
                }
                return View("Resultados", cv);
            }
            else
            {
                return View("Index");
            }

        }

        public ActionResult Resultados(Curriculum cv)
        {
            return View(cv);
        }
    }
}