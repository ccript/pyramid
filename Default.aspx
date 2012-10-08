<%@ Page Title="" enableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <script type="text/javascript" src="Resources/jquery-page-transitions/custom.js"></script>
    <style type="text/css">
        a:hover
{ 
   font-size: 110%;
 
}  
        .style1
        {
            width: 94%;
            margin-left: 13px;
        }
        .style2
        {
            width: 94px;
        }
        .style3
        {
         
        }
        .style4
        {
            height: 50px;
            text-align: center;
        }
        .style5
        {
            height: 50px;
        }
        .login{
background: rgb(252,255,244); /* Old browsers */
background: -moz-linear-gradient(top, rgba(252,255,244,1) 0%, rgba(233,233,206,1) 100%); /* FF3.6+ */
background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(252,255,244,1)), color-stop(100%,rgba(233,233,206,1))); /* Chrome,Safari4+ */
background: -webkit-linear-gradient(top, rgba(252,255,244,1) 0%,rgba(233,233,206,1) 100%); /* Chrome10+,Safari5.1+ */
background: -o-linear-gradient(top, rgba(252,255,244,1) 0%,rgba(233,233,206,1) 100%); /* Opera 11.10+ */
background: -ms-linear-gradient(top, rgba(252,255,244,1) 0%,rgba(233,233,206,1) 100%); /* IE10+ */
background: linear-gradient(top, rgba(252,255,244,1) 0%,rgba(233,233,206,1) 100%); /* W3C */
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#fcfff4', endColorstr='#e9e9ce',GradientType=0 ); /* IE6-9 */

}
        .style6
        {
            height: 50px;
            text-align: center;
        }
        .style10
        {
            height: 15px;
            text-align: center;
        }
        .style11
        {
            height: 50px;
            width: 33px;
        }
        .style12
        {
            font-family: Calibri;
            font-size: medium;
        }
    </style>
    
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   

<div ID="logindiv">
   
     
   
   
     
        <asp:Panel ID="Panel1" runat="server" CssClass="login" BackColor="#FFFFFF" Width="368px" 
            BorderColor="#C5E1F5" style="margin-left: 0px" Height="333px"  
            >
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" 
                style="font-family: Calibri; font-size: medium; color: #0000; text-align: center;" 
                Text="Login to your Pyramid Plus account"></asp:Label>
            <br />
            <br />
            <table class="style1">
                <tr>
                    <td class="style2">
                        <asp:Label ID="Label2" runat="server" Text="Email Address" CssClass="style3"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtUserName" CssClass="asptextbox" runat="server" height="20px" MaxLength="40"
                            Width="229px"></asp:TextBox>
                            
                 <%--           <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" 
                            TargetControlID="txtUserName" WatermarkCssClass="water" 
                            WatermarkText="name@example.com" />--%>
                           
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="Label3" runat="server" Text="Password" CssClass="style3"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtPassword"  CssClass="asptextbox" runat="server" height="20px" TextMode="Password"
                            Width="229px"></asp:TextBox>
        <%--                <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" 
                            TargetControlID="txtPassword" WatermarkCssClass="water" 
                            WatermarkText="password" />--%>
                           
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        </td>
                    <td class="style11">
                        <asp:Button ID="Button1" runat="server" CssClass="button" 
                            onclick="Button1_Click" Text="LogIn" />
                    </td>
                    <td class="style5">
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                            NavigateUrl="UI/Login/Recover.aspx?Show=Normal">Forgot your password?</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style12" colspan="3">
                        Dont have an account?<br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        <br />
                        <a href="UI/SignUp/signup.aspx">&nbsp;</a></td>
                    <td colspan="2">
                        <a href="UI/SignUp/signup.aspx">
                        <img src="Resources/images/signup_button.png" 
        style="text-align: center" border="0"/>
                        </a>
                    </td>
                </tr>
            </table>
           
        </asp:Panel>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtUserName" ErrorMessage="User Name required" 
            Display="None"></asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender runat="server" ID="PNReqE" 
            TargetControlID="RequiredFieldValidator1"  Width="250px" PopupPosition="Left" />
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtPassword" ErrorMessage="Password required" 
            Display="None"></asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender1" 
            TargetControlID="RequiredFieldValidator2"  Width="250px" PopupPosition="Left" />
        <br />
        <asp:CustomValidator ID="CustomValidator1" runat="server" 
            ControlToValidate="txtUserName" ErrorMessage="The User Name does not exist." 
            onservervalidate="CustomValidator1_ServerValidate" Display="None"></asp:CustomValidator>
            <asp:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender2" 
            TargetControlID="CustomValidator1"  Width="250px" PopupPosition="Left" />
        <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                    ControlToValidate="txtUserName" 
                    ErrorMessage="Email must be correct format" 
                    
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
            Display="None"></asp:RegularExpressionValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="White" 
            ShowSummary="False" />
    <asp:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender3" 
            TargetControlID="RegularExpressionValidator4"  Width="250px" PopupPosition="Left" />
    </div>
    <asp:DropShadowExtender ID="dse" runat="server"
    TargetControlID="Panel1" 
    Opacity=".5" 
    Rounded="true"
    TrackPosition="true" 
   />
<p >
    &nbsp;</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
</asp:Content>

