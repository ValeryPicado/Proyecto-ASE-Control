using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Consola.Tools
{
    public static class Utilerias
    {
        /// <summary>
        /// Validar si un string es una fecha
        /// </summary>
        /// <param name="dateInString"></param>
        /// <returns></returns>
        public static bool ValidaFecha(string dateInString)
        {
            DateTime temp;
            if (DateTime.TryParse(dateInString, out temp))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Permite Validar si un string es un correo
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static Boolean ValidarCorreo(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}