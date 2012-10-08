<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/User/MasterPage.master" CodeFile="ManageList.aspx.cs" Inherits="User_ManageList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style5
        {
            color: #666666;
            font-weight: bold;
            font-family: Verdana;
            font-size: 10pt;
            vertical-align: top;
        }
        .style980
        {
            width: 9px;
        }
        .style981
        {
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
    
    <table>
    <tr>
        <td class="style980">
            &nbsp;</td>
        <td class="style981" colspan="2">
        <h1 class="style5">Here you can rename existing friends list </h1>
        </td>
    </tr>
        <tr>
            <td class="style980">
                &nbsp;</td>
            <td class="style981">
            <asp:Label ID="Label1" runat="server" Text="Current list name"></asp:Label>    
            </td>
            <td>
            <asp:TextBox ID="ListTextBox" ReadOnly="true" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style980">
                &nbsp;</td>
            <td class="style981">
            <asp:Label ID="Label2" runat="server" Text="New list name:"></asp:Label>
            </td>
            <td>
            <asp:TextBox ID="newTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style980">
                &nbsp;</td>
            <td class="style981">
            <asp:RequiredFieldValidator
        ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter a valid value." ControlToValidate="newTextBox"></asp:RequiredFieldValidator>
            </td>
            <td>
            <asp:Button ID="ListButton" CssClass="button" runat="server" Text="Add" 
        onclick="ListButton_Click" />

            </td>
        </tr>
    </table>

        
    <br />

        
        
            

</asp:Content>