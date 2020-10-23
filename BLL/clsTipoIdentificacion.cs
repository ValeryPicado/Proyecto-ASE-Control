using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsTipoIdentificacion
    {
        public List<ConsultarTiposIdentificacionResult> ConsultarTipoIdentificacion()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarTiposIdentificacionResult> data = dc.ConsultarTiposIdentificacion().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<ConsultaTiposIdentificacionResult> ConsultaTipoIdentificacion(int Codigo)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultaTiposIdentificacionResult> data = dc.ConsultaTiposIdentificacion(Codigo).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public int AgregarTipoIdentificacion(string TipoIdentificacion, bool Estado)
        {
            try
            {
                int respuesta = 0;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarTipoIdentificacion(TipoIdentificacion, Estado));

                return respuesta;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool ActualizarInstucion(int IdTipoIdentificacion, string TipoIdentificacion, bool Estado)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.ActualizarTipoIdentificacion(IdTipoIdentificacion, TipoIdentificacion, Estado);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
