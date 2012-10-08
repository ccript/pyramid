<%@ Page Language="C#" MasterPageFile="~/UI/Login/MasterPage.master" AutoEventWireup="true" CodeFile="ReenterPassword.aspx.cs" Inherits="RenterPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
            color: #666666;
            font-weight: bold;
            font-family: Verdana;
            font-size: 10pt;
            vertical-align: top;
        }
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
        .style6
        {
            width: 100%;
        }
        .style2
        {
            margin-left: 3px;
        }
        .style7
        {
            width: 4px;
        }
        .style8
        {
            color: #990000;
        }
    </style>
  
</asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>  <div>
    
    <h4 class="style8">
        Re-enter Password</h4>
              <table class="style6">
                  <tr>
                      <td>
                          &nbsp;</td>
                      <td>
    <asp:Panel ID="Panel1" runat="server" BackColor="White" Height="232px" 
        Width="666px" BorderStyle="Solid" CssClass="style2" BorderColor="Silver" BorderWidth="1px">
        <table class="style6">
            <tr>
                <td colspan="3">
                    <span style=" font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 14px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px;  display: inline !important; float: none; ">
                    <span class="style5">Please re-enter your pasword</span><br class="style5" />
                    <span class="style5">The password you entered is incorrect. Please try again 
                    (make sure your caps lock is off).</span></span></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <span style=" font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 14px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px;  display: inline !important; float: none; ">
                    <span class="style5">Forgot your password?&nbsp;</span></span><a class="style5" 
                        
                        style="cursor: pointer; text-decoration: none; font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-size: 12px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 14px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(204, 204, 204); ">Request 
                    a new one.</a></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right">
                    <span class="style3"><span class="style2"><span class="style5">LogIn as
                    <asp:Label ID="lblFullName" runat="server" CssClass="style7"></asp:Label>
                    : </span>
                    </span></span>
                </td>
                <td colspan="2">
                    <span class="style3"><span class="style2">
                    <asp:Label ID="lblUserName" runat="server" CssClass="style7"></asp:Label>
                    </span></span>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right">
                    <h3>
                        <span class="style5"><span class="style5">Password:</span><span class="style5">
                        </span></span>
                    </h3>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtPassword" runat="server" BackColor="#FFFFCC" 
                        BorderStyle="Ridge" CssClass="asptextbox" MaxLength="10" TextMode="Password" 
                        Width="159px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtPassword" ErrorMessage="* Required"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <span class="style4"><strong><span class="style5">
                    <asp:Button ID="btnLogin" runat="server" cssClass="button" Height="26px" 
                        onclick="btnLogin_Click" Text="Login" />
                    </span></strong></span>
                </td>
                <td>
                    <span class="style4"><strong><span class="style5">
                    <asp:HyperLink ID="HyperLink3" runat="server" 
                        NavigateUrl="../SignUp/signup.aspx">or Sign Up for Pyramid Plus</asp:HyperLink>
                    </span></strong></span>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                </td>
                <td colspan="2">
                    <span class="style4"><strong>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="../../Default.aspx">Login as different user</asp:HyperLink>
                    </strong></span>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="2">
                    <span class="style4"><strong>
                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl="Recover.aspx?Show=normal">Forgot your password?</asp:HyperLink>
                    </strong></span>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <span class="style4"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /></strong>
        </span>
    </asp:Panel>
                      </td>
                  </tr>
                  <tr>
                      <td>
                          &nbsp;</td>
                      <td>
                          &nbsp;</td>
                  </tr>
              </table>

 </asp:Content>
