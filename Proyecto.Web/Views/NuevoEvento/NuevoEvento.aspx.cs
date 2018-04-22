using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Proyecto.Web.Views.NuevoEvento
{
    public partial class NuevoEvento : System.Web.UI.Page
    {

        void getNuevoEvento()
        {
            try
            {


                Controllers.NuevoEventoController obNuevoEventoController = new Controllers.NuevoEventoController();
                DataSet dsConsulta = obNuevoEventoController.getConsultarNuevoEventoController();

                if (dsConsulta.Tables[0].Rows.Count > 0) gvrDatos.DataSource = dsConsulta;

                else gvrDatos.DataSource = null;


                gvrDatos.DataBind();

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mensaje", "<script>swal('Error!', '" + ex.Message + "', 'error') </script>");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            Controllers.clsRelacionadoEventoController obclsRelacionadoEventoController = new Controllers.clsRelacionadoEventoController();
            DataSet dsConsultaRelacionadoEvento = obclsRelacionadoEventoController.getConsultarRelacionadoEventoController();

            ddlRelacionado.DataSource = dsConsultaRelacionadoEvento;
            ddlRelacionado.DataTextField = "relEventoDescripcion";
            ddlRelacionado.DataValueField = "relEventoCodigo";
            ddlRelacionado.DataBind();

            getNuevoEvento();

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string stMensaje = string.Empty;
                if (string.IsNullOrEmpty(txtCodigo.Text)) stMensaje += "Ingresa Codigo,";
                if (!string.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                Logica.Models.clsNuevoEvento obclsNuevoEvento = new Logica.Models.clsNuevoEvento
                {
                    inCodigo = Convert.ToInt32(txtCodigo.Text),
                    stNombre = txtNombre.Text,
                    stUbicacion = txtUbicacion.Text,
                    stParticipantes = txtParticipantes.Text,
                    stFecha = txtFecha.Text,
                    obclsRelacionadoEvento = new Logica.Models.clsRelacionadoEvento() { stDescripcion = ddlRelacionado.Text },
                    stDescripcion = txtDescripcion.Text



                };

                Controllers.NuevoEventoController obNuevoEventoController = new Controllers.NuevoEventoController();

                if (string.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                ClientScript.RegisterStartupScript(GetType(), "mensaje", "<script> alert('" + obNuevoEventoController.setAdministrarNuevoEventoController(obclsNuevoEvento, Convert.ToInt32(lblOpcion.Text)) + "') </script>");
                lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtUbicacion.Text = txtParticipantes.Text = txtFecha.Text = ddlRelacionado.Text
                    = txtDescripcion.Text  = string.Empty;
                getNuevoEvento();

            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(GetType(), "mensaje", "<script> alert('" + ex.Message + "') </script>"); }
        }

        protected void gvrDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int inIndice = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("Editar"))
                {
                    lblOpcion.Text = "2";

                    txtCodigo.Text = ((Label)gvrDatos.Rows[inIndice].FindControl("lblCodigo")).Text;
                    txtNombre.Text = gvrDatos.Rows[inIndice].Cells[1].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[1].Text;
                    txtUbicacion.Text = gvrDatos.Rows[inIndice].Cells[2].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[2].Text;
                    txtParticipantes.Text = gvrDatos.Rows[inIndice].Cells[3].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[3].Text;
                    txtFecha.Text = gvrDatos.Rows[inIndice].Cells[4].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[4].Text;
                    ddlRelacionado.Text = gvrDatos.Rows[inIndice].Cells[5].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[5].Text;
                    txtDescripcion.Text = gvrDatos.Rows[inIndice].Cells[6].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[6].Text;
                   


                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    lblOpcion.Text = "3";

                    Logica.Models.clsNuevoEvento obclsNuevoEvento = new Logica.Models.clsNuevoEvento
                    {
                        inCodigo = Convert.ToInt32(((Label)gvrDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        stNombre = string.Empty,
                        stUbicacion = string.Empty,
                        stParticipantes = string.Empty,
                        stFecha = string.Empty,
                        obclsRelacionadoEvento = new Logica.Models.clsRelacionadoEvento() { stDescripcion = ddlRelacionado.Text },
                        stDescripcion = string.Empty
                       


                    };

                    Controllers.NuevoEventoController obNuevoEventoController = new Controllers.NuevoEventoController();


                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "<script> alert('" + obNuevoEventoController.setAdministrarNuevoEventoController(obclsNuevoEvento, Convert.ToInt32(lblOpcion.Text)) + "') </script>");
                    lblOpcion.Text = string.Empty;

                    getNuevoEvento();

                }

            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(GetType(), "mensaje", "<script> alert('" + ex.Message + "') </script>"); }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtUbicacion.Text = txtParticipantes.Text = txtFecha.Text = ddlRelacionado.Text
                    = txtDescripcion.Text = string.Empty;
        }


    }
}