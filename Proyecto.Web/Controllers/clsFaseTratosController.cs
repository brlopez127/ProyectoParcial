using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Proyecto.Web.Controllers
{
    public class clsFaseTratosController
    {
        public DataSet getConsultarFaseTratosController()
        {
            try
            {

                Logica.BL.clsFaseTrato obclsFaseTrato = new Logica.BL.clsFaseTrato();
                return obclsFaseTrato.getConsultarFaseTrato();

            }
            catch (Exception ex) { throw ex; }
        }

        public DataSet getConsultarTipoTratoController()
        {
            try
            {

                Logica.BL.clsTipoTrato obclsTipoTrato = new Logica.BL.clsTipoTrato();
                return obclsTipoTrato.getConsultarTipoTrato();

            }
            catch (Exception ex) { throw ex; }
        }

        public DataSet getConsultarFuentePosibleClienteTratoController()
        {
            try
            {

                Logica.BL.clsFuentePosibleClienteTrato obclsFuentePosibleClienteTrato = new Logica.BL.clsFuentePosibleClienteTrato();
                return obclsFuentePosibleClienteTrato.getConsultarFuentePosibleClienteTrato();

            }
            catch (Exception ex) { throw ex; }
        }

    }
}