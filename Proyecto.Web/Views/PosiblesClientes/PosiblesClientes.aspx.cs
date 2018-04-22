using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Proyecto.Web.Views.PosiblesClientes
{
    public partial class PosiblesClientes : System.Web.UI.Page
    {
        void getPosiblesClientes()
        {
            try
            {


                Controllers.PosiblesClientesController obPosiblesClientesController = new Controllers.PosiblesClientesController();
                DataSet dsConsulta = obPosiblesClientesController.getConsultarPosiblesClientesController();

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
                Controllers.clsFuentePosibleClienteController obclsFuentePosibleClienteController = new Controllers.clsFuentePosibleClienteController();
                DataSet dsConsultaFuentePosibleCliente = obclsFuentePosibleClienteController.getConsultarFuentePosiblesClientesController();
                DataSet dsConsultaEstadoPosibleCliente = obclsFuentePosibleClienteController.getConsultarEstadoPosiblesClientesController();
                DataSet dsConsultaSectorPosibleCliente = obclsFuentePosibleClienteController.getConsultarSectorPosiblesClientesController();
                DataSet dsConsultaCalificacionPosbleCliente = obclsFuentePosibleClienteController.getConsultarCalificacionPosiblesClientesController();
               
                

                ddlFuente.DataSource = dsConsultaFuentePosibleCliente;
                ddlFuente.DataTextField = "fueposibleclieDescripcion";
                ddlFuente.DataValueField = "fuenposibleclieCodigo";
                ddlFuente.DataBind();

                ddlEstado.DataSource = dsConsultaEstadoPosibleCliente;
                ddlEstado.DataTextField = "estaPosibleClieDescripcion";
                ddlEstado.DataValueField = "estaPosibleClieCodigo";
                ddlEstado.DataBind();

                ddlSector.DataSource = dsConsultaSectorPosibleCliente;
                ddlSector.DataTextField = "secPosibleClieDescripcion";
                ddlSector.DataValueField = "secPosibleClieCodigo";
                ddlSector.DataBind();

                ddlCalificacion.DataSource = dsConsultaCalificacionPosbleCliente;
                ddlCalificacion.DataTextField = "caliPosibleClieDescripcion";
                ddlCalificacion.DataValueField = "caliPosibleClieCodigo";
                ddlCalificacion.DataBind();

                

                
                
                getPosiblesClientes();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string stMensaje = string.Empty;
                if (string.IsNullOrEmpty(txtCodigo.Text)) stMensaje += "Ingresa Codigo,";
                if (!string.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                Logica.Models.clsPosiblesClientes obclsPosiblesClientes = new Logica.Models.clsPosiblesClientes
                {
                    lnCodigo = Convert.ToInt64(txtCodigo.Text),
                    stEmpresa = txtempresa.Text,
                    stNombre = txtNombre.Text,
                    stApellidos = txtApellidos.Text,
                    stTitulo = txtTitulo.Text,
                    stCorreElectronico = txtcorreo.Text,
                    stTelefono = txtTelefono.Text,
                    stFax = txtFax.Text,
                    stMovil = txtMovil.Text,
                    stSitioWeb = txtSitio.Text,
                    obclsFuentePosibleCliente = new Logica.Models.clsFuentePosibleCliente() { stDescripcion = ddlFuente.Text },
                    obclsEstadoPosibleCliente = new Logica.Models.clsEstadoPosibleCliente() { stDescripcion = ddlEstado.Text },
                    obclsSectorPosibleCliente = new Logica.Models.clsSectorPosibleCliente() { stDescripcion = ddlSector.Text },
                    inCantidad = Convert.ToInt32(txtCantidad.Text),
                    flIngresos = Convert.ToInt64(txtingresos.Text),
                    obclsCalificacionPosibleCliente = new Logica.Models.clsCalificacionPosibleCliente() { stDescripcion = ddlCalificacion.Text },
                    stIdSkype = txtIdSkype.Text,
                    stTwitter = txtTwitter.Text,
                    stCorreoSecundrio = txtCorreoSecundario.Text



                };

                Controllers.PosiblesClientesController obPosiblesClientesController = new Controllers.PosiblesClientesController();

                if (string.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                ClientScript.RegisterStartupScript(GetType(), "mensaje", "<script> alert('" + obPosiblesClientesController.setAdministrarPosiblesClientesController(obclsPosiblesClientes,Convert.ToInt32(lblOpcion.Text)) + "') </script>");
                lblOpcion.Text = txtCodigo.Text = txtempresa.Text = txtNombre.Text = txtApellidos.Text = txtTitulo.Text = txtcorreo.Text
                    = txtTelefono.Text = txtFax.Text = txtMovil.Text = txtSitio.Text = ddlFuente.Text = ddlEstado.Text= ddlSector.Text
                    =txtCantidad.Text = txtingresos.Text=ddlCalificacion.Text = txtIdSkype.Text = txtTwitter.Text = txtCorreoSecundario.Text = string.Empty;
                getPosiblesClientes();

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
                    txtempresa.Text = gvrDatos.Rows[inIndice].Cells[1].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[1].Text;
                    txtNombre.Text = gvrDatos.Rows[inIndice].Cells[2].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[2].Text;
                    txtApellidos.Text = gvrDatos.Rows[inIndice].Cells[3].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[3].Text;
                    txtTitulo.Text = gvrDatos.Rows[inIndice].Cells[4].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[4].Text;
                    txtcorreo.Text = gvrDatos.Rows[inIndice].Cells[5].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[5].Text;
                    txtTelefono.Text = gvrDatos.Rows[inIndice].Cells[6].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[6].Text;
                    txtFax.Text = gvrDatos.Rows[inIndice].Cells[7].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[7].Text;
                    txtMovil.Text = gvrDatos.Rows[inIndice].Cells[8].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[8].Text;
                    txtSitio.Text = gvrDatos.Rows[inIndice].Cells[9].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[9].Text;
                    ddlFuente.Text = gvrDatos.Rows[inIndice].Cells[10].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[10].Text;
                    ddlEstado.Text = gvrDatos.Rows[inIndice].Cells[11].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[11].Text;
                    ddlSector.Text = gvrDatos.Rows[inIndice].Cells[12].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[12].Text;
                    txtCantidad.Text = gvrDatos.Rows[inIndice].Cells[13].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[13].Text;
                    txtingresos.Text = gvrDatos.Rows[inIndice].Cells[14].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[14].Text;
                    ddlCalificacion.Text = gvrDatos.Rows[inIndice].Cells[15].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[15].Text;
                    txtIdSkype.Text = gvrDatos.Rows[inIndice].Cells[16].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[16].Text;
                    txtTwitter.Text = gvrDatos.Rows[inIndice].Cells[17].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[17].Text;
                    txtCorreoSecundario.Text = gvrDatos.Rows[inIndice].Cells[18].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[18].Text;

                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    lblOpcion.Text = "3";

                    Logica.Models.clsPosiblesClientes obclsPosiblesClientes = new Logica.Models.clsPosiblesClientes
                    {
                        lnCodigo = Convert.ToInt64(((Label)gvrDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        stEmpresa = string.Empty,
                        stNombre = string.Empty,
                        stApellidos = string.Empty,
                        stTitulo = string.Empty,
                        stCorreElectronico = string.Empty,
                        stTelefono = string.Empty,
                        stFax = string.Empty,
                        stMovil = string.Empty,
                        stSitioWeb = string.Empty,
                        obclsFuentePosibleCliente = new Logica.Models.clsFuentePosibleCliente() { stDescripcion = ddlFuente.Text },
                        obclsEstadoPosibleCliente = new Logica.Models.clsEstadoPosibleCliente() { stDescripcion = ddlEstado.Text },
                        obclsSectorPosibleCliente = new Logica.Models.clsSectorPosibleCliente() { stDescripcion = ddlSector.Text },
                        inCantidad = Convert.ToInt32(string.Empty),
                        flIngresos = Convert.ToInt64(string.Empty),
                        obclsCalificacionPosibleCliente = new Logica.Models.clsCalificacionPosibleCliente() { stDescripcion = ddlCalificacion.Text },
                        stIdSkype = string.Empty,
                        stTwitter = string.Empty,
                        stCorreoSecundrio = string.Empty

                    };

                    Controllers.PosiblesClientesController obPosiblesClientesController = new Controllers.PosiblesClientesController();

                  
                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "<script> alert('" + obPosiblesClientesController.setAdministrarPosiblesClientesController(obclsPosiblesClientes, Convert.ToInt32(lblOpcion.Text)) + "') </script>");
                    lblOpcion.Text = string.Empty;

                    getPosiblesClientes();

                }

            }catch (Exception ex) { ClientScript.RegisterStartupScript(GetType(), "mensaje", "<script> alert('" + ex.Message + "') </script>"); }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtempresa.Text = txtNombre.Text = txtApellidos.Text = txtTitulo.Text = txtcorreo.Text
                    = txtTelefono.Text = txtFax.Text = txtMovil.Text = txtSitio.Text = ddlFuente.Text = ddlEstado.Text = ddlSector.Text
                    = txtCantidad.Text = txtingresos.Text=ddlCalificacion.Text = txtIdSkype.Text = txtTwitter.Text = txtCorreoSecundario.Text = string.Empty;
        }
    }
}