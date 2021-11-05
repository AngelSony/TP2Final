<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvertenciaAccesoUsuario.aspx.cs" Inherits="UI.Web.AdvertenciaAccesoUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" BackColor="#CC0000" BorderColor="Red" Font-Bold="True" Font-Italic="False" Font-Size="Larger" ForeColor="Black" Text="Usted NO tiene Permiso para ver este contenido"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnVolverMenu" runat="server" OnClick="btnVolverMenu_Click" Text="Volver al menu" />
        </div>
    </form>
</body>
</html>
