using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Proyecto.Web.Controllers
{
    public class clsPropositoLlamadaController
    {
        public DataSet getConsultarPropositoLlamadaController()
        {
            try
            {

                Logica.BL.clsPropositoLlamada obclsPropositoLlamada = new Logica.BL.clsPropositoLlamada();
                return obclsPropositoLlamada.getConsultarPropositoLlamada();

            }
            catch (Exception ex) { throw ex; }
        }


        public DataSet getConsultarRelacionadoLlamadaController()
        {
            try
            {

                Logica.BL.clsRelacionadoLlamada obclsRelacionadoLlamada = new Logica.BL.clsRelacionadoLlamada();
                return obclsRelacionadoLlamada.getConsultarRelacionadoLlamada();

            }
            catch (Exception ex) { throw ex; }
        }



    }
}