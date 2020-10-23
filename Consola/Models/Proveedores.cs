using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consola.Models
{
    public class Proveedores
    {
        public int idProveedor { get; set; }

        public string nombreProveedor { get; set; }

        public string telefono { get; set; }

        public string direccion { get; set; }

        public string correoElectronico { get; set; }

        public string nombreContacto { get; set; }

        public bool estadoProveedor { get; set; }
    }
}