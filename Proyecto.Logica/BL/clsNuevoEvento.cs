using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.Logica.BL
{
    public class clsNuevoEvento
    {

        SqlConnection _SqlConnection = null;
        SqlCommand _SqlCommand = null;
        SqlDataAdapter _SqlDataAtapter = null;
        string stConexion = string.Empty;

        SqlParameter _SqlParameter = null;


        public clsNuevoEvento()
        {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.getConexion();

        }
        public DataSet getConsultarNuevoEvento()
        {
            try
            {
                DataSet dsConsulta = new DataSet();
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultaNuevoEvento", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;



                _SqlCommand.ExecuteNonQuery();

                _SqlDataAtapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAtapter.Fill(dsConsulta);

                return dsConsulta;

            }
            catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }
        }

        public string setAdministrarNuevoEvento(Models.clsNuevoEvento obclsNuevoEvento, int inOpcion)
        {
            try
            {

                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spAdministrarNuevoEvento", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.Parameters.Add(new SqlParameter("@evenCodigo", obclsNuevoEvento.inCodigo));
                _SqlCommand.Parameters.Add(new SqlParameter("@evenNombre", obclsNuevoEvento.stNombre));
                _SqlCommand.Parameters.Add(new SqlParameter("@evenUbicacion", obclsNuevoEvento.stUbicacion));
                _SqlCommand.Parameters.Add(new SqlParameter("@evenParticipantes", obclsNuevoEvento.stParticipantes));
                _SqlCommand.Parameters.Add(new SqlParameter("@evenFecha", obclsNuevoEvento.stFecha));
                _SqlCommand.Parameters.Add(new SqlParameter("@relEventoCodigo", obclsNuevoEvento.obclsRelacionadoEvento.stDescripcion));
                _SqlCommand.Parameters.Add(new SqlParameter("@evenDescripcion", obclsNuevoEvento.stDescripcion));
               
                _SqlCommand.Parameters.Add(new SqlParameter("@ntareOpcion", inOpcion));




                _SqlParameter = new SqlParameter();
                _SqlParameter.ParameterName = "@evenMensaje";
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
