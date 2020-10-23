using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsCita
    {
        public List<ConsultarCitaResult> ConsultarCita()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarCitaResult> data = dc.ConsultarCita().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ConsultaCitaResult> ConsultaCita(int Codigo)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultaCitaResult> data = dc.ConsultaCita(Codigo).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /*public bool DeshabilitarCita(int idCita)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.DeshabilitarCita(idCita);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }*/

        public List<ConsultarCitasUsuarioResult> ConsultarCitasUsuario(int idUsuario)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarCitasUsuarioResult> data = dc.ConsultarCitasUsuario(idUsuario).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool AgregarCita(int idUsuario, string asunto, string descripcion, DateTime inicio, DateTime fin, string colorFonto, bool diaCompleto, bool estadoCita)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarCita(idUsuario, asunto, descripcion, inicio, fin, colorFonto, diaCompleto, estadoCita));

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

        public bool ActualizarCita(int idCita, int idUsuario, string asunto, string descripcion, DateTime inicio, DateTime fin, string colorFonto, bool diaCompleto, bool estadoCita)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = dc.ActualizarCita(idCita, idUsuario, asunto, descripcion, inicio, fin, colorFonto, diaCompleto, estadoCita);
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
