using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consola.Models
{
    public class Institucion
    {
        public int IdPersona { get; set; }

        public string Cedula { get; set; }

        public int Sexo { get; set; }

        public string Nombre { get; set; }

        public string ApellidoP { get; set; }

        public string ApellidoM { get; set; }

        public string Direccion { get; set; }
    }
}