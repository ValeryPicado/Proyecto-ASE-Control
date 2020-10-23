using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsBitacoraUsuario
    {
        public bool AgregarBitacoraUsuario(int idUsuario, string nombreUsuario, DateTime fechaCambio, int idTipoRol, string usuario, string clave, bool estado)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarBitacoraUsuario(idUsuario, nombreUsuario, fechaCambio, idTipoRol, usuario, clave, estado));

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

        public bool ActualizarBitacoraUsuario(int idUsuario, int idCambioUsuario, string nombreUsuario, DateTime fechaCambio, int idTipoRol, string usuario, string clave, bool estado)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = dc.ActualizarBitacoraUsuario(idUsuario, idCambioUsuario, nombreUsuario, fechaCambio, idTipoRol, usuario, clave, estado);
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
