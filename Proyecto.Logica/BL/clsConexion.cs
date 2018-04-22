using System.Configuration;

namespace Proyecto.Logica.BL
{
    public  class clsConexion
    {
        public string getConexion()
        {
            return ConfigurationManager.ConnectionStrings["Cnx"].ToString();

        }
    }
}
