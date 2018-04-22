using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Logica.Models
{
    public class clsPosiblesClientes
    {
        public long lnCodigo { get; set; }
        public string stEmpresa { get; set; }
        public string stNombre { get; set; }
        public string stApellidos { get; set; }
        public string stTitulo { get; set; }
        public string stCorreElectronico { get; set; }
        public string stTelefono { get; set; }
        public string stFax { get; set; }
        public string stMovil { get; set; }
        public string stSitioWeb { get; set; }
        public clsFuentePosibleCliente obclsFuentePosibleCliente { get; set; }
        public clsEstadoPosibleCliente obclsEstadoPosibleCliente { get; set; }
        public clsSectorPosibleCliente obclsSectorPosibleCliente { get; set; }
        public int inCantidad { get; set; }
        public float flIngresos { get; set; }
        public clsCalificacionPosibleCliente obclsCalificacionPosibleCliente { get; set; }
        public string stIdSkype { get; set; }
        public string stTwitter { get; set; }
        public string stCorreoSecundrio { get; set; }


    }
}
