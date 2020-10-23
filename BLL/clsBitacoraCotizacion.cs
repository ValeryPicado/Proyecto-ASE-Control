using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsBitacoraCotizacion
    {
        public bool AgregarBitacoraCotizacion(int idUsuario, string nombreUsuario, DateTime fechaCambio, string nombreProductoCotizacion,
            int cantidadProductoCotizacion, string detalleCotizacion, bool estadoCotizacion)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarBitacoraCotizacion(idUsuario, nombreUsuario, fechaCambio, nombreProductoCotizacion,
                    cantidadProductoCotizacion, detalleCotizacion, estadoCotizacion));

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
