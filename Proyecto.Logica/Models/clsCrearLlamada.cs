using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Logica.Models
{
    public class clsCrearLlamada
    {


        public int inCodigo { get; set; }
        public string stNombreContacto { get; set; }
        public string stAsunto { get; set; }
        public clsPropositoLlamada obclsPropositoLlamada { get; set; }
        public clsRelacionadoLlamada obclsRelacionadoLlamada { get; set; }
        public string stTipoLlamada { get; set; }
        public string stDetalle { get; set; }
        public string stDescripcion { get; set; }
        public string stResultado { get; set; }

    }
}
