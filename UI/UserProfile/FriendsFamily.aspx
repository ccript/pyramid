<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserProfile/MasterPage.master" AutoEventWireup="true" CodeFile="FriendsFamily.aspx.cs" Inherits="FriendsFamily" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
 

<table class="style1" width="100%">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                Relationship Status:</td>
            <td>
                  <asp:DropDownList ID="lstRelationshipStatus" runat="server">
                    <asp:ListItem Value="Single">Single</asp:ListItem>
                    <asp:ListItem Value="Married">Married</asp:ListItem>
                    <asp:ListItem Value="Engaged">Engaged</asp:ListItem>
                    <asp:ListItem Value="Windowed">Widowed</asp:ListItem>
                    <asp:ListItem Value="Windowed">Divorced</asp:ListItem>
                    <asp:ListItem Value="In a relationship">In a relationship</asp:ListItem>
                    <asp:ListItem Value="In a open relationship">In a open relationship</asp:ListItem>
            
                </asp:DropDownList></td>
            <td>
              &nbsp;
            </td>
        </tr>

          <tr>
            <td>
                &nbsp;</td>
            <td colspan="2">
                <hr /></td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                Friends:</td>
            <td>
                 <asp:DataList ID="DataListFriends" runat="server" 
                    RepeatColumns="5" Width="300px">
                    <ItemTemplate>
                        &nbsp;<asp:Label ID="FirstNameLabel" runat="server" 
                            Text='<%# Eval("FirstName") %>' /> &nbsp;<asp:Label ID="Label1" runat="server" 
                            Text='<%# Eval("LastName") %>' />
                        <br />
                        <br />
<br />
                    </ItemTemplate>
                </asp:DataList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                            &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
          <tr>
            <td>
                &nbsp;</td>
            <td colspan="2">
                <hr /></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                Family:</td>
            <td>
                  <asp:DropDownList ID="lstFriends" runat="server" 
                    AppendDataBoundItems="True" 
                    DataTextField="FirstName" DataValueField="Id" 
                    DataSourceID="ObjectDataSource1">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    SelectMethod="getAllFriendsListName" TypeName="BuinessLayer.FriendsBLL">
                    <SelectParameters>
                        <asp:SessionParameter Name="UserId" SessionField="UserId" Type="String" />
                        <asp:Parameter DefaultValue=Global.CONFIRMED Name="status" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                </asp:DropDownList>
                <asp:DropDownList ID="lstRelation" runat="server">
                    <asp:ListItem>Select Relation</asp:ListItem>
                    <asp:ListItem>Brother</asp:ListItem>
                    <asp:ListItem>Husband</asp:ListItem>
                    <asp:ListItem>Sister</asp:ListItem>
                    <asp:ListItem>Son</asp:ListItem>
                    <asp:ListItem>Father</asp:ListItem>
                    <asp:ListItem>Uncle</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:DataList ID="DataList2" runat="server"
                    RepeatColumns="5" Width="300px">
                    <ItemTemplate>
                        <br />
&nbsp;<asp:Label ID="FirstNameLabel" runat="server" style="font-weight: 700" 
                            Text='<%# Eval("FirstName") %>' />
                        <br />
                        <asp:Label ID="RelationLabel" runat="server" Text='<%# Eval("Relation") %>' />
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
            </td>
            <td>
                &nbsp;</td>
        </tr>

          <tr>
            <td>
                &nbsp;</td>
            <td colspan="2">
                <hr /></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save Changes" 
                    onclick="btnSave_Click"  />
            </td>
            <td>
                <asp:Image ID="imgSave" runat="server" ImageUrl="~/Resources/images/Icon/check.png" 
                    Visible="False" />
                <asp:Label ID="lblSave" runat="server" Text="Save changes is successful" 
                    ForeColor="#006600" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

