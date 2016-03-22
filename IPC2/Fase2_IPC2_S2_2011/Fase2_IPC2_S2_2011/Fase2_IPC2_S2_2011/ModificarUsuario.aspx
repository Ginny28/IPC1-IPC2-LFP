<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="Fase2_IPC2_S2_2011.ModificarUsuario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 218px;
        }
        .style2
        {
            width: 218px;
            color: #FFFFFF;
        }
        .style3
        {
            width: 158px;
        }
        .style4
        {
            font-size: xx-large;
            font-family: "Comic Sans MS";
        }
    </style>
</head>
<body bgcolor="#808080">
    <form id="form1" runat="server">
    <div>
    
    </div>
    <p class="style4">
        <strong>Modificar Usuario:</strong></p>
    <p>
        <table style="width:100%;">
            <tr>
                <td bgcolor="Black" class="style2">
                    Datos Personales:</td>
                <td bgcolor="Black" class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td bgcolor="Black" class="style2">
                    Nombre:</td>
                <td bgcolor="Black" class="style3">
                    <asp:TextBox ID="txtNombre" runat="server" BackColor="Black" BorderStyle="None" 
                        ForeColor="White" Width="161px" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td bgcolor="Black" class="style2">
                    Apellidos:</td>
                <td bgcolor="Black" class="style3">
                    <asp:TextBox ID="txtApellido" runat="server" BackColor="Black" 
                        BorderStyle="None" ForeColor="White" Width="161px" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
             <tr>
                <td bgcolor="Black" class="style2">
                    Telefono:</td>
                <td bgcolor="Black" class="style3">
                    <asp:TextBox ID="txtTelefono" runat="server" BackColor="Black" 
                        BorderStyle="None" ForeColor="White" Width="161px" Enabled="False"></asp:TextBox>
                 </td>
                <td>
                    &nbsp;</td>
            </tr>
                         <tr>
                <td bgcolor="Black" class="style2">
                    &nbsp;</td>
                <td bgcolor="Black" class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
                         <tr>
                <td bgcolor="Black" class="style2">
                    Cambiar Contraseña (Opcional):</td>
                <td bgcolor="Black" class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
                         <tr>
                <td bgcolor="Black" class="style2">
                    Contraseña Nueva:</td>
                <td bgcolor="Black" class="style3">
                    <asp:TextBox ID="txtContraseñaNueva" runat="server" Width="160px" 
                        TextMode="Password"></asp:TextBox>
                             </td>
                <td>
                    &nbsp;</td>
            </tr>
                         <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Button ID="btnModificar" runat="server" onclick="btnModificar_Click" 
                        style="margin-left: 82px" Text="Modificar" />
                             </td>
                <td>
                    &nbsp;</td>
            </tr>
                         <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
                         <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
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
</body>
</html>
