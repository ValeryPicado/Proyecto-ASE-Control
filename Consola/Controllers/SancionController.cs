using BLL;
using Consola.Helpers;
using Consola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Windows.Forms;

namespace Consola.Controllers
{
    [SessionManage]
    public class SancionController : Controller
    {
        // GET: Sancion
        public ActionResult Index()
        {
            try
            {
                List<Sancion> listaSancion = new List<Sancion>();
                clsSancion activo = new clsSancion();
                var data = activo.ConsultarSancion().ToList();

                foreach (var item in data)
                {
                    Sancion modelo = new Sancion();
                    modelo.idSanciones = item.idSanciones;
                    modelo.idEmpleado = item.IdEmpleado;
                    modelo.idDepartamento = item.idDepartamento;
                    modelo.fechaSancion = item.fechaSancion;
                    modelo.codigo = item.codigo;
                    modelo.nombre = item.nombre;
                    modelo.detalle = item.detalle;
                    modelo.estadoSancion = item.estadoSancion;

                    listaSancion.Add(modelo);
                }
                return View(listaSancion);
            }
            catch
            {
                string descMsg = "Error consultando la informacion del CLiente.";
                //Bitacora
                return RedirectToAction("Error", "Error");
            }
        }

        // GET: Sancion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Crear()
        {
            clsSancion ObjSancion = new clsSancion();
            ViewBag.Lista = ObjSancion.ConsultarDepartamento().ToList();
            ViewBag.Lista2 = ObjSancion.ConsultarIdEmpleado().ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Sancion sancion, string txtDetalleSancion, string txtCodigo, int listIdDepartamento, int listIdEmpleado)
        {
            try
            {
                if (!txtDetalleSancion.Equals("") && !txtCodigo.Equals(""))
                {
                    if (!ModelState.IsValid)
                    {
                        clsSancion ObjSancion = new clsSancion();
                        ViewBag.Lista = ObjSancion.ConsultarDepartamento().ToList();
                        ViewBag.Lista2 = ObjSancion.ConsultarIdEmpleado().ToList();

                        ModelState.AddModelError("", "Inserte correctamente los datos.");
                        return View();
                    }
                    else
                    {
                        clsSancion ObjSancion = new clsSancion();
                        clsUsuario objUsuario = new clsUsuario();
                        clsBitacoraSancion objBitacoraSancion = new clsBitacoraSancion();

                        bool Resultado = ObjSancion.AgregarSancion(listIdEmpleado, listIdDepartamento, sancion.fechaSancion, txtCodigo,
                            ObjSancion.ConsultaNombreEmpleado().ElementAt(listIdEmpleado - 1).Nombre, txtDetalleSancion, true);

                        string nombreUsuario = (string)Session["Usuario"];
                        int IdUsuario = objUsuario.ConsultarIdUsuario(nombreUsuario);

                        objBitacoraSancion.AgregarBitacoraSancion(IdUsuario, nombreUsuario, DateTime.Now, listIdEmpleado, listIdDepartamento, sancion.fechaSancion, txtCodigo,
                            ObjSancion.ConsultaNombreEmpleado().ElementAt(listIdEmpleado - 1).Nombre, txtDetalleSancion, true);

                        if (Resultado)
                        {
                            TempData["exitoMensaje"] = "La sanción se ha insertado exitosamente.";
                            return RedirectToAction("Crear");
                        }
                        else
                        {
                            TempData["errorMensaje"] = "Se presentó un error al intentar insertar este elemento, revise que los datos coincidan con lo que especifican los campos";
                            return View("Crear");
                        }
                    }
                }
                else
                {
                    clsSancion ObjSancion = new clsSancion();
                    ViewBag.Lista = ObjSancion.ConsultarDepartamento().ToList();
                    ViewBag.Lista2 = ObjSancion.ConsultarIdEmpleado().ToList();

                    TempData["errorMensaje"] = "Inserte todos los datos.";
                    return RedirectToAction("Crear");
                }
            }
            catch
            {
                clsSancion ObjSancion = new clsSancion();
                ViewBag.Lista = ObjSancion.ConsultarDepartamento().ToList();
                ViewBag.Lista2 = ObjSancion.ConsultarIdEmpleado().ToList();

                TempData["errorMensaje"] = "Todos los campos son obligatorios.";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            try
            {
                clsSancion sancion = new clsSancion();

                ViewBag.Lista = sancion.ConsultarDepartamento().ToList();
                ViewBag.Lista2 = sancion.ConsultarIdEmpleado().ToList();

                var dato = sancion.ConsultaSancion(id);

                Sancion modelo = new Sancion();
                modelo.idSanciones = dato[0].idSanciones;
                modelo.idEmpleado = dato[0].IdEmpleado;
                modelo.idDepartamento = dato[0].idDepartamento;
                modelo.fechaSancion = dato[0].fechaSancion;
                modelo.codigo = dato[0].codigo;
                modelo.nombre = dato[0].nombre;
                modelo.detalle = dato[0].detalle;
                modelo.estadoSancion = dato[0].estadoSancion;
                return View(modelo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: Sancion/Edit/5
        [HttpPost]
        public ActionResult Editar(int id, Sancion sancion, int listIdDepartamento, int listIdEmpleado)
        {
            try
            {
                if (!sancion.detalle.Equals("") && !sancion.codigo.Equals(""))
                {
                    if (!ModelState.IsValid)
                    {
                        clsSancion ObjSancion = new clsSancion();
                        ViewBag.Lista = ObjSancion.ConsultarDepartamento().ToList();
                        ViewBag.Lista2 = ObjSancion.ConsultarIdEmpleado().ToList();

                        ModelState.AddModelError("", "Inserte correctamente los datos.");
                        return View();
                    }
                    else
                    {
                        clsSancion Objsancion = new clsSancion();
                        clsUsuario objUsuario = new clsUsuario();
                        clsBitacoraSancion objBitacoraSancion = new clsBitacoraSancion();

                        ViewBag.Lista = Objsancion.ConsultarDepartamento().ToList();
                        ViewBag.Lista2 = Objsancion.ConsultarIdEmpleado().ToList();

                        bool Resultado = Objsancion.ActualizarSancion(sancion.idSanciones, listIdEmpleado, listIdDepartamento, sancion.fechaSancion, sancion.codigo,
                                Objsancion.ConsultaNombreEmpleado().ElementAt(listIdEmpleado - 1).Nombre, sancion.detalle, true);


                        string nombreUsuario = (string)Session["Usuario"];
                        int IdUsuario = objUsuario.ConsultarIdUsuario(nombreUsuario);

                        objBitacoraSancion.ActualizarBitacoraSancion(sancion.idSanciones, IdUsuario, nombreUsuario, DateTime.Now, listIdEmpleado, listIdDepartamento, sancion.fechaSancion, sancion.codigo,
                                Objsancion.ConsultaNombreEmpleado().ElementAt(listIdEmpleado - 1).Nombre, sancion.detalle, true);

                        TempData["exitoMensaje"] = "Los datos de la sanción se han modificado exitosamente.";
                        return View("Editar");
                    }
                }
                else
                {
                    clsSancion ObjSancion = new clsSancion();
                    ViewBag.Lista = ObjSancion.ConsultarDepartamento().ToList();
                    ViewBag.Lista2 = ObjSancion.ConsultarIdEmpleado().ToList();

                    TempData["errorMensaje"] = "Inserte todos los datos.";
                    return RedirectToAction("Crear");
                }
            }
            catch
            {
                clsSancion ObjSancion = new clsSancion();
                ViewBag.Lista = ObjSancion.ConsultarDepartamento().ToList();
                ViewBag.Lista2 = ObjSancion.ConsultarIdEmpleado().ToList();

                TempData["errorMensaje"] = "Se produjo un error, revise los datos insertados.";
                return View("Editar");
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
                    clsSancion ObjSancion = new clsSancion();
                    ObjSancion.DeshabilitarSancion(id);
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

