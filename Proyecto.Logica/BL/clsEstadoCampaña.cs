using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.Logica.BL
{
    public class clsEstadoCampaña
    {

        SqlConnection _SqlConnection = null;
        SqlCommand _SqlCommand = null;
        SqlDataAdapter _SqlDataAtapter = null;
        string stConexion = string.Empty;

        SqlParameter _SqlParameter = null;


        public clsEstadoCampaña()
        {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.getConexion();

        }
        public DataSet getConsultarEstadoCampaña()
        {
            try
            {
                DataSet dsConsulta = new DataSet();
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultaCapmañaEstado", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;



                _SqlCommand.ExecuteNonQuery();

                _SqlDataAtapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAtapter.Fill(dsConsulta);

                return dsConsulta;

            }
            catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }
        }

    }
}
