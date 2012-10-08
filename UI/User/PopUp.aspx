<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopUp.aspx.cs" Inherits="popup_calendar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <link rel="stylesheet" href="../../Resources/Cropped/style/jcrop.css" type="text/css" />

  <link rel="stylesheet" type="text/css" href="../../Resources/Stylesheet/style.css" />

    <script src="../../Resources/Cropped/js/jquery.min.js" type="text/javascript"></script>

    <script src="../../Resources/Cropped/js/jquery.Jcrop.js" type="text/javascript"></script>

    <script src="../../Resources/Cropped/js/crop.js" type="text/javascript"></script>
    <title></title>
    <script type="text/javascript">

        function passDateValue(CtlID, DateValue) {
            window.opener.document.getElementById(CtlID).value = DateValue;
            window.close();
        }

</script>
</head>
<body onload="Init();" onunload="opener.location=('Photos.aspx')">
    <form id="form1" runat="server">
<table class="style1">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Image ID="imgProfile" runat="server" style="text-align: center" 
                    Height="128px" Width="128px" BorderColor="#662D3D" 
                    BorderStyle="Solid" BorderWidth="2px" />
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />

        <asp:RegularExpressionValidator runat="server" ID="valUpTest" ControlToValidate="FileUpload1"
                               ErrorMessage="Image Files Only (jpg,jpeg,gif,png)" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$" /></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:LinkButton ID="lbtnremove" runat="server">Remove</asp:LinkButton>
            &nbsp;&nbsp;
                </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSaveUpload" CssClass="button" runat="server" Text="Save" 
                    onclick="btnSaveUpload_Click" />

            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="lblMsg" runat="server" Text="Label" ForeColor="Red" 
                    Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                     &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                     &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </form>
</body>
</html>
