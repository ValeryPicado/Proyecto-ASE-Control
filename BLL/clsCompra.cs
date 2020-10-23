using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class clsCompra
    {
        public List<ConsultarCompraResult> ConsultarCompra()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarCompraResult> data = dc.ConsultarCompra().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ConsultaCompraResult> ConsultaCompra(int Codigo)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultaCompraResult> data = dc.ConsultaCompra(Codigo).ToList();
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

        public bool AgregarCompra(string nombreProducto, int cantidadCompra, string detalleCompra, bool estadoCompra)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarCompra(nombreProducto, cantidadCompra, detalleCompra, estadoCompra));

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

       /* public bool ActualizarCompra(int idCompra, int idColaborador, string detalleCompra, int cantidadCompra, string nombreProducto)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = dc.ActualizarCompra(idCompra, idColaborador, detalleCompra, cantidadCompra, nombreProducto);
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

        public bool DeshabilitarCompra(int IdCompra)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.DeshabilitarCompra(IdCompra);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
