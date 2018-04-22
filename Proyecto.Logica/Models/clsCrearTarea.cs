using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Logica.Models
{
    public class clsCrearTarea
    {
        public int inCodigo { get; set; }
        public string stAsunto { get; set; }
        public string stFechaVencimiento { get; set; }
        public string stContacto { get; set; }
        public string stCuenta { get; set; }
        public clsEstadoTareas obclsEstadoTareas { get; set; }
        public clsPrioridadTarea obclsPrioridadTarea { get; set; }
        public string stDescripcion { get; set; }


    }
}
