<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlumnoInscripciones.aspx.cs" Inherits="UI.Web.AlumnoInscripciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <asp:Panel ID="Panel2" runat="server">
            <asp:DropDownList ID="ddlCursos" runat="server" Height="24px" Width="306px">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;<asp:Button ID="btnInscribirse" runat="server" Text="Inscribirse" OnClick="btnInscribirse_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblAdvertencia" runat="server" Enabled="False" Font-Bold="True" Font-Overline="False" Font-Size="Larger" ForeColor="Red" Text="ERROR: Usted ya esta inscripto en el curso." Visible="False"></asp:Label>
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server">
        <asp:GridView ID="grdInscripciones" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                <asp:BoundField DataField="Descripcion" HeaderText="Comision" SortExpression="Comision" />
                <asp:BoundField DataField="AnioCalendario" HeaderText="Año de Curso" SortExpression="AnioDeCurso" />
                <asp:BoundField DataField="Condicion" HeaderText="Condicion" SortExpression="Condicion" />
                <asp:BoundField DataField="Nota" HeaderText="Nota" SortExpression="Nota" />
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
</asp:Content>
