<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alumno.aspx.cs" Inherits="UI.Web.Alumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 502px">
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="gridPanel" runat="server">
                <br />
                <asp:GridView ID="grdAlumnos" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="grdAlumnos_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                        <asp:BoundField DataField="Legajo" HeaderText="Legajo" SortExpression="Legajo" />
                        <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="FechaNacimiento" SortExpression="FechaNacimiento" />
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="gridActionsPanel" runat="server" Height="20px">
                <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
            </asp:Panel>
            <br />
            <asp:Panel ID="formPanel" runat="server" Visible="False">
                <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
                <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="nombreValidator" runat="server" ControlToValidate="nombreTextBox" ErrorMessage="El nombre no puede estar vacío" ForeColor="Red">*</asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
                <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="apellidoTextBox" ErrorMessage="Ingrese Apellido" ForeColor="Red">*</asp:RequiredFieldValidator>

                <br />
                <asp:Label ID="fechaNacimientoLabel" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                <asp:TextBox ID="fechanacimientoTextBox" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fechanacimientoTextBox" ErrorMessage="Ingresar Fecha de Nacimiento con Formato dd/MM/aaaa" ForeColor="Red" ValidationExpression="^([0-2][0-9]|3[0-1])(\/|-)(0[1-9]|1[0-2])\2(\d{4})">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="fechanacimientoTextBox" ErrorMessage="La fecha de nacimiento no puede estar vacío" ForeColor="Red">*</asp:RequiredFieldValidator>

                <br />
                <asp:Label ID="Label1" runat="server" Text="E-Mail"></asp:Label>
                &nbsp;&nbsp;
                <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="emailTextBox" ErrorMessage="Ingresar Email Válido" ForeColor="Red" ValidationExpression="^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@(([a-zA-Z]+[\w-]+\.){1,2}[a-zA-Z]{2,4})$">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="emailTextBox" ErrorMessage="El correo no puede estar vacío" ForeColor="Red">*</asp:RequiredFieldValidator>
  
                <br />
                <asp:Label ID="Label2" runat="server" Text="Plan"></asp:Label>
                &nbsp;<asp:TextBox ID="planTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="planTextBox" ErrorMessage="Ingresar Plan" ForeColor="Red">*</asp:RequiredFieldValidator>

                <br />
                <asp:Label ID="legajoLabel" runat="server" Text="Legajo:"></asp:Label>
                <asp:TextBox ID="legajoTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="planTextBox" ErrorMessage="Ingrese Legajo" ForeColor="Red">*</asp:RequiredFieldValidator>

                <br />
                <asp:Label ID="telefonoLabel" runat="server" Text="Telefono: "></asp:Label>
                <asp:TextBox ID="telefonoTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="telefonoTextBox" ErrorMessage="Ingrese Numero de Telefono" ForeColor="Red">*</asp:RequiredFieldValidator>

                <br />
                <asp:Label ID="direccionLabel" runat="server" Text="Direccion:"></asp:Label>
                <asp:TextBox ID="direccionTextBox" runat="server"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="direccionTextBox" ErrorMessage="Ingresar Dirección" ForeColor="Red">*</asp:RequiredFieldValidator>


            </asp:Panel>
            <asp:Panel ID="formActionPanel" runat="server" Visible="False">
                &nbsp;
                <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            </asp:Panel>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>
