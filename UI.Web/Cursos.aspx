<%@ Page Title="Cursos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gvCursos" runat="server" AuroGenerateColumns="False" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gvCursos_SelectedIndexChanged" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="ID Curso" DataField="ID" />
                <asp:BoundField HeaderText="Materia" DataField="IDMateria" />
                <asp:BoundField HeaderText="Comisión" DataField="IDComision" />
                <asp:BoundField HeaderText="Año Calendario" DataField="AnioCalendario" />
                <asp:BoundField HeaderText="Cupo" DataField="Cupo" />
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
        <asp:Label ID="idMateriaLabel" runat="server" Text="Materia: "></asp:Label>
        <asp:DropDownList ID="ddMateria" runat="server">
        </asp:DropDownList>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="ddMateria" ErrorMessage="Debe seleccionar una Materia" ForeColor="Red" MaximumValue="999999" MinimumValue="1" ValidationGroup="validar">*</asp:RangeValidator>
        <br />
        <asp:Label ID="comisionLabel" runat="server" Text="Comisión: "></asp:Label>
        <asp:DropDownList ID="ddComision" runat="server">
        </asp:DropDownList>
        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="ddComision" ErrorMessage="Debe seleccionar una Comisión" ForeColor="Red" MaximumValue="999999" MinimumValue="1" ValidationGroup="validar">*</asp:RangeValidator>
        <br />
        <asp:Label ID="anioCalendarioLabel" runat="server" Text="Año Calendario:  "></asp:Label>
        <asp:TextBox ID="anioCalendarioTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="anioCalendarioTextBox" ErrorMessage="El año Calendario no puede estar vacío" ForeColor="Red" ValidationGroup="validar">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="cupoLabel" runat="server" Text="Cupo: "></asp:Label>
        <asp:TextBox ID="cupoTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cupoTextBox" ErrorMessage="El Cupo no puede estar vacío" ForeColor="Red" ValidationGroup="validar">*</asp:RequiredFieldValidator>
        <br />
    </asp:Panel>
    <asp:Panel ID="formActionsPanel" runat="server" Visible="False">
        <asp:LinkButton ID="aceptarLinkButton" runat="server" ValidationGroup="validar" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
    </asp:Panel>
<asp:ValidationSummary ID="ValidationSummary" runat="server" ValidationGroup="validar" ForeColor="Red" />
</asp:Content>
