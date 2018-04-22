using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Proyecto.Web.Controllers
{
    public class InfoContactoController
    {


        public DataSet getConsultarInfoContactoController()
        {
            try
            {

                Logica.BL.clsInfoContacto obclsInfoContacto = new Logica.BL.clsInfoContacto();
                return obclsInfoContacto.getConsultarInfoContacto();

            }
            catch (Exception ex) { throw ex; }
        }

        public string setAdministrarInfoContactoController(Logica.Models.clsInfoContacto obclsInfoContactoModels, int inOpcion)
        {
            try
            {
                Logica.BL.clsInfoContacto obclsInfoContacto = new Logica.BL.clsInfoContacto();
                return obclsInfoContacto.setAdministrarInfoContacto(obclsInfoContactoModels, inOpcion);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}