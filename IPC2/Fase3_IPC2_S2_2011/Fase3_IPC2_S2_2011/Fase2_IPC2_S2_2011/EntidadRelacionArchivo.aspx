<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntidadRelacionArchivo.aspx.cs" Inherits="Fase2_IPC2_S2_2011.EntidadRelacionArchivo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-family: "Comic Sans MS";
            font-size: xx-large;
        }
        .style2
        {
            width: 49px;
        }
        .style3
        {
            width: 359px;
        }
        .style4
        {
            width: 49px;
            height: 144px;
        }
        .style5
        {
            width: 359px;
            height: 144px;
        }
        .style6
        {
            width: 30px;
        }
        .style7
        {
            width: 30px;
            height: 144px;
        }
    </style>
</head>
<body bgcolor="#808080">
    <form id="form1" runat="server">
    <p class="style1">
        <strong>Entidad Relacion:</strong></p>
    <table style="width:100%;">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:DropDownList ID="dropER" runat="server" Height="26px" Width="210px">
                </asp:DropDownList>
            </td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Button ID="VerER" runat="server" Height="28px" onclick="VerER_Click" 
                    style="margin-left: 137px" Text="Ver ER" Width="73px" />
            </td>
            <td class="style6">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/HomeArchivo.aspx" 
                    style="font-size: x-large">Atraz</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td class="style2">
            </td>
            <td class="style3">
                </td>
            <td class="style6">
                &nbsp;</td>
        </tr>
                <tr>
            <td class="style4">
            </td>
            <td class="style5">
                <asp:Image ID="imgIma" runat="server" Height="637px" Width="1123px" />
                    </td>
            <td class="style7">
                &nbsp;</td>
        </tr>
    </table>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    </form>
</body>
</html>
