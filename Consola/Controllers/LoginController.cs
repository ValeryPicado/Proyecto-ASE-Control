using Consola.Models;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL;
using Consola.Tools;
using System.Collections.Generic;

namespace Consola.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl, string Password)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Usuario o contraseña Incorrectos");
                    return View();
                }
                else
                {
                    clsUsuario Objusuario = new clsUsuario();

                    IList<DAL.ConsultarClaveUsuarioResult> clave = new List<DAL.ConsultarClaveUsuarioResult>();

                    int idUsuario = Objusuario.ConsultarIdUsuario(model.Usuario);

                    clave = Objusuario.ConsultarClaveUsuario(idUsuario);

                    string claveEncriptada = Seguridad.Encriptar(Password);

                    if (clave.ElementAt(0).clave.Equals(claveEncriptada))
                    {
                        var usuario = Objusuario.ExisteUsuario(model.Usuario, Seguridad.Encriptar(model.Password)).Where(x => x.estado == true);

                        int Rol = Objusuario.ConsultarRolUsuario(model.Usuario);
                        int estado = Objusuario.ConsultarEstadoUsuario(model.Usuario);
                        if (estado == 1)
                        {
                            if (usuario.Count() > 0)
                            {

                                Session["US"] = model.Usuario;
                                Session["PW"] = model.Password;

                                Session["Usuario"] = model.Usuario;
                                Session["idUsuario"] = Objusuario.ConsultarIdUsuario((string)Session["Usuario"]);

                                if (Rol.Equals(1))
                                {
                                    Session["ROLES"] = "Admin";
                                }

                                if (Rol.Equals(2))
                                {
                                    Session["ROLES"] = "Regular";
                                }

                                if (Rol.Equals(3))
                                {
                                    Session["ROLES"] = "Bodega";
                                }

                                string baseUrl = ConfigurationManager.AppSettings["URL_API"];

                                //crea el el encabezado
                                HttpClient client = new HttpClient();
                                client.BaseAddress = new Uri(baseUrl);
                                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                                client.DefaultRequestHeaders.Accept.Add(contentType);

                                Usuario userModel = new Usuario();
                                userModel.UserName = model.Usuario;
                                userModel.Password = claveEncriptada;

                                string stringData = JsonConvert.SerializeObject(userModel);
                                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

                                HttpResponseMessage response = client.PostAsync("/api/login/authenticate", contentData).Result;
                                var stringJWT = response.Content.ReadAsStringAsync().Result;

                                JWT jwt = new JWT { Token = stringJWT.Replace("\"", "") };

                                //Aca se crea la sesion
                                Session["token"] = jwt.Token;
                                Session["US"] = model.Usuario.ToUpper();

                                string userData = "Datos específicos de aplicación para este usuario.";

                                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                                model.Usuario.ToUpper(),
                                DateTime.Now,
                                DateTime.Now.AddMinutes(30),
                                model.RememberMe,
                                userData,
                                FormsAuthentication.FormsCookiePath);

                                // Encryptar el ticket.
                                string encTicket = FormsAuthentication.Encrypt(ticket);

                                // Crea la cookie.
                                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                                if (!string.IsNullOrEmpty(returnUrl))
                                {
                                    return Redirect(returnUrl);
                                }
                                else
                                {
                                    return RedirectToAction("Index", "Home");
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("Error de Autenticación", "Usuario o Contaseña Invalida");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("Error de Autenticación", "El usuario ingresado está deshabilitado");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Error de Autenticación", "La contraseña insertada no es correcta, intente de nuevo.");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Usuario o contaseña Incorrectos");
                return View();
            }
            return View(model);
        }

        //[Authorize]
        public ActionResult Salir()
        {
            Session.Remove("US");
            Session["token"] = null;
            Session.RemoveAll();
            Response.Cache.SetCacheability(HttpCacheability.Private);
            Session.Clear();
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Cache.SetNoServerCaching();
            Request.Cookies.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}