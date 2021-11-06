<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroNota.aspx.cs" Inherits="UI.Web.RegistroNota" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

        <div>
            <asp:Panel ID="grdPanel" runat="server" Width="1374px">
                <asp:Label ID="Label2" runat="server" Text="Curso: "></asp:Label>
                <asp:DropDownList ID="cursosDropDown" runat="server" Height="16px" Width="126px" AutoPostBack="True" OnSelectedIndexChanged="cursosDropDown_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:GridView ID="grvNotas" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grvNotas_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                        <asp:BoundField DataField="Alumno" HeaderText="Alumno" SortExpression="Alumno" />
                        <asp:BoundField DataField="Condicion" HeaderText="Condición" SortExpression="Condicion" />
                        <asp:BoundField DataField="Nota" HeaderText="Nota" />
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
            <asp:Panel ID="grdActionPanel" runat="server" Visible="False">
                <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="elmininarLinkButton" runat="server" OnClick="elmininarLinkButton_Click">Eliminar</asp:LinkButton>
                &nbsp;
                </asp:Panel>
            <asp:Panel ID="formPanel" runat="server" Visible="False">
                <asp:Label ID="Label1" runat="server" Text="Alumno: "></asp:Label>
                <asp:TextBox ID="alumnoTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="alumnoTextBox" ErrorMessage="Debe ingresar una Descripción" ForeColor="Red" ValidationGroup="validar">*</asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Condición: "></asp:Label>
                <asp:TextBox ID="condicionTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="condicionTextBox" ErrorMessage="Debe ingresar las Horas Semanales" ForeColor="Red" ValidationGroup="validar">*</asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Nota: "></asp:Label>
                <asp:TextBox ID="notaTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="notaTextBox" ErrorMessage="Debe ingresar las Horas totales" ForeColor="Red" ValidationGroup="validar">*</asp:RequiredFieldValidator>
                <br />
            </asp:Panel>
            <asp:Panel ID="formActionPanel" runat="server" Visible="False">
                <asp:LinkButton ID="aceptarLinkButton" runat="server" ValidationGroup="validar" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            </asp:Panel>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="validar" />
            <br />
        </div>
</asp:Content>
