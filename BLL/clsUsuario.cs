
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsUsuario
    {
        public List<ExisteUsuarioResult> ExisteUsuario(string Usuario, string Clave)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ExisteUsuarioResult> data = dc.ExisteUsuario(Usuario, Clave).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ConsultarUsuarioResult> ConsultarUsuario()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarUsuarioResult> data = dc.ConsultarUsuario().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public List<ConsultarUsuariosResult> ConsultarUsuarios()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarUsuariosResult> data = dc.ConsultarUsuarios().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ConsultarClaveUsuarioResult> ConsultarClaveUsuario(int idUsuario)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarClaveUsuarioResult> data = dc.ConsultarClaveUsuario(idUsuario).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ConsultaUsuarioResult> ConsultaUsuario(int IdUsuario)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultaUsuarioResult> data = dc.ConsultaUsuario(IdUsuario).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<ConsultarRolesResult> ConsultarRoles()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarRolesResult> data = dc.ConsultarRoles().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ConsultarUltimaClaveUsuarioResult> ConsultarUltimaClaveUsuario()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarUltimaClaveUsuarioResult> data = dc.ConsultarUltimaClaveUsuario().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int ConsultarRolUsuario(string usuario)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int Rol = dc.ConsultarRolUsuario(usuario);
                return Rol;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int ConsultarIdUsuario(string usuario)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int Id = dc.ConsultarIdUsuario(usuario);
                return Id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int ConsultarUltimoIdUsuario()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int data = dc.ConsultarUltimoIdUsuario();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int ConsultarEstadoUsuario(string usuario)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int Rol = dc.ConsultarEstadoUsuario(usuario);
                return Rol;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int ConsultarExisteNombreUsuario(string usuario)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int Rol = dc.ConsultarExisteNombreUsuario(usuario);
                return Rol;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool AgregarUsuario(int idTipoRol, string usuario, string clave, bool estado)
        {
            try
            {
                int respuesta = 1;
                estado = true;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarUsuario(idTipoRol, usuario, clave, estado));

                if (respuesta == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool ActualizarUsuario(string usuario, string clave)
        {
            try
            {
                int respuesta = 0;


                DatosDataContext dc = new DatosDataContext();
                dc.ActualizarUsuario(usuario, clave);

                if (respuesta == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ActualizarEditarUsuario(int idUsuario, int idTipoRol, string usuario, string clave, bool estado)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = dc.ActualizarEditarUsuario(idUsuario, idTipoRol, usuario, clave, estado);
                if (respuesta == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ActualizarContrasenaUsuario(int idUsuario,  string clave)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = dc.ActualizarContrasenaUsuario(idUsuario, clave);
                if (respuesta == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeshabilitarUsuario(int IdUsuario)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.DeshabilitarUsuario(IdUsuario);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

