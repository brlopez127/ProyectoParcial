using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Proyecto.Logica.BL
{
    public class clsCrearLlamada
    {

        SqlConnection _SqlConnection = null;
        SqlCommand _SqlCommand = null;
        SqlDataAdapter _SqlDataAtapter = null;
        string stConexion = string.Empty;

        SqlParameter _SqlParameter = null;


        public clsCrearLlamada()
        {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.getConexion();

        }
        public DataSet getConsultarCrearLlamada()
        {
            try
            {
                DataSet dsConsulta = new DataSet();
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spCrearLlamada", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;



                _SqlCommand.ExecuteNonQuery();

                _SqlDataAtapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAtapter.Fill(dsConsulta);

                return dsConsulta;

            }
            catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }
        }

        public string setAdministrarCrearLlamada(Models.clsCrearLlamada obclsCrearLlamada, int inOpcion)
        {
            try
            {

                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spAdministrarCrearLlamada", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.Parameters.Add(new SqlParameter("@llamCodigo", obclsCrearLlamada.inCodigo));
                _SqlCommand.Parameters.Add(new SqlParameter("@llamNombreContacto", obclsCrearLlamada.stNombreContacto));
                _SqlCommand.Parameters.Add(new SqlParameter("@llamAsunto", obclsCrearLlamada.stAsunto));
                _SqlCommand.Parameters.Add(new SqlParameter("@propllamCodigo", obclsCrearLlamada.obclsPropositoLlamada.stDescripcion));
                _SqlCommand.Parameters.Add(new SqlParameter("@relllamCodigo", obclsCrearLlamada.obclsRelacionadoLlamada.stDescripcion));
                _SqlCommand.Parameters.Add(new SqlParameter("@llamTipoLlamada", obclsCrearLlamada.stTipoLlamada));
                _SqlCommand.Parameters.Add(new SqlParameter("@llamDetalle", obclsCrearLlamada.stDetalle));
                _SqlCommand.Parameters.Add(new SqlParameter("@llamDescripcion", obclsCrearLlamada.stDescripcion));
                _SqlCommand.Parameters.Add(new SqlParameter("@llamResultado", obclsCrearLlamada.stResultado));

                _SqlCommand.Parameters.Add(new SqlParameter("@nllamOpcion", inOpcion));




                _SqlParameter = new SqlParameter();
                _SqlParameter.ParameterName = "@llamMensaje";
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
