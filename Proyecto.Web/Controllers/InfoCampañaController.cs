using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Proyecto.Web.Controllers
{
    public class InfoCampañaController
    {


        public DataSet getConsultarInfoCampañaController()
        {
            try
            {

                Logica.BL.clsInfoCampaña obclsInfoCampaña = new Logica.BL.clsInfoCampaña();
                return obclsInfoCampaña.getConsultarInfoCampaña();

            }
            catch (Exception ex) { throw ex; }
        }

        public string setAdministrarInfoCampañaController(Logica.Models.clsInfoCampaña obclsInfoCampañaModels, int inOpcion)
        {
            try
            {
                Logica.BL.clsInfoCampaña obclsInfoCampaña = new Logica.BL.clsInfoCampaña();
                return obclsInfoCampaña.setAdministrarInfoCampaña(obclsInfoCampañaModels, inOpcion);
            }
            catch (Exception ex) { throw ex; }
        }

    }
}