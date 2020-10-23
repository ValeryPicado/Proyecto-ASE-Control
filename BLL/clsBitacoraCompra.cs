using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsBitacoraCompra
    {
        public bool AgregarBitacoraCompra(int idUsuario, string nombreUsuario, DateTime fechaCambio, string nombreProducto, int cantidadCompra, string detalleCompra, bool estadoCompra)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarBitacoraCompra(idUsuario, nombreUsuario, fechaCambio, nombreProducto, cantidadCompra, detalleCompra, estadoCompra));

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
    }
}
