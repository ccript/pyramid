<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/SignUp/MasterPage.master" CodeFile="User-Phone.aspx.cs" Inherits="SignUp_User_Email" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script type="text/javascript" src="jquery.js"></script>
<script language="javascript">
    function sending_sms(phone,sms) {
        
        alert("SMS SENT..!! It may take time depending upon SMS Up Time And SMS QUEUE");

        $(document).ready(function(){   
    // we want to store the values from the form input box, then send via ajax below  
    
    var urlsend="http://smsurdu.net/dssd/send-sms.php?sms="+sms+"&phone="+phone;
		$.ajax({  
            type: "POST",  
            url: urlsend,  
            data: "sms="+ sms +"& phone="+ phone,  
         
    });  

});

window.location="../../Default.aspx";
    }
</script>


    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 105px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



<br />
<br />
    <table class="style1">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
    <asp:Label ID="ProfileLabel" runat="server" Text="Phone No"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="phoneNo" runat="server" MaxLength="11" ></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="*" ControlToValidate="phoneNo"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ErrorMessage="Number Are Allowed" ValidationExpression="^\d+$" ControlToValidate="phoneNo"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button cssClass="button" ID="SubmitPhoneNo" runat="server" Text="Enter" 
                 width="100"   onclick="SubmitPhoneNo_Click"  />

            </td>
        </tr>
    </table>
    <br />

</asp:Content>