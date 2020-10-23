using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consola.Models
{
    public class Activos
    {
        public int IdActivo { get; set; }

        public string codigoActivo { get; set; }

        public string nombreActivo { get; set; }

        public decimal costoActivo { get; set; }

        public int anno { get; set; }

        public int meses { get; set; }

        public decimal costoAnual { get; set; }

        public decimal costoMensual { get; set; }

        public DateTime fechaActivo { get; set; }

        public bool estadoActivo { get; set; }
    }
}