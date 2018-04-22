using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Proyecto.Web.Views.InfoTrato
{
    public partial class InfoTrato : System.Web.UI.Page
    {


        void getInfoTrato()
        {
            try
            {


                Controllers.InfoTratoController obInfoTratoController = new Controllers.InfoTratoController();
                DataSet dsConsulta = obInfoTratoController.getConsultarInfoTratoController();

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

                Controllers.clsFaseTratosController obclsFaseTratosController = new Controllers.clsFaseTratosController();
                DataSet dsConsultaFaseTratos = obclsFaseTratosController.getConsultarFaseTratosController();
                DataSet dsConsultaTipoTratos = obclsFaseTratosController.getConsultarTipoTratoController();
                DataSet dsConsultaFuentePosibleClienteTratos = obclsFaseTratosController.getConsultarFuentePosibleClienteTratoController();
                



                ddlFase.DataSource = dsConsultaFaseTratos;
                ddlFase.DataTextField = "traFaseDescripcion";
                ddlFase.DataValueField = "traFaseCodigo";
                ddlFase.DataBind();

                ddlTipo.DataSource = dsConsultaTipoTratos;
                ddlTipo.DataTextField = "traTipoDescripcion";
                ddlTipo.DataValueField = "traTipoCodigo";
                ddlTipo.DataBind();

                ddlFuentePosibleCliente.DataSource = dsConsultaFuentePosibleClienteTratos;
                ddlFuentePosibleCliente.DataTextField = "traFuenPosibleClienteDescripcion";
                ddlFuentePosibleCliente.DataValueField = "traFuenPosibleClienteCodigo";
                ddlFuentePosibleCliente.DataBind();

                

                getInfoTrato();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string stMensaje = string.Empty;
                if (string.IsNullOrEmpty(txtCodigo.Text)) stMensaje += "Ingresa Codigo,";
                if (!string.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                Logica.Models.clsInfoTrato obclsInfoTrato = new Logica.Models.clsInfoTrato
                {
                    inCodigo = Convert.ToInt32(txtCodigo.Text),
                    stImporte = txtImporte.Text,
                    stNombreTrato = txtNombre.Text,
                    stFechaCierre = txtFechaCierre.Text,
                    stNumeroCuenta = txtNumeroCuenta.Text,
                    obclsFaseTratos = new Logica.Models.clsFaseTratos() { stDescripcion = ddlFase.Text },
                    obclsTipoTrato = new Logica.Models.clsTipoTrato() { stDescripcion = ddlTipo.Text },
                    stProbabilidad = txtProbabilidad.Text,
                    stSiguientePaso = txtSiguientePaso.Text,
                    stIngresos = txtIngresos.Text,
                    obclsFuentePosibleClienteTrato = new Logica.Models.clsFuentePosibleClienteTrato() { stDescripcion = ddlFuentePosibleCliente.Text },
                    stFuenteCompañia = txtFuenteCompañia.Text,
                    stNombreContacto = txtNombreContacto.Text,
                    stDescripcion = txtDescripcion.Text
                   



                };

                Controllers.InfoTratoController obInfoTratoController = new Controllers.InfoTratoController();

                if (string.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                ClientScript.RegisterStartupScript(GetType(), "mensaje", "<script> alert('" + obInfoTratoController.setAdministrarInfoTratoController(obclsInfoTrato, Convert.ToInt32(lblOpcion.Text)) + "') </script>");
                lblOpcion.Text = txtCodigo.Text = txtImporte.Text = txtNombre.Text = txtFechaCierre.Text = txtNumeroCuenta.Text = ddlFase.Text = ddlTipo.Text
                    = txtProbabilidad.Text = txtSiguientePaso.Text = txtIngresos.Text = ddlFuentePosibleCliente.Text = txtFuenteCompañia.Text = txtNombreContacto.Text
                    = txtDescripcion.Text  = string.Empty;
                getInfoTrato();

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
                    txtImporte.Text = gvrDatos.Rows[inIndice].Cells[1].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[1].Text;
                    txtNombre.Text = gvrDatos.Rows[inIndice].Cells[2].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[2].Text;
                    txtFechaCierre.Text = gvrDatos.Rows[inIndice].Cells[3].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[3].Text;
                    txtNumeroCuenta.Text = gvrDatos.Rows[inIndice].Cells[4].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[4].Text;
                    ddlFase.Text = gvrDatos.Rows[inIndice].Cells[5].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[5].Text;
                    ddlTipo.Text = gvrDatos.Rows[inIndice].Cells[6].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[6].Text;
                    txtProbabilidad.Text = gvrDatos.Rows[inIndice].Cells[7].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[7].Text;
                    txtSiguientePaso.Text = gvrDatos.Rows[inIndice].Cells[8].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[8].Text;
                    txtIngresos.Text = gvrDatos.Rows[inIndice].Cells[9].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[9].Text;
                    ddlFuentePosibleCliente.Text = gvrDatos.Rows[inIndice].Cells[10].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[10].Text;
                    txtFuenteCompañia.Text = gvrDatos.Rows[inIndice].Cells[11].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[11].Text;
                    txtNombreContacto.Text = gvrDatos.Rows[inIndice].Cells[12].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[12].Text;
                    txtDescripcion.Text = gvrDatos.Rows[inIndice].Cells[13].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[13].Text;
                   

                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    lblOpcion.Text = "3";

                    Logica.Models.clsInfoTrato obclsInfoTrato = new Logica.Models.clsInfoTrato
                    {
                        inCodigo = Convert.ToInt32(((Label)gvrDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        stImporte = string.Empty,
                        stNombreTrato = string.Empty,
                        stFechaCierre = string.Empty,
                        stNumeroCuenta = string.Empty,
                        obclsFaseTratos = new Logica.Models.clsFaseTratos() { stDescripcion = ddlFase.Text },
                        obclsTipoTrato = new Logica.Models.clsTipoTrato() { stDescripcion = ddlTipo.Text },
                        stProbabilidad = string.Empty,
                        stSiguientePaso = string.Empty,
                        stIngresos = string.Empty,
                        obclsFuentePosibleClienteTrato = new Logica.Models.clsFuentePosibleClienteTrato() { stDescripcion = ddlFuentePosibleCliente.Text },
                        stFuenteCompañia = string.Empty,
                        stNombreContacto = string.Empty,
                        stDescripcion = string.Empty
                        

                    };

                    Controllers.InfoTratoController obInfoTratoController = new Controllers.InfoTratoController();


                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "<script> alert('" + obInfoTratoController.setAdministrarInfoTratoController(obclsInfoTrato, Convert.ToInt32(lblOpcion.Text)) + "') </script>");
                    lblOpcion.Text = string.Empty;

                    getInfoTrato();

                }

            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(GetType(), "mensaje", "<script> alert('" + ex.Message + "') </script>"); }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtImporte.Text = txtNombre.Text = txtFechaCierre.Text = txtNumeroCuenta.Text = ddlFase.Text
                    = ddlTipo.Text = txtProbabilidad.Text = txtSiguientePaso.Text = txtIngresos.Text = ddlFuentePosibleCliente.Text = txtFuenteCompañia.Text
                    = txtNombreContacto.Text = txtDescripcion.Text  = string.Empty;
        }

    }
}