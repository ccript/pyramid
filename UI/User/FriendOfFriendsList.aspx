<%@ Page Title="" Language="C#" MasterPageFile="~/UI/User/MasterPage.master" AutoEventWireup="true" CodeFile="FriendOfFriendsList.aspx.cs" Inherits="User_FriendOfFriendsList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 252px;
        }
    </style>
</asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  

    <br />
    <table class="style1">
        <tr>
            <td>
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style2">
                <asp:GridView ID="GridViewFriendsOfFriend" runat="server" AutoGenerateColumns="False" 
                     DataKeyNames="FriendUserId" 
                    style="margin-right: 67px" 
                    onselectedindexchanged="GridViewFriendsOfFriend_SelectedIndexChanged"
                    onpageindexchanging="GridViewFriendsOfFriend_PageIndexChanging"
                    onrowcommand="GridViewFriendsOfFriend_RowCommand" AllowSorting="False" AllowPaging="True" PageSize="5" PagerSettings-PageButtonCount="10" EnableSortingAndPagingCallbacks="False" PagerSettings-Mode="Numeric"
                    CellPadding="4" 
                    ForeColor="#333333" GridLines="None" ShowHeader="False" Width="100%"
                    >
                    <Columns>
                    
                    
                        <asp:TemplateField>
                          <ItemTemplate>
                        <asp:ImageButton ID="Image1" runat="server" ImageAlign="Middle" 
                  ImageUrl='<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "../../Resources/ProfilePictures/{0}.jpg") %>' 
                   PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "UserData.aspx?UserId={0}") %>'
                            Style="position: relative" Height="64px" Width="64px" />
                              <asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                          &nbsp; <asp:Label ID="Label2" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                            
                             
                         
                            <br />
                    </ItemTemplate>
                        
                        </asp:TemplateField>
                             
                      
                    </Columns>
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
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

