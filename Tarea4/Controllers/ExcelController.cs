using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bytescout.Spreadsheet;

namespace Tarea4.Controllers
{
    public class ExcelController : Controller
    {

        // GET: Excel
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult _ExcelPartial()
        {
            return View();
        }


        [HttpPost]
        public ActionResult _ExcelPartial(HttpPostedFileBase archivo)
        {
            archivo.SaveAs(Server.MapPath("/Lector/" + archivo.FileName));
            Spreadsheet doc = new Spreadsheet();
            doc.LoadFromFile(Server.MapPath("/Lector/" + archivo.FileName));
            Worksheet ws = doc.Workbook.Worksheets.ByName("Hoja1");
            List<string> columnas = new List<string>();
            int r = 0;
            int c = 0;

            while (ws.Cell(r, c).ValueAsString != null)
            {
                columnas.Add(ws.Cell(r, c).ValueAsString);
                c++;
                r++;
            }
            return View();
        }
    }
}