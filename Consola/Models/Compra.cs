using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consola.Models
{
    public class Compra
    {
        public int idCompra { get; set; }

        public string nombreProducto { get; set; }

        public int cantidadCompra { get; set; }

        public string detalleCompra { get; set; }

        public bool estadoCompra { get; set; }
    }
}