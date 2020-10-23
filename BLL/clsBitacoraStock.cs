using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsBitacoraStock
    {
        public bool AgregarBitacoraStock(int idUsuario, string nombreUsuario, DateTime fechaCambio, string codigoProducto, string nombreProducto, 
            int unidad, int idBodega, int idProveedor, bool estadoStock)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarBitacoraStock(idUsuario, nombreUsuario, fechaCambio, codigoProducto, nombreProducto, 
                    unidad, idBodega, idProveedor, estadoStock));

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

        public bool ActualizarBitacoraStock(int idStock, int idUsuario, string nombreUsuario, DateTime fechaCambio, string codigoProducto, string nombreProducto, int unidad, int idBodega
        , int idProveedor, bool estadoStock)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = dc.ActualizarBitacoraStock(idStock, idUsuario, nombreUsuario, fechaCambio, codigoProducto, nombreProducto, unidad, idBodega, idProveedor, estadoStock);
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
