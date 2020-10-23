using API_Proyecto.Models;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace API_Proyecto.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }
        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user:{identity.Name}-IsAuthenticated:{identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticated(LoginRequest login)
        {
            if (login == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            clsUsuario Objusuario = new clsUsuario();
            var usuario = Objusuario.ExisteUsuario(login.UserName, login.Password).Where(x => x.estado == true);

            if (usuario.Count() > 0)
            {
                var token = TokenGenerator.GenerateTokenJwt(login.UserName);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
