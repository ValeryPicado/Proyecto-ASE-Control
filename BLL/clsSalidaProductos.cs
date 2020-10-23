using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsSalidaProductos
    {
        public List<ConsultarSalidaProductoResult> ConsultarSalidaProducto()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarSalidaProductoResult> data = dc.ConsultarSalidaProducto().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ConsultaSalidaProductoResult> ConsultaSalidaProducto(int Codigo)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultaSalidaProductoResult> data = dc.ConsultaSalidaProducto(Codigo).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ConsultarCodigoStockResult> ConsultarCodigoStock()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarCodigoStockResult> data = dc.ConsultarCodigoStock().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int ConsultaIdProducto(string codigo)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int ID = dc.ConsultaIdProducto(codigo);
                return ID;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int ComprobarUnidadesStock(string codigoProducto, int unidades)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int excede = dc.ComprobarUnidadesStock(codigoProducto, unidades);
                return excede;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ConsultaNombreProductoResult> ConsultaNombreProducto()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultaNombreProductoResult> data = dc.ConsultaNombreProducto().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool AgregarSalidaProducto(DateTime fechaSalida, string codigoProducto, string nombreProducto, int unidad, string detalle, bool estadoSalidaProducto)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarSalidaProducto(fechaSalida, codigoProducto, nombreProducto, unidad, detalle, estadoSalidaProducto));

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

        public bool ActualizarSalidaProducto(int idSalida, DateTime fechaSalida, string codigoProducto, string nombreProducto, string detalle, bool estadoSalidaProducto)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = dc.ActualizarSalidaProducto(idSalida, fechaSalida, codigoProducto, nombreProducto, detalle, estadoSalidaProducto);
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

        public bool DeshabilitarSalidaProducto(int IdSalida)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.DeshabilitarSalidaProducto(IdSalida);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
