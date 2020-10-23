using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsActivos
    {
        public List<ConsultarActivoResult> ConsultarActivo()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarActivoResult> data = dc.ConsultarActivo().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<ConsultaActivoResult> ConsultaActivo(int Codigo)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultaActivoResult> data = dc.ConsultaActivo(Codigo).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public bool AgregarActivo(string codigoActivo, string nombreActivo, decimal costoActivo, int anno, int meses, DateTime fechaActivo, bool estadoActivo)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarActivo(codigoActivo, nombreActivo, costoActivo, anno, meses, fechaActivo, estadoActivo));

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
        public bool ActualizarActivo(int IdActivo, string codigoActivo, string nombreActivo, decimal costoActivo, int anno, int meses, DateTime fechaActivo, bool estadoActivo)
        {
            try
            {
                int respuesta = 0;

                DatosDataContext dc = new DatosDataContext();
                dc.ActualizarActivo(IdActivo, codigoActivo, nombreActivo, costoActivo, anno, meses, fechaActivo, estadoActivo);

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

        public bool DeshabilitarActivo(int IdActivo)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.DeshabilitarActivo(IdActivo);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
