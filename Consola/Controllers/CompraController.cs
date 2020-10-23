using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using BLL;
using Consola.Helpers;
using Consola.Models;

namespace Consola.Controllers
{
    [SessionManage]
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Index()
        {
            try
            {
                List<Compra> listaCompra = new List<Compra>();
                clsCompra compra = new clsCompra();
                var data = compra.ConsultarCompra().ToList();

                foreach (var item in data)
                {
                    Compra modelo = new Compra();
                    modelo.idCompra = item.idCompra;
                    modelo.nombreProducto = item.nombreProducto;
                    modelo.cantidadCompra = item.cantidadCompra;
                    modelo.detalleCompra = item.detalleCompra;
                    modelo.estadoCompra = item.estadoCompra;

                    listaCompra.Add(modelo);
                }
                return View(listaCompra);
            }
            catch
            {
                string descMsg = "Error consultando la informacion de la compra.";
                //Bitacora
                return RedirectToAction("Error", "Error");
            }
        }

        // GET: Compra/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Crear()
        {
            clsCompra ObjCompra = new clsCompra();
            ViewBag.Lista = ObjCompra.ConsultaCorreoProveedor().ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Crear(string txtCorreoElectronico, string asunto, string mensaje
            , string txtNombreProducto, string txtCantidadProducto, string txtDetalleCompra)
        {
            try
            {
                if (Int32.Parse(txtCantidadProducto) > 0)
                {
                    if (ModelState.IsValid)
                    {
                        clsCompra objcompra = new clsCompra();
                        clsUsuario objUsuario = new clsUsuario();
                        clsBitacoraCompra objBitacoraCompra = new clsBitacoraCompra();

                        bool Resultado = objcompra.AgregarCompra(txtNombreProducto,
                            Int32.Parse(txtCantidadProducto), txtDetalleCompra, true);

                        string nombreUsuario = (string)Session["Usuario"];
                        int IdUsuario = objUsuario.ConsultarIdUsuario(nombreUsuario);

                        objBitacoraCompra.AgregarBitacoraCompra(IdUsuario, nombreUsuario, DateTime.Now, txtNombreProducto,
                            Int32.Parse(txtCantidadProducto), txtDetalleCompra, true);

                        if (Resultado)
                        {
                            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

                            mmsg.To.Add(txtCorreoElectronico);
                            asunto = "Orden de compra Tarimas LS";
                            mensaje =

                                  "<h1 text-align: center;><b> Orden de compra Tarimas LS </b></h1>" +
                                "<br />" +
                                "<br /> Este es un correo automatizado del sistema de Tarimas LS, a continuación se detalla la siguiente orden de compra: " +
                                "<br />" +
                                "<br /> ********************************************************************************************** " +
                                "<h3 text-align: center;><b> Orden de compra: </b></h3>" +
                                "<br /> Nombre de producto: " + txtNombreProducto +
                                "<br /> Cantidad: " + txtCantidadProducto +
                                "<br /> Detalles: " + txtDetalleCompra +
                                "<br /> ********************************************************************************************** " +
                                "<br />" +
                                "<br /> Tarimas LS S.A. <a href='https://www.tarimasls.com/'> Tarimas LS S.A </a>";

                            mmsg.Subject = asunto;
                            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

                            mmsg.Body = mensaje;
                            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                            mmsg.IsBodyHtml = true;
                            mmsg.From = new System.Net.Mail.MailAddress("sistemaASEcorreo@gmail.com"); //En "correo" se tiene que escribir el correo que va a usar el sistema para enviar correos

                            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

                            cliente.Credentials = new System.Net.NetworkCredential("sistemaASEcorreo@gmail.com", "sisASE-123"); //En "correo" se escribe de nuevo el correo que va a usar el sistema y en contraseña va la contraseña del correo
                                                                                                                                //OJO: cuidado ponen su correo y contraseña aqui y mandan una version del proyecto por accidente con eso
                            cliente.Port = 587;
                            cliente.EnableSsl = true;
                            cliente.Host = "smtp.gmail.com"; //esta dirección de hosteo va a cambiar dependiendo del proveedor de correo electronico que se use en el correo del sistema, en esta caso, esa es la dirección de hosteo de gmail

                            try
                            {
                                cliente.Send(mmsg);
                            }
                            catch (Exception ex)
                            {
                                TempData["errorMensaje"] = "Se ha producido un error al intentar enviar el correo, revise que los datos insertados correspondan a lo que se pide en los campos.";
                            }
                            TempData["exitoMensaje"] = "La orden de compra ha sido enviada por correo exitosamente.";
                            return RedirectToAction("Crear");
                        }
                        else
                        {
                            return View("Crear");
                        }
                    }
                    else
                    {
                        return View("Crear");
                    }
                }
                else
                {
                    clsCompra ObjCompra = new clsCompra();
                    ViewBag.Lista = ObjCompra.ConsultaCorreoProveedor().ToList();
                    TempData["errorMensaje"] = "La cantidad de unidades debe ser superior a cero.";
                    return View();
                }
            }
            catch
            {
                clsCompra ObjCompra = new clsCompra();
                ViewBag.Lista = ObjCompra.ConsultaCorreoProveedor().ToList();
                TempData["errorMensaje"] = "Inserte correctamente el formato de los datos.";
                return View();
            }
        }

        // GET: Compra/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //// POST: Compra/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Cotizacion/Delete/5
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
                    clsCompra ObjCompra = new clsCompra();
                    ObjCompra.DeshabilitarCompra(id);
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
