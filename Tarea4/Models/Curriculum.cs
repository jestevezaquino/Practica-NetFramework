using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Tarea4.Models
{
    public class Curriculum
    {
        [Required(ErrorMessage ="El campo es requerido"), MinLength(11, ErrorMessage ="El campo debe tener solo 11 carácteres"),MaxLength(11, ErrorMessage ="El campo debe de tener solo 11 carácteres")]
        public string Cedula { get; set; }
        [Required(ErrorMessage ="El campo es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage ="El campo es requerido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage ="El campo es requerido"), Range(15,100, ErrorMessage ="Debes insertar una edad mayor que 15")]
        public int Edad { get; set; }

        [Required(ErrorMessage ="El campo es requerido"), MinLength(10, ErrorMessage ="Debes insertar solo 10 carácteres"), MaxLength(10, ErrorMessage ="Debes insertar solo 10 carácteres")]
        public string Telefono { get; set; }
        [Required(ErrorMessage ="El campo es requerido"), EmailAddress(ErrorMessage ="Debes insertar un email válido")]
        public string Email { get; set; }
        public string Genero { get; set; }
        public Puesto Cargo { get; set; }
        public HttpPostedFileBase Foto { get; set; }
        public HttpPostedFileBase Cv { get; set; }
    }

    public enum Puesto 
    {
       ProgramadorBackEnd, ProgramadorFrontEnd, ProgramadorFullStack, ProgamadorMovil, ProgramadorEscritorio, Analista, Diseñador, SoporteTecnico, Contador, Tesorero, Secretaria, Otro  
    }
}