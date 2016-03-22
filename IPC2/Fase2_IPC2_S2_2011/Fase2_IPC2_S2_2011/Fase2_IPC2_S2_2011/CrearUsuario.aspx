<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearUsuario.aspx.cs" Inherits="Fase2_IPC2_S2_2011.CrearUsuario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1
        {
            height: 32px;
        }
        .style1
        {
            width: 231px;
            text-align: right;
            color: #FFFFFF;
            font-family: "Comic Sans MS";
        }
        .style2
        {
            width: 86px;
        }
        .style3
        {
            width: 86px;
            text-align: right;
            color: #FFFFFF;
        }
        .style4
        {
            width: 27px;
        }
    </style>
</head>
<body bgcolor="Gray" style="height: 627px">
    <form id="form1" runat="server">
    <div>
    
    </div>
    <p>
        <strong style="font-family: 'Comic Sans MS'; font-size: x-large">Ingresar Datos 
        Usuario:</strong></p>
    <p style="height: 14px">
        <br />
        <br />
        <table style="width: 69%;">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td bgcolor="Black" class="style1">
                    Correo:</td>
                <td bgcolor="Black" class="style4">
                    <ul>
                        <li style="width: 218px; height: 22px">
                            <asp:TextBox ID="txtCorreo" runat="server" Width="210px"></asp:TextBox>
                        </li>
                    </ul>
                </td>
                <td class="style2">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtCorreo" ErrorMessage="Correo Invalido" ForeColor="White" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtCorreo" ErrorMessage="Correo Obligatorio" 
                        ForeColor="White">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td bgcolor="Black" class="style1">
                    Contraseña:</td>
                <td bgcolor="Black" class="style4">
                    <ul>
                        <li style="height: 22px; width: 215px">
                            <asp:TextBox ID="txtContraseña" runat="server" Height="22px" 
                                TextMode="Password" Width="210px"></asp:TextBox>
                        </li>
                    </ul>
                </td>
                <td class="style2">
                    <asp:CompareValidator ID="comparadorContraseña" runat="server" 
                        ControlToCompare="txtConfirmarContraseña" ControlToValidate="txtContraseña" 
                        ErrorMessage="Contraseñas no coinciden" ForeColor="White">*</asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtContraseña" ErrorMessage="Ingrese Contraseña" 
                        ForeColor="White">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style3">
                </td>
                <td bgcolor="Black" class="style1">
                    Confirmar Contraseña:</td>
                <td bgcolor="Black" class="style4">
                    <ul>
                        <li style="height: 22px; width: 217px">
                            <asp:TextBox ID="txtConfirmarContraseña" runat="server" Height="22px" 
                                TextMode="Password" Width="210px"></asp:TextBox>
                        </li>
                    </ul>
                </td>
                <td class="style2">
                </td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td bgcolor="Black" class="style1">
                    Nombres:</td>
                <td bgcolor="Black" class="style4">
                    <ul>
                        <li style="height: 22px; width: 215px">
                            <asp:TextBox ID="txtNombre" runat="server" Width="210px"></asp:TextBox>
                        </li>
                    </ul>
                </td>
                <td class="style2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtNombre" ErrorMessage="Ingrese Nombre" ForeColor="White">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td bgcolor="Black" class="style1">
                    Apellidos:</td>
                <td bgcolor="Black" class="style4">
                    <ul>
                        <li style="height: 22px; width: 215px">
                            <asp:TextBox ID="txtApellido" runat="server" Width="210px"></asp:TextBox>
                        </li>
                    </ul>
                </td>
                <td class="style2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtApellido" ErrorMessage="Ingrese Apellido" 
                        ForeColor="White">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td bgcolor="Black" class="style1">
                    Direccion:</td>
                <td bgcolor="Black" class="style4">
                    <ul>
                        <li style="height: 22px; width: 215px">
                            <asp:TextBox ID="txtDireccion" runat="server" Width="210px"></asp:TextBox>
                        </li>
                    </ul>
                </td>
                <td class="style2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="txtDireccion" ErrorMessage="Ingrese Direccion" 
                        ForeColor="White">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td bgcolor="Black" class="style1">
                    Telefono:</td>
                <td bgcolor="Black" class="style4">
                    <ul>
                        <li style="height: 22px; width: 218px">
                            <asp:TextBox ID="txtTelefono" runat="server" Width="210px"></asp:TextBox>
                        </li>
                    </ul>
                </td>
                <td class="style2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="txtTelefono" ErrorMessage="Ingrese Telefono" 
                        ForeColor="White">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td bgcolor="Black" class="style1">
                    Tipo Rol</td>
                <td bgcolor="Black" class="style4">
                    <asp:RadioButtonList ID="opcion" runat="server" ForeColor="White" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True">Usuario_Normal</asp:ListItem>
                        <asp:ListItem>Usuario_Administrador</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="style2">
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td bgcolor="Black" class="style1">
                    &nbsp;</td>
                <td bgcolor="Black" class="style4">
                    <asp:Button ID="Button1" runat="server" style="margin-left: 234px" 
                        Text="Crear" onclick="Button1_Click" Width="58px" />
                </td>
                <td class="style2">
                </td>
            </tr>
            <tr>
                <td bgcolor="Gray" class="style2">
                    &nbsp;</td>
                <td bgcolor="Gray" class="style1">
                    &nbsp;</td>
                <td bgcolor="Gray" class="style4">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Height="115px" 
                        Width="279px" />
                </td>
                <td class="style2">
                    &nbsp;</td>
            </tr>
        </table>
    </p>
    </form>
</body>
</html>
