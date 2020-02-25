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


        public ActionResult Datos()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Datos(HttpPostedFileBase archivo)
        {
            archivo.SaveAs(Server.MapPath("/Lector/" + archivo.FileName));
            Spreadsheet doc = new Spreadsheet();
            doc.LoadFromFile(Server.MapPath("/Lector/" + archivo.FileName));
            Worksheet ws = doc.Workbook.Worksheets.ByName("Hoja1");
            string[,] matriz;
            int r = 0;
            int c = 0;
            while (ws.Cell(r, c).ValueAsString != "") 
            {
                r++;
                c++;
            }
            matriz = new string[r, c];

            for(int i = 0; i < r; i++) 
            { 
                for(int j = 0; j<c; j++) 
                {
                    matriz[i, j] = ws.Cell(i, j).ValueAsString;
                }
            }

            return View(matriz);
        }
    }
}