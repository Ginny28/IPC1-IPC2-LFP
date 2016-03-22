<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Fase2_IPC2_S2_2011.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 234px;
        }
        .style2
        {
            width: 249px;
        }
        .style3
        {
            width: 249px;
            height: 41px;
        }
        .style4
        {
            width: 234px;
            height: 41px;
        }
        .style5
        {
            height: 41px;
            width: 289px;
        }
        #form1
        {
            height: 503px;
            width: 989px;
        }
        .style6
        {
            width: 249px;
            height: 137px;
        }
        .style7
        {
            width: 234px;
            height: 137px;
        }
        .style8
        {
            height: 137px;
            width: 289px;
        }
        .style9
        {
            width: 249px;
            height: 31px;
        }
        .style10
        {
            width: 234px;
            height: 31px;
        }
        .style11
        {
            height: 31px;
            width: 289px;
        }
        .style12
        {
            color: #FFFFFF;
        }
        .style13
        {
            color: #FFFFFF;
            width: 289px;
        }
        .style14
        {
            width: 289px;
        }
    </style>
</head>
<body bgcolor="Gray">
    <form id="form1" runat="server">
    <div style="width: 830px">
    
        <table style="width: 75%; height: 155px;">
            <tr>
                <td class="style3">
                    <strong>XML READER</strong></td>
                <td class="style4">
                    </td>
                <td class="style5">
                    </td>
            </tr>
            <tr>
                <td class="style6">
                    </td>
                <td class="style7">
                    </td>
                <td class="style8">
                    </td>
            </tr>
                        <tr>
                <td class="style9">
                    </td>
                <td class="style10">
                    </td>
                <td class="style11" bgcolor="Black">
                    <span class="style12">Iniciar Seccion</span>n:</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td bgcolor="Black" class="style13">
                    Usuario</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    <asp:Label ID="labelMensaje" runat="server" style="text-align: right"></asp:Label>
                </td>
                <td bgcolor="Black" class="style14">
                    <asp:TextBox ID="txtUsuario" runat="server" Width="265px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="vUsuario" runat="server" 
                        ControlToValidate="txtUsuario" ErrorMessage="Escriba Usuario" ForeColor="White">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="vre" runat="server" 
                        ControlToValidate="txtUsuario" ErrorMessage="Usuario Mal Escrito" 
                        ForeColor="White" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </td>
            </tr>
                        <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td bgcolor="Black" class="style13">
                    Pasword</td>
            </tr>
                        <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td bgcolor="Black" class="style14">
                    <asp:TextBox ID="txtContraseña" runat="server" Width="265px" 
                        TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="vContraseña" runat="server" 
                        ControlToValidate="txtContraseña" ErrorMessage="Escriba Contraseña" 
                        ForeColor="White">*</asp:RequiredFieldValidator>
                            </td>
            </tr>
                        <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td bgcolor="Black" class="style14">
                    <asp:Button ID="btnLogin" runat="server" style="margin-left: 211px" 
                        Text="Login" Width="54px" onclick="btnLogin_Click" />
                            </td>
            </tr>
        </table>
    
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
            style="margin-left: 357px" Width="219px" />
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    
    </div>
    </form>
</body>
</html>
