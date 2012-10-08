<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sending-sms-demo.aspx.cs" Inherits="sending_sms_demo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script type="text/javascript" src="jquery.js"></script>


<script language="javascript">
    function sending_sms() {
        alert("Hello world");

        $(document).ready(function(){   
    // we want to store the values from the form input box, then send via ajax below  
    var sms     = "Testingcool";
	var phone     = "03004650094";
	var urlsend="http://smsurdu.net/dssd/send-sms.php?sms="+sms+"&phone="+phone;
		$.ajax({  
            type: "POST",  
            url: urlsend,  
            data: "sms="+ sms +"& phone="+ phone,  
         
    });  
});

    }
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

        <input id="Button1" type="button" value="Click to send sms" onclick="sending_sms();" />

    </div>
    </form>
</body>
</html>
