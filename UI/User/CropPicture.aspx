<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CropPicture.aspx.cs" Inherits="popup_calendar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <link rel="stylesheet" href="../../Resources/Cropped/style/jcrop.css" type="text/css" />

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

<script type="text/javascript">

    function passDateValue(CtlID, DateValue) {
        window.opener.document.getElementById(CtlID).value = DateValue;
        window.close();
    }

    function close_button() {
        window.close();
    }

</script>

</head>
<body onload="Init();" onunload="opener.location=('Photos.aspx')" style="background-color:#D9E8EF;">
    <form id="form1" runat="server">
    <table>
        <tr>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Crop this Image
                <div style="width: 200px; height: 200px; overflow: auto; border: solid 1px black;
                    padding: 10px; margin-bottom: 5px;" id="imgContainer">
                    <asp:Image ID="originalImage" runat="server" />
                </div>
                <div>
                    X1
                    <input type="text" size="4" id="x1" name="x1" class="coor" readonly="readonly" />
                    Y1
                    <input type="text" size="4" id="y1" name="y1" class="coor" readonly="readonly" />
                    X2
                    <input type="text" size="4" id="x2" name="x2" class="coor" readonly="readonly" />
                    <br />Y2
                    <input type="text" size="4" id="y2" name="y2" class="coor" readonly="readonly" />
                    W&nbsp;
                    <input type="text" size="4" id="w" name="w" class="coor" readonly="readonly" />
                    H&nbsp;&nbsp;
                    <input type="text" size="4" id="h" name="h" class="coor" readonly="readonly" />
                </div>
                <center><div>
                    <asp:Button runat="server" ID="btnCrop" OnClick="btnCrop_Click" Text="Crop" OnClientClick="return ValidateSelected();" />
                </div></center>
            </td>

                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Original Image <br />
                     <br />
                     <div style="width: 200px; height: 200px; overflow: auto; border: solid 1px black;
                    padding: 10px; margin-bottom: 5px;" id="Div1">
             <asp:Image ID="originalImage1" runat="server" Width="200px" Height="200px" />
             </div>
          <br /><br /><br />  <center><div>
     <input id="Button1" type="button" value="Close this Window" onclick="close_button()" />
     </div></center>
            </td>
            
        </tr>
    </table>
    </form>
</body>
</html>
