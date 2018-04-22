using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.Logica.BL
{
    public class clsInfoCampaña
    {


        SqlConnection _SqlConnection = null;
        SqlCommand _SqlCommand = null;
        SqlDataAdapter _SqlDataAtapter = null;
        string stConexion = string.Empty;

        SqlParameter _SqlParameter = null;


        public clsInfoCampaña()
        {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.getConexion();

        }
        public DataSet getConsultarInfoCampaña()
        {
            try
            {
                DataSet dsConsulta = new DataSet();
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultaInfoCampaña", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;



                _SqlCommand.ExecuteNonQuery();

                _SqlDataAtapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAtapter.Fill(dsConsulta);

                return dsConsulta;

            }
            catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }
        }

        public string setAdministrarInfoCampaña(Models.clsInfoCampaña obclsInfoCampaña, int inOpcion)
        {
            try
            {

                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spAdministrarInfoCampaña", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.Parameters.Add(new SqlParameter("@camCodigo", obclsInfoCampaña.inCodigo));
                _SqlCommand.Parameters.Add(new SqlParameter("@camTipoCodigo", obclsInfoCampaña.obclsTipoCampaña.stDescripcion));
                _SqlCommand.Parameters.Add(new SqlParameter("@camNombreCampaña", obclsInfoCampaña.stNombreCampaña));
                _SqlCommand.Parameters.Add(new SqlParameter("@camEstadoCodigo", obclsInfoCampaña.obclsEstadoCampaña.stDescripcion));
                _SqlCommand.Parameters.Add(new SqlParameter("@camFechaInicio", obclsInfoCampaña.stFechaInicio));
                _SqlCommand.Parameters.Add(new SqlParameter("@camFechaFinalizacion", obclsInfoCampaña.stFechaFinalizacion));
                _SqlCommand.Parameters.Add(new SqlParameter("@camIngresos", obclsInfoCampaña.stIngresos));
                _SqlCommand.Parameters.Add(new SqlParameter("@camCostePresupuesto", obclsInfoCampaña.stCostePresupuesto));
                _SqlCommand.Parameters.Add(new SqlParameter("@camCosteReal", obclsInfoCampaña.stCosteReal));
                _SqlCommand.Parameters.Add(new SqlParameter("@camRespuesta", obclsInfoCampaña.stRespuesta));
                _SqlCommand.Parameters.Add(new SqlParameter("@camNumerosEnviados", obclsInfoCampaña.stNumerosEnviados));
                _SqlCommand.Parameters.Add(new SqlParameter("@camDescripcion", obclsInfoCampaña.stDescripcion));
                _SqlCommand.Parameters.Add(new SqlParameter("@ncamOpcion", inOpcion));



                _SqlParameter = new SqlParameter();
                _SqlParameter.ParameterName = "@camMensaje";
                _SqlParameter.Direction = ParameterDirection.Output;
                _SqlParameter.SqlDbType = SqlDbType.VarChar;
                _SqlParameter.Size = 50;
                _SqlCommand.Parameters.Add(_SqlParameter);
                _SqlCommand.ExecuteNonQuery();


                return _SqlParameter.Value.ToString();

            }
            catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }
        }

    }
}
