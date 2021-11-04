<%@ Page Title="Personas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPersonas.aspx.cs" Inherits="UI.Web.frmPersonas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
                <asp:GridView ID="grvPersonas" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                        <asp:BoundField DataField="Legajo" HeaderText="Legajo" SortExpression="Legajo" />
                        <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="FechaNacimiento" SortExpression="FechaNacimiento" />
                        <asp:BoundField DataField="IDPlan" HeaderText="IDPlan" SortExpression="IDPlan" />
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
            <asp:Panel ID="gridActionsPanel" runat="server" Height="20px">
                <asp:LinkButton ID="editarLinkButton" runat="server">Editar</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="eliminarLinkButton" runat="server">Eliminar</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="nuevoLinkButton" runat="server">Nuevo</asp:LinkButton>
            </asp:Panel>
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Panel ID="formPanel" runat="server" Visible="False">
                <br />
                <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
                <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="nombreValidator" runat="server" ControlToValidate="nombreTextBox" ErrorMessage="El nombre no puede estar vacío" ForeColor="Red" ValidationGroup="validar">*</asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
                <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="apellidoTextBox" ErrorMessage="Ingrese Apellido" ForeColor="Red" ValidationGroup="validar">*</asp:RequiredFieldValidator>

                <br />
                <asp:Label ID="fechaNacimientoLabel" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                <asp:TextBox ID="fechanacimientoTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="fechanacimientoTextBox" ErrorMessage="La fecha de nacimiento no puede estar vacío" ForeColor="Red" ValidationGroup="validar">*</asp:RequiredFieldValidator>

                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="fechanacimientoTextBox" ErrorMessage="Ingrese Formato de Fecha dd/MM/aaaa" ForeColor="Red" ValidationExpression="^([0-2][0-9]|3[0-1])(\/|-)(0[1-9]|1[0-2])\2(\d{4})" ValidationGroup="validar">*</asp:RegularExpressionValidator>

                <br />
                <asp:Label ID="Label1" runat="server" Text="E-Mail"></asp:Label>
                &nbsp;&nbsp;
                <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="emailTextBox" ErrorMessage="Ingresar Email Válido" ForeColor="Red" ValidationExpression="^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@(([a-zA-Z]+[\w-]+\.){1,2}[a-zA-Z]{2,4})$" ValidationGroup="validar">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="emailTextBox" ErrorMessage="El correo no puede estar vacío" ForeColor="Red" ValidationGroup="validar">*</asp:RequiredFieldValidator>
  
                <br />
                <asp:Label ID="Label2" runat="server" Text="Plan"></asp:Label>
                &nbsp;
                <asp:DropDownList ID="ddPlanes" runat="server" Height="21px" Width="169px">
                </asp:DropDownList>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="ddPlanes" ErrorMessage="Seleecione un item Válido" ForeColor="Red" MaximumValue="999999" MinimumValue="1" ValidationGroup="validar">*</asp:RangeValidator>
                <br />
                <asp:Label ID="legajoLabel" runat="server" Text="Legajo:"></asp:Label>
                &nbsp;
                <asp:TextBox ID="legajoTextBox" runat="server"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="legajoTextBox" ErrorMessage="Ingrese un legajo" ForeColor="#CC0000" ValidationGroup="validar">*</asp:RequiredFieldValidator>

                <br />
                <asp:Label ID="telefonoLabel" runat="server" Text="Telefono: "></asp:Label>
                <asp:TextBox ID="telefonoTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="telefonoTextBox" ErrorMessage="Ingrese Numero de Telefono" ForeColor="Red" ValidationGroup="validar">*</asp:RequiredFieldValidator>

                <br />
                <asp:Label ID="direccionLabel" runat="server" Text="Direccion:"></asp:Label>
                <asp:TextBox ID="direccionTextBox" runat="server"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="direccionTextBox" ErrorMessage="Ingresar Dirección" ForeColor="Red" ValidationGroup="validar">*</asp:RequiredFieldValidator>


            </asp:Panel>
            <asp:Panel ID="formActionPanel" runat="server" Visible="False">
                &nbsp;
                <asp:LinkButton ID="aceptarLinkButton" runat="server" ValidationGroup="validar">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="cancelarLinkButton" runat="server">Cancelar</asp:LinkButton>
            </asp:Panel>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="Red" ValidationGroup="validar" />
</asp:Content>
