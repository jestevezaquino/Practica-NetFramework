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

                if (ConversorLongitud(uds.UnidadMed1, uds.UnidadMed2, uds.CantidadLongitud) >= 1)
                {
                    ViewBag.Resultado = ConversorLongitud(uds.UnidadMed1, uds.UnidadMed2, uds.CantidadLongitud).ToString("N2");
                }
                else 
                {
                    ViewBag.Resultado = ConversorLongitud(uds.UnidadMed1, uds.UnidadMed2, uds.CantidadLongitud).ToString("N10");
                }
            }
            else if (Request.Form["btnConvertir2"] == "convertirTemperatura")
            {
                uds.CantidadTemperatura = Double.Parse(Request.Form["CantidadTemperatura"]);
                uds.UnidadMed1 = Request.Form["UnidadMed1"];
                uds.UnidadMed2 = Request.Form["UnidadMed2"];
                ViewBag.Resultado2 = ConversorTemperatura(uds.UnidadMed1, uds.UnidadMed2, uds.CantidadTemperatura).ToString("N2");
            }
            else if (Request.Form["btnConvertir3"] == "convertirMasa")
            {
                uds.CantidadMasa = Double.Parse(Request.Form["CantidadMasa"]);
                uds.UnidadMed1 = Request.Form["UnidadMed1"];
                uds.UnidadMed2 = Request.Form["UnidadMed2"];
                
                if (ConversorMasa(uds.UnidadMed1, uds.UnidadMed2, uds.CantidadMasa) >= 1)
                {
                    ViewBag.Resultado3 = ConversorMasa(uds.UnidadMed1, uds.UnidadMed2, uds.CantidadMasa).ToString("N2");
                }
                else
                {
                    ViewBag.Resultado3 = ConversorMasa(uds.UnidadMed1, uds.UnidadMed2, uds.CantidadMasa).ToString("N10");
                }
            }
            else if (Request.Form["btnConvertir4"] == "convertirDatos")
            {
                uds.CantidadDatos = Double.Parse(Request.Form["CantidadDatos"]);
                uds.UnidadMed1 = Request.Form["UnidadMed1"];
                uds.UnidadMed2 = Request.Form["UnidadMed2"];

                if (ConversorDatos(uds.UnidadMed1, uds.UnidadMed2, uds.CantidadDatos) >= 1)
                {
                    ViewBag.Resultado4 = ConversorDatos(uds.UnidadMed1, uds.UnidadMed2, uds.CantidadDatos).ToString("N2");
                }
                else
                {
                    ViewBag.Resultado4 = ConversorDatos(uds.UnidadMed1, uds.UnidadMed2, uds.CantidadDatos).ToString("N15");
                }
            }

            return View(uds);
        }

        double ConversorLongitud(string unidad1, string unidad2, double cantidadSolicitada) 
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

        double ConversorTemperatura(string unidad1, string unidad2, double cantidadSolicitada)
        {
            //Se utilizará el metro como medida base para las respectivas conversiones.
            double unidadEnCelcius = 0;
            double unidadConvertida = 0;

            switch (unidad1)
            {
                case "Celcius":
                    unidadEnCelcius = cantidadSolicitada;
                    break;

                case "Farenheit":
                    unidadEnCelcius = (cantidadSolicitada - 32) * 5 / 9;
                    break;

                case "Kelvin":
                    unidadEnCelcius = cantidadSolicitada - 273.15;
                    break;
            }

            switch (unidad2)
            {
                case "Celcius":
                    unidadConvertida = unidadEnCelcius;
                    break;

                case "Farenheit":
                    unidadConvertida = (unidadEnCelcius * 9 / 5) + 32;
                    break;

                case "Kelvin":
                    unidadConvertida = unidadEnCelcius + 273.15;
                    break;
            }

            return unidadConvertida;
        }

        double ConversorMasa(string unidad1, string unidad2, double cantidadSolicitada)
        {
            //Se utilizará el metro como medida base para las respectivas conversiones.
            double unidadEnGramos = 0;
            double unidadConvertida = 0;

            switch (unidad1)
            {
                case "Gramo":
                    unidadEnGramos = cantidadSolicitada;
                    break;

                case "Kilogramo":
                    unidadEnGramos = cantidadSolicitada * 1000;
                    break;

                case "Onza":
                    unidadEnGramos = cantidadSolicitada * 28.35;
                    break;

                case "Libra":
                    unidadEnGramos = cantidadSolicitada * 454;
                    break;
            }

            switch (unidad2)
            {
                case "Gramo":
                    unidadConvertida = unidadEnGramos;
                    break;

                case "Kilogramo":
                    unidadConvertida = unidadEnGramos / 1000;
                    break;

                case "Onza":
                    unidadConvertida = unidadEnGramos / 28.35;
                    break;

                case "Libra":
                    unidadConvertida = unidadEnGramos / 454;
                    break;
            }

            return unidadConvertida;
        }

        double ConversorDatos(string unidad1, string unidad2, double cantidadSolicitada)
        {
            //Se utilizará el metro como medida base para las respectivas conversiones.
            double unidadEnMb = 0;
            double unidadConvertida = 0;

            switch (unidad1)
            {
                case "Bit":
                    unidadEnMb = cantidadSolicitada / 8e+6;
                    break;

                case "Byte":
                    unidadEnMb = cantidadSolicitada / 1e+6;
                    break;

                case "Kilobyte":
                    unidadEnMb = cantidadSolicitada / 1000;
                    break;

                case "Megabyte":
                    unidadEnMb = cantidadSolicitada;
                    break;

                case "Gigabyte":
                    unidadEnMb = cantidadSolicitada * 1000;
                    break;

                case "Terabyte":
                    unidadEnMb = cantidadSolicitada * 1e+6;
                    break;
            }

            switch (unidad2)
            {
                case "Bit":
                    unidadConvertida = unidadEnMb * 8e+6;
                    break;

                case "Byte":
                    unidadConvertida = unidadEnMb * 1e+6;
                    break;

                case "Kilobyte":
                    unidadConvertida = unidadEnMb * 1000;
                    break;

                case "Megabyte":
                    unidadConvertida = unidadEnMb;
                    break;

                case "Gigabyte":
                    unidadConvertida = unidadEnMb / 1000;
                    break;

                case "Terabyte":
                    unidadConvertida = unidadEnMb / 1e+6;
                    break;
            }

            return unidadConvertida;
        }

    }
}