using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consola.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }

        public int idTipoRol { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool Estado { get; set; }
    }
}