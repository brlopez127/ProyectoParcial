using System;
using System.Data;


namespace Proyecto.Web.Controllers
{
    public class PosiblesClientesController
    {
        public DataSet getConsultarPosiblesClientesController()
        {
            try
            {

                Logica.BL.clsPosiblesClientes obclsPosiblesClientes = new Logica.BL.clsPosiblesClientes();
                return obclsPosiblesClientes.getConsultarPosiblesClientes();

            }catch (Exception ex) { throw ex; }
        }

        public string setAdministrarPosiblesClientesController(Logica.Models.clsPosiblesClientes obclsPosiblesClientesModels, int inOpcion)
        {
            try
            {
                Logica.BL.clsPosiblesClientes obclsPosiblesClientes = new Logica.BL.clsPosiblesClientes();
                return obclsPosiblesClientes.setAdministrarPosiblesClientes(obclsPosiblesClientesModels, inOpcion);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}