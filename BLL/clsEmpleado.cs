using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsEmpleado
    {
        public List<ConsultarEmpleadoResult> ConsultarEmpleado()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarEmpleadoResult> data = dc.ConsultarEmpleado().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<ConsultaEmpleadoResult> ConsultaEmpleado(int Codigo)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultaEmpleadoResult> data = dc.ConsultaEmpleado(Codigo).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public bool AgregarEmpleado(int IdTipoIdentificacion, string Identificacion, string Nombre, string Apellido1, string Apellido2,
            string Direccion, string fechaNacimiento, string departamento, string Correo, string Telefono, char Provincia, string Canton, string Distrito,
            string FechaEntrada, string FechaSalida, bool estadoEmpleado)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarEmpleado(IdTipoIdentificacion, Identificacion, Nombre, Apellido1, Apellido2,
             Direccion, fechaNacimiento, departamento, Correo, Telefono, Provincia, Canton, Distrito,
             FechaEntrada, FechaSalida, estadoEmpleado));

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
        public bool ActualizarEmpleado(int IdEmpleado, string Direccion, string fechaNacimiento, string departamento, string correo, string telefono, char provincia, string canton, string distrito
            , string fechaEntrada, string fechaSalida, bool estadoEmpleado)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = dc.ActualizarEmpleado(IdEmpleado, Direccion, fechaNacimiento, departamento, correo, telefono, provincia, canton, distrito,
                    fechaEntrada, fechaSalida, estadoEmpleado);
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

        public bool DeshabilitarEmpleado(int IdEmpleado)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.DeshabilitarEmpleado(IdEmpleado);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
