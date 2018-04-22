using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Logica.Models
{
    public class clsNuevoEvento
    {


        public int inCodigo { get; set; }
        public string stNombre { get; set; }
        public string stUbicacion { get; set; }
        public string stParticipantes { get; set; }
        public string stFecha { get; set; }
        public clsRelacionadoEvento obclsRelacionadoEvento { get; set; }
        public string stDescripcion { get; set; }
     
    }
}
