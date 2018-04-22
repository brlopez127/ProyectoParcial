using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Proyecto.Web.Controllers
{
    public class CrearLlamadaController
    {

        public DataSet getConsultarCrearLlamada()
        {
            try
            {

                Logica.BL.clsCrearLlamada obclsCrearLlamada = new Logica.BL.clsCrearLlamada();
                return obclsCrearLlamada.getConsultarCrearLlamada();

            }
            catch (Exception ex) { throw ex; }
        }

        public string setAdministrarCrearLlamadaController(Logica.Models.clsCrearLlamada obclsCrearLlamadaModels, int inOpcion)
        {
            try
            {
                Logica.BL.clsCrearLlamada obclsCrearLlamada = new Logica.BL.clsCrearLlamada();
                return obclsCrearLlamada.setAdministrarCrearLlamada(obclsCrearLlamadaModels, inOpcion);
            }
            catch (Exception ex) { throw ex; }
        }


    }
}