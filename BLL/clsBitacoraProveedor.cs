using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsBitacoraProveedor
    {
        public bool AgregarBitacoraProveedor(int idUsuario, string nombreUsuario, DateTime fechaCambio, string nombreProveedor, string telefono, 
            string direccion, string correoElectronico, string nombreContacto, bool estadoProveedor)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarBitacoraProveedor(idUsuario, nombreUsuario, fechaCambio, nombreProveedor, telefono, 
                    direccion, correoElectronico, nombreContacto, estadoProveedor));

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

        public bool ActualizarBitacoraProveedor(int idStock, int idUsuario, string nombreUsuario, DateTime fechaCambio, string nombreProveedor, string telefono, string direccion, string correoElectronico,
            string nombreContacto, bool estadoProveedor)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = dc.ActualizarBitacoraProveedor(idStock, idUsuario, nombreUsuario, fechaCambio, nombreProveedor, telefono, direccion, correoElectronico,
            nombreContacto, estadoProveedor);
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
