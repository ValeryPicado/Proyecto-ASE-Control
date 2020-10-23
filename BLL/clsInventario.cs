using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsInventario
    {
        public List<ConsultarInventarioResult> ConsultarInventario()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarInventarioResult> data = dc.ConsultarInventario().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ConsultaInventarioResult> ConsultaInventario(int Codigo)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultaInventarioResult> data = dc.ConsultaInventario(Codigo).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public List<ConsultarIdProveedorResult> ConsultarIdProveedor()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarIdProveedorResult> data = dc.ConsultarIdProveedor().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int ConsultaIdBodega(string codigoBodega)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int ID = dc.ConsultaIdBodega(codigoBodega);
                return ID;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ConsultarNombreBodegaResult> ConsultarNombreBodega()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarNombreBodegaResult> data = dc.ConsultarNombreBodega().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int ComprobarCodigoStock(string codigo)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int verifica = dc.ComprobarCodigoStock(codigo);
                return verifica;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool AgregarStock(string codigoProducto, string nombreProducto, int unidad, int idBodega, int idProveedor, bool estadoStock)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarStock(codigoProducto, nombreProducto, unidad, idBodega, idProveedor, estadoStock));

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

        public bool ActualizarInventario(int idStock, string codigo, string nombreProducto, int unidad, int idBodega
            , int idProveedor, bool estadoStock)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = dc.ActualizarInventario(idStock, codigo, nombreProducto, unidad, idBodega, idProveedor, estadoStock);
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

        public bool DeshabilitarInventario(int IdStock)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.DeshabilitarInventario(IdStock);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public List<ConsultarBodegaResult> ConsultarBodega()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarBodegaResult> data = dc.ConsultarBodega().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public List<ConsultarNombreProveedorResult> ConsultarNombreProveedor()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarNombreProveedorResult> data = dc.ConsultarNombreProveedor().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
