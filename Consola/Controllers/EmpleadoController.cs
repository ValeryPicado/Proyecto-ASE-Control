using BLL;
using Consola.Helpers;
using Consola.Models;
using Consola.Tools;
using DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace Consola.Controllers
{
    [SessionManage]
    public class EmpleadoController : Controller
    {
        clsInformacion Informacion = new clsInformacion();
        // GET: Empleado
        public ActionResult Index()
        {
            try
            {
                List<Empleado> listaEmpleado = new List<Empleado>();
                clsEmpleado empleado = new clsEmpleado();
                var data = empleado.ConsultarEmpleado().ToList();

                foreach (var item in data)
                {
                    Empleado modelo = new Empleado();
                    modelo.IdEmpleado = item.IdEmpleado;
                    modelo.IdTipoIdentificacion = item.IdTipoIdentificacion;
                    modelo.Identificacion = item.Identificacion;
                    modelo.Nombre = item.Nombre;
                    modelo.Apellido1 = item.Apellido1;
                    modelo.Apellido2 = item.Apellido2;
                    modelo.Direccion = item.Direccion;
                    modelo.fechaNacimiento = item.fechaNacimiento;
                    modelo.departamento = item.departamento;
                    modelo.Correo = item.Correo;
                    modelo.Telefono = item.Telefono;
                    modelo.Provincia = item.Provincia;
                    modelo.Canton = item.Canton;
                    modelo.Distrito = item.Distrito;
                    modelo.fechaEntrada = item.fechaEntrada;
                    modelo.fechaSalida = item.fechaSalida;
                    modelo.estadoEmpleado = item.estadoEmpleado;

                    listaEmpleado.Add(modelo);
                }
                return View(listaEmpleado);
            }
            catch
            {
                string descMsg = "Error consultando la informacion del CLiente.";
                //Bitacora
                return RedirectToAction("Error", "Error");
            }
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Empleado/Create
        public ActionResult Crear()
        {
            try
            {
                clsTipoIdentificacion tiposIdentificacion = new clsTipoIdentificacion();
                ViewBag.ListaSexo = new SelectList(new[] {
                                   new SelectListItem { Value = "1", Text = "Hombre" },
                                   new SelectListItem { Value = "2", Text = "Mujer" }
                                                               }, "Value", "Text");
                ViewBag.ListaEstados = new SelectList(new[] {
                                   new SelectListItem { Value = "True", Text = "Activo" },
                                   new SelectListItem { Value = "False", Text = "Inactivo" }
                                                               }, "Value", "Text");
                ViewBag.ListaProvincias = CargaProvincias();
                ViewBag.ListaTiposIdentificacion = tiposIdentificacion.ConsultarTipoIdentificacion();

                clsSancion ObjSancion = new clsSancion();
                ViewBag.Lista = ObjSancion.ConsultarDepartamento().ToList();

                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: Empleado/Create
        [HttpPost]
        public ActionResult Crear(Empleado empleado, string listIdDepartamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!Utilerias.ValidarCorreo(empleado.Correo))
                    {

                    }
                    clsEmpleado Objempleado = new clsEmpleado();
                    clsUsuario objUsuario = new clsUsuario();
                    clsBitacoraEmpleado objBitacoraEmpleado = new clsBitacoraEmpleado();

                    bool Resultado = Objempleado.AgregarEmpleado(empleado.IdTipoIdentificacion, empleado.Identificacion, empleado.Nombre, empleado.Apellido1, empleado.Apellido2,
             empleado.Direccion, empleado.fechaNacimiento, listIdDepartamento, empleado.Correo, empleado.Telefono, empleado.Provincia, empleado.Canton, empleado.Distrito,
             empleado.fechaEntrada, empleado.fechaSalida, true);

                    string nombreUsuario = (string)Session["Usuario"];
                    int IdUsuario = objUsuario.ConsultarIdUsuario(nombreUsuario);

                    objBitacoraEmpleado.AgregarBitacoraEmpleado(IdUsuario, nombreUsuario, DateTime.Now, empleado.IdTipoIdentificacion, empleado.Identificacion, empleado.Nombre, empleado.Apellido1, empleado.Apellido2,
             empleado.Direccion, empleado.fechaNacimiento, listIdDepartamento, empleado.Correo, empleado.Telefono, empleado.Provincia, empleado.Canton, empleado.Distrito,
             empleado.fechaEntrada, empleado.fechaSalida, true);

                    if (Resultado)
                    {
                        TempData["exitoMensaje"] = "El empleado se ha insertado exitosamente.";
                        return RedirectToAction("Crear");
                    }
                    else
                    {
                        clsTipoIdentificacion tiposIdentificacion = new clsTipoIdentificacion();
                        ViewBag.ListaSexo = new SelectList(new[] {
                                       new SelectListItem { Value = "1", Text = "Hombre" },
                                       new SelectListItem { Value = "2", Text = "Mujer" }
                                                                   }, "Value", "Text");
                        ViewBag.ListaEstados = new SelectList(new[] {
                                   new SelectListItem { Value = "1", Text = "Activo" },
                                   new SelectListItem { Value = "0", Text = "Inactivo" }
                                                               }, "Value", "Text");
                        ViewBag.ListaProvincias = CargaProvincias();
                        ViewBag.ListaTiposIdentificacion = tiposIdentificacion.ConsultarTipoIdentificacion();
                        TempData["errorMensaje"] = "Se presentó un error al intentar insertar este elemento, revise que los datos coincidan con lo que especifican los campos";

                        clsSancion ObjSancion = new clsSancion();
                        ViewBag.Lista = ObjSancion.ConsultarDepartamento().ToList();

                        return View("Crear");
                    }
                }
                else
                {
                    clsTipoIdentificacion tiposIdentificacion = new clsTipoIdentificacion();
                    ViewBag.ListaSexo = new SelectList(new[] {
                                   new SelectListItem { Value = "H", Text = "Hombre" },
                                   new SelectListItem { Value = "M", Text = "Mujer" }
                                                               }, "Value", "Text");
                    ViewBag.ListaEstados = new SelectList(new[] {
                                   new SelectListItem { Value = "1", Text = "Activo" },
                                   new SelectListItem { Value = "0", Text = "Inactivo" }
                                                               }, "Value", "Text");
                    ViewBag.ListaProvincias = CargaProvincias();
                    ViewBag.ListaTiposIdentificacion = tiposIdentificacion.ConsultarTipoIdentificacion();

                    clsSancion ObjSancion = new clsSancion();
                    ViewBag.Lista = ObjSancion.ConsultarDepartamento().ToList();
                    TempData["errorMensaje"] = "Se ha producido un error, revise los datos inserdatos.";
                    return View("Crear");
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
                clsEmpleado empleado = new clsEmpleado();
                var dato = empleado.ConsultaEmpleado(id);

                //clsSancion ObjSancion = new clsSancion();
                //ViewBag.Lista = ObjSancion.ConsultarDepartamento().ToList();

                clsTipoIdentificacion tiposIdentificacion = new clsTipoIdentificacion();
                ViewBag.ListaSexo = new SelectList(new[] {
                                   new SelectListItem { Value = "1", Text = "Hombre" },
                                   new SelectListItem { Value = "2", Text = "Mujer" }
                                                               }, "Value", "Text");
                ViewBag.ListaEstados = new SelectList(new[] {
                                   new SelectListItem { Value = "True", Text = "Activo" },
                                   new SelectListItem { Value = "False", Text = "Inactivo" }
                                                               }, "Value", "Text");
                ViewBag.ListaProvincias = CargaProvincias();
                ViewBag.ListaTiposIdentificacion = tiposIdentificacion.ConsultarTipoIdentificacion();

                clsSancion ObjSancion = new clsSancion();
                ViewBag.Lista = ObjSancion.ConsultarDepartamento().ToList();

                Empleado modelo = new Empleado();
                modelo.IdEmpleado = dato[0].IdEmpleado;
                modelo.IdTipoIdentificacion = dato[0].IdTipoIdentificacion;
                modelo.Identificacion = dato[0].Identificacion;
                modelo.Nombre = dato[0].Nombre;
                modelo.Apellido1 = dato[0].Apellido1;
                modelo.Apellido2 = dato[0].Apellido2;
                modelo.Direccion = dato[0].Direccion;
                modelo.fechaNacimiento = dato[0].fechaNacimiento;
                modelo.departamento = dato[0].departamento;
                modelo.Correo = dato[0].Correo;
                modelo.Telefono = dato[0].Telefono;
                modelo.Provincia = dato[0].Provincia;
                modelo.Canton = dato[0].Canton;
                modelo.Distrito = dato[0].Distrito;
                modelo.fechaEntrada = dato[0].fechaEntrada;
                modelo.fechaSalida = dato[0].fechaSalida;
                modelo.estadoEmpleado = dato[0].estadoEmpleado;
                return View(modelo);
            }
            catch (Exception)
            {
                throw;
            }

        }

        // POST: Activos/Edit/5
        [HttpPost]
        public ActionResult Editar(int id, Empleado empleado, string listIdDepartamento)
        {
            try
            {
                if (!empleado.Provincia.Equals("--Provincia--") && !empleado.Canton.Equals("--Canton--") && !empleado.Distrito.Equals("--Distrito--"))
                {
                    clsEmpleado ObjEmpleado = new clsEmpleado();
                    clsUsuario objUsuario = new clsUsuario();
                    clsBitacoraEmpleado objBitacoraEmpleado = new clsBitacoraEmpleado();

                    bool Resultado = ObjEmpleado.ActualizarEmpleado(empleado.IdEmpleado, empleado.Direccion, empleado.fechaNacimiento, listIdDepartamento
                        , empleado.Correo, empleado.Telefono, empleado.Provincia, empleado.Canton, empleado.Distrito, empleado.fechaEntrada, empleado.fechaSalida
                        , true);

                    string nombreUsuario = (string)Session["Usuario"];
                    int IdUsuario = objUsuario.ConsultarIdUsuario(nombreUsuario);

                    objBitacoraEmpleado.ActualizarBitacoraEmpleado(empleado.IdEmpleado, IdUsuario, nombreUsuario, DateTime.Now, empleado.Direccion, empleado.fechaNacimiento, listIdDepartamento
                        , empleado.Correo, empleado.Telefono, empleado.Provincia, empleado.Canton, empleado.Distrito, empleado.fechaEntrada, empleado.fechaSalida
                        , true);

                    clsTipoIdentificacion tiposIdentificacion = new clsTipoIdentificacion();
                    ViewBag.ListaSexo = new SelectList(new[] {
                                   new SelectListItem { Value = "1", Text = "Hombre" },
                                   new SelectListItem { Value = "2", Text = "Mujer" }
                                                               }, "Value", "Text");
                    ViewBag.ListaEstados = new SelectList(new[] {
                                   new SelectListItem { Value = "True", Text = "Activo" },
                                   new SelectListItem { Value = "False", Text = "Inactivo" }
                                                               }, "Value", "Text");
                    ViewBag.ListaProvincias = CargaProvincias();
                    ViewBag.ListaTiposIdentificacion = tiposIdentificacion.ConsultarTipoIdentificacion();

                    clsSancion ObjSancion = new clsSancion();
                    ViewBag.Lista = ObjSancion.ConsultarDepartamento().ToList();


                    TempData["exitoMensaje"] = "El colaborador se ha modificado exitosamente.";
                    return View();
                }
                else
                {
                    clsTipoIdentificacion tiposIdentificacion = new clsTipoIdentificacion();
                    ViewBag.ListaSexo = new SelectList(new[] {
                                   new SelectListItem { Value = "1", Text = "Hombre" },
                                   new SelectListItem { Value = "2", Text = "Mujer" }
                                                               }, "Value", "Text");
                    ViewBag.ListaEstados = new SelectList(new[] {
                                   new SelectListItem { Value = "True", Text = "Activo" },
                                   new SelectListItem { Value = "False", Text = "Inactivo" }
                                                               }, "Value", "Text");
                    ViewBag.ListaProvincias = CargaProvincias();
                    ViewBag.ListaTiposIdentificacion = tiposIdentificacion.ConsultarTipoIdentificacion();

                    clsSancion ObjSancion = new clsSancion();
                    ViewBag.Lista = ObjSancion.ConsultarDepartamento().ToList();

                    TempData["errorMensaje"] = "Inserte correctamente la provincia, cantón y distrito de residencia del colaborador.";
                    return View();
                }
            }
            catch
            {
                clsTipoIdentificacion tiposIdentificacion = new clsTipoIdentificacion();
                ViewBag.ListaSexo = new SelectList(new[] {
                                   new SelectListItem { Value = "1", Text = "Hombre" },
                                   new SelectListItem { Value = "2", Text = "Mujer" }
                                                               }, "Value", "Text");
                ViewBag.ListaEstados = new SelectList(new[] {
                                   new SelectListItem { Value = "True", Text = "Activo" },
                                   new SelectListItem { Value = "False", Text = "Inactivo" }
                                                               }, "Value", "Text");
                ViewBag.ListaProvincias = CargaProvincias();
                ViewBag.ListaTiposIdentificacion = tiposIdentificacion.ConsultarTipoIdentificacion();

                clsSancion ObjSancion = new clsSancion();
                ViewBag.Lista = ObjSancion.ConsultarDepartamento().ToList();

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
                    clsEmpleado ObjEmpleado = new clsEmpleado();
                    ObjEmpleado.DeshabilitarEmpleado(id);
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
            
        public List<ProvinciasResult> CargaProvincias()
        {
            List<ProvinciasResult> provincias = Informacion.ObtenerProvincias();
            return provincias;
        }
        /// <summary>
        /// Obtiene Cantones
        /// </summary>
        /// <param name="provincia"></param>
        /// <returns></returns>
        public List<CantonesResult> CargaCanton(char provincia)
        {
            List<CantonesResult> cantones = Informacion.ObtenerCantones(provincia);
            return cantones;
        }
        /// <summary>
        /// Obtiene Distritos
        /// </summary>
        /// <param name="provincia"></param>
        /// <param name="canton"></param>
        /// <returns></returns>
        public List<DistritosResult> CargaDistrito(char provincia, string canton)
        {
            List<DistritosResult> distritos = Informacion.ObtenerDistritos(provincia, canton);
            return distritos;
        }
        /// <summary>
        /// Cargar Cantones hacia la pantalla
        /// </summary>
        /// <param name="provincia"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CargaCantones(char provincia)
        {
            List<CantonesResult> cantones = Informacion.ObtenerCantones(provincia);
            return Json(cantones, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Cargar Disttritos hacia la pantalla
        /// </summary>
        /// <param name="provincia"></param>
        /// <param name="canton"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CargaDistritos(char provincia, string canton)
        {
            List<DistritosResult> distritos = Informacion.ObtenerDistritos(provincia, canton);
            return Json(distritos, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ConsultaPersona(string identificacion)
        {
            string baseUrl = ConfigurationManager.AppSettings["URL_API"];

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(contentType);
            JWT jwt = new JWT();
            jwt.Token = HttpContext.Session["token"].ToString();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.Token);

            DatoPersona personModel = new DatoPersona();
            personModel.Identificacion = identificacion;

            string stringData = JsonConvert.SerializeObject(personModel);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("/api/consultas/ObtenerIdentificacion", contentData).Result;
            string stringPersona = response.Content.ReadAsStringAsync().Result;
            List<Institucion> data = JsonConvert.DeserializeObject<List<Institucion>>(stringPersona);

            if (!response.IsSuccessStatusCode)
            {
                string Message = "Unauthorized!";
                return Json(Message, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
