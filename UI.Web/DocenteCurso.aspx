<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocenteCurso.aspx.cs" Inherits="UI.Web.DocenteCurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="grdDocenteCursos" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grdDocenteCursos_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Curso" HeaderText="Curso" SortExpression="Curso" />
                <asp:BoundField DataField="NombreApellidoDocente" HeaderText="Docente" SortExpression="NombreApellidoDocente" />
                <asp:BoundField DataField="Cargo" HeaderText="Cargo" SortExpression="Cargo" />
                <asp:CommandField ShowSelectButton="True" />
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
    <asp:Panel ID="gridActionPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        &nbsp;<asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
        &nbsp;<asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="formPanel" runat="server" Visible="False">
        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
        &nbsp;<asp:TextBox ID="IDTextBox" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Curso"></asp:Label>
        &nbsp;&nbsp;<asp:DropDownList ID="ddlCurso" runat="server">
        </asp:DropDownList>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="ddlCurso" ErrorMessage="Seleccione un Curso" ForeColor="Red" MaximumValue="999999" MinimumValue="1" ValidationGroup="validar">*</asp:RangeValidator>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Docente"></asp:Label>
        &nbsp;<asp:DropDownList ID="ddlDocente" runat="server">
        </asp:DropDownList>
        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="ddlDocente" ErrorMessage="Seleccione Docente" ForeColor="Red" MaximumValue="99999" MinimumValue="1" ValidationGroup="validar" EnableViewState="False">*</asp:RangeValidator>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Cargo"></asp:Label>
        &nbsp;<asp:DropDownList ID="ddlCargo" runat="server">
        </asp:DropDownList>
        <br />
        <br />
    </asp:Panel>
    <asp:Panel ID="formActionPanel" runat="server" Visible="False">
        <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" ValidationGroup="validar">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="Panel5" runat="server">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="validar" />
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
