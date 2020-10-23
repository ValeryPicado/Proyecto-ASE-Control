using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consola.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }

        public int IdTipoIdentificacion { get; set; }

        public string Identificacion { get; set; }

        public string Nombre { get; set; }

        public string Apellido1 { get; set; }

        public string Apellido2 { get; set; }

        public string Direccion { get; set; }

        public string fechaNacimiento { get; set; }

        public string departamento { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public char Provincia { get; set; }

        public string Canton { get; set; }

        public string Distrito { get; set; }

        public string fechaEntrada { get; set; }

        public string fechaSalida { get; set; }

        public bool estadoEmpleado { get; set; }
    }
}