using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsBitacoraCitas
    {
        public bool AgregarBitacoraCita(int idCambioUsuario, string nombreUsuario, DateTime fechaCambio, int idUsuario, string Asunto, string Descripcion, DateTime Inicio, DateTime Fin, string ColorFonto, bool DiaCompleto, bool estadoCita)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarBitacoraCita(idCambioUsuario, nombreUsuario, fechaCambio, idUsuario, Asunto, Descripcion, Inicio, Fin, ColorFonto, DiaCompleto, estadoCita));

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

        public bool ActualizarBitacoraCita(int idCita, int idCambioUsuario, string nombreUsuario, DateTime fechaCambio, int idUsuario, string Asunto, string Descripcion, DateTime Inicio, DateTime Fin, string ColorFonto, bool DiaCompleto, bool estadoCita)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = dc.ActualizarBitacoraCita(idCita, idCambioUsuario, nombreUsuario, fechaCambio, idUsuario, Asunto, Descripcion, Inicio, Fin, ColorFonto, DiaCompleto, estadoCita);
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
