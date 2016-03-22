<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MostrarHistorial.aspx.cs" Inherits="Fase2_IPC2_S2_2011.MostrarHistorial" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style2
        {
            width: 192px;
            font-family: "Comic Sans MS";
        }
        .style3
        {
            width: 192px;
            height: 26px;
        }
        .style4
        {
            height: 26px;
        }
        .style5
        {
            width: 478px;
        }
        .style6
        {
            height: 26px;
            width: 478px;
        }
        .style7
        {
            width: 192px;
            color: #FFFFFF;
            font-weight: 700;
            font-family: "Comic Sans MS";
            font-size: small;
            margin-left: 40px;
        }
        .style8
        {
            width: 192px;
            color: #FFFFFF;
            font-weight: 700;
            font-family: "Comic Sans MS";
            font-size: medium;
        }
    </style>
</head>
<body bgcolor="#808080">
    <form id="form1" runat="server">
    <div>
    
    </div>
    <p>
        <table style="width:100%;">
            <tr>
                <td class="style8" bgcolor="Black">
                    Historial Por Usuario:</td>
                <td class="style5" bgcolor="Black" dir="rtl" rowspan="1">
                    &nbsp;</td>
                <td bgcolor="Gray">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" bgcolor="Black">
                    <strong style="color: #FFFFFF">Usuario:</strong></td>
                <td bgcolor="Black" class="style5" dir="rtl" rowspan="1">
                    &nbsp;</td>
                <td bgcolor="Gray">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" bgcolor="Black">
                    <asp:DropDownList ID="dropUsuario" runat="server" Height="22px" Width="241px">
                    </asp:DropDownList>
                </td>
                <td bgcolor="Black" class="style6" dir="rtl" rowspan="1">
                    &nbsp;</td>
                <td bgcolor="Gray" class="style4">
                    </td>
            </tr>
            <tr>
                <td class="style7" bgcolor="Black">
                    <asp:Button ID="btnMostrarHistorial" runat="server" 
                        onclick="btnMostrarHistorial_Click" Text="Mostrar" Width="58px" 
                        style="margin-left: 183px" />
                </td>
                <td bgcolor="Black" class="style5" dir="rtl" rowspan="1">
                    &nbsp;</td>
                <td bgcolor="Gray">
                    &nbsp;</td>
            </tr>
                        <tr>
                <td class="style8" bgcolor="Black">
                    Historial General:</td>
                <td bgcolor="Black" class="style5" dir="rtl" rowspan="1">
                    &nbsp;</td>
                <td bgcolor="Gray">
                    &nbsp;</td>
            </tr>
                        <tr>
                <td class="style7" bgcolor="Black">
                    <asp:Button ID="brnMostrarGeneral" runat="server" 
                        onclick="brnMostrarGeneral_Click" style="margin-left: 181px" Text="Mostrar" 
                        Width="58px" />
                            </td>
                <td class="style5" bgcolor="Black" dir="rtl" rowspan="1">
                    &nbsp;</td>
                <td bgcolor="Gray">
                    &nbsp;</td>
            </tr>
                        <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style5">
                    <asp:GridView ID="GridHistorial" runat="server" ForeColor="White" Width="590px" 
                        BackColor="Black">
                    </asp:GridView>
                            </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </p>
    </form>
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
    <p>
        &nbsp;</p>
</body>
</html>
