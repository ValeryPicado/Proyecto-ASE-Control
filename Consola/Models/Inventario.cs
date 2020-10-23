using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consola.Models
{
    public class Inventario
    {
        public int idStock { get; set; }

        public int idBodega { get; set; }

        public string nombreProducto { get; set; }

        public int unidad { get; set; }

        public string codigoProducto { get; set; }

        public int idProveedor { get; set; }

        public bool estadoStock { get; set; }
    }
}