using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using API_Proyecto.BancoCentral;
using BLL;
using API_Proyecto.Models;
using DAL;

namespace API_Proyecto.Controllers
{
    [Authorize]
    [RoutePrefix("api/consultas")]
    public class ConsultaController : ApiController
    {
        string token = ConfigurationManager.AppSettings["BancoCentralToken"];
        wsindicadoreseconomicosSoapClient bancocentral = new wsindicadoreseconomicosSoapClient("wsindicadoreseconomicosSoap12");
        clsPersona objPersona = new clsPersona();

        [HttpPost]
        [Route("ObtenerTipoCambio")]
        public IHttpActionResult ObtenerTipoCambio(Object datos)
        {
            dynamic jsonObjet = datos;
            var indicador = jsonObjet.Bombom.Value;
            var fechaInicio = jsonObjet.Burbuja.Value;
            var fechaFin = jsonObjet.Bellota.Value;

            DataSet tipocambio = bancocentral.ObtenerIndicadoresEconomicos(indicador, fechaInicio, fechaFin, "Emilio Campos A", "N", "emiliocamp99@hotmail.com", token);
            var codigoConsultado = tipocambio.Tables[0].Rows[0].ItemArray[0].ToString();
            var fechaConsultad = tipocambio.Tables[0].Rows[0].ItemArray[1].ToString();
            var valor = tipocambio.Tables[0].Rows[0].ItemArray[2].ToString();
            //compra 317
            //venta  318
            return Ok(valor);
        }

        [HttpPost]
        [Route("ObtenerIdentificacion")]
        public IHttpActionResult ObtenerIdentificacion(Persona persona)
        {
            //dynamic jsonObjet = datos;

            //var Cedula = jsonObjet.Identificacion.Value;

            var Cedula = persona.Identificacion;
            if (string.IsNullOrEmpty(Cedula))
            {
                return NotFound();
            }
            try
            {
                var Resultado = objPersona.ConsultaPersona(Cedula);
                return Ok(Resultado);
            }
            catch (Exception)
            {

                return BadRequest("Salado no existe");
            }

        }
    }
}