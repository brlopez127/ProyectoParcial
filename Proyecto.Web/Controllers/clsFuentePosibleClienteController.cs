using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Proyecto.Web.Controllers
{
    public class clsFuentePosibleClienteController
    {
        public DataSet getConsultarFuentePosiblesClientesController()
        {
            try
            {

                Logica.BL.clsFuentePosibleCliente obclsFuentePosibleCliente = new Logica.BL.clsFuentePosibleCliente();
                return obclsFuentePosibleCliente.getConsultarFuentePosibleCliente();

            }
            catch (Exception ex) { throw ex; }
        }

        public DataSet getConsultarEstadoPosiblesClientesController()
        {
            try
            {

                Logica.BL.clsEstadoPosibleCliente obclsEstadoPisibleCliente = new Logica.BL.clsEstadoPosibleCliente();
                return obclsEstadoPisibleCliente.getConsultarEstadoPosibleCliente();

            }
            catch (Exception ex) { throw ex; }
        }

        public DataSet getConsultarSectorPosiblesClientesController()
        {
            try
            {

                Logica.BL.clsSectorPosibleCliente obclsSectorPosibleCliente = new Logica.BL.clsSectorPosibleCliente();
                return obclsSectorPosibleCliente.getConsultarSectorPosibleCliente();

            }
            catch (Exception ex) { throw ex; }
        }

        public DataSet getConsultarCalificacionPosiblesClientesController()
        {
            try
            {

                Logica.BL.clsCalificacionPosibleCliente obclsCalificacionPosibleCliente = new Logica.BL.clsCalificacionPosibleCliente();
                return obclsCalificacionPosibleCliente.getConsultarCalificacionPosibleCliente();

            }
            catch (Exception ex) { throw ex; }
        }

    }
}