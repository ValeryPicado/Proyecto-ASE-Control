using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consola.Models
{
    public class SalidaProductos
    {
        public int idSalida { get; set; }

        public DateTime fechaSalida { get; set; }

        public string codigoProducto { get; set; }

        public string nombreProducto { get; set; }

        public int unidad { get; set; }

        public string detalle { get; set; }

        public bool estadoSalidaProducto { get; set; }
    }
}