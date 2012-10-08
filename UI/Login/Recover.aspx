<%@ Page Language="C#" MasterPageFile="~/UI/Login/MasterPage.master" AutoEventWireup="true" CodeFile="Recover.aspx.cs" Inherits="Recover" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
        .style1
        {
            width: 100%;
        }
        .style3
        {
            width: 558px;
        }
        .style5
        {
            width: 15px;
        }
        .style6
        {
            width: 499px;
        }
        .style7
        {
            width: 499px;
            height: 51px;
        }
    </style>
  
</asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>  
          <h6>
                  <asp:Label ID="lblAccountNotFound" runat="server" style="text-align: left" 
                      
              Text="We couldn't identify your account.<br/> The email address you entered does not belong to any account. Make sure that it is typed correctly. You may also try again using any other email, username or mobile phone number associated with your account." 
              Font-Size="Small" ForeColor="#CC0000" Visible="False"></asp:Label>
          </h6>
          <div>
    
              <h4>
            <asp:Label ID="Label1" runat="server" ForeColor="#A10D0D" 
                Text="Identify Account"></asp:Label>
              &nbsp;</h4>
        <table class="style3">
            <tr>
                <td colspan="3">
            <span 
    
                
                style="color: rgb(51, 51, 51); font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 16px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none; " 
                __designer:mapid="16c8"><span class="Apple-converted-space" __designer:mapid="16c9">&nbsp;&nbsp;&nbsp; Before we can reset your password, you need to enter the&nbsp;&nbsp; information below to 
help identify your&nbsp;account.<br __designer:mapid="16ca" />
            </span>
          
            </span></td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td rowspan="3">
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;</td>
                <td class="style6" rowspan="3">
        <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" Width="299px" 
                        BorderColor="Silver" BorderWidth="1px">
            <span 
    
                style="color: rgb(51, 51, 51); font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 16px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none; ">
            &nbsp; <span class="Apple-converted-space">
            <strong style="color: rgb(51, 51, 51); font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-size: 11px; font-style: normal; font-variant: normal; letter-spacing: normal; line-height: 14px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); ">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Enter email address or phone number.<br />
            <br />
            <span style="color: rgb(51, 51, 51); font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 16px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
            <asp:TextBox ID="txtEmailPhone" runat="server" CssClass="asptextbox" 
                MaxLength="40" Width="246px"></asp:TextBox>
                <asp:ValidatorCalloutExtender runat="server" ID="PNReqE" TargetControlID="RequiredFieldValidator1"  Width="250px" PopupPosition="Right" />
            <br />
            </strong>
            <strong style="color: rgb(51, 51, 51); font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-size: 11px; font-style: normal; font-variant: normal; letter-spacing: normal; line-height: 14px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); ">
            <br />
            <span style="color: rgb(51, 51, 51); font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 16px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>-----------------OR-----------------------------<br />
            <br />
            <span style="color: rgb(51, 51, 51); font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 16px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>Enter your Pyramid Plus username.<br />
            <br />
            <span style="color: rgb(51, 51, 51); font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 16px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
            <asp:TextBox ID="txtUserName" runat="server" CssClass="asptextbox" 
                Enabled="False" width="246px"></asp:TextBox>
            <br />
            <br />
            <span style="color: rgb(51, 51, 51); font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 16px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none;">
            <strong style="color: rgb(51, 51, 51); font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-size: 11px; font-style: normal; font-variant: normal; letter-spacing: normal; line-height: 14px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -----------------OR-----------------------------<br /> </strong></span>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Enter your name and a friend&#39;s name.</strong><br />
            <br />
            <strong style="color: rgb(51, 51, 51); font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-size: 11px; font-style: normal; font-variant: normal; letter-spacing: normal; line-height: 14px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <span style="color: rgb(51, 51, 51); font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 16px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></strong>
            <asp:TextBox ID="txtYourName" runat="server" CssClass="asptextbox" 
                Enabled="False" width="246px"></asp:TextBox>
            <br />
            <br />
            <strong style="color: rgb(51, 51, 51); font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-size: 11px; font-style: normal; font-variant: normal; letter-spacing: normal; line-height: 14px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <span style="color: rgb(51, 51, 51); font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 16px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></strong></span>
            <asp:TextBox ID="txtFriendsName" runat="server" width="246px" Enabled="False" 
                CssClass="asptextbox"></asp:TextBox>
            <table class="style1">
                <tr>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" cssClass="button" 
                            onclick="btnSearch_Click" Text="Search" />
                    </td>
                    <td>
                        <span style="color: rgb(51, 51, 51); font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 16px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none;">
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                            NavigateUrl="CantIdentifyAccount.aspx" 
                            style="font-family: Arial, Helvetica, sans-serif; font-size: small">Cant identify account</asp:HyperLink>
                        </span>
                    </td>
                </tr>
            </table>
          
            </span>
        </asp:Panel>
    
                </td>
                <td class="style6">
            <span 
    
                
                style="color: rgb(51, 51, 51); font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 16px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none; " 
                __designer:mapid="178c">
                    <span class="Apple-converted-space" __designer:mapid="178d">
            <span style="color: rgb(51, 51, 51); font-family: 'lucida grande', tahoma, verdana, arial, sans-serif; font-size: 11px; font-style: normal; font-variant: normal; letter-spacing: normal; line-height: 14px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); " 
                __designer:mapid="1795">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtEmailPhone" ErrorMessage="Please enter email id or phone" 
                 ForeColor="White"></asp:RequiredFieldValidator>
            </span>
                    </span>
          
            </span>
    
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
  </asp:Content>