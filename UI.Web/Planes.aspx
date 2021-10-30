<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="grdPanel" runat="server" Width="1374px">
                <asp:GridView ID="grdPlanes" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grdPlanes_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                        <asp:BoundField DataField="IDEspecialidad" HeaderText="IDEspecialidad" SortExpression="IDEspecialidad" />
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
            <asp:Panel ID="grdActionPanel" runat="server">
                <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="elmininarLinkButton" runat="server" OnClick="elmininarLinkButton_Click">Eliminar</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="formPanel" runat="server">
                <br />
                <asp:Label ID="Label1" runat="server" Text="Descripcion: "></asp:Label>
                <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="descripcionTextBox" ErrorMessage="Completar Descripciòn" ForeColor="Red" ValidationGroup="validar">*</asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Especialidad"></asp:Label>
                <asp:TextBox ID="especialdadTextBox" runat="server"></asp:TextBox>
            </asp:Panel>
            <asp:Panel ID="formActionPanel" runat="server">
                <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" ValidationGroup="validar">Aceptar</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            </asp:Panel>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="validar" />
            <br />
        </div>
    </form>
</body>
</html>
