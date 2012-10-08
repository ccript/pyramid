<%@ Page Language="C#" MasterPageFile="~/UI/Login/MasterPage.master" Debug="true" AutoEventWireup="true" CodeFile="SetNewPassword.aspx.cs" Inherits="SetNewPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
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
            width: 151px;
        }
        .style7
        {
            width: 9px;
        }
    </style>
  
</asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>  <div>
    
    
        <h4>
            Set New Password</h4>
        <p class="style2">
            <table class="style3">
                <tr>
                    <td class="style7">
                        &nbsp;</td>
                    <td class="style6">
                        <asp:Label ID="Label1" runat="server" Text="Enter new password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" style="margin-left: 0px" 
                            TextMode="Password" MaxLength="10" CssClass="asptextbox" width="243px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtPassword" ErrorMessage="Password Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        &nbsp;</td>
                    <td class="style6">
                        <asp:Label ID="Label2" runat="server" Text="Reconfirm password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" 
                            MaxLength="10" CssClass="asptextbox" Width="243px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtConfirmPassword" 
                            ErrorMessage="Reconfirm Password Required"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToCompare="txtConfirmPassword" ControlToValidate="txtPassword" 
                            ErrorMessage="The two passwords must match"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        &nbsp;</td>
                    <td class="style6">
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnResetPassword" runat="server"  cssClass="button"
                            onclick="btnResetPassword_Click" Text="Reset" Width="127px" />
                    </td>
                </tr>
            </table>
        </p>
    
    </div>
 </asp:Content>
