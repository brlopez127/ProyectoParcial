using System;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.Logica.BL
{
    public class clsPosiblesClientes
    {
        SqlConnection _SqlConnection = null;
        SqlCommand _SqlCommand = null;
        SqlDataAdapter _SqlDataAtapter = null;
        string stConexion = string.Empty;

        SqlParameter _SqlParameter = null;


        public clsPosiblesClientes()
        {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.getConexion();

        }
        public DataSet getConsultarPosiblesClientes()
        {
            try
            {
                DataSet dsConsulta = new DataSet();
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultarPosiblesClientes", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                


                _SqlCommand.ExecuteNonQuery();

                _SqlDataAtapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAtapter.Fill(dsConsulta);

                return dsConsulta;

            }
            catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }
        }

        public string setAdministrarPosiblesClientes(Models.clsPosiblesClientes obclsPosiblesClientes, int inOpcion)
        {
            try
            {
                
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spAdministrarPosiblesClientes", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.Parameters.Add(new SqlParameter("@nCodigo", obclsPosiblesClientes.lnCodigo));
                _SqlCommand.Parameters.Add(new SqlParameter("@cEmpresa", obclsPosiblesClientes.stEmpresa));
                _SqlCommand.Parameters.Add(new SqlParameter("@cNombre", obclsPosiblesClientes.stNombre));
                _SqlCommand.Parameters.Add(new SqlParameter("@cApellidos", obclsPosiblesClientes.stApellidos));
                _SqlCommand.Parameters.Add(new SqlParameter("@cTitulo", obclsPosiblesClientes.stTitulo));
                _SqlCommand.Parameters.Add(new SqlParameter("@cCorreoElectronico", obclsPosiblesClientes.stCorreElectronico));
                _SqlCommand.Parameters.Add(new SqlParameter("@cTelefono", obclsPosiblesClientes.stTelefono));
                _SqlCommand.Parameters.Add(new SqlParameter("@cFax", obclsPosiblesClientes.stFax));
                _SqlCommand.Parameters.Add(new SqlParameter("@cMovil", obclsPosiblesClientes.stMovil));
                _SqlCommand.Parameters.Add(new SqlParameter("@cSitioWeb", obclsPosiblesClientes.stSitioWeb));
                _SqlCommand.Parameters.Add(new SqlParameter("@fuenposibleclieCodigo", obclsPosiblesClientes.obclsFuentePosibleCliente.stDescripcion));
                _SqlCommand.Parameters.Add(new SqlParameter("@estaPosibleClieCodigo", obclsPosiblesClientes.obclsEstadoPosibleCliente.stDescripcion));
                _SqlCommand.Parameters.Add(new SqlParameter("@secPosibleClieCodigo", obclsPosiblesClientes.obclsSectorPosibleCliente.stDescripcion));
                _SqlCommand.Parameters.Add(new SqlParameter("@cCantidad", obclsPosiblesClientes.inCantidad));
                _SqlCommand.Parameters.Add(new SqlParameter("@cIngresos", obclsPosiblesClientes.flIngresos));
                _SqlCommand.Parameters.Add(new SqlParameter("@caliPosibleClieCodigo", obclsPosiblesClientes.obclsCalificacionPosibleCliente.stDescripcion));
                _SqlCommand.Parameters.Add(new SqlParameter("@cSkype", obclsPosiblesClientes.stIdSkype));
                _SqlCommand.Parameters.Add(new SqlParameter("@cTwitter", obclsPosiblesClientes.stTwitter));
                _SqlCommand.Parameters.Add(new SqlParameter("@cCorreoSecundario", obclsPosiblesClientes.stCorreoSecundrio));
                _SqlCommand.Parameters.Add(new SqlParameter("@nOpcion", inOpcion));

                

                _SqlParameter = new SqlParameter();
                _SqlParameter.ParameterName = "@cMensaje";
                _SqlParameter.Direction = ParameterDirection.Output;
                _SqlParameter.SqlDbType = SqlDbType.VarChar;
                _SqlParameter.Size = 50;
                _SqlCommand.Parameters.Add(_SqlParameter);
                _SqlCommand.ExecuteNonQuery();


                return _SqlParameter.Value.ToString()   ;

            }
            catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }
        }
    }
}
