using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Proyecto.Web.Controllers
{
    public class clsEstadoTareaController
    {

        public DataSet getConsultarEstadoTareaController()
        {
            try
            {

                Logica.BL.clsEstadoTarea obclsclsEstadoTarea = new Logica.BL.clsEstadoTarea();
                return obclsclsEstadoTarea.getConsultarEstadoTarea();

            }
            catch (Exception ex) { throw ex; }
        }

        public DataSet getConsultarPrioridadTareaController()
        {
            try
            {

                Logica.BL.clsPrioridadTarea obclsPrioridadTarea = new Logica.BL.clsPrioridadTarea();
                return obclsPrioridadTarea.getConsultarPrioridadTarea();

            }
            catch (Exception ex) { throw ex; }
        }

    }
}