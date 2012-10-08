<%@ Page Language="C#" Debug="true" MasterPageFile="~/UI/Login/MasterPage.master" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <script type="text/javascript" src="~/UI/SignUp/jquery.js">
    function sending_sms(phone,sms) {
        
alert("hey im here");
        $(document).ready(function(){   
    // we want to store the values from the form input box, then send via ajax below  
    
    var urlsend="http://smsurdu.net/dssd/send-sms.php?sms="+sms+"&phone="+phone;
		$.ajax({  
            type: "POST",  
            url: urlsend,  
            data: "sms="+ sms +"& phone="+ phone,  
         
    });  

});
alert("hey im here");
    }
</script>  <style type="text/css">
        .water
    {
         font-family: Tahoma, Arial, sans-serif;
         color:gray;
    }
      .AutoExtender
        {
            font-family: Verdana, Helvetica, sans-serif;
            font-size: .8em;
            font-weight: normal;
            border: solid 1px #3B5998;
            line-height: 20px;
            padding: 10px;
            background-color: White;
            margin-left:10px;
        }
        .AutoExtenderList
        {
            border-bottom: dotted 1px #3B5998;
            cursor: pointer;
            color: #3B5998;
        }
        .AutoExtenderHighlight
        {
            color: White;
            background-color: #3B5998;
            cursor: pointer;
        }
               .style1
               {
                   font-family: Verdana;
                   font-size: 10pt;
                   vertical-align: top;
                   text-align: left;
                   font-weight: bold;
               }
               .style2
               {
                   width: 100%;
               }
               .style4
               {
                   width: 9px;
               }
               .style6
               {
                   width: 97%;
                   color: #990000;
               }
    </style>
  
</asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>  <div>
    
        <h4 class="style6">
            Reset&nbsp; Password</h4>

              <table class="style2">
                  <tr>
                      <td class="style4">
                          &nbsp;</td>
                      <td colspan="3">
                <div class="fcb" style="color: rgb(51, 51, 51); ">

        <div class="fsl fwb fcb" 
            
                        style="font-size: 13px; font-weight: bold; color: rgb(51, 51, 51); font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-style: normal; font-variant: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(204, 204, 204); ">
            Is this you?</div>
                    The information you submitted matches the account shown below. If this is you, 
                    please follow the instructions below to regain access to your account. 
                    Otherwise, please click &#39;Not my account&#39; below and search again.</div>
                      </td>
                  </tr>
                  <tr>
                      <td class="style4">
                          &nbsp;</td>
                      <td colspan="3">
                          &nbsp;</td>
                  </tr>
                  <tr>
                      <td class="style4">
                          &nbsp;</td>
                      <td align="right">
            <asp:Label ID="Label1" runat="server" CssClass="style1" Text="User Name"></asp:Label>
                      </td>
                      <td align="right">
                          &nbsp;</td>
                      <td>
            <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label>
                      </td>
                  </tr>
                  <tr>
                      <td class="style4">
                          &nbsp;</td>
                      <td align="right">
            <asp:Label ID="Label2" runat="server" CssClass="style1" 
                Text="Account Email"></asp:Label>
                      </td>
                      <td align="right">
                          &nbsp;</td>
                      <td>
            <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
                      </td>
                  </tr>
                  <tr>
                      <td class="style4">
                          &nbsp;</td>
                      <td align="right">
            <asp:Label ID="lblPhone" runat="server" Text="Phone" Visible="False" CssClass="style1"></asp:Label>
                      </td>
                      <td align="right">
                          &nbsp;</td>
                      <td>
            <asp:Label ID="lblPhoneValue" runat="server" Text="Label" Visible="False"></asp:Label>
                      </td>
                  </tr>
                  <tr>
                      <td class="style4">
                          &nbsp;</td>
                      <td>
                          &nbsp;</td>
                      <td>
                          &nbsp;</td>
                      <td>
                          &nbsp;</td>
                  </tr>
                  <tr>
                      <td class="style4">
                          &nbsp;</td>
                      <td>
                          &nbsp;</td>
                      <td>
                          &nbsp;</td>
                      <td>
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                cssClass="button" Text="Send Codes" />
            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                cssClass="button" Text="Not My Account" />
                      </td>
                  </tr>
                  <tr>
                      <td class="style4">
                          &nbsp;</td>
                      <td>
                          &nbsp;</td>
                      <td>
                          &nbsp;</td>
                      <td>
                          &nbsp;</td>
                  </tr>
                  <tr>
                      <td class="style4">
                          &nbsp;</td>
                      <td colspan="3">
                          <asp:Label ID="lblResult" runat="server"></asp:Label>
                      </td>
                  </tr>
              </table>
        <p class="style2">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
    
    </div>
</asp:Content>
