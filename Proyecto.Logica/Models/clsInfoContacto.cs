using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Logica.Models
{
    public class clsInfoContacto
    {

        public int inCodigo { get; set; }
        public clsFuentePosibleClienteContacto obclsFuentePosibleClienteContacto { get; set; }
        public string stNombre { get; set; }
        public string stApellidos { get; set; }
        public string stNumeroCuenta { get; set; }
        public string stTitulo { get; set; }
        public string stCorreo { get; set; }
        public string stDepartamento { get; set; }
        public string stTelefono { get; set; }
        public string stTelefonoParticular { get; set; }
        public string stOtroTelefono { get; set; }
        public string stFax { get; set; }
        public string stMovil { get; set; }
        public string stFechaNacimiento { get; set; }
        public string stAsistente { get; set; }
        public string stTelefonoAsistente { get; set; }
        public string stResponder { get; set; }
        public string stIdSkype { get; set; }
        public string stCorreoSecundario { get; set; }

    }
}
