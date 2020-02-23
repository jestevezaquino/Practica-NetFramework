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
            string fileName = cv.Foto.FileName;
            cv.Foto.SaveAs(Server.MapPath("/img/" + fileName));
            ViewBag.picture = fileName;

            string fileName2 = cv.Cv.FileName;
            cv.Cv.SaveAs(Server.MapPath("/pdf/" + fileName2));
            ViewBag.curriculum = fileName2;

            if (ModelState.IsValid) 
            { 
                return View("Resultados", cv);
            }
            else 
            {
                return View();
            }
            
        }

        public ActionResult Resultados(Curriculum cv) 
        {
            return View(cv);
        }
    }
}