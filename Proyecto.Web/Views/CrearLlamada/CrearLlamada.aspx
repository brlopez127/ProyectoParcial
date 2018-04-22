<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Template.Master" AutoEventWireup="true" CodeBehind="CrearLlamada.aspx.cs" Inherits="Proyecto.Web.Views.Crear_Llamada.CrearLlamada" %>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="Header" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-right: 2px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenedor" runat="server">
    <div class="mx-auto mt-5">
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:Label runat="server" ID="lblTitulo" Text="CREAR LLAMADA"></asp:Label>
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


        <div class="col-md-6">
            <asp:Label runat="server" ID="lblNombreContacto" Text="Nombre de Contacto"></asp:Label>
            <asp:TextBox runat="server" ID="txtNombreContacto" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <asp:Label runat="server" ID="lblAsunto" Text="Asunto"></asp:Label>
            <asp:TextBox runat="server" ID="txtAsunto" CssClass="form-control"></asp:TextBox>

        </div>
    </div>

       <div class="form-row">


        <div class="col-md-6">
            <asp:Label runat="server" ID="lblProposito" Text="Proposito de la Llamada"></asp:Label>
             <asp:DropDownList runat="server" ID="ddlProposito" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="col-md-6">
            <asp:Label runat="server" ID="lblRelacionado" Text="Relacionado Con"></asp:Label>
             <asp:DropDownList runat="server" ID="ddlRelacionado" CssClass="form-control"></asp:DropDownList>

        </div>
    </div>
    </div>

   


    <div class="form-row">


        <div class="col-md-6">
            <asp:Label runat="server" ID="lblTipoLlamada" Text="Tipo de Llamada"></asp:Label>
            <asp:TextBox runat="server" ID="txttipodeLlamada" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <asp:Label runat="server" ID="lbldetalle" Text="Detalles de la Llamada"></asp:Label>
            <asp:TextBox runat="server" ID="txtDetalle" CssClass="form-control"></asp:TextBox>

        </div>
    </div>

        <div class="form-row">



            <div class="col-md-6">
                <asp:Label runat="server" ID="lblDescripcion" Text="Descripcion"></asp:Label>
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>

            </div>
        </div>

     <div class="form-row">



            <div class="col-md-6">
                <asp:Label runat="server" ID="lblResultado" Text="Resultado de la Llamada"></asp:Label>
                <asp:TextBox runat="server" ID="txtResultado" CssClass="form-control"></asp:TextBox>

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

                        <asp:TemplateField HeaderText="Codigo">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("llamCodigo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Nombre Contacto" DataField="llamNombreContacto"/>
                        <asp:BoundField HeaderText="Asunto" DataField="llamAsunto"/>
                        <asp:BoundField HeaderText="Proposito de la Llamada" DataField="llamProposito"/>
                        <asp:BoundField HeaderText="Relacionado Con" DataField="llamRelacionadoCon"/>
                        <asp:BoundField HeaderText="Tipo de Llamada" DataField="llamTipoLlamada"/>
                        <asp:BoundField HeaderText="Detalles de la Llamada" DataField="llamDetalle"/>
                        <asp:BoundField HeaderText="Descripcion" DataField="llamDescripcion"/>
                        <asp:BoundField HeaderText="Resultado de la Llamada" DataField="llamResultado"/>
                       
                       
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
