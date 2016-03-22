<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PRACTIK2._Default" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
        #form1
        {
            height: 1015px;
            width: 1144px;
        }
    </style>
</head>
<body bgcolor="#993399">
    <form id="form1" runat="server" style="border: thick dotted #008080">
    <div class="style1" 
        style="border: medium dashed #008000; width: 180px; margin-left: 475px; font-size: xx-large; font-family: 'Comic Sans MS'; font-weight: 100; font-style: normal; color: #000000; text-decoration: blink;">
    
        AIRLINES</div>
    <br />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" 
        Font-Names="Comic Sans MS" Font-Size="Large" Text="CARGAR UN ARCHIVO XML:"></asp:Label>
    <br />
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" Height="20px" 
        style="margin-left: 254px" Width="251px" />
    <br />
    <br />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click1" 
        Text="LEER XML" Font-Names="Comic Sans MS" Height="41px" 
        style="margin-left: 487px" Width="139px" />
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Reportes1"></asp:Label>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="R1.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="PRACTIK2.DS1TableAdapters.listaridreservacionTableAdapter">
    </asp:ObjectDataSource>
    <br />
    <br />
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <br />
    </form>
</body>
</html>
