using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tarea4.Controllers
{
    public class ContenidoController : Controller
    {
        // GET: Contenido
        public ActionResult Noticias()
        {
            return View();
        }
    }
}