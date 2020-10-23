using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consola.Models
{
    public class Cita
    {
        public int IdCita { get; set; }

        public int idUsuario { get; set; }

        public string Asunto { get; set; }

        public string Descripcion { get; set; }

        public DateTime Inicio { get; set; }

        public DateTime Fin { get; set; }

        public string ColorFondo { get; set; }

        public bool DiaCompleto { get; set; }

        public bool estadoCita { get; set; }
    }
}