using BLL;
using Consola.Helpers;
using Consola.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consola.Controllers
{
    [SessionManage]
    public class CitasController : Controller
    {
        clsCita Informacion = new clsCita();
        clsUsuario objUsuario = new clsUsuario();
        clsBitacoraCitas objBitacoraCitas = new clsBitacoraCitas();

        // GET: Citas
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Citas()
        {
            return View();
        }

        public JsonResult ConsultarCita()
        {
            List<ConsultarCitaResult> citas = Informacion.ConsultarCita();
            return Json(citas, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ConsultarCitasUsuario(int idUsuario)
        {
            List<ConsultarCitasUsuarioResult> citas = Informacion.ConsultarCitasUsuario(idUsuario);
            return Json(citas, JsonRequestBehavior.AllowGet);
        }

       /* public JsonResult DeshabilitarCita(int idCita)
        {
            var citas = Informacion.DeshabilitarCita(idCita);
            return Json(citas, JsonRequestBehavior.AllowGet);
        }*/

        public JsonResult AgregarCita(int IdUsuario, string asunto, string descripcion, DateTime inicio, DateTime fin, string colorFondo, bool diaCompleto, bool estadoCita)
        {
            var status = false;
            try
            {
                bool Resultado = Informacion.AgregarCita(IdUsuario, asunto, descripcion, inicio, fin, colorFondo, diaCompleto, estadoCita);
                string Usuario = (string)Session["Usuario"];

                if (Resultado)
                {
                    objBitacoraCitas.AgregarBitacoraCita(IdUsuario, Usuario, DateTime.Now, IdUsuario, asunto, descripcion, inicio, fin, colorFondo, diaCompleto, true);
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch
            {
                status = false;
            }
            return Json(new { Estado = status }, JsonRequestBehavior.AllowGet);
        }


        //[HttpPost]
        public JsonResult CambiarCita(int idCita, int idUsuario, string asunto, string descripcion, DateTime inicio, DateTime Fin, string colorFondo, bool diaCompleto, bool estadoCita)
        {
            var status = false;
            try
            {
                int IdUsuario = (int)Session["idUsuario"];

                bool Resultado = Informacion.ActualizarCita(idCita, IdUsuario, asunto, descripcion, inicio, Fin, colorFondo, diaCompleto, estadoCita);

                if (Resultado)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch
            {
                status = false;
            }
            return Json(new { Estado = status }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AgregarBitacoraCita(int idCambioUsuario, string nombreUsuario, DateTime fechaCambio, int idUsuario, string asunto, string descripcion, DateTime inicio, DateTime fin, string colorFondo, bool diaCompleto, bool estadoCita)
        {
            var status = false;
            try
            {
                bool Resultado = objBitacoraCitas.AgregarBitacoraCita(idCambioUsuario, nombreUsuario, DateTime.Now, idUsuario, asunto, descripcion, inicio, fin, colorFondo, diaCompleto, true);

                if (Resultado)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch
            {
                status = false;
            }
            return Json(new { Estado = status }, JsonRequestBehavior.AllowGet);
        }
    }
}