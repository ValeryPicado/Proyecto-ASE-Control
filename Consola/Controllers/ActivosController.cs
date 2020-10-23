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
    public class ActivosController : Controller
    {
        // GET: Activos
        public ActionResult Index()
        {
            try
            {
                List<Activos> listaActivos = new List<Activos>();
                clsActivos activo = new clsActivos();
                var data = activo.ConsultarActivo().ToList();

                foreach (var item in data)
                {
                    Activos modelo = new Activos();
                    modelo.IdActivo = item.IdActivo;
                    modelo.codigoActivo = item.codigoActivo;
                    modelo.nombreActivo = item.nombreActivo;
                    modelo.costoActivo = item.costoActivo;
                    modelo.anno = item.anno;
                    modelo.meses = item.meses;
                    modelo.costoAnual = item.costoAnual;
                    modelo.costoMensual = item.costoMensual;
                    modelo.fechaActivo = item.fechaActivo;
                    modelo.estadoActivo = item.estadoActivo;

                    listaActivos.Add(modelo);
                }
                return View(listaActivos);
            }
            catch
            {
                string descMsg = "Error consultando la informacion del CLiente.";
                //Bitacora
                return RedirectToAction("Error", "Error");
            }
        }

        // GET: Activos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Activos activos)
        {
            try
            {
                if ((activos.costoActivo >= 0) && (activos.anno > 0) && (activos.meses > 0))
                {
                    if (ModelState.IsValid)
                    {
                        clsActivos ObjActivo = new clsActivos();
                        clsUsuario objUsuario = new clsUsuario();
                        clsBitacoraActivos objBitacoraActivos = new clsBitacoraActivos();

                        bool Resultado = ObjActivo.AgregarActivo(activos.codigoActivo, activos.nombreActivo, activos.costoActivo, activos.anno,
                            activos.meses, activos.fechaActivo, true);

                        string nombreUsuario = (string)Session["Usuario"];
                        int IdUsuario = objUsuario.ConsultarIdUsuario(nombreUsuario);

                        objBitacoraActivos.AgregarBitacoraActivos(IdUsuario, nombreUsuario, DateTime.Now, activos.codigoActivo, activos.nombreActivo, activos.costoActivo, activos.anno,
                            activos.meses, activos.fechaActivo, true);

                        if (Resultado)
                        {
                            TempData["exitoMensaje"] = "El activo se ha insertado exitosamente.";
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
                        TempData["errorMensaje"] = "Error de inserción, revise los datos.";
                        return View("Crear");
                    }
                }
                else
                {
                TempData["errorMensaje"] = "Los campos de costo, años o meses no pueden tener valores negativos.";
                return View();
                }
            }
            catch
            {
                TempData["errorMensaje"] = "Todos los campos son obligatorios.";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            try
            {
                clsActivos activos = new clsActivos();

                var dato = activos.ConsultaActivo(id);

                Activos modelo = new Activos();
                modelo.IdActivo = dato[0].IdActivo;
                modelo.codigoActivo = dato[0].codigoActivo;
                modelo.nombreActivo = dato[0].nombreActivo;
                modelo.costoActivo = dato[0].costoActivo;
                modelo.anno = dato[0].anno;
                modelo.meses = dato[0].meses;
                modelo.fechaActivo = dato[0].fechaActivo;
                return View(modelo);
            }
            catch (Exception)
            {
                throw;
            }

        }

        // POST: Activos/Edit/5

        [HttpPost]
        public ActionResult Editar(int id, Activos activos)
        {
            try
            {
                if ((activos.costoActivo > 0) && (activos.anno > 0) && (activos.meses > 0))
                {
                    if (ModelState.IsValid)
                    {
                        clsActivos Objactivos = new clsActivos();
                        clsUsuario objUsuario = new clsUsuario();
                        clsBitacoraActivos objBitacoraActivos = new clsBitacoraActivos();

                        bool Resultado = Objactivos.ActualizarActivo(activos.IdActivo, activos.codigoActivo, activos.nombreActivo,
                            activos.costoActivo, activos.anno, activos.meses, activos.fechaActivo, true);

                        string nombreUsuario = (string)Session["Usuario"];
                        int IdUsuario = objUsuario.ConsultarIdUsuario(nombreUsuario);

                        objBitacoraActivos.ActualizarBitacoraActivos(activos.IdActivo, IdUsuario, nombreUsuario, DateTime.Now, activos.codigoActivo, activos.nombreActivo, activos.costoActivo, activos.anno,
                        activos.meses, activos.fechaActivo, true);

                        TempData["exitoMensaje"] = "El activo se ha modificado exitosamente.";
                        return View();
                    }
                    else
                    {
                        TempData["errorMensaje"] = "Error de inserción, revise los datos.";
                        return View("Crear");
                    }
                }
                else
                {
                    TempData["errorMensaje"] = "Los campos de costo, años o meses no pueden tener valores negativos.";
                    return View();
                }
            }
            catch
            {
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
                    clsActivos ObjActivo = new clsActivos();
                    ObjActivo.DeshabilitarActivo(id);
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
