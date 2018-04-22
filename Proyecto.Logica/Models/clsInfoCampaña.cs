using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Logica.Models
{
    public class clsInfoCampaña
    {

        public int inCodigo { get; set; }
        public clsTipoCampaña obclsTipoCampaña { get; set; }
        public string stNombreCampaña { get; set; }
        public clsEstadoCampaña obclsEstadoCampaña { get; set; }
        public string stFechaInicio { get; set; }
        public string stFechaFinalizacion { get; set; }
        public string stIngresos { get; set; }
        public string stCostePresupuesto { get; set; }
        public string stCosteReal { get; set; }
        public string stRespuesta { get; set; }
        public string stNumerosEnviados { get; set; }
        public string stDescripcion { get; set; }
    


    }
}
