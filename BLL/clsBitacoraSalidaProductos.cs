using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsBitacoraSalidaProductos
    {
        public bool AgregarBitacoraSalidaProductos(int idUsuario, string nombreUsuario, DateTime fechaCambio, DateTime fechaSalida, string codigoProducto, string nombreProducto, int unidad, string detalle, bool estadoSalidaProducto)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarBitacoraSalidaProductos(idUsuario, nombreUsuario, fechaCambio, fechaSalida, codigoProducto, nombreProducto, unidad, detalle, estadoSalidaProducto));

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

        public bool ActualizarBitacoraSalidaProductos(int idSalida, int idUsuario, string nombreUsuario, DateTime fechaCambio, DateTime fechaSalida, string codigoProducto, string nombreProducto, string detalle, bool estadoSalidaProducto)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = dc.ActualizarBitacoraSalidaProductos(idSalida, idUsuario, nombreUsuario, fechaCambio, fechaSalida, codigoProducto, nombreProducto, detalle, estadoSalidaProducto);
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
