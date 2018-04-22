using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Proyecto.Web.Views.InfoCampaña
{
    public partial class InfoCampaña : System.Web.UI.Page
    {


        void getInfoCampaña()
        {
            try
            {


                Controllers.InfoCampañaController obInfoCampañaController = new Controllers.InfoCampañaController();
                DataSet dsConsulta = obInfoCampañaController.getConsultarInfoCampañaController();

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
            if (!IsPostBack)
            {

                Controllers.clsTipoCampañaController obclsTipoCampañaController = new Controllers.clsTipoCampañaController();
                DataSet dsConsultaTipoCampaña = obclsTipoCampañaController.getConsultarTipoCampañaController();
                DataSet dsConsultaEstadoCampaña = obclsTipoCampañaController.getConsultarEstadoCampañaController();


                ddlTipo.DataSource = dsConsultaTipoCampaña;
                ddlTipo.DataTextField = "camTipoDescripcion";
                ddlTipo.DataValueField = "camTipoCodigo";
                ddlTipo.DataBind();

                ddlEstado.DataSource = dsConsultaEstadoCampaña;
                ddlEstado.DataTextField = "camEstadoDescripcion";
                ddlEstado.DataValueField = "camEstadoCodigo";
                ddlEstado.DataBind();

                getInfoCampaña();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string stMensaje = string.Empty;
                if (string.IsNullOrEmpty(txtCodigo.Text)) stMensaje += "Ingresa Codigo,";
                if (!string.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                Logica.Models.clsInfoCampaña obclsInfoCampaña = new Logica.Models.clsInfoCampaña
                {
                    inCodigo = Convert.ToInt32(txtCodigo.Text),
                    obclsTipoCampaña = new Logica.Models.clsTipoCampaña() { stDescripcion = ddlTipo.Text },
                    stNombreCampaña = txtNombreCampaña.Text,
                    obclsEstadoCampaña = new Logica.Models.clsEstadoCampaña() { stDescripcion = ddlEstado.Text },
                    stFechaInicio = txtFechaInicio.Text,
                    stFechaFinalizacion = txtFechaFinalizacion.Text,
                    stIngresos = txtIngresos.Text,
                    stCostePresupuesto = txtCostePresupuesto.Text,
                    stCosteReal = txtCosteReal.Text,
                    stRespuesta = txtRespuesta.Text,
                    stNumerosEnviados = txtNumerosEnviados.Text,
                    stDescripcion = txtDescripcion.Text
                   



                };

                Controllers.InfoCampañaController obInfoCampañaController = new Controllers.InfoCampañaController();

                if (string.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                ClientScript.RegisterStartupScript(GetType(), "mensaje", "<script> alert('" + obInfoCampañaController.setAdministrarInfoCampañaController(obclsInfoCampaña, Convert.ToInt32(lblOpcion.Text)) + "') </script>");
                lblOpcion.Text = txtCodigo.Text = ddlTipo.Text = txtNombreCampaña.Text = ddlEstado.Text = txtFechaInicio.Text = txtFechaFinalizacion.Text = txtIngresos.Text
                    = txtCostePresupuesto.Text = txtCosteReal.Text = txtRespuesta.Text = txtNumerosEnviados.Text = txtDescripcion.Text  = string.Empty;
                getInfoCampaña();

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
                    ddlTipo.Text = gvrDatos.Rows[inIndice].Cells[1].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[1].Text;
                    txtNombreCampaña.Text = gvrDatos.Rows[inIndice].Cells[2].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[2].Text;
                    ddlEstado.Text = gvrDatos.Rows[inIndice].Cells[3].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[3].Text;
                    txtFechaInicio.Text = gvrDatos.Rows[inIndice].Cells[4].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[4].Text;
                    txtFechaFinalizacion.Text = gvrDatos.Rows[inIndice].Cells[5].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[5].Text;
                    txtIngresos.Text = gvrDatos.Rows[inIndice].Cells[6].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[6].Text;
                    txtCostePresupuesto.Text = gvrDatos.Rows[inIndice].Cells[7].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[7].Text;
                    txtCosteReal.Text = gvrDatos.Rows[inIndice].Cells[8].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[8].Text;
                    txtRespuesta.Text = gvrDatos.Rows[inIndice].Cells[9].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[9].Text;
                    txtNumerosEnviados.Text = gvrDatos.Rows[inIndice].Cells[10].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[10].Text;
                    txtDescripcion.Text = gvrDatos.Rows[inIndice].Cells[11].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[11].Text;
                   

                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    lblOpcion.Text = "3";

                    Logica.Models.clsInfoCampaña obclsInfoCampaña = new Logica.Models.clsInfoCampaña
                    {
                        inCodigo = Convert.ToInt32(((Label)gvrDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        obclsTipoCampaña = new Logica.Models.clsTipoCampaña() { stDescripcion = ddlTipo.Text },
                        stNombreCampaña = string.Empty,
                        obclsEstadoCampaña = new Logica.Models.clsEstadoCampaña() { stDescripcion = ddlEstado.Text },
                        stFechaInicio = string.Empty,
                        stFechaFinalizacion = string.Empty,
                        stIngresos = string.Empty,
                        stCostePresupuesto = string.Empty,
                        stCosteReal = string.Empty,
                        stRespuesta = string.Empty,
                        stNumerosEnviados = string.Empty,
                        stDescripcion = string.Empty
                        

                    };

                    Controllers.InfoCampañaController obInfoCampañaController = new Controllers.InfoCampañaController();


                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "<script> alert('" + obInfoCampañaController.setAdministrarInfoCampañaController(obclsInfoCampaña, Convert.ToInt32(lblOpcion.Text)) + "') </script>");
                    lblOpcion.Text = string.Empty;

                    getInfoCampaña();

                }

            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(GetType(), "mensaje", "<script> alert('" + ex.Message + "') </script>"); }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = ddlTipo.Text = txtNombreCampaña.Text = ddlEstado.Text = txtFechaInicio.Text = txtFechaFinalizacion.Text
                    = txtIngresos.Text = txtCostePresupuesto.Text = txtCosteReal.Text = txtRespuesta.Text = txtNumerosEnviados.Text = txtDescripcion.Text
                     = string.Empty;
        }

    }
}