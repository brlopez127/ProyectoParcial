using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.Logica.BL
{
    public class clsCrearTarea
    {

        SqlConnection _SqlConnection = null;
        SqlCommand _SqlCommand = null;
        SqlDataAdapter _SqlDataAtapter = null;
        string stConexion = string.Empty;

        SqlParameter _SqlParameter = null;


        public clsCrearTarea()
        {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.getConexion();

        }
        public DataSet getConsultarCrearTarea()
        {
            try
            {
                DataSet dsConsulta = new DataSet();
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultaTareas", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;



                _SqlCommand.ExecuteNonQuery();

                _SqlDataAtapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAtapter.Fill(dsConsulta);

                return dsConsulta;

            }
            catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }
        }

        public string setAdministrarCrearTarea(Models.clsCrearTarea obclsCrearTarea, int inOpcion)
        {
            try
            {

                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spAdministrarTareas", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.Parameters.Add(new SqlParameter("@ntareCodigo", obclsCrearTarea.inCodigo));
                _SqlCommand.Parameters.Add(new SqlParameter("@tareAsunto", obclsCrearTarea.stAsunto));
                _SqlCommand.Parameters.Add(new SqlParameter("@tarefechaVencimiento", obclsCrearTarea.stFechaVencimiento));
                _SqlCommand.Parameters.Add(new SqlParameter("@tareContacto", obclsCrearTarea.stContacto));
                _SqlCommand.Parameters.Add(new SqlParameter("@tareCuenta", obclsCrearTarea.stCuenta));
                _SqlCommand.Parameters.Add(new SqlParameter("@estatareaCodigo", obclsCrearTarea.obclsEstadoTareas.stDescripcion));
                _SqlCommand.Parameters.Add(new SqlParameter("@priotareaCodigo", obclsCrearTarea.obclsPrioridadTarea.stDescripcion));
                _SqlCommand.Parameters.Add(new SqlParameter("@tareDescripcion", obclsCrearTarea.stDescripcion));
                _SqlCommand.Parameters.Add(new SqlParameter("@ntareOpcion", inOpcion));




                _SqlParameter = new SqlParameter();
                _SqlParameter.ParameterName = "@tareMensaje";
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
