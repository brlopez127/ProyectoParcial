using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Proyecto.Web.Resources
{
    public partial class CrearTarea : System.Web.UI.Page
    {
        void getCrearTarea()
        {
            try
            {


                Controllers.CrearTareaController obCrearTareaController = new Controllers.CrearTareaController();
                DataSet dsConsulta = obCrearTareaController.getConsultarCrearTareaController();

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
                Controllers.clsEstadoTareaController obclsEstadoTareaController = new Controllers.clsEstadoTareaController();
                DataSet dsConsultaEstadoTarea = obclsEstadoTareaController.getConsultarEstadoTareaController();
                DataSet dsConsultaPrioridadTarea = obclsEstadoTareaController.getConsultarPrioridadTareaController();
               

                ddlEstado.DataSource = dsConsultaEstadoTarea;
                ddlEstado.DataTextField = "estatareaDescripcion";
                ddlEstado.DataValueField = "estatareaCodigo";
                ddlEstado.DataBind();

                ddlPrioridad.DataSource = dsConsultaPrioridadTarea;
                ddlPrioridad.DataTextField = "priotareDescripcion";
                ddlPrioridad.DataValueField = "priotareaCodigo";
                ddlPrioridad.DataBind();

              
                getCrearTarea();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string stMensaje = string.Empty;
                if (string.IsNullOrEmpty(txtCodigo.Text)) stMensaje += "Ingresa Codigo,";
                if (!string.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                Logica.Models.clsCrearTarea obclsCrearTarea = new Logica.Models.clsCrearTarea
                {
                    inCodigo = Convert.ToInt32(txtCodigo.Text),
                    stAsunto = txtAsunto.Text,
                    stFechaVencimiento = txtFechadeVencimiento.Text,
                    stContacto = txtContacto.Text,
                    stCuenta = txtCuenta.Text,
                    obclsEstadoTareas =new Logica.Models.clsEstadoTareas() {stDescripcion= ddlEstado.Text } ,
                    obclsPrioridadTarea = new Logica.Models.clsPrioridadTarea(){ stDescripcion= ddlPrioridad.Text },
                    
                    stDescripcion = txtDescripcion.Text
                   


                };

                Controllers.CrearTareaController obCrearTareaController = new Controllers.CrearTareaController();

                if (string.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                ClientScript.RegisterStartupScript(GetType(), "mensaje", "<script> alert('" + obCrearTareaController.setAdministrarCrearTareaController(obclsCrearTarea, Convert.ToInt32(lblOpcion.Text)) + "') </script>");
                lblOpcion.Text = txtCodigo.Text = txtAsunto.Text = txtFechadeVencimiento.Text = txtContacto.Text = txtCuenta.Text = ddlEstado.Text
                    = ddlPrioridad.Text = txtDescripcion.Text  = string.Empty;
                getCrearTarea();

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
                    txtAsunto.Text = gvrDatos.Rows[inIndice].Cells[1].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[1].Text;
                    txtFechadeVencimiento   .Text = gvrDatos.Rows[inIndice].Cells[2].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[2].Text;
                    txtContacto.Text = gvrDatos.Rows[inIndice].Cells[3].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[3].Text;
                    txtCuenta.Text = gvrDatos.Rows[inIndice].Cells[4].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[4].Text;
                    ddlEstado.Text = gvrDatos.Rows[inIndice].Cells[5].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[5].Text;
                    ddlPrioridad.Text = gvrDatos.Rows[inIndice].Cells[6].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[6].Text;
                    txtDescripcion.Text = gvrDatos.Rows[inIndice].Cells[7].Text.Equals("&nbsp;") ? string.Empty : gvrDatos.Rows[inIndice].Cells[7].Text;
                    

                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    lblOpcion.Text = "3";

                    Logica.Models.clsCrearTarea obclsCrearTarea = new Logica.Models.clsCrearTarea()
                    {
                        inCodigo = Convert.ToInt32(((Label)gvrDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        stAsunto = string.Empty,
                        stFechaVencimiento = string.Empty,
                        stContacto = string.Empty,
                        stCuenta = string.Empty,
                        obclsEstadoTareas = new Logica.Models.clsEstadoTareas() { stDescripcion = ddlEstado.Text },
                        obclsPrioridadTarea = new Logica.Models.clsPrioridadTarea() { stDescripcion = ddlPrioridad.Text },
                        stDescripcion = string.Empty
                        

                    };

                    Controllers.CrearTareaController obCrearTareaController = new Controllers.CrearTareaController();


                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "<script> alert('" + obCrearTareaController.setAdministrarCrearTareaController(obclsCrearTarea, Convert.ToInt32(lblOpcion.Text)) + "') </script>");
                    lblOpcion.Text = string.Empty;

                    getCrearTarea();

                }

            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(GetType(), "mensaje", "<script> alert('" + ex.Message + "') </script>"); }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtAsunto.Text = txtFechadeVencimiento.Text = txtContacto.Text = txtCuenta.Text = ddlEstado.Text
                    = ddlPrioridad.Text = txtDescripcion.Text = string.Empty;
        }

       
    }
}