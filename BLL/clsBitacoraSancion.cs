using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsBitacoraSancion
    {
        public bool AgregarBitacoraSancion(int idUsuario, string nombreUsuario, DateTime fechaCambio, int idEmpleado, int idDepartamento, string fechaSancion, string codigo, string nombre, string detalle, bool estadoSancion)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarBitacoraSancion(idUsuario, nombreUsuario, fechaCambio, idEmpleado, idDepartamento, fechaSancion, codigo, nombre, detalle, estadoSancion));

                if (respuesta == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool ActualizarBitacoraSancion(int idSanciones, int idUsuario, string nombreUsuario, DateTime fechaCambio, int idEmpleado, int idDepartamento, string fechaSancion, string codigo, string nombre, string detalle, bool estadoSancion)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = dc.ActualizarBitacoraSancion(idSanciones, idUsuario, nombreUsuario, fechaCambio, idEmpleado, idDepartamento, fechaSancion, codigo, nombre, detalle, estadoSancion);
                if (respuesta == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
