using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tarea4.Models
{
    public class Curriculum
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }
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