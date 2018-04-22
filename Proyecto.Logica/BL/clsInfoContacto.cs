using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.Logica.BL
{
    public class clsInfoContacto
    {

        SqlConnection _SqlConnection = null;
        SqlCommand _SqlCommand = null;
        SqlDataAdapter _SqlDataAtapter = null;
        string stConexion = string.Empty;

        SqlParameter _SqlParameter = null;


        public clsInfoContacto()
        {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.getConexion();

        }
        public DataSet getConsultarInfoContacto()
        {
            try
            {
                DataSet dsConsulta = new DataSet();
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultaInfoContacto", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;



                _SqlCommand.ExecuteNonQuery();

                _SqlDataAtapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAtapter.Fill(dsConsulta);

                return dsConsulta;

            }
            catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }
        }

        public string setAdministrarInfoContacto(Models.clsInfoContacto obclsInfoContacto, int inOpcion)
        {
            try
            {

                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spAdministrarInfoContacto", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.Parameters.Add(new SqlParameter("@contCodigo", obclsInfoContacto.inCodigo));
                _SqlCommand.Parameters.Add(new SqlParameter("@fuenInfoContactoCodigo", obclsInfoContacto.obclsFuentePosibleClienteContacto.stDescripcion));
                _SqlCommand.Parameters.Add(new SqlParameter("@contNombre", obclsInfoContacto.stNombre));
                _SqlCommand.Parameters.Add(new SqlParameter("@contApellidos", obclsInfoContacto.stApellidos));
                _SqlCommand.Parameters.Add(new SqlParameter("@contNumeroCuenta", obclsInfoContacto.stNumeroCuenta));
                _SqlCommand.Parameters.Add(new SqlParameter("@contTitulo", obclsInfoContacto.stTitulo));
                _SqlCommand.Parameters.Add(new SqlParameter("@contCorreo", obclsInfoContacto.stCorreo));
                _SqlCommand.Parameters.Add(new SqlParameter("@contDepartamento", obclsInfoContacto.stDepartamento));
                _SqlCommand.Parameters.Add(new SqlParameter("@contTelefonoParticular", obclsInfoContacto.stTelefonoParticular));
                _SqlCommand.Parameters.Add(new SqlParameter("@contOtroTelefono", obclsInfoContacto.stOtroTelefono));
                _SqlCommand.Parameters.Add(new SqlParameter("@contFax", obclsInfoContacto.stFax));
                _SqlCommand.Parameters.Add(new SqlParameter("@contMovil", obclsInfoContacto.stMovil));
                _SqlCommand.Parameters.Add(new SqlParameter("@contFechaNacimiento", obclsInfoContacto.stFechaNacimiento));
                _SqlCommand.Parameters.Add(new SqlParameter("@contTelefono", obclsInfoContacto.stTelefono));
                _SqlCommand.Parameters.Add(new SqlParameter("@contAsistente", obclsInfoContacto.stAsistente));
                _SqlCommand.Parameters.Add(new SqlParameter("@contTelefonoAsistente", obclsInfoContacto.stTelefonoAsistente));
                _SqlCommand.Parameters.Add(new SqlParameter("@contResponder", obclsInfoContacto.stResponder));
                _SqlCommand.Parameters.Add(new SqlParameter("@contIdSkype", obclsInfoContacto.stIdSkype));
                _SqlCommand.Parameters.Add(new SqlParameter("@contCorreoSecundario", obclsInfoContacto.stCorreoSecundario));
                _SqlCommand.Parameters.Add(new SqlParameter("@nOpcion", inOpcion));



                _SqlParameter = new SqlParameter();
                _SqlParameter.ParameterName = "@contMensaje";
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
