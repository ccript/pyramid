<%@ Page Title="" Language="C#" MasterPageFile="~/UI/User/MasterPage.master" AutoEventWireup="true" CodeFile="FriendsList.aspx.cs" Inherits="FriendsList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
         .hideFromScreen {display:none;}
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
                <asp:Panel ID="Panel1" runat="server">
                <asp:DropDownList ID="SearchDropDownList" runat="server">
                    <asp:ListItem Value="Name">By Name</asp:ListItem>
                    <asp:ListItem Value="CurrrentCity">By Currrent City</asp:ListItem>
                    <asp:ListItem Value="HomeTown">By HomeTown</asp:ListItem>
                    <asp:ListItem Value="School">By School</asp:ListItem>
                    <asp:ListItem Value="WorkPlace">By WorkPlace</asp:ListItem>
                    
                </asp:DropDownList>
                <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
                     <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkCssClass="water" 
                    TargetControlID="SearchTextBox" WatermarkText="Search User">
                    </asp:TextBoxWatermarkExtender>
                <asp:Button ID="SearchButton" runat="server" Text="Search"  CssClass="button"
                    onclick="SearchButton_Click" />
                </asp:Panel>  
            
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
            Confirmed
                <asp:GridView ID="GridViewFriendsList" runat="server" 
                    AutoGenerateColumns="False" DataKeyNames="Id" 
                    onselectedindexchanged="GridViewFriendsList_SelectedIndexChanged" 
                     AllowPaging="true" PageSize="6"
                    GridLines="None" ShowHeader="False" Width="100%" CellPadding="4" 
                    ForeColor="#333333" onpageindexchanging="GridViewFriendsList_PageIndexChanging">
                    
                    <Columns>
                       
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" 
                            SortExpression="Id" Visible="false" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="Image1" runat="server" Height="64px" ImageAlign="Middle" 
                                    ImageUrl='<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "../../Resources/ProfilePictures/{0}.jpg") %>' 
                                    PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "UserData.aspx?UserId={0}") %>' 
                                    Style="position: relative" Width="64px" />
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                 &nbsp; <asp:Label ID="Label3" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                               &nbsp; <asp:Label ID="Label4"  runat="server" Text='<%# Bind("Status") %>' CssClass="hideFromScreen"></asp:Label>
                              <br />
                      
                            </ItemTemplate>
                        </asp:TemplateField>
                   

                         <asp:CommandField  SelectText="Remove" ShowSelectButton="True" ControlStyle-ForeColor="#0066FF">
                         
                   
                        </asp:CommandField>
                         
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
            <asp:Label runat="server" id="pendinglabel" Text="Pending"></asp:Label>
                <asp:GridView ID="GridViewFriendsListRequest" runat="server" 
                    AutoGenerateColumns="False" DataKeyNames="FriendUserId" 
                    onselectedindexchanged="GridViewFriendsListRequest_SelectedIndexChanged" 
                    Width="100%" GridLines="None" ShowHeader="False" CellPadding="4" 
                    ForeColor="#333333">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                   
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="Image2" runat="server" Height="64px" ImageAlign="Middle" 
                                    ImageUrl='<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "../../Resources/ProfilePictures/{0}.jpg") %>' 
                                    PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "UserData.aspx?UserId={0}") %>' 
                                    Style="position: relative" Width="64px" />
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                            &nbsp; <asp:Label ID="Label3" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                             &nbsp; <asp:Label ID="Label5" CssClass="hideFromScreen" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                              <br />
                   
                            </ItemTemplate>
                        </asp:TemplateField>
                   <asp:CommandField  SelectText="Mutual Friends" ShowSelectButton="True"   ControlStyle-ForeColor="#0066FF"   />
                        <asp:BoundField DataField="FriendUserId" HeaderText="Id" ReadOnly="True" 
                            SortExpression="Id" Visible="false" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
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

