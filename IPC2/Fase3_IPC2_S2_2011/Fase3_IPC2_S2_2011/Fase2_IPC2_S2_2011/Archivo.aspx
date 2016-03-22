<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Archivo.aspx.cs" Inherits="Fase2_IPC2_S2_2011.Archivo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 216px;
        }
        .style2
        {
            width: 146px;
        }
        .style3
        {
            width: 216px;
            height: 30px;
        }
        .style4
        {
            width: 146px;
            height: 30px;
        }
        .style5
        {
            height: 30px;
        }
        .style6
        {
            width: 216px;
            font-family: "Comic Sans MS";
            font-size: large;
            color: #FFFFFF;
        }
        .style7
        {
            width: 146px;
            font-size: medium;
            font-family: "Comic Sans MS";
            color: #FFFFFF;
        }
        .style8
        {
            font-family: "Comic Sans MS";
        }
        </style>
</head>
<body bgcolor="#808080">
    <form id="form1" runat="server">
    <div style="height: 25px" class="style8">
    
        <strong>Editor de Archivos XML</strong></div>
    <p>
        <table style="width:100%; margin-left: 65px;">
             <tr>
                <td class="style1" bgcolor="Black">
                   
                    &nbsp;</td>
                <td class="style2" bgcolor="Black">
                    <asp:TextBox ID="FechaHora" runat="server" BackColor="Black" BorderStyle="None" 
                        ForeColor="White" style="margin-left: 579px" Width="151px" Enabled="False" 
                        Height="19px"></asp:TextBox>
                </td>
                <td bgcolor="Gray">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" bgcolor="Black">
                   
                </td>
                <td class="style2" bgcolor="Black">
                    &nbsp;</td>
                <td bgcolor="Gray">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/HomeArchivo.aspx" 
                        style="font-size: x-large">Atraz</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="style6" bgcolor="Black">
                    <strong>Cargar Archivo:</strong></td>
                <td class="style7" bgcolor="Black">
                    <strong>Nombre Archivo:</strong></td>
                <td bgcolor="Gray">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" bgcolor="Black">
                    <asp:DropDownList ID="cargaArchivos" runat="server" Height="22px" Width="215px">
                    </asp:DropDownList>
                </td>
                <td class="style4" bgcolor="Black">
                    <asp:TextBox ID="txtNombreArchivo" runat="server" Width="730px"></asp:TextBox>
                </td>
                <td class="style5" bgcolor="Gray">
                    </td>
            </tr>
            <tr>
                <td class="style1" bgcolor="Black">
                    <asp:Button ID="btnCargar" runat="server" onclick="btnCargar_Click1" 
                        style="margin-left: 118px" Text="Cargar Archivo" Width="97px" />
                </td>
                <td class="style2" bgcolor="Black">
                    &nbsp;</td>
                <td bgcolor="Gray">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" bgcolor="Black">
                    &nbsp;</td>
                <td class="style2" bgcolor="Black">
                    <asp:TextBox ID="txtArea" runat="server" Height="408px" TextMode="MultiLine" 
                        Width="730px"></asp:TextBox>
                </td>
                <td bgcolor="Gray">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" bgcolor="Black">
                    &nbsp;</td>
                <td class="style2" bgcolor="Black">
                    <asp:Button ID="Almacenar" runat="server" onclick="Crear_Click" 
                        Text="Almacenar" style="margin-left: 636px" Enabled="False" />
                </td>
                <td bgcolor="Gray">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" bgcolor="Black">
                   
                    &nbsp;</td>
                <td class="style2" bgcolor="Black">
     
                    <asp:Button ID="Button1" runat="server" style="margin-left: 637px" 
                        Text="Validar" onclick="Button1_Click" Width="93px" />
                </td>
                <td bgcolor="Gray">
                    &nbsp;</td>
            </tr>
            <tr>
                <td bgcolor="Black">
                    <asp:FileUpload ID="fuArchivos" runat="server" style="margin-left: 0px" 
                        Width="214px" />
                </td>
                <td class="style2" bgcolor="Black">
                    <asp:Button ID="btnCargarGBD" runat="server" style="margin-left: 0px" 
                        Text="Almacenar BD" onclick="btnCargar_Click" />
                </td>
                <td bgcolor="Gray">
                    &nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
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
</body>
</html>
