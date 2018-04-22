<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Template.Master" AutoEventWireup="true" CodeBehind="InfoContacto.aspx.cs" Inherits="Proyecto.Web.Views.InfoContacto.InfoContacto" %>


<asp:Content ID="ContentHeader" ContentPlaceHolderID="Header" runat="server">

    <style type="text/css">
        .auto-style1 {
            margin-right: 2px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="contenedor" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="mx-auto mt-5">
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:Label runat="server" ID="lblTitul" Text="INFORMACION DE CONTACTO"></asp:Label>
                    <asp:Label runat="server" ID="lblOpcion" Visible="false"></asp:Label>

                </div>


                <div class="form-row">
                    <div class="col-md-12">

                        <asp:Button runat="server" ID="btnGuardar" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click"></asp:Button>
                        <%--<asp:Button runat="server" ID="btnModificar" Text="Modificar" CssClass="btn btn-primary"></asp:Button>--%>
                        <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="btn btn-primary" OnClick="btnCancelar_Click"></asp:Button>
                    </div>


                </div>

            </div>

            <div class="form-row">
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblCodigo" Text="Codigo"></asp:Label>
                    <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control"></asp:TextBox>

                </div>


            </div>

        </div>

        <div class="form-row">
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblFuentePosibleCliente" Text="Fuente de PosibleCliente"></asp:Label>
                 <asp:DropDownList runat="server" ID="ddlFuentePosibleCliente" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblNombre" Text="Nombre"></asp:Label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblApellidos" Text="Apellidos"></asp:Label>
                <asp:TextBox runat="server" ID="txtApellidos" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblNumeroCuenta" Text="Numero de Cuenta"></asp:Label>
                <asp:TextBox runat="server" ID="txtNumeroCuenta" CssClass="form-control"></asp:TextBox>

            </div>
        </div>
    </div>

    <div class="form-group">
        <div class="form-row">
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblTitulo" Text="Titulo"></asp:Label>
                <asp:TextBox runat="server" ID="txtTitulo" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblCorreo" Text="Correo Electronico"></asp:Label>
                <asp:TextBox runat="server" ID="txtCorreo" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblDepartamento" Text="Departamento"></asp:Label>
                <asp:TextBox runat="server" ID="txtDepartamento" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblTelefono" Text="Telefono"></asp:Label>
                <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="form-group">
        <div class="form-row">
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblTelefonoParticular" Text="Telefono Particular"></asp:Label>
                <asp:TextBox runat="server" ID="txtTelefonoParticular" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblOtroTelefono" Text="Otro Telefono"></asp:Label>
                <asp:TextBox runat="server" ID="txtOtroTelefono" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblFax" Text="Fax"></asp:Label>
                <asp:TextBox runat="server" ID="txtFax" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblMovil" Text="Movil"></asp:Label>
                <asp:TextBox runat="server" ID="txtMovil" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </div>



    
    <div class="form-group">
        <div class="form-row">
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblFechaNacimiento" Text="Fechade Nacimiento"></asp:Label>
                <asp:TextBox runat="server" ID="txtFechaNacimiento" CssClass="form-control"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="ceFechaNacimiento" runat="server" TargetControlID="txtFechaNacimiento" />
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblAsistente" Text="Asistente"></asp:Label>
                <asp:TextBox runat="server" ID="txtAsistente" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblTelefonoAsistente" Text="Nº de Telefono del asistente"></asp:Label>
                <asp:TextBox runat="server" ID="txtTelefonoAsistente" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblResponder" Text="Responder a"></asp:Label>
                <asp:TextBox runat="server" ID="txtResponder" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </div>
   
    <div class="form-row">


        <div class="col-md-6">
            <asp:Label runat="server" ID="lblIdSkyp" Text="ID de Skype"></asp:Label>
            <asp:TextBox runat="server" ID="txtIdSkype" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <asp:Label runat="server" ID="lblCorreoSecundario" Text="Correo Electronico Secundario"></asp:Label>
            <asp:TextBox runat="server" ID="txtCorreoSecundario" CssClass="form-control"></asp:TextBox>

        </div>
    </div>


    <div class="form-group">
        <div class="form-row">
            <div class="col-md-12">
                <asp:Label runat="server" ID="lblSubtitulo" Text="Resultado"></asp:Label>
            </div>

        </div>

    </div>
    <div class="form-group">
        <div class="form-row">
            <div class="col-md-12" style="overflow:auto">
                <asp:GridView runat="server" ID="gvrDatos" Width="100%" AutoGenerateColumns="False" EmptyDataText="No se Encontraron Registros" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" CssClass="auto-style1" OnRowCommand="gvrDatos_RowCommand" >
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>

                        <asp:TemplateField HeaderText="Identificacion">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("contCodigo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Empresa" DataField="clieEmpresa"/>
                        <asp:BoundField HeaderText="Nombre" DataField="clieNombre"/>
                        <asp:BoundField HeaderText="Apellidos" DataField="clieApellidos"/>
                        <asp:BoundField HeaderText="Titulo" DataField="clieTitulo"/>
                        <asp:BoundField HeaderText="Correo Electronico" DataField="clieCorreoElectronico"/>
                        <asp:BoundField HeaderText="Telefono" DataField="clieTelefono"/>
                        <asp:BoundField HeaderText="Fax" DataField="clieFax"/>
                        <asp:BoundField HeaderText="Movil" DataField="cliemovil"/>
                        <asp:BoundField HeaderText="Sitio Web" DataField="clieSitioweb"/>
                        <asp:BoundField HeaderText="Fuente de PosibleCliente" DataField="clieFuentePosibleCliente"/>
                        <asp:BoundField HeaderText="Estado" DataField="clieEstado"/>
                        <asp:BoundField HeaderText="Cantidad" DataField="clieCantidad"/>
                        <asp:BoundField HeaderText="Ingresos" DataField="clieIngresos"/>
                        <asp:BoundField HeaderText="Id Skype" DataField="clieIdSkype"/>
                        <asp:BoundField HeaderText="Twitter" DataField="clieTwitter"/>
                        <asp:BoundField HeaderText="Correo Secundario" DataField="clieCorreoSecundario"/>
                        <%-- Editar --%>
                         <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibEditar" runat="server" ImageUrl="~/Resources/Images/edi.gif"
                                    CommandName="Editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <%-- Editar --%>
                         <asp:TemplateField HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibEliminar" runat="server" ImageUrl="~/Resources/Images/eliminar.gif"
                                    CommandName="Eliminar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                    </Columns>

                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />

                </asp:GridView>
            </div>

        </div>

    </div>

</asp:Content>

