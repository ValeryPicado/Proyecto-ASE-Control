using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsPersona
    {
        public List<ConsultaPersonaResult> ConsultaPersona(string Cedula)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultaPersonaResult> data = dc.ConsultaPersona(Cedula).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public bool AgregarPersona(string Cedula, int Sexo, string Nombre, string ApellidoP, string ApellidoM)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.AgregarPersona(Cedula, Sexo, Nombre, ApellidoP, ApellidoM);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
