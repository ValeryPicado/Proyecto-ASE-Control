using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consola.Models
{
    public class Sancion
    {
        public int idSanciones { get; set; }

        public int idEmpleado { get; set; }

        public int idDepartamento { get; set; }

        public string fechaSancion { get; set; }

        public string codigo { get; set; }

        public string nombre { get; set; }

        public string detalle { get; set; }

        public bool estadoSancion { get; set; }
    }
}