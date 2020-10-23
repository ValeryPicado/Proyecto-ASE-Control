using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsBitacoraActivos
    {
        public bool AgregarBitacoraActivos(int idUsuario, string nombreUsuario, DateTime fechaCambio, string codigoActivo, string nombreActivo, decimal costoActivo, int anno, int meses, DateTime fechaActivo, bool estadoActivo)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarBitacoraActivos(idUsuario, nombreUsuario, fechaCambio, codigoActivo, nombreActivo, costoActivo, anno, meses, fechaActivo, estadoActivo));

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

        public bool ActualizarBitacoraActivos(int idActivo, int idUsuario, string nombreUsuario, DateTime fechaCambio, string codigoActivo, string nombreActivo, decimal costoActivo, int anno, int meses, DateTime fechaActivo, bool estadoActivo)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = dc.ActualizarBitacoraActivos(idActivo, idUsuario, nombreUsuario, fechaCambio, codigoActivo, nombreActivo, costoActivo, anno, meses, fechaActivo, estadoActivo);
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
