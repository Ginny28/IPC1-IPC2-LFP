<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultasArchivo.aspx.cs" Inherits="Fase2_IPC2_S2_2011.ConsultasArchivo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            color: #FFFFFF;
            font-family: "Comic Sans MS";
            font-size: medium;
        }
        .style2
        {
            color: #FFFFFF;
            width: 266px;
            font-family: "Comic Sans MS";
            font-size: medium;
            text-align: right;
        }
        .style3
        {
            color: #FFFFFF;
            font-family: "Comic Sans MS";
            font-size: medium;
            width: 624px;
        }
        .style4
        {
            font-size: xx-large;
        }
    </style>
</head>
<body bgcolor="#808080">
    <form id="form1" runat="server">
    <div>
    
    </div>
    <p class="style4">
        <strong>Consultas XPATH</strong></p>
    <p>
        <table bgcolor="Gray" style="width:100%; margin-left: 155px;">
            <tr>
                <td class="style2" bgcolor="Black">
                    &nbsp;</td>
                <td class="style3" bgcolor="Black">
                    &nbsp;</td>
                <td class="style1" bgcolor="Gray">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/HomeArchivo.aspx" 
                        style="text-align: right; font-size: xx-large">Atraz</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="style2" bgcolor="Black">
                    Cargar Archivo:</td>
                <td class="style3" bgcolor="Black">
                    Nombre Archivo:</td>
                <td class="style1" bgcolor="Gray">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" bgcolor="Black">
                    <asp:DropDownList ID="dropArchivos" runat="server" Height="22px" Width="266px">
                    </asp:DropDownList>
                </td>
                <td class="style3" bgcolor="Black">
                    <asp:TextBox ID="txtNombre" runat="server" Width="627px" Enabled="False"></asp:TextBox>
                </td>
                <td class="style1" bgcolor="Gray">
                    &nbsp;</td>
            </tr>
                        <tr>
                <td class="style2" bgcolor="Black">
                    <asp:Button ID="btnCargar" runat="server" style="margin-left: 212px" 
                        Text="Cargar" onclick="btnCargar_Click" />
                            </td>
                <td class="style3" bgcolor="Black">
                    &nbsp;</td>
                <td class="style1" bgcolor="Gray">
                    &nbsp;</td>
            </tr>
                        <tr>
                <td class="style2" bgcolor="Black">
                    &nbsp;</td>
                <td class="style3" bgcolor="Black">
                    <asp:TextBox ID="txtEditor" runat="server" Height="225px" TextMode="MultiLine" 
                        Width="627px" ontextchanged="txtEditor_TextChanged" Enabled="False"></asp:TextBox>
                            </td>
                <td class="style1" bgcolor="Gray">
                    &nbsp;</td>
            </tr>
                        <tr>
                <td class="style2" bgcolor="Black">
                    &nbsp;</td>
                <td class="style3" bgcolor="Black">
                    &nbsp;</td>
                <td class="style1" bgcolor="Gray">
                    &nbsp;</td>
            </tr>
                        <tr>
                <td class="style2" bgcolor="Black">
                    Consulta:</td>
                <td class="style3" bgcolor="Black">
                    <asp:TextBox ID="txtConsulta" runat="server" Width="627px"></asp:TextBox>
                            </td>
                <td class="style1" bgcolor="Gray">
                    &nbsp;</td>
            </tr>
                                    <tr>
                <td class="style2" bgcolor="Black">
                    &nbsp;</td>
                <td class="style3" bgcolor="Black">
                    <asp:Button ID="btnAceptar" runat="server" style="margin-left: 560px" 
                        Text="Aceptar" onclick="btnAceptar_Click1" />
                                        </td>
                <td class="style1" bgcolor="Gray">
                    &nbsp;</td>
            </tr>
                 <tr>
                <td class="style2" bgcolor="Black">
                    &nbsp;</td>
                <td class="style3" bgcolor="Black">
                    <asp:TextBox ID="EditorConsulta" runat="server" BackColor="#CCCCCC" 
                        Height="245px" TextMode="MultiLine" Width="627px"></asp:TextBox>
                     </td>
                <td class="style1" bgcolor="Gray">
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
</body>
</html>
