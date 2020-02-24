using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tarea4.Models;

namespace Tarea4.Controllers
{
    public class ConversorController : Controller
    {
        // GET: Conversor
        public ActionResult Medidas()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Medidas(Unidades uds) 
        {
            if (Request.Form["btnConvertir1"] == "convertirLongitud")
            {
                uds.CantidadLongitud = Double.Parse(Request.Form["CantidadLongitud"]);
                uds.UnidadMed1 = Request.Form["UnidadMed1"];
                uds.UnidadMed2 = Request.Form["UnidadMed2"];

                if (conversorLongitud(uds.UnidadMed1, uds.UnidadMed2, uds.CantidadLongitud) >= 1)
                {
                    ViewBag.Resultado = conversorLongitud(uds.UnidadMed1, uds.UnidadMed2, uds.CantidadLongitud).ToString("N2");
                }
                else 
                {
                    ViewBag.Resultado = conversorLongitud(uds.UnidadMed1, uds.UnidadMed2, uds.CantidadLongitud).ToString("N10");
                }
            }
            else if (Request.Form["btnConvertir2"] == "convertirTemperatura")
            {
                ViewBag.test = "LE DISTE A Temperatura!";
            }
            else if (Request.Form["btnConvertir3"] == "convertirMasa")
            {
                ViewBag.test = "LE DISTE A Temperatura!";
            }
            else if (Request.Form["btnConvertir4"] == "convertirDatos")
            {
                ViewBag.test = "LE DISTE A Temperatura!";
            }

            return View(uds);
        }

        double conversorLongitud(string unidad1, string unidad2, double cantidadSolicitada) 
        {
            //Se utilizará el metro como medida base para las respectivas conversiones.
            double unidadEnMetros=0;
            double unidadConvertida=0;

            switch (unidad1) 
            {
                case "Centimetros":
                    unidadEnMetros = cantidadSolicitada / 100;
                    break;

                case "Pies":
                    unidadEnMetros = cantidadSolicitada / 3.281;
                    break;

                case "Pulgadas":
                    unidadEnMetros = cantidadSolicitada / 39.37;
                    break;

                case "Metros":
                    unidadEnMetros = cantidadSolicitada;
                    break;

                case "Kilometros":
                    unidadEnMetros = cantidadSolicitada * 1000;
                    break;

                case "Millas":
                    unidadEnMetros = cantidadSolicitada * 1609;
                    break;
            }

            switch (unidad2)
            {
                case "Centimetros":
                    unidadConvertida = unidadEnMetros * 100;
                    break;

                case "Pies":
                    unidadConvertida = unidadEnMetros * 3.281;
                    break;

                case "Pulgadas":
                    unidadConvertida = unidadEnMetros * 39.37;
                    break;

                case "Metros":
                    unidadConvertida = unidadEnMetros;
                    break;

                case "Kilometros":
                    unidadConvertida = unidadEnMetros / 1000;
                    break;

                case "Millas":
                    unidadConvertida = unidadEnMetros / 1609;
                    break;
            }

            return unidadConvertida;
        }
    }
}