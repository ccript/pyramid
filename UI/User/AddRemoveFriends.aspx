<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/User/MasterPage.master" CodeFile="AddRemoveFriends.aspx.cs" Inherits="User_AddRemoveFriends" %>

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
    <table class="style1">
       
        <tr>
            <td>
                &nbsp;</td>
            <td>

            
            <br />
                <asp:Panel ID="Panel1" runat="server">
                
                <asp:DropDownList ID="SearchDropDownList" runat="server">
                    <asp:ListItem Value="Name">By Name</asp:ListItem>
                    <asp:ListItem Value="CurrrentCity">By Currrent City</asp:ListItem>
                    <asp:ListItem Value="HomeTown">By HomeTown</asp:ListItem>
                    <asp:ListItem Value="School">By School</asp:ListItem>
                    <asp:ListItem Value="WorkPlace">By WorkPlace</asp:ListItem>
                    
                </asp:DropDownList>
                <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
                <asp:Button ID="SearchButton" CssClass="button" runat="server" Text="Search" 
                    onclick="SearchButton_Click" />
                <br />
                </asp:Panel>
                <br />
                <br />
                <asp:GridView ID="GridViewFriendsList" runat="server" 
                    AutoGenerateColumns="False" DataKeyNames="Id" 
                    onselectedindexchanged="GridViewFriendsList_SelectedIndexChanged" 
                    CellPadding="4" 
                    ForeColor="#333333" GridLines="None" ShowHeader="False" Width="100%" AllowPaging="True" 
                    onpageindexchanging="GridViewFriendsList_PageIndexChanging" PageSize="5">
                    <Columns>
                        <asp:CommandField SelectText="Remove" ControlStyle-BorderStyle="Ridge" ShowSelectButton="True" />
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" Visible="false"
                            SortExpression="Id" />
                        
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="Image1" runat="server" Height="64px" ImageAlign="Middle" 
                                    ImageUrl='<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "../../Resources/ProfilePictures/{0}.jpg") %>' 
                                    PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "ChangeFriendList.aspx?UserId={0}") %>' 
                                    Style="position: relative" Width="64px" />
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                                       &nbsp; <asp:Label ID="Label3" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                            
                              <br />
                           
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField Visible="false" DataField="Status" />
                    </Columns>
                    <PagerSettings FirstPageText="First" LastPageText="Last" 
                        Mode="NextPreviousFirstLast" NextPageText="Next" Position="TopAndBottom" 
                        PreviousPageText="Prev" />
                    <PagerStyle CssClass="GridRowStyle" />
                       <RowStyle CssClass="GridRowStyle"/>
                    <AlternatingRowStyle CssClass="GridAlternatingRowStyle" />
                </asp:GridView> 
                
                
            </td>
            <td>
                &nbsp;</td>
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


            <td>

                <asp:GridView ID="GridViewFriendsListRequest" runat="server" 
                    AutoGenerateColumns="False" DataKeyNames="FriendUserId" 
                    onselectedindexchanged="GridViewFriendsListRequest_SelectedIndexChanged" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" ShowHeader="False" Width="100%" AllowPaging="True" 
                    onpageindexchanging="GridViewFriendsList_PageIndexChanging" PageSize="5">
                    <Columns>
                        <asp:CommandField SelectText="Mutual Friends" ControlStyle-BorderStyle="Ridge" ShowSelectButton="True" />
                        <asp:BoundField DataField="FriendUserId" Visible="false" HeaderText="Id" ReadOnly="True" 
                            SortExpression="Id" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="Image2" runat="server" Height="64px" ImageAlign="Middle" 
                                    ImageUrl='<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "../../Resources/ProfilePictures/{0}.jpg") %>' 
                                    PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "ViewProfile.aspx?UserId={0}") %>' 
                                    Style="position: relative" Width="64px" />
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                            &nbsp; <asp:Label ID="Label3" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                            
                              <br />
                           
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField Visible="false" DataField="Status" />
                    </Columns>
                    <PagerSettings FirstPageText="First" LastPageText="Last" 
                        Mode="NextPreviousFirstLast" NextPageText="Next" Position="TopAndBottom" 
                        PreviousPageText="Prev" />
                    <PagerStyle CssClass="GridRowStyle" />
                </asp:GridView>
            
            

            </td>

            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:GridView ID="GridView1" runat="server" >
                      
                        
                </asp:GridView>
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
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

