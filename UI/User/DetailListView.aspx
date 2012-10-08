<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/User/MasterPage.master" CodeFile="DetailListView.aspx.cs" Inherits="User_DetailListView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
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

<br />
    <asp:Panel ID="Panel1" runat="server">
    <table>
        <tr>
            <td>
            <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
            </td>
            <td>
            <asp:Button ID="SearchButton" runat="server" Text="Search" 
                    onclick="SearchButton_Click" CssClass="button"/>
               
            </td>
        </tr>
    </table>




       <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkCssClass="water" 
                    TargetControlID="SearchTextBox" WatermarkText="Search User">
                    </asp:TextBoxWatermarkExtender>
                <br /><br />
        </asp:Panel>
<asp:GridView ID="GridViewFriendsList" runat="server" AutoGenerateColumns="false" 
                     DataKeyNames="Id" GridLines="None" ShowHeader="False" Width="100%" 
                    AllowPaging="True" 
                    onpageindexchanging="GridViewFriendsList_PageIndexChanging" PageSize="6">

                    <Columns>
                        <asp:CommandField SelectText="Remove" ShowSelectButton="True"  Visible=false/>
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" 
                            SortExpression="Id" Visible="false" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="Image1" runat="server" Height="64px" ImageAlign="Middle" 
                                    ImageUrl='<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "../../Resources/ProfilePictures/{0}.jpg") %>' 
                                    PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "ViewProfile.aspx?UserId={0}") %>' 
                                    Style="position: relative" Width="64px" />
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                                       &nbsp; <asp:Label ID="Label3" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                            
                              <br />
                           
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Status" Visible="false" />
                    </Columns>
                    <PagerSettings FirstPageText="First" LastPageText="Last" 
                        Mode="NextPreviousFirstLast" NextPageText="Next" Position="TopAndBottom" 
                        PreviousPageText="Prev" />
                    <PagerStyle CssClass="GridRowStyle" />
                    
                       <RowStyle CssClass="GridRowStyle"/>
                    <AlternatingRowStyle CssClass="GridAlternatingRowStyle" />
                </asp:GridView> 


    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />


</asp:Content>