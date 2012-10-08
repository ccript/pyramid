<%@ Page Title="" Language="C#" MasterPageFile="~/UI/User/MasterPage.master" AutoEventWireup="true" CodeFile="FriendRequests.aspx.cs" Inherits="User_FriendRequests" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

    <br />
    <table class="style1">
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
                <asp:GridView ID="GridViewFriendsListRequest" runat="server" AutoGenerateColumns="False" 
                    
                    DataKeyNames="Id" 
                    onrowcommand="GridViewFriendsListRequest_RowCommand" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" ShowHeader="False" Width="100%" 
                   >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                          <asp:buttonfield buttontype="Link" ControlStyle-BorderStyle="Ridge" Text="Not Now" commandname="notnow"/>
                          <asp:buttonfield buttontype="Link" ControlStyle-BorderStyle="Ridge" Text="Confirm Now" commandname="confirmnow"/>
                          <asp:BoundField DataField="FriendUserId" HeaderText="FriendUserId" ReadOnly="True" 
                    SortExpression="FriendUserId" Visible="False" />
                        <asp:TemplateField>
                          <ItemTemplate>
                         <asp:ImageButton ID="Image2" runat="server" ImageAlign="Middle" 
                  ImageUrl='<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "../../Resources/ProfilePictures/{0}.jpg") %>' 
                           PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "UserData.aspx?UserId={0}")%>'  Style="position: relative" Height="64px" Width="64px" />
                              <asp:Label ID="Label2" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                            &nbsp; <asp:Label ID="Label1" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                              <br />
                            <asp:HiddenField runat="server" ID="HiddenField1" Value='<%#Eval("FriendUserId")%>'></asp:HiddenField>

                    </ItemTemplate>
                        
                        </asp:TemplateField>
                               <asp:BoundField DataField="Status" Visible="false" />   
                
                    </Columns>
                      <RowStyle CssClass="GridRowStyle"/>
                    <AlternatingRowStyle CssClass="GridAlternatingRowStyle" />
                </asp:GridView>
                <br />
                <asp:GridView ID="GridViewSuggestions" runat="server" AutoGenerateColumns="False" 
                    
                    DataKeyNames="Id" 
                    onrowcommand="GridViewSuggestions_RowCommand" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" ShowHeader="False" Width="100%" 
                   >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                          <asp:buttonfield buttontype="Link" ControlStyle-BorderStyle="Ridge" Text="Not Now" commandname="notnow"/>
                          <asp:buttonfield buttontype="Link" ControlStyle-BorderStyle="Ridge" Text="Confirm Now" commandname="confirmnow"/>
                          <asp:BoundField DataField="FriendUserId" HeaderText="FriendUserId" ReadOnly="True" 
                    SortExpression="FriendUserId" Visible="False" />
                        <asp:TemplateField>
                          <ItemTemplate>
                         <asp:ImageButton ID="Image2" runat="server" ImageAlign="Middle" 
                  ImageUrl='<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "../../Resources/ProfilePictures/{0}.jpg") %>' 
                           PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "UserData.aspx?UserId={0}")%>'  Style="position: relative" Height="64px" Width="64px" />
                              <asp:Label ID="Label2" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                            &nbsp; <asp:Label ID="Label1" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                              <br />
                            <asp:HiddenField runat="server" ID="HiddenField1" Value='<%#Eval("FriendUserId")%>'></asp:HiddenField>

                    </ItemTemplate>
                        
                        </asp:TemplateField>
                               
                 <asp:BoundField DataField="Status" />       
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

