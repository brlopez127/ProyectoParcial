using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Proyecto.Web.Controllers
{
    public class InfoTratoController
    {


        public DataSet getConsultarInfoTratoController()
        {
            try
            {

                Logica.BL.clsInfoTrato obclsInfoTrato = new Logica.BL.clsInfoTrato();
                return obclsInfoTrato.getConsultarInfoTrato();

            }
            catch (Exception ex) { throw ex; }
        }

        public string setAdministrarInfoTratoController(Logica.Models.clsInfoTrato obclsInfoTratoModels, int inOpcion)
        {
            try
            {
                Logica.BL.clsInfoTrato obclsInfoTrato = new Logica.BL.clsInfoTrato();
                return obclsInfoTrato.setAdministrarInfoTrato(obclsInfoTratoModels, inOpcion);
            }
            catch (Exception ex) { throw ex; }
        }

    }
}