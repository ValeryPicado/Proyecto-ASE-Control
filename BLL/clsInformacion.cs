using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsInformacion
    {
        public List<ProvinciasResult> ObtenerProvincias()
        {
            DatosDataContext db = new DatosDataContext();
            List<ProvinciasResult> datos = db.Provincias().ToList();
            return datos;
        }
        public List<CantonesResult> ObtenerCantones(char Provincia)
        {
            DatosDataContext db = new DatosDataContext();
            List<CantonesResult> datos = db.Cantones(Provincia).ToList();
            return datos;
        }
        public List<DistritosResult> ObtenerDistritos(char Provincia, string Canton)
        {
            DatosDataContext db = new DatosDataContext();
            List<DistritosResult> datos = db.Distritos(Provincia, Canton).ToList();
            return datos;
        }
    }
}
