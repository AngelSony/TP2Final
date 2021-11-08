<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="grdComisiones" runat="server" AuroGenerateColumns="False" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="grdComisiones_SelectedIndexChanged" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                <asp:BoundField HeaderText="Año Especialidad" DataField="AnioEspecialidad" />
                <asp:BoundField HeaderText="Plan" DataField="Plan" />
                <asp:CommandField SelectText="Seleccionar" showSelectButton="True" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion:  "></asp:Label>
        <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="descripcionTextBox" ErrorMessage="La Descripción no puede estar vacía" ForeColor="Red" ValidationGroup="validar">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="anioEspecialidadLabel" runat="server" Text="Año Especialidad: "></asp:Label>
        <asp:TextBox ID="anioEspecialidadTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="anioEspecialidadTextBox" ErrorMessage="El Año Especialidad no puede estar vacío" ForeColor="Red" ValidationGroup="validar">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="planesLabel" runat="server" Text="Plan: "></asp:Label>
        <asp:DropDownList ID="ddPlanes" runat="server">
        </asp:DropDownList>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="ddPlanes" ErrorMessage="Debe seleccionar un Plan" ForeColor="Red" MaximumValue="999999" MinimumValue="1" ValidationGroup="validar">*</asp:RangeValidator>
        <br />
    </asp:Panel>
    <asp:Panel ID="formActionsPanel" runat="server" Visible="False">
        <asp:LinkButton ID="aceptarLinkButton" runat="server" ValidationGroup="validar" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
    </asp:Panel>
<asp:ValidationSummary ID="ValidationSummary" runat="server" ValidationGroup="validar" ForeColor="Red" />
</asp:Content>
