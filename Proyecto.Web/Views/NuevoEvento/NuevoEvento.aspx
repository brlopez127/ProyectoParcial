<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Template.Master" AutoEventWireup="true" CodeBehind="NuevoEvento.aspx.cs" Inherits="Proyecto.Web.Views.NuevoEvento.NuevoEvento" %>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="Header" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-right: 2px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenedor" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="mx-auto mt-5">
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:Label runat="server" ID="lblTitulo" Text="INFORMACIN SOBRE El EVE"></asp:Label>
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
            <asp:Label runat="server" ID="lblNombre" Text="Nombre Evento"></asp:Label>
            <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <asp:Label runat="server" ID="lblUbicacion" Text="ubicacion"></asp:Label>
            <asp:TextBox runat="server" ID="txtUbicacion" CssClass="form-control"></asp:TextBox>

        </div>
    </div>

        <div class="form-row">



            <div class="col-md-6">
                <asp:Label runat="server" ID="lblParticipantes" Text="Participantes"></asp:Label>
                <asp:TextBox runat="server" ID="txtParticipantes" CssClass="form-control"></asp:TextBox>

            </div>
        </div>
    </div>

   


    <div class="form-row">


        <div class="col-md-6">
            <asp:Label runat="server" ID="lblFecha" Text="Fecha"></asp:Label>
            <asp:TextBox runat="server" ID="txtFecha" CssClass="form-control"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="ceFecha" runat="server" TargetControlID="txtFecha" />
        </div>
        <div class="col-md-6">
            <asp:Label runat="server" ID="lblRelacionado" Text="Relacionado Con"></asp:Label>
             <asp:DropDownList runat="server" ID="ddlRelacionado" CssClass="form-control"></asp:DropDownList>

        </div>
    </div>

        <div class="form-row">



            <div class="col-md-6">
                <asp:Label runat="server" ID="lblDescripcion" Text="Informacion de la Descripcion"></asp:Label>
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>

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
                                <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("evenCodigo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Nombre" DataField="evenNombre"/>
                        <asp:BoundField HeaderText="Ubicacion" DataField="evenUbicacion"/>
                        <asp:BoundField HeaderText="Participantes" DataField="evenParticipantes"/>
                        <asp:BoundField HeaderText="Fecha" DataField="evenFecha "/>
                        <asp:BoundField HeaderText="Relacionado Con" DataField="evenRelacionado"/>
                        <asp:BoundField HeaderText="Descripcion" DataField="evenDescripcion"/>
                       
                       
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
