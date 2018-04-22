using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Proyecto.Web.Controllers
{
    public class NuevoEventoController
    {

        public DataSet getConsultarNuevoEventoController()
        {
            try
            {

                Logica.BL.clsNuevoEvento obclsNuevoEvento = new Logica.BL.clsNuevoEvento();
                return obclsNuevoEvento.getConsultarNuevoEvento();

            }
            catch (Exception ex) { throw ex; }
        }

        public string setAdministrarNuevoEventoController(Logica.Models.clsNuevoEvento obclsNuevoEventoModels, int inOpcion)
        {
            try
            {
                Logica.BL.clsNuevoEvento obclsNuevoEvento = new Logica.BL.clsNuevoEvento();
                return obclsNuevoEvento.setAdministrarNuevoEvento(obclsNuevoEventoModels, inOpcion);
            }
            catch (Exception ex) { throw ex; }
        }

    }
}