using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Logica.Models
{
    public class clsInfoTrato
    {

        public int inCodigo { get; set; }
        public string stImporte { get; set; }
        public string stNombreTrato { get; set; }
        public string stFechaCierre { get; set; }
        public string stNumeroCuenta { get; set; }
        public clsFaseTratos obclsFaseTratos { get; set; }
        public clsTipoTrato obclsTipoTrato { get; set; }
        public string stProbabilidad { get; set; }
        public string stSiguientePaso { get; set; }
        public string stIngresos { get; set; }
        public clsFuentePosibleClienteTrato obclsFuentePosibleClienteTrato { get; set; }
        public string stFuenteCompañia { get; set; }
        public string stNombreContacto { get; set; }
        public string stDescripcion { get; set; }

    }
}
