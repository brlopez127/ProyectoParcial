using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Proyecto.Web.Controllers
{
    public class clsRelacionadoEventoController
    {
        public DataSet getConsultarRelacionadoEventoController()
        {
            try
            {

                Logica.BL.clsRelacionadoEvento obclsRelacionadoEvento = new Logica.BL.clsRelacionadoEvento();
                return obclsRelacionadoEvento.getConsultarRelacionadoEvento();

            }
            catch (Exception ex) { throw ex; }
        }

    }
}