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
            if(ws == null) 
            {
                ws = doc.Workbook.Worksheets.ByName("Sheet1");
                if(ws == null) 
                {
                    ViewBag.message = "Error no se puede leer tu archivo, aségurate que la hoja de trabajo tenga como nombre Hoja1 o Sheet1";
                }
            }
            
            string[,] matriz;
            int r = 0;
            int c = 0;
            int g = 0;
            bool comprobar = false;
            do
            {
                if (ws.Cell(r, c).ValueAsString == "")
                {
                    r++;
                    g = c;
                    c = 0;
                    if (ws.Cell(r, c).ValueAsString == "")
                    {
                        comprobar = true;
                    }
                    c++;
                }
                else
                {
                    c++;
                }
            }
            while (comprobar == false);
            matriz = new string[r, g];
            for(int i = 0; i < r; i++) 
            { 
                for(int j = 0; j < g; j++) 
                {
                    matriz[i, j] = ws.Cell(i, j).ValueAsString;
                }
            }

            return View(matriz);
        }
    }
}