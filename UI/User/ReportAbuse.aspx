<%@ Page Language="C#" MasterPageFile="~/UI/User/MasterPage.master" AutoEventWireup="true" CodeFile="ReportAbuse.aspx.cs" Inherits="UI_User_ReportAbuse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
  .style5
        {
            color: #666666;
            font-weight: bold;
            font-family: Verdana;
            font-size: 9pt;
            vertical-align: top;
        }
         .style1
        {
         
           text-align:left;
  
        }
         </style>

         <link rel="stylesheet" href="../../Resources/Script/jqtransformplugin/fieldsJQuery.css" type="text/css" media="all" />
	<link rel="stylesheet" href="../../Resources/Script/demo.css" type="text/css" media="all" />
	
	<script type="text/javascript" src="../../Resources/Script/requiered/jquery.js" ></script>
	<script type="text/javascript" src="../../Resources/Script/jqtransformplugin/jquery.jqtransform.js" ></script>
	<script language="javascript">
	    $(function () {
	        $('form').jqTransform({ imgPath: 'jqtransformplugin/img/' });
	    });
	</script>
    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="margin-left: 70px;">
<br />
<br />
<br />

    <asp:Image ID="Photo" runat="server" Height="118px" Width="143px" />
    <br />
    <br />
<br />
Is this about you or a friend?
<br />
<br />

    <asp:DropDownList ID="AboutDropDownList" runat="server">
    </asp:DropDownList>

    <br /> <br />   <br />
    No, this photo is about something else:
    <br />
    <br />
    <asp:DropDownList ID="SomethingElseDropDownList" runat="server">
    </asp:DropDownList>

    <br /><br /> <br /><br />
    <asp:Button ID="ReportButton" CssClass="button" runat="server" Text="Report Spam" 
        onclick="ReportButton_Click" />
    <br />
    <br /> 
    <asp:Label ID="ReportConfirmLabel" runat="server" Text=""></asp:Label>
    <br />
    <br />
</div>
</asp:Content>