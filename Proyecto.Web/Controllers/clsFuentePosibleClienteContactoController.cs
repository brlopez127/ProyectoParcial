using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Proyecto.Web.Controllers
{
    public class clsFuentePosibleClienteContactoController
    {

        public DataSet getConsultarFuentePosibleClienteContactoController()
        {
            try
            {

                Logica.BL.clsFuentePosibleClienteContacto obclsFuentePosibleClienteContacto = new Logica.BL.clsFuentePosibleClienteContacto();
                return obclsFuentePosibleClienteContacto.getConsultarFuentePosibleClienteContacto();

            }
            catch (Exception ex) { throw ex; }
        }

    }
}