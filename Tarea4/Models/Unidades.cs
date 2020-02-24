using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Tarea4.Models
{
    public class Unidades
    {
        [Required (ErrorMessage = "Este campo es requerido.")]
        public double CantidadLongitud { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public double CantidadTemperatura { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public double CantidadMasa { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public double CantidadDatos { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string UnidadMed1 { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string UnidadMed2 { get; set; }
        public Longitud Longi { get; set; }
        public Temperatura Temp { get; set; }
        public Masa Ms { get; set; }
        public Datos Dts { get; set; }
    }

    public enum Longitud { Centimetros, Pies, Pulgadas, Metros, Kilometros, Millas }
    public enum Temperatura { Celcius, Farenheit, Kelvin }

    public enum Masa { Gramo, Kilogramo, Onza , Libra }

    public enum Datos { Bit, Byte, Kilobyte, Megabyte, Gigabyte, Terabyte }
}