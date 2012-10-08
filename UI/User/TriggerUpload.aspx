<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="TriggerUpload.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Advanced Upload</title>
	<link href="../../Resources/Uploadify/css/default.css" rel="stylesheet" type="text/css" />
	<link href="../../Resources/Uploadify/css/uploadify.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="../../Resources/Uploadify/scripts/jquery-1.4.2.min.js"></script>
	<script type="text/javascript" src="../../Resources/Uploadify/scripts/swfobject.js"></script>
	<script type="text/javascript" src="../../Resources/Uploadify/scripts/jquery.uploadify.v2.1.4.min.js"></script> 
</head>
<body style='background:black;' onunload="opener.location=('ManagePhotos.aspx')">
<div id='main'>
        <form id="form1" runat="server">
			<br/>
              <center> <h1> Upload Photos</h1> </center>
           <div class="demo">
			
                <asp:FileUpload ID="FileUpload1" runat="server" />
				
				<br />
				<a href="#" id="startUploadLink">Start Upload</a>&nbsp; |&nbsp;
				<a href="#" id="clearQueueLink">Clear</a>
                <br />
               
              
                <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" 
                    oncheckedchanged="CheckBox2_CheckedChanged" />High Resoultion
            </div> 
        </form>
</div>
</body>
</html>
<script type = "text/javascript">
    var UploadifyAuthCookie = '<% = Request.Cookies[FormsAuthentication.FormsCookieName] == null ? string.Empty : Request.Cookies[FormsAuthentication.FormsCookieName].Value %>';
    var UploadifySessionId = '<%= Session.SessionID %>';

	$(document).ready( function() 
	{ 
		$("#<%=FileUpload1.ClientID%>").uploadify({
		    'uploader': '../../Resources/Uploadify/scripts/uploadify.swf',
		'script'         : 'Upload.ashx',
		'cancelImg': '../../Resources/Uploadify/images/cancel.png',
		'folder': '../../Resources/UserPhotos/',
		'scriptData': { RequireUploadifySessionSync: true, SecurityToken: UploadifyAuthCookie, SessionId: UploadifySessionId },
		
		'multi'          : true

		});
		
		$("#startUploadLink").click( function()
		{			
			$('#<%=FileUpload1.ClientID%>').uploadifyUpload();
			return false;
		});
		
		$("#clearQueueLink").click( function()
		{
			$("#<%=FileUpload1.ClientID%>").uploadifyClearQueue();							
			return false;			
		});

	});

</script> 
<script type = "text/javascript">
<!--
    function refreshParent() {
        window.opener.location.href = window.opener.location.href;

        if (window.opener.progressWindow) {
            window.opener.progressWindow.close()
        }
        window.close();
    }
  

//-->
</script>