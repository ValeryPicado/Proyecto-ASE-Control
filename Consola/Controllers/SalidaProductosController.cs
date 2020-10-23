using BLL;
using Consola.Helpers;
using Consola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace Consola.Controllers
{
    [SessionManage]
    public class SalidaProductosController : Controller
    {
        // GET: SalidaProductos
        public ActionResult Index()
        {
            try
            {
                List<SalidaProductos> listaSalidaProducto = new List<SalidaProductos>();
                clsSalidaProductos salida = new clsSalidaProductos();
                var data = salida.ConsultarSalidaProducto().ToList();

                foreach (var item in data)
                {
                    SalidaProductos modelo = new SalidaProductos();
                    modelo.idSalida = item.idSalida;
                    modelo.fechaSalida = item.fechaSalida;
                    modelo.codigoProducto = item.codigoProducto;
                    modelo.nombreProducto = item.nombreProducto;
                    modelo.unidad = item.unidad;
                    modelo.detalle = item.detalle;
                    modelo.estadoSalidaProducto = item.estadoSalidaProducto;

                    listaSalidaProducto.Add(modelo);
                }
                return View(listaSalidaProducto);
            }
            catch
            {
                string descMsg = "Error consultando la informacion del CLiente.";
                //Bitacora
                return RedirectToAction("Error", "Error");
            }
            return View();
        }

        // GET: SalidaProductos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Proveedores/Create
        [HttpGet]
        public ActionResult Crear()
        {
            clsSalidaProductos objSalidaproductos = new clsSalidaProductos();
            ViewBag.Lista = objSalidaproductos.ConsultarCodigoStock().ToList();
            return View();
        }

        // POST: Proveedores/Create
        [HttpPost]
        public ActionResult Crear(SalidaProductos salida, string listCodigoStock)
        {
            try
            {
                if (salida.unidad > 0)
                {
                    if (ModelState.IsValid)
                    {
                        clsSalidaProductos objsalida = new clsSalidaProductos();

                        int excede = objsalida.ComprobarUnidadesStock(listCodigoStock, salida.unidad);

                        if (excede == 0)
                        {
                            clsUsuario objUsuario = new clsUsuario();
                            clsBitacoraSalidaProductos objBitacoraSalidaProductos = new clsBitacoraSalidaProductos();

                            int idStock = objsalida.ConsultaIdProducto(listCodigoStock);

                            bool Resultado = objsalida.AgregarSalidaProducto(salida.fechaSalida, listCodigoStock, objsalida.ConsultaNombreProducto().ElementAt(idStock - 1).nombreProducto,
                                salida.unidad, salida.detalle, true);

                            string nombreUsuario = (string)Session["Usuario"];
                            int IdUsuario = objUsuario.ConsultarIdUsuario(nombreUsuario);

                            objBitacoraSalidaProductos.AgregarBitacoraSalidaProductos(IdUsuario, nombreUsuario, DateTime.Now, salida.fechaSalida, listCodigoStock, objsalida.ConsultaNombreProducto().ElementAt(idStock - 1).nombreProducto,
                                salida.unidad, salida.detalle, true);

                            if (Resultado)
                            {
                                TempData["exitoMensaje"] = "La boleta de salida del producto se ha insertado exitosamente.";
                                return RedirectToAction("Crear");
                            }
                            else
                            {
                                TempData["errorMensaje"] = "Se presentó un error al intentar insertar este elemento, revise que los datos coincidan con lo que especifican los campos";
                                return View("Crear");
                            }
                        }
                        else
                        {
                            clsSalidaProductos objSalidaproductos = new clsSalidaProductos();
                            ViewBag.Lista = objSalidaproductos.ConsultarCodigoStock().ToList();
                            TempData["errorMensaje"] = "La cantidad de unidades del producto a retirar excede la cantidad de unidades disponibles en el inventario.";
                            return View("Crear");
                        }
                    }
                    else
                    {
                        clsSalidaProductos objSalidaproductos = new clsSalidaProductos();
                        ViewBag.Lista = objSalidaproductos.ConsultarCodigoStock().ToList();
                        return View("Crear");
                    }
                }
                else
                {
                    clsSalidaProductos objSalidaproductos = new clsSalidaProductos();
                    ViewBag.Lista = objSalidaproductos.ConsultarCodigoStock().ToList();
                    TempData["errorMensaje"] = "El número de unidades no puede ser negativo.";
                    return View("Crear");
                }
            }
            catch
            {
                clsSalidaProductos objSalidaproductos = new clsSalidaProductos();
                ViewBag.Lista = objSalidaproductos.ConsultarCodigoStock().ToList();
                TempData["errorMensaje"] = "Todos los campos son obligatorios.";
                return View();
            }
        }

        //// POST: SalidaProductos/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [HttpGet]
        public ActionResult Editar(int id)
        {
            try
            {
                clsSalidaProductos salida = new clsSalidaProductos();
                var dato = salida.ConsultaSalidaProducto(id);

                clsSalidaProductos objSalidaproductos = new clsSalidaProductos();
                ViewBag.Lista = objSalidaproductos.ConsultarCodigoStock().ToList();

                SalidaProductos modelo = new SalidaProductos();
                modelo.idSalida = dato[0].idSalida;
                modelo.fechaSalida = dato[0].fechaSalida;
                modelo.codigoProducto = dato[0].codigoProducto;
                modelo.nombreProducto = dato[0].nombreProducto;
                modelo.unidad = dato[0].unidad;
                modelo.detalle = dato[0].detalle;
                modelo.estadoSalidaProducto = dato[0].estadoSalidaProducto;
                return View(modelo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: Activos/Edit/5
        [HttpPost]
        public ActionResult Editar(int id, SalidaProductos salida, string listCodigoStock)
        {
            try
            {
                clsSalidaProductos ObjSalida = new clsSalidaProductos();
                clsUsuario objUsuario = new clsUsuario();
                clsBitacoraSalidaProductos objBitacoraSalidaProductos = new clsBitacoraSalidaProductos();

                clsSalidaProductos objSalidaproductos = new clsSalidaProductos();

                int idStock = objSalidaproductos.ConsultaIdProducto(listCodigoStock);

                ViewBag.Lista = objSalidaproductos.ConsultarCodigoStock().ToList();

                bool Resultado = ObjSalida.ActualizarSalidaProducto(salida.idSalida, salida.fechaSalida, listCodigoStock,
                    objSalidaproductos.ConsultaNombreProducto().ElementAt(idStock - 1).nombreProducto, salida.detalle, true);

                string nombreUsuario = (string)Session["Usuario"];
                int IdUsuario = objUsuario.ConsultarIdUsuario(nombreUsuario);

                objBitacoraSalidaProductos.ActualizarBitacoraSalidaProductos(salida.idSalida, IdUsuario, nombreUsuario, DateTime.Now, salida.fechaSalida, listCodigoStock,
                    objSalidaproductos.ConsultaNombreProducto().ElementAt(idStock - 1).nombreProducto, salida.detalle, true);

                TempData["exitoMensaje"] = "La boleta de salida de productos se ha modificado exitosamente.";
                return View();

            }
            catch
            {
                clsSalidaProductos objSalidaproductos = new clsSalidaProductos();
                ViewBag.Lista = objSalidaproductos.ConsultarCodigoStock().ToList();
                TempData["errorMensaje"] = "Inserte correctamente el formato de los datos.";
                return View();
            }
        }

        // GET: Proveedor/Deshabilitar/5
        public ActionResult Deshabilitar(int id)
        {
            if (Session["ROLES"].Equals("Bodega") || Session["ROLES"].Equals("Admin"))
            {
                string message = "¿Desea deshabilitar este elemento?";
                string title = "Deshabilitar elemento.";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);

                if (result == DialogResult.Yes)
                {
                    clsSalidaProductos ObjSalida = new clsSalidaProductos();
                    ObjSalida.DeshabilitarSalidaProducto(id);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            { 
            TempData["alertaMensaje"] = "El usuario con el que ha ingresado no tiene permiso para realizar esta operación.";
            return RedirectToAction("Index");
            }
        }
    }
}
