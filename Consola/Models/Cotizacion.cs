using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consola.Models
{
    public class Cotizacion
    {
        public int idCotizacion { get; set; }

        public string nombreProductoCotizacion { get; set; }

        public int cantidadProductoCotizacion { get; set; }

        public string detalleCotizacion { get; set; }

        public bool estadoCotizacion { get; set; }
    }
}