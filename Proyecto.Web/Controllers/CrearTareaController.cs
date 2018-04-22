using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;


namespace Proyecto.Web.Controllers
{
    public class CrearTareaController
    {

        public DataSet getConsultarCrearTareaController()
        {
            try
            {

                Logica.BL.clsCrearTarea obclsCrearTarea = new Logica.BL.clsCrearTarea();
                return obclsCrearTarea.getConsultarCrearTarea();

            }
            catch (Exception ex) { throw ex; }
        }

        public string setAdministrarCrearTareaController(Logica.Models.clsCrearTarea obclsCrearTareaModels, int inOpcion)
        {
            try
            {
                Logica.BL.clsCrearTarea obclsCrearTarea = new Logica.BL.clsCrearTarea();
                return obclsCrearTarea.setAdministrarCrearTarea(obclsCrearTareaModels, inOpcion);
            }
            catch (Exception ex) { throw ex; }
        }

    }
}