<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Template.Master" AutoEventWireup="true" CodeBehind="InfoTrato.aspx.cs" Inherits="Proyecto.Web.Views.InfoTrato.InfoTrato" %>
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
                    <asp:Label runat="server" ID="lblTitul" Text="INFORMACION DE TRATO"></asp:Label>
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
                <asp:Label runat="server" ID="lblImporte" Text="Importe"></asp:Label>
                <asp:TextBox runat="server" ID="txtImporte" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblNombre" Text="Nombre"></asp:Label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblFechaCierre" Text="Fecha de Cierre"></asp:Label>
                <asp:TextBox runat="server" ID="txtFechaCierre" CssClass="form-control"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="ceFechaCierre" runat="server" TargetControlID="txtFechaCierre" />
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
                <asp:Label runat="server" ID="lblFase" Text="Fase"></asp:Label>
             <asp:DropDownList runat="server" ID="ddlFase" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblTipo" Text="Tipo"></asp:Label>
                 <asp:DropDownList runat="server" ID="ddlTipo" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblProbabilidad" Text="Probabilidad"></asp:Label>
                <asp:TextBox runat="server" ID="txtProbabilidad" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblSiguientePaso" Text="Siguiente Paso"></asp:Label>
                <asp:TextBox runat="server" ID="txtSiguientePaso" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="form-group">
        <div class="form-row">
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblIngresos" Text="Ingresos Esperados"></asp:Label>
                <asp:TextBox runat="server" ID="txtIngresos" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblFuentePosibleCliente" Text="Fuente de Posible Cliente"></asp:Label>
                 <asp:DropDownList runat="server" ID="ddlFuentePosibleCliente" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblFuenteCompañia" Text="Fuente Compañia"></asp:Label>
                <asp:TextBox runat="server" ID="txtFuenteCompañia" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblNombreContacto" Text="Nombre deContacto"></asp:Label>
                <asp:TextBox runat="server" ID="txtNombreContacto" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </div>
   
 <div class="form-row">



            <div class="col-md-6">
                <asp:Label runat="server" ID="lblDescripcion" Text="Descripcion"></asp:Label>
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

                        <asp:TemplateField HeaderText="Identificacion">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="Label1" Text='<%# Bind("traCodigo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Importe" DataField="traImporte"/>
                        <asp:BoundField HeaderText="Nombre" DataField="traNombreTrato"/>
                        <asp:BoundField HeaderText="Fecha Cierre" DataField="traFechaCierre"/>
                        <asp:BoundField HeaderText="Numero Cuenta" DataField="traNumeroCuenta"/>
                        <asp:BoundField HeaderText="Fase" DataField="traFase"/>
                        <asp:BoundField HeaderText="Tipo" DataField="traTipo"/>
                        <asp:BoundField HeaderText="Probabilidad" DataField="traProbabilidad"/>
                        <asp:BoundField HeaderText="Siguiente Paso" DataField="traSiguientePaso"/>
                        <asp:BoundField HeaderText="Ingresos" DataField="traIngresos"/>
                        <asp:BoundField HeaderText="Fuente de Posible Cliente" DataField="traFuentePosibleCliente"/>
                        <asp:BoundField HeaderText="Fuente Campaña" DataField="traFuenteCampaña"/>
                        <asp:BoundField HeaderText="Nombre Contacto" DataField="traNombreContacto"/>
                        <asp:BoundField HeaderText="Descripcion" DataField="traDescripcion"/>
                        
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
