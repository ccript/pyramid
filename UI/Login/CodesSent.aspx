<%@ Page Language="C#" MasterPageFile="~/UI/Login/MasterPage.master" AutoEventWireup="true" CodeFile="CodesSent.aspx.cs" Inherits="CodesSent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
         .style5
        {
            color: #666666;
            font-weight: bold;
            font-family: Verdana;
            font-size: 10pt;
            vertical-align: top;
            margin-top: 0px;
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
        .style3
        {
            width: 100%;
        }
    </style>
  
</asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>  
          <table class="style3">
              <tr>
                  <td>
                      &nbsp;</td>
                  <td colspan="3">
    
    
        <h4 
            style="margin: 0px; padding-top: 0px; padding-right: 0px; padding-bottom: 2px; padding-left: 0px; outline-style: none; outline-width: initial; outline-color: initial; line-height: 20px; min-height: 20px; vertical-align: bottom; font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-style: normal; font-variant: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); " 
            >
            Please check your emails and text messages</h4>
                  </td>
              </tr>
              <tr>
                  <td>
                      &nbsp;</td>
                  <td colspan="3">
                      &nbsp;</td>
              </tr>
              <tr>
                  <td>
                      &nbsp;</td>
                  <td colspan="3">
            <span>
            Check all your email addresses and phones listed below for a message from </span>Pyramid Plus</td>
              </tr>
              <tr>
                  <td>
                      &nbsp;</td>
                  <td colspan="3">
            Please enter the password reset code that was sent to you. This is not the same 
            as your password.</td>
              </tr>
              <tr>
                  <td>
                      &nbsp;</td>
                  <td colspan="3">
                      &nbsp;</td>
              </tr>
              <tr>
                  <td>
                      &nbsp;</td>
                  <td align="right" class="style5">
                        User Name:</td>
                  <td>
                      &nbsp;</td>
                  <td>
                        <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label>
                    </td>
              </tr>
              <tr>
                  <td>
                      &nbsp;</td>
                  <td align="right" class="style5">
                        Email:</td>
                  <td class="style5">
                        &nbsp;</td>
                  <td>
                        <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
                    </td>
              </tr>
              <tr>
                  <td>
                      &nbsp;</td>
                  <td align="right" class="style5">
       
        Password reset code:</td>
                  <td>
                      &nbsp;</td>
                  <td>
        <span class="mrm" 
            
                          style="color: rgb(51, 51, 51); font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 14px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); ">
        <label for="n" 
            style="cursor: pointer; color: rgb(102, 102, 102); font-weight: bold; vertical-align: middle; ">
                      <asp:TextBox ID="txtResetCode" runat="server" Width="88px" 
                  MaxLength="6" CssClass="asptextbox"></asp:TextBox>
        </label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtResetCode" ErrorMessage="Code required"></asp:RequiredFieldValidator>
        </span>
                  </td>
              </tr>
              <tr>
                  <td>
                      &nbsp;</td>
                  <td>
                      &nbsp;</td>
                  <td>
                      &nbsp;</td>
                  <td>
            <asp:Button   cssClass="button" ID="btnSubmitCode" runat="server" onclick="Button1_Click" 
                Text="Submit Code" />
            <asp:Button  cssClass="button" ID="Button2" runat="server" Text="Cancel" onclick="Button2_Click" />
                  </td>
              </tr>
          </table>
          <div>
    
    
        <div class="mvm uiP fsm" 
            style="margin-top: 10px; margin-bottom: 10px; font-size: 11px; line-height: 16px; color: rgb(51, 51, 51); font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); ">
            <br />
        </div>
    
    </div>
 </asp:Content>