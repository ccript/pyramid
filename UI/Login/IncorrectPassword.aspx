<%@ Page Language="C#" MasterPageFile="~/UI/Login/MasterPage.master" Debug="true" AutoEventWireup="true" CodeFile="IncorrectPassword.aspx.cs" Inherits="IncorrectPassword" %>

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
         .style1
        {
           
            font-family: Verdana;
            font-size: 10pt;
            vertical-align: top;
            text-align:left;
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
    </style>
  
</asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>  <div>
    
        <h4>
            Incorrect Password</h4>
        <p class="style1">
            &nbsp;&nbsp;
            The password you entered wasn&#39;t valid.</p>
        <p class="style1">
        &nbsp;&nbsp; 
        <asp:Label ID="lblFullName" runat="server" CssClass="style5"></asp:Label>
        </p>
        <p class="style1">
            &nbsp;&nbsp;
        <asp:Label ID="lblUserName" runat="server" CssClass="style7"></asp:Label>
        </p>
        <p class="style1">
            <asp:Button ID="btnResetPassword"  cssClass="button"  runat="server" 
                onclick="btnResetPassword_Click" Text="Reset Password" />
            <asp:Button ID="btnTryAgain"  cssClass="button" runat="server" onclick="btnTryAgain_Click" 
                Text="Try Again" />
        </p>
    
</asp:Content>