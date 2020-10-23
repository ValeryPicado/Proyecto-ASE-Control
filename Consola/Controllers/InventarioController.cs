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
    public class InventarioController : Controller
    {
        // GET: Inventario
        public ActionResult Index()
        {
            try
            {
                List<Inventario> listaInventario = new List<Inventario>();
                clsInventario invent = new clsInventario();
                var data = invent.ConsultarInventario().ToList();

                foreach (var item in data)
                {
                    Inventario modelo = new Inventario();
                    modelo.idStock = item.idStock;
                    modelo.codigoProducto = item.codigoProducto;
                    modelo.nombreProducto = item.nombreProducto;
                    modelo.unidad = item.unidad;
                    modelo.idBodega = item.idBodega;
                    modelo.idProveedor = item.idProveedor;
                    modelo.estadoStock = item.estadoStock;

                    listaInventario.Add(modelo);
                }
                return View(listaInventario);
            }
            catch
            {
                string descMsg = "Error consultando la informacion del CLiente.";
                //Bitacora
                return RedirectToAction("Error", "Error");
            }
        }

        // GET: Inventario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inventario/Create
        public ActionResult Crear()
        {
            clsInventario ObjInventario = new clsInventario();
            ViewBag.Lista = ObjInventario.ConsultarBodega().ToList();
            ViewBag.Lista2 = ObjInventario.ConsultarNombreProveedor().ToList();

            return View();
        }

        // POST: Inventario/Create
        [HttpPost]
        public ActionResult Crear(Inventario stocks, int listIdBodega, int listIdProveedor)
        {
            try
            {
                if (stocks.unidad > 0)
                {
                    if (ModelState.IsValid)
                    {
                        clsUsuario objUsuario = new clsUsuario();
                        clsInventario objstock = new clsInventario();
                        clsBitacoraStock objBitacoraStock = new clsBitacoraStock();

                        int existeCodigo = objstock.ComprobarCodigoStock(stocks.codigoProducto);

                        if (existeCodigo == 0)
                        {
                            ViewBag.Lista = objstock.ConsultarBodega().ToList();
                            ViewBag.Lista2 = objstock.ConsultarNombreProveedor().ToList();

                            bool Resultado = objstock.AgregarStock(stocks.codigoProducto, stocks.nombreProducto, stocks.unidad, listIdBodega, listIdProveedor, true);

                            string nombreUsuario = (string)Session["Usuario"];
                            int IdUsuario = objUsuario.ConsultarIdUsuario(nombreUsuario);

                            objBitacoraStock.AgregarBitacoraStock(IdUsuario, nombreUsuario, DateTime.Now, stocks.codigoProducto, stocks.nombreProducto, 
                                stocks.unidad, listIdBodega, listIdProveedor, true);

                            if (Resultado == true)
                            {
                                TempData["exitoMensaje"] = "El ítem se ha insertado exitosamente.";
                                return RedirectToAction("Crear");
                            }
                            else
                            {
                                return View("Crear");
                            }
                        }
                        else
                        {
                            clsInventario ObjStock = new clsInventario();
                            ViewBag.Lista = ObjStock.ConsultarBodega().ToList();
                            ViewBag.Lista2 = ObjStock.ConsultarNombreProveedor().ToList();
                            TempData["errorMensaje"] = "El código de producto insertado ya existe.";
                            return View("Crear");
                        }
                    }
                    else
                    {
                        clsInventario ObjStock = new clsInventario();
                        ViewBag.Lista = ObjStock.ConsultarBodega().ToList();
                        ViewBag.Lista2 = ObjStock.ConsultarNombreProveedor().ToList();
                        TempData["errorMensaje"] = "Error de inserción, revise los datos.";
                        return View("Crear");
                    }
                }
                else
                {
                    clsInventario ObjStock = new clsInventario();
                    ViewBag.Lista = ObjStock.ConsultarBodega().ToList();
                    ViewBag.Lista2 = ObjStock.ConsultarNombreProveedor().ToList();
                    TempData["errorMensaje"] = "El número de unidades no puede ser negativo.";
                    return View("Crear");
                }
            }
            catch
            {
                clsInventario ObjInventario = new clsInventario();
                ViewBag.Lista = ObjInventario.ConsultarBodega().ToList();
                ViewBag.Lista2 = ObjInventario.ConsultarNombreProveedor().ToList();
                TempData["errorMensaje"] = "Error de inserción, revise los datos.";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            try
            {
                clsInventario ObjStock = new clsInventario();

                ViewBag.Lista = ObjStock.ConsultarBodega().ToList();
                ViewBag.Lista2 = ObjStock.ConsultarNombreProveedor().ToList();

                var dato = ObjStock.ConsultaInventario(id);

                Inventario modelo = new Inventario();
                modelo.idStock = dato[0].idStock;
                modelo.codigoProducto = dato[0].codigoProducto;
                modelo.nombreProducto = dato[0].nombreProducto;
                modelo.unidad = dato[0].unidad;
                modelo.idBodega = dato[0].idBodega;
                modelo.idProveedor = dato[0].idProveedor;
                modelo.estadoStock = dato[0].estadoStock;
                return View(modelo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: Activos/Edit/5
        [HttpPost]
        public ActionResult Editar(int id, Inventario stock, int listIdBodega, int listIdProveedor)
        {
            try
            {
                if (stock.unidad >= 0)
                {
                    if (ModelState.IsValid)
                    {
                        clsInventario ObjStock = new clsInventario();
                        clsUsuario objUsuario = new clsUsuario();
                        clsBitacoraStock objBitacoraStock = new clsBitacoraStock();

                        ViewBag.Lista = ObjStock.ConsultarBodega().ToList();
                        ViewBag.Lista2 = ObjStock.ConsultarNombreProveedor().ToList();

                        bool Resultado = ObjStock.ActualizarInventario(stock.idStock, stock.codigoProducto, stock.nombreProducto,
                            stock.unidad, listIdBodega, listIdProveedor, true);

                        string nombreUsuario = (string)Session["Usuario"];
                        int IdUsuario = objUsuario.ConsultarIdUsuario(nombreUsuario);

                        TempData["exitoMensaje"] = "El ítem se ha modificado exitosamente.";
                        return View();
                    }
                    else
                    {
                        clsInventario ObjStock = new clsInventario();
                        ViewBag.Lista = ObjStock.ConsultarBodega().ToList();
                        ViewBag.Lista2 = ObjStock.ConsultarNombreProveedor().ToList();

                        TempData["errorMensaje"] = "Error de inserción, revise los datos.";
                        return View("Crear");
                    }
                }
                else
                {
                    clsInventario ObjStock = new clsInventario();
                    ViewBag.Lista = ObjStock.ConsultarBodega().ToList();
                    ViewBag.Lista2 = ObjStock.ConsultarNombreProveedor().ToList();

                    TempData["errorMensaje"] = "El número de unidades no puede ser negativo.";
                    return View("Crear");
                }
            }
            catch
            {
                clsInventario ObjStock = new clsInventario();
                ViewBag.Lista = ObjStock.ConsultarBodega().ToList();
                ViewBag.Lista2 = ObjStock.ConsultarNombreProveedor().ToList();

                TempData["errorMensaje"] = "Inserte correctamente el formato de los datos.";
                return View();
            }
        }

        // GET: Proveedor/Deshabilitar/5
        public ActionResult Deshabilitar(int id)
        {
            if (Session["ROLES"].Equals("Admin"))
            {
                string message = "¿Desea deshabilitar este elemento?";
                string title = "Deshabilitar elemento.";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);

                if (result == DialogResult.Yes)
                {
                    clsInventario ObjStock = new clsInventario();
                    ObjStock.DeshabilitarInventario(id);
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
