using BLL;
using Consola.Helpers;
using Consola.Tools;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Consola.Controllers
{
    [SessionManage]
    public class CrearUsuarioController : Controller
    {
        [HttpGet]
        public ActionResult CrearUsuario()
        {
            clsUsuario ObjUsuario = new clsUsuario();
            ViewBag.Lista = ObjUsuario.ConsultarRoles().ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CrearUsuario(string txtNombreUsuario, int listIdRol, string txtContrasena, string txtConfirmarContrasena)
        {
            try
            {
                if (txtContrasena.Equals(txtConfirmarContrasena))
                {
                    if (!txtNombreUsuario.Equals("") && !txtContrasena.Equals("") && !txtConfirmarContrasena.Equals(""))
                    {
                        if (!ModelState.IsValid)
                        {
                            ModelState.AddModelError("", "Usuario o Password Incorrectos");
                            return View();
                        }
                        else
                        {
                            clsUsuario ObjUsuario = new clsUsuario();
                            clsBitacoraUsuario objBitacoraUsuarios = new clsBitacoraUsuario();

                            int existeUsuario = ObjUsuario.ConsultarExisteNombreUsuario(txtNombreUsuario);

                            if (existeUsuario != 1)
                            {
                                bool Resultado = ObjUsuario.AgregarUsuario(listIdRol, txtNombreUsuario, txtConfirmarContrasena, true);

                                var nuevoUsuario = ObjUsuario.ExisteUsuario(txtNombreUsuario, Seguridad.Encriptar(txtConfirmarContrasena)).Where(x => x.estado == true);

                                string nombreUsuario = (string)Session["Usuario"];
                                int IdUsuario = ObjUsuario.ConsultarIdUsuario(nombreUsuario);

                                objBitacoraUsuarios.AgregarBitacoraUsuario(IdUsuario, nombreUsuario, DateTime.Now, listIdRol, txtNombreUsuario, Seguridad.Encriptar(txtConfirmarContrasena), true);

                                if (Resultado)
                                {
                                    TempData["exitoMensaje"] = "El usuario se ha creado exitosamente.";
                                    return RedirectToAction("CrearUsuario");
                                }
                                else
                                {
                                    TempData["errorMensaje"] = "Se presentó un error al intentar insertar este elemento, revise que los datos coincidan con lo que especifican los campos";
                                    return View("CrearUsuario");
                                }
                            }
                            else
                            {
                                TempData["errorMensaje"] = "El nombre de usuario insertado ya existe, intente con otro nombre.";
                                return RedirectToAction("CrearUsuario");
                            }
                        }
                    }
                    else
                    {
                        TempData["errorMensaje"] = "Inserte un nombre de usuario.";
                        return RedirectToAction("CrearUsuario");
                    }
                }
                else
                {
                    TempData["errorMensaje"] = "Las contraseñas ingresadas en los campos no coinciden.";
                    return RedirectToAction("CrearUsuario");
                }
            }
            catch (Exception)
            {
                TempData["errorMensaje"] = "Todos los campos son obligatorios.";
                return CrearUsuario();
            }
        }

        // GET: CrearUsuario
        public ActionResult Index()
        {
            return View();
        }

        // GET: CrearUsuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CrearUsuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CrearUsuario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CrearUsuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CrearUsuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CrearUsuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CrearUsuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
