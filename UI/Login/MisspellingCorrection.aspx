<%@ Page Language="C#" MasterPageFile="~/UI/Login/MasterPage.master" AutoEventWireup="true" CodeFile="MisspellingCorrection.aspx.cs" Inherits="MisspellingCorrection" %>

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
            font-size: small;
        }
        .style7
        {
            width: 100%;
        }
        .style8
        {
        }
        .style2
        {
            margin-left: 4px;
        }
        .style9
        {
            width: 179px;
        }
    </style>
  
</asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>  
          <table class="style7">
              <tr>
                  <td class="style8" colspan="2">
    
    <h4>
        Login : Fixed misspelling</h4>
                  </td>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr>
                  <td class="style8">
                      &nbsp;</td>
                  <td>
    <asp:Panel ID="Panel1" runat="server" BackColor="White" Height="232px" 
        Width="666px" BorderStyle="Solid" CssClass="style2" BorderColor="Silver" BorderWidth="1px">
        <table class="style7">
            <tr>
                <td colspan="3">
                    <span style=" font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 14px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px;  display: inline !important; float: none; ">
                    <span class="style5">&nbsp;Please re-enter your pasword<br /> </span>
                    <br class="style5" />
                    <span>&nbsp; It looks like you entered a slight misspelling of your email address or 
                    username. Please re-enter your password</span></span><br class="style5" />&nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    <span class="style3"><span class="style2"><span class="style5">LogIn as : </span>
                    <asp:Label ID="lblFullName" runat="server" CssClass="style5"></asp:Label>
                    <br class="style5" />
                    </span></span>
                </td>
                <td colspan="2">
                    <span class="style3"><span class="style2">
                    <asp:Label ID="lblUserName" runat="server" CssClass="style7"></asp:Label>
                    </span></span>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    <span class="style5"><span class="style6">&nbsp;Password:</span><span class="style5" 
                        dir="ltr"> </span></span>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtPassword" runat="server" BackColor="#FFFFCC" 
                        BorderStyle="Ridge" CssClass="asptextbox" MaxLength="10" TextMode="Password" 
                        Width="159px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="txtPassword" ErrorMessage="Password Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td>
                    <span class="style5">
                    <asp:Button ID="btnLogin" runat="server" cssClass="button" 
                        onclick="btnLogin_Click1" Text="Login" />
                    </span>
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink3" runat="server" 
                        NavigateUrl="~/UI/SignUp/signup.aspx">or Sign Up for Pyramid Plus</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td colspan="2">
                    <span class="style4"><strong>
                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="style6" 
                        NavigateUrl="../../Default.aspx">Login as different user</asp:HyperLink>
                    </strong></span>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td colspan="2">
                    <span class="style4">
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="style6" 
                        NavigateUrl="Recover.aspx?Sow=normal">Forgot your password?</asp:HyperLink>
                    </span>
                </td>
            </tr>
        </table>
    </asp:Panel>
                  </td>
                  <td>
                      &nbsp;</td>
              </tr>
          </table>
          <div>
    
    
 </asp:Content>
