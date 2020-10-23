using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsCotizacion
    {
        public List<ConsultarCotizacionResult> ConsultarCotizacion()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarCotizacionResult> data = dc.ConsultarCotizacion().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ConsultarCorreoProveedorResult> ConsultaCorreoProveedor()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarCorreoProveedorResult> data = dc.ConsultarCorreoProveedor().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ConsultaCotizacionResult> ConsultaCotizacion(int Codigo)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultaCotizacionResult> data = dc.ConsultaCotizacion(Codigo).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool AgregarCotizacion(string nombreProductoCotizacion,
            int cantidadProductoCotizacion, string detalleCotizacion, bool estadoCotizacion)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarCotizacion(nombreProductoCotizacion,
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

        /*public bool ActualizarCotizacion(int IdCotizacion, int idProveedor, string nombreProductoCotizacion,
            int cantidadProductoCotizacion, string detalleCotizacion, bool estadoCotizacion)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = dc.ActualizarCotizacion(IdCotizacion, idProveedor, nombreProductoCotizacion,
                    cantidadProductoCotizacion, detalleCotizacion, estadoCotizacion);
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
        }*/

        public bool DeshabilitarCotizacion(int IdCotizacion)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.DeshabilitarCotizacion(IdCotizacion);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}