﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
        .auto-style2 {
            height: 238px;
        }
        .auto-style3 {
            height: 26px;
        }
        .auto-style4 {
            height: 26px;
            width: 164px;
        }
        .auto-style5 {
            width: 164px;
        }
        .auto-style6 {
            height: 22px;
            width: 164px;
        }
        .auto-style7 {
            height: 26px;
            width: 154px;
        }
        .auto-style8 {
            width: 154px;
        }
        .auto-style9 {
            height: 22px;
            width: 154px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style2">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Large" ForeColor="#000099" Text="¡Bienvenido al sistema Academia!"></asp:Label>
&nbsp;<table style="width:100%;">
                <tr>
                    <td class="auto-style4"></td>
                    <td class="auto-style7"></td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Ingresar Usuario:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtUsuario" runat="server" Columns="1" Width="146px"></asp:TextBox>
                    </td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="False" Text="Ingresar Contraseña:"></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtClave" runat="server" Width="145px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style9">
                        <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="cancelarBtn" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" Width="62px" />
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
        </div>
    </form>
</body>
</html>