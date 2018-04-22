using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Proyecto.Web.Views.InfoContacto
{
    public partial class InfoContacto : System.Web.UI.Page
    {

        void getInfoContacto()
        {
            try
            {


                Controllers.InfoContactoController obInfoContactoController = new Controllers.InfoContactoController();
                DataSet dsConsulta = obInfoContactoController.getConsultarInfoContactoController();

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

                Controllers.clsFuentePosibleClienteContactoController obclsFuentePosibleClienteContactoController = new Controllers.clsFuentePosibleClienteContactoController();
                DataSet dsConsultaFuentePosibleClienteContacto = obclsFuentePosibleClienteContactoController.getConsultarFuentePosibleClienteContactoController();

                ddlFuentePosibleCliente.DataSource = dsConsultaFuentePosibleClienteContacto;
                ddlFuentePosibleCliente.DataTextField = "fuenInfoContactoDescripcion";
                ddlFuentePosibleCliente.DataValueField = "fuenInfoContactoCodigo";
                ddlFuentePosibleCliente.DataBind();

                 getInfoContacto();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string stMensaje = string.Empty;
                if (string.IsNullOrEmpty(txtCodigo.Text)) stMensaje += "Ingresa Codigo,";
                if (!string.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                Logica.Models.clsInfoContacto obclsInfoContacto = new Logica.Models.clsInfoContacto
                {
                    inCodigo = Convert.ToInt32(txtCodigo.Text),
                    obclsFuentePosibleClienteContacto = new Logica.Models.clsFuentePosibleClienteContacto() { stDescripcion = ddlFuentePosibleCliente.Text },
                    stNombre = txtNombre.Text,
                    stApellidos = txtApellidos.Text,
                    stNumeroCuenta = txtNumeroCuenta.Text,
                    stTitulo = txtTitulo.Text,
                    stCorreo = txtCorreo.Text,
                    stDepartamento = txtDepartamento.Text,
                    stTelefono = txtTelefono.Text,
                    stTelefonoParticular = txtTelefonoParticular.Text,
                    stOtroTelefono = txtTelefono.Text,
                    stFax = txtFax.Text,
                    stMovil = txtMovil.Text,
                    stFechaNacimiento = txtFechaNacimiento.Text,
                    stAsistente = txtAsistente.Text,
                    stTelefonoAsistente = txtTelefonoAsistente.Text,
                    stResponder = txtResponder.Text,
                    stIdSkype = txtIdSkype.Text,
                    stCorreoSecundario = txtCorreoSecundario.Text



                };

                Controllers.InfoContactoController obInfoContactoController = new Controllers.InfoContactoController();

                if (string.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                ClientScript.RegisterStartupScript(GetType(), "mensaje", "<script> alert('" + obInfoContactoController.setAdministrarInfoContactoController(obclsInfoContacto, Convert.ToInt32(lblOpcion.Text)) + "') </script>");
                lblOpcion.Text = txtCodigo.Text = ddlFuentePosibleCliente.Text = txtNombre.Text = txtApellidos.Text = txtNumeroCuenta.Text = txtTitulo.Text = txtCorreo.Text
                    = txtDepartamento.Text = txtTelefono.Text = txtTelefonoParticular.Text = txtOtroTelefono.Text = txtFax.Text = txtMovil.Text
                    = txtFechaNacimiento.Text = txtAsistente.Text = txtTelefonoAsistente.Text = txtResponder.Text = txtIdSkype.Text = txtCorreoSecundario.Text = string.Empty;
                getInfoContacto();

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
                    ddlFuentePosibleCliente.Text = gvrDatos.Rows[inIndice].Cells[1].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[1].Text;
                    txtNombre.Text = gvrDatos.Rows[inIndice].Cells[2].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[2].Text;
                    txtApellidos.Text = gvrDatos.Rows[inIndice].Cells[3].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[3].Text;
                    txtNumeroCuenta.Text = gvrDatos.Rows[inIndice].Cells[4].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[4].Text;
                    txtTitulo.Text = gvrDatos.Rows[inIndice].Cells[5].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[5].Text;
                    txtCorreo.Text = gvrDatos.Rows[inIndice].Cells[6].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[6].Text;
                    txtDepartamento.Text = gvrDatos.Rows[inIndice].Cells[7].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[7].Text;
                    txtTelefonoParticular.Text = gvrDatos.Rows[inIndice].Cells[8].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[8].Text;
                    txtOtroTelefono.Text = gvrDatos.Rows[inIndice].Cells[9].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[9].Text;
                    txtFax.Text = gvrDatos.Rows[inIndice].Cells[10].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[10].Text;
                    txtMovil.Text = gvrDatos.Rows[inIndice].Cells[11].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[11].Text;
                    txtFechaNacimiento.Text = gvrDatos.Rows[inIndice].Cells[12].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[12].Text;
                    txtTelefono.Text = gvrDatos.Rows[inIndice].Cells[13].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[13].Text;
                    txtAsistente.Text = gvrDatos.Rows[inIndice].Cells[14].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[14].Text;
                    txtTelefonoAsistente.Text = gvrDatos.Rows[inIndice].Cells[15].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[15].Text;
                    txtResponder.Text = gvrDatos.Rows[inIndice].Cells[16].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[16].Text;
                    txtIdSkype.Text = gvrDatos.Rows[inIndice].Cells[17].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[17].Text;
                    txtCorreoSecundario.Text = gvrDatos.Rows[inIndice].Cells[18].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[18].Text;

                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    lblOpcion.Text = "3";

                    Logica.Models.clsInfoContacto obclsInfoContacto = new Logica.Models.clsInfoContacto
                    {
                        inCodigo = Convert.ToInt32(((Label)gvrDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        obclsFuentePosibleClienteContacto = new Logica.Models.clsFuentePosibleClienteContacto() { stDescripcion = ddlFuentePosibleCliente.Text },
                        stNombre = string.Empty,
                        stApellidos = string.Empty,
                        stNumeroCuenta = string.Empty,
                        stTitulo = string.Empty,
                        stCorreo = string.Empty,
                        stDepartamento = string.Empty,
                        stTelefonoParticular = string.Empty,
                        stOtroTelefono = string.Empty,
                        stFax = string.Empty,
                        stMovil = string.Empty,
                        stFechaNacimiento = string.Empty,
                        stTelefono = string.Empty,
                        stAsistente = string.Empty,
                        stResponder = string.Empty,
                        stIdSkype = string.Empty,
                        stCorreoSecundario = string.Empty

                    };

                    Controllers.InfoContactoController obInfoContactoController = new Controllers.InfoContactoController();


                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "<script> alert('" + obInfoContactoController.setAdministrarInfoContactoController(obclsInfoContacto, Convert.ToInt32(lblOpcion.Text)) + "') </script>");
                    lblOpcion.Text = string.Empty;

                    getInfoContacto();

                }

            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(GetType(), "mensaje", "<script> alert('" + ex.Message + "') </script>"); }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = ddlFuentePosibleCliente.Text = txtNombre.Text = txtApellidos.Text = txtNumeroCuenta.Text = txtTitulo.Text
                    = txtCorreo.Text = txtDepartamento.Text = txtTelefonoParticular.Text = txtOtroTelefono.Text = txtFax.Text = txtMovil.Text
                    = txtFechaNacimiento.Text = txtTelefono.Text = txtAsistente.Text = txtResponder.Text = txtIdSkype.Text = txtCorreoSecundario.Text = string.Empty;
        }

    }
}