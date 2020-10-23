using BLL;
using Consola.Helpers;
using Consola.Models;
using Consola.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace Consola.Controllers
{
    [SessionManage]
    public class Usuario2Controller : Controller
    {
        // GET: Usuario2
        public ActionResult Index()
        {
            try
            {
                List<Usuario> listaUsuario = new List<Usuario>();
                clsUsuario usuario = new clsUsuario();
                var data = usuario.ConsultarUsuarios().ToList();

                foreach (var item in data)
                {
                    Usuario modelo = new Usuario();
                    modelo.idUsuario = item.idUsuario;
                    modelo.idTipoRol = item.idTipoRol;
                    modelo.UserName = item.usuario;
                    modelo.Password = item.clave;
                    modelo.Estado = item.estado;

                    listaUsuario.Add(modelo);

                }
                return View(listaUsuario);
            }
            catch
            {
                //Bitacora
                return RedirectToAction("Error", "Error");
            }
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            clsUsuario ObjUsuario = new clsUsuario();

            ViewBag.Lista = ObjUsuario.ConsultarRoles().ToList();

            try
            {
                clsUsuario usuario = new clsUsuario();
                var dato = usuario.ConsultaUsuario(id);

                Usuario modelo = new Usuario();
                modelo.idUsuario = dato[0].idUsuario;
                modelo.idTipoRol = dato[0].idTipoRol;
                modelo.UserName = dato[0].usuario;
                modelo.Password = dato[0].clave;
                modelo.Estado = dato[0].estado;
                return View(modelo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: Activos/Edit/5
        [HttpPost]
        public ActionResult Editar(int id, Usuario usuario, string txtNombreUsuario, int listIdRol, string txtContrasena, string txtConfirmarContrasena)
        {
            try
            {
                if (txtContrasena.Equals(txtConfirmarContrasena))
                {
                    if (!txtContrasena.Equals("") && !txtConfirmarContrasena.Equals(""))
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

                            ViewBag.Lista = ObjUsuario.ConsultarRoles().ToList();

                            int ultimoId = ObjUsuario.ConsultarUltimoIdUsuario();

                            IList<DAL.ConsultarUltimaClaveUsuarioResult> clave = new List<DAL.ConsultarUltimaClaveUsuarioResult>();

                            clave = ObjUsuario.ConsultarUltimaClaveUsuario();

                            string claveEncriptada = Seguridad.Encriptar(txtConfirmarContrasena);

                            ObjUsuario.ActualizarEditarUsuario(usuario.idUsuario, listIdRol, txtNombreUsuario,
                            claveEncriptada, true);

                            ObjUsuario.ActualizarContrasenaUsuario(ultimoId,
                            clave.ElementAt(0).clave);

                            bool Resultado = true;

                            string nombreUsuario = (string)Session["Usuario"];
                            int IdUsuario = ObjUsuario.ConsultarIdUsuario(nombreUsuario);

                            objBitacoraUsuarios.ActualizarBitacoraUsuario(usuario.idUsuario, IdUsuario, nombreUsuario, DateTime.Now, listIdRol, usuario.UserName,
                            claveEncriptada, true);

                            if (Resultado)
                            {
                                TempData["exitoMensaje"] = "El usuario se ha modificado exitosamente.";
                                return RedirectToAction("Editar");
                            }
                            else
                            {
                                return View("Editar");
                            }
                        }
                    }
                    else
                    {
                        TempData["errorMensaje"] = "Inserte un nombre de usuario.";
                        return RedirectToAction("Editar");
                    }
                }
                else
                {
                    TempData["errorMensaje"] = "Las contraseñas ingresadas en los campos no coinciden.";
                    return RedirectToAction("Editar");
                }
            }
            catch (Exception)
            {
                TempData["errorMensaje"] = "Todos los campos son obligatorios.";
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
                    clsUsuario ObjUsuario = new clsUsuario();
                    ObjUsuario.DeshabilitarUsuario(id);
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

        [HttpGet]
        public ActionResult Crear()
        {
            clsUsuario ObjUsuario = new clsUsuario();
            ViewBag.Lista = ObjUsuario.ConsultarRoles().ToList();
            return View();
        }
    }
}