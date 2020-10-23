using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsProveedores
    {
        public List<ConsultarProveedorResult> ConsultarProveedor()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarProveedorResult> data = dc.ConsultarProveedor().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ConsultaProveedorResult> ConsultaProveedor(int Codigo)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultaProveedorResult> data = dc.ConsultaProveedor(Codigo).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool AgregarProveedor(string nombreProveedor, string telefono, string direccion, string correoElectronico,
            string nombreContacto, bool estadoProveedor)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarProveedor(nombreProveedor, telefono, direccion, correoElectronico,
                    nombreContacto, estadoProveedor));

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

        public bool ActualizarProveedor(int idProveedor, string nombreProveedor, string telefono, string direccion, string correoElectronico,
            string nombreContacto, bool estadoProveedor)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.ActualizarProveedor(idProveedor, nombreProveedor, telefono, direccion, correoElectronico,
                    nombreContacto, estadoProveedor));
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

        public bool DeshabilitarProveedor(int IdProveedor)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.DeshabilitarProveedor(IdProveedor);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
