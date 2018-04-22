using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.Logica.BL
{
    public class clsInfoTrato
    {

        SqlConnection _SqlConnection = null;
        SqlCommand _SqlCommand = null;
        SqlDataAdapter _SqlDataAtapter = null;
        string stConexion = string.Empty;

        SqlParameter _SqlParameter = null;


        public clsInfoTrato()
        {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.getConexion();

        }
        public DataSet getConsultarInfoTrato()
        {
            try
            {
                DataSet dsConsulta = new DataSet();
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultaInfoTrato", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;



                _SqlCommand.ExecuteNonQuery();

                _SqlDataAtapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAtapter.Fill(dsConsulta);

                return dsConsulta;

            }
            catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }
        }

        public string setAdministrarInfoTrato(Models.clsInfoTrato obclsInfoTrato, int inOpcion)
        {
            try
            {

                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spAdministrarInfoTrato", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.Parameters.Add(new SqlParameter("@traCodigo", obclsInfoTrato.inCodigo));
                _SqlCommand.Parameters.Add(new SqlParameter("@@traImporte", obclsInfoTrato.stImporte));
                _SqlCommand.Parameters.Add(new SqlParameter("@traNombreTrato", obclsInfoTrato.stNombreTrato));
                _SqlCommand.Parameters.Add(new SqlParameter("@traFechaCierre", obclsInfoTrato.stFechaCierre));
                _SqlCommand.Parameters.Add(new SqlParameter("@traNumeroCuenta", obclsInfoTrato.stNumeroCuenta));
                _SqlCommand.Parameters.Add(new SqlParameter("@traFaseCodigo", obclsInfoTrato.obclsFaseTratos.stDescripcion));
                _SqlCommand.Parameters.Add(new SqlParameter("@traTipoCodigo", obclsInfoTrato.obclsTipoTrato.stDescripcion));
                _SqlCommand.Parameters.Add(new SqlParameter("@traProbabilidad", obclsInfoTrato.stProbabilidad));
                _SqlCommand.Parameters.Add(new SqlParameter("@traSiguientePaso", obclsInfoTrato.stSiguientePaso));
                _SqlCommand.Parameters.Add(new SqlParameter("@traIngresos", obclsInfoTrato.stIngresos));
                _SqlCommand.Parameters.Add(new SqlParameter("@traFuenPosibleClienteCodigo", obclsInfoTrato.obclsFuentePosibleClienteTrato.stDescripcion));
                _SqlCommand.Parameters.Add(new SqlParameter("@traFuenteCampaña", obclsInfoTrato.stFuenteCompañia));
                _SqlCommand.Parameters.Add(new SqlParameter("@traNombreContacto", obclsInfoTrato.stNombreContacto));
                _SqlCommand.Parameters.Add(new SqlParameter("@traDescripcion", obclsInfoTrato.stDescripcion));
                _SqlCommand.Parameters.Add(new SqlParameter("@ntraOpcion", inOpcion));




                _SqlParameter = new SqlParameter();
                _SqlParameter.ParameterName = "@traMensaje";
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
