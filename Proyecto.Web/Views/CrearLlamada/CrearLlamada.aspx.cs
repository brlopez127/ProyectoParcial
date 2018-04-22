using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Proyecto.Web.Views.Crear_Llamada
{
    public partial class CrearLlamada : System.Web.UI.Page
    {

        void getCrearLlamada()
        {
            try
            {


                Controllers.CrearLlamadaController obCrearLlamadaController = new Controllers.CrearLlamadaController();
                DataSet dsConsulta = obCrearLlamadaController.getConsultarCrearLlamada();

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
                Controllers.clsPropositoLlamadaController obclsPropositoLlamadaController = new Controllers.clsPropositoLlamadaController();
                DataSet dsConsultaPropositoLlamada = obclsPropositoLlamadaController.getConsultarPropositoLlamadaController();
                DataSet dsConsultaRelacionadoLlamada = obclsPropositoLlamadaController.getConsultarRelacionadoLlamadaController();


                ddlProposito.DataSource = dsConsultaPropositoLlamada;
                ddlProposito.DataTextField = "propllamDescripcion";
                ddlProposito.DataValueField = "propllamCodigo";
                ddlProposito.DataBind();

                ddlRelacionado.DataSource = dsConsultaRelacionadoLlamada;
                ddlRelacionado.DataTextField = "relllamDescripcion";
                ddlRelacionado.DataValueField = "relllamCodigo";
                ddlRelacionado.DataBind();

                 getCrearLlamada();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string stMensaje = string.Empty;
                if (string.IsNullOrEmpty(txtCodigo.Text)) stMensaje += "Ingresa Codigo,";
                if (!string.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                Logica.Models.clsCrearLlamada obclsCrearLlamada = new Logica.Models.clsCrearLlamada
                {
                    inCodigo = Convert.ToInt32(txtCodigo.Text),
                    stNombreContacto = txtNombreContacto.Text,
                    stAsunto = txtAsunto.Text,
                    obclsPropositoLlamada = new Logica.Models.clsPropositoLlamada() { stDescripcion = ddlProposito.Text },
                    obclsRelacionadoLlamada = new Logica.Models.clsRelacionadoLlamada() { stDescripcion = ddlRelacionado.Text},
                    stTipoLlamada = txttipodeLlamada.Text,
                    stDetalle = txtDetalle.Text,
                    stDescripcion = txtDescripcion.Text,
                    stResultado = txtResultado.Text



                };

                Controllers.CrearLlamadaController obCrearLlamadaController = new Controllers.CrearLlamadaController();

                if (string.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                ClientScript.RegisterStartupScript(GetType(), "mensaje", "<script> alert('" + obCrearLlamadaController.setAdministrarCrearLlamadaController(obclsCrearLlamada, Convert.ToInt32(lblOpcion.Text)) + "') </script>");
                lblOpcion.Text = txtCodigo.Text = txtNombreContacto.Text = txtAsunto.Text = ddlProposito.Text = ddlProposito.Text = txttipodeLlamada.Text
                    = txtDetalle.Text = txtDescripcion.Text = txtResultado.Text = string.Empty;
                getCrearLlamada();

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
                    txtNombreContacto.Text = gvrDatos.Rows[inIndice].Cells[1].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[1].Text;
                    txtAsunto.Text = gvrDatos.Rows[inIndice].Cells[2].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[2].Text;
                    ddlProposito.Text = gvrDatos.Rows[inIndice].Cells[3].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[3].Text;
                    ddlRelacionado.Text = gvrDatos.Rows[inIndice].Cells[4].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[4].Text;
                    txttipodeLlamada.Text = gvrDatos.Rows[inIndice].Cells[5].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[5].Text;
                    txtDetalle.Text = gvrDatos.Rows[inIndice].Cells[6].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[6].Text;
                    txtDescripcion.Text = gvrDatos.Rows[inIndice].Cells[7].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[7].Text;
                    txtResultado.Text = gvrDatos.Rows[inIndice].Cells[8].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[8].Text;



                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    lblOpcion.Text = "3";

                    Logica.Models.clsCrearLlamada obclsCrearLlamada = new Logica.Models.clsCrearLlamada
                    {
                        inCodigo = Convert.ToInt32(((Label)gvrDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        stNombreContacto = string.Empty,
                        stAsunto = string.Empty,
                        obclsPropositoLlamada = new Logica.Models.clsPropositoLlamada() { stDescripcion = ddlProposito.Text },
                        obclsRelacionadoLlamada = new Logica.Models.clsRelacionadoLlamada() { stDescripcion = ddlRelacionado.Text },
                        stTipoLlamada = string.Empty,
                        stDetalle = string.Empty,
                        stDescripcion = string.Empty,
                        stResultado = string.Empty



                    };

                    Controllers.CrearLlamadaController obCrearLlamadaController = new Controllers.CrearLlamadaController();


                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "<script> alert('" + obCrearLlamadaController.setAdministrarCrearLlamadaController(obclsCrearLlamada, Convert.ToInt32(lblOpcion.Text)) + "') </script>");
                    lblOpcion.Text = string.Empty;

                    getCrearLlamada();

                }

            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(GetType(), "mensaje", "<script> alert('" + ex.Message + "') </script>"); }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtNombreContacto.Text = txtAsunto.Text = ddlProposito.Text = ddlRelacionado.Text = txttipodeLlamada.Text
                    = txtDetalle.Text = txtDescripcion.Text = txtResultado.Text = string.Empty;
        }

    }
}