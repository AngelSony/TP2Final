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
        <asp:LinkButton ID="editarLinkButton" runat="server">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server">Nuevo</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="idLabel" runat="server" Text="ID: "></asp:Label>
        <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="nombreValidator" runat="server" ControlToValidate="nombreTextBox" ErrorMessage="El nombre no puede estar vacío" ValidationGroup="validar" ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="idMateriaLabel" runat="server" Text="Materia: "></asp:Label>
        <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="apellidoValidator" runat="server" ControlToValidate="apellidoTextBox" ErrorMessage="El apellido no puede estar vacío" ForeColor="Red" ValidationGroup="validar">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="comisionLabel" runat="server" Text="Comisióm: "></asp:Label>
        <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="emailValidator" runat="server" ControlToValidate="emailTextBox" ErrorMessage="El email es inválido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="validar">*</asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="emailValidator1" runat="server" ControlToValidate="emailTextBox" ErrorMessage="El email no puede estar vacío" ForeColor="Red" ValidationGroup="validar">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
        <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="nombreUsuarioValidator" runat="server" ControlToValidate="nombreUsuarioTextBox" ErrorMessage="El nombre de usuario no puede estar vacío" ForeColor="Red" SetFocusOnError="True" ValidationGroup="validar">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
        <asp:TextBox ID="claveTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="claveValidator" runat="server" ControlToValidate="claveTextBox" ErrorMessage="La clave no puede estar vacía" ForeColor="Red" ValidationGroup="validar">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="claveTextBox" ErrorMessage="La clave debe tener al 8 caracteres o más y al menos una letra y un número" ForeColor="Red" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" ValidationGroup="validar">*</asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir Clave: "></asp:Label>
        <asp:TextBox ID="repetirClaveTextBox" TextMode="Password" runat="server"></asp:TextBox>
        <asp:CompareValidator ID="repetirClaveValidator" runat="server" ControlToCompare="claveTextBox" ControlToValidate="repetirClaveTextBox" ErrorMessage="Las claves no coinciden" ForeColor="Red" ValidationGroup="validar">*</asp:CompareValidator>
        <asp:RequiredFieldValidator ID="repetirClaveValidator1" runat="server" ControlToValidate="repetirClaveTextBox" ErrorMessage="Debe comfirmar su clave" ForeColor="Red" ValidationGroup="validar">*</asp:RequiredFieldValidator>
        <br />
    </asp:Panel>
    <asp:Panel ID="formActionsPanel" runat="server" Visible="False">
        <asp:LinkButton ID="aceptarLinkButton" runat="server" ValidationGroup="validar">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server">Cancelar</asp:LinkButton>
    </asp:Panel>
<asp:ValidationSummary ID="ValidationSummary" runat="server" ValidationGroup="validar" ForeColor="Red" />
</asp:Content>
