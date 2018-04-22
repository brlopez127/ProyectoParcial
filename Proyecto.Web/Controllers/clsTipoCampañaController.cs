using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Proyecto.Web.Controllers
{
    public class clsTipoCampañaController
    {
        public DataSet getConsultarTipoCampañaController()
        {
            try
            {

                Logica.BL.clsTipoCampaña obclsTipoCampaña = new Logica.BL.clsTipoCampaña();
                return obclsTipoCampaña.getConsultarTipoCampaña();

            }
            catch (Exception ex) { throw ex; }
        }

        public DataSet getConsultarEstadoCampañaController()
        {
            try
            {

                Logica.BL.clsEstadoCampaña obclsEstadoCampaña = new Logica.BL.clsEstadoCampaña();
                return obclsEstadoCampaña.getConsultarEstadoCampaña();

            }
            catch (Exception ex) { throw ex; }
        }

    }
}