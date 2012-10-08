<%@ Page Language="C#" enableEventValidation="false" AutoEventWireup="true" MasterPageFile="~/UI/User/MasterPage.master"  CodeFile="Suggestions.aspx.cs" Inherits="UI_User_Suggestions" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
        {
            width: 242px;
        }
        .style5
        {
            width: 146px;
        }
        .style6
        {
            width: 522px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <table class="main_middlecontent">
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style6">
                   
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                HomeTown
                <asp:TextBox ID="HomeTownTextBox" runat="server" Text=""></asp:TextBox>
                     <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkCssClass="water" 
                    TargetControlID="HomeTownTextBox" WatermarkText="Enter a City">
                    </asp:TextBoxWatermarkExtender>
                     <br />
                    Current Location
                <asp:TextBox ID="LocationTextBox" runat="server"></asp:TextBox>

                     <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" WatermarkCssClass="water" 
                    TargetControlID="LocationTextBox" WatermarkText="Enter a City">
                    </asp:TextBoxWatermarkExtender>
                     <br />

                Employer
                <asp:GridView ID="GridViewEmps" runat="server" 
                    AutoGenerateColumns="False"
                    
                    GridLines="None" ShowHeader="False" Width="180" >
                    <Columns>
                       
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" 
                            SortExpression="Id" Visible="false" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItem %>'></asp:Label>
                                 &nbsp; 
                                
                              <br />
                                <br />
                            </ItemTemplate>
                        </asp:TemplateField>              

                   
                   
                         
                    </Columns>
                </asp:GridView>
                    <asp:TextBox ID="EmployerTextBox" runat="server"></asp:TextBox>
                     <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" WatermarkCssClass="water" 
                    TargetControlID="EmployerTextBox" WatermarkText="Enter an Employer">
                    </asp:TextBoxWatermarkExtender>
                     <br />
                    University
                     <asp:GridView ID="GridViewUnis" runat="server" 
                    AutoGenerateColumns="False"
                    
                    GridLines="None" ShowHeader="False" Width="180" >
                    <Columns>
                       
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" 
                            SortExpression="Id" Visible="false" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItem %>'></asp:Label>
                                 &nbsp; 
                                
                              <br />
                                <br />
                            </ItemTemplate>
                        </asp:TemplateField>              

                   
                   
                         
                    </Columns>
                </asp:GridView>
                    <asp:TextBox ID="EducationTextBox" runat="server"></asp:TextBox>
                     <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" WatermarkCssClass="water" 
                    TargetControlID="EducationTextBox" WatermarkText="Enter a University">
                    </asp:TextBoxWatermarkExtender>

                    <br />
                     School
                     <asp:GridView ID="GridViewSchool" runat="server" 
                    AutoGenerateColumns="False"
                    
                    GridLines="None" ShowHeader="False" Width="180" >
                    <Columns>
                       
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" 
                            SortExpression="Id" Visible="false" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItem %>'></asp:Label>
                                 &nbsp; 
                                
                              <br />
                                <br />
                            </ItemTemplate>
                        </asp:TemplateField>              

                   
                   
                         
                    </Columns>
                </asp:GridView>
                    <asp:TextBox ID="SchoolTextBox" runat="server"></asp:TextBox>
                     <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" WatermarkCssClass="water" 
                    TargetControlID="SchoolTextBox" WatermarkText="Enter a School">
                    </asp:TextBoxWatermarkExtender>
                    <br />
                     Mutual Friends
                     <asp:GridView ID="GridViewMutualFriends" runat="server" 
                    AutoGenerateColumns="False"
                    
                    GridLines="None" ShowHeader="False" Width="180" >
                    <Columns>
                       
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" 
                            SortExpression="Id" Visible="false" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItem %>'></asp:Label>
                                 &nbsp; 
                                
                              <br />
                                <br />
                            </ItemTemplate>
                        </asp:TemplateField>              

                   
                   
                         
                    </Columns>
                </asp:GridView>
                     <br />
                <asp:Button ID="SearchButton" runat="server" Text="Search"  CssClass="button"
                    onclick="SearchButton_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td align="left" rowspan="3">
            People You May Know: Friend Suggestions
           <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                <asp:GridView ID="GridViewFriendsList" runat="server" 
                    AutoGenerateColumns="False" DataKeyNames="FriendUserId" 
                     onrowcommand="GridViewFriendsList_RowCommand" 
                    GridLines="None" ShowHeader="False" Width="500px" CellPadding="4" 
                    ForeColor="#333333" style="margin-right: 36px" AllowPaging="True" 
                    onpageindexchanging="GridViewFriendsList_PageIndexChanging" PageSize="5">

                   
                    <Columns>
                       
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" 
                            SortExpression="Id" Visible="false" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="Image1" runat="server" Height="64px" ImageAlign="Middle" 
                                    ImageUrl='<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "../../Resources/ProfilePictures/{0}.jpg") %>' 
                                    PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "UserData.aspx?UserId={0}") %>' 
                                    Style="position: relative" Width="64px" />
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstName") %>' Font-Bold="True" Font-Size="Medium" ForeColor="#3B5998"></asp:Label>
                                 &nbsp; <asp:Label ID="Label3" runat="server" Text='<%# Bind("LastName") %>' Font-Bold="True" Font-Size="Medium" ForeColor="#3B5998"></asp:Label>
                               <br />&nbsp; <asp:Label ID="lblHometown" runat="server" Text='<%# Bind("Hometown") %>'></asp:Label>
                                &nbsp; <asp:Label ID="Label6" runat="server" Text='<%# Bind("Education") %>'></asp:Label>
                                 &nbsp; <asp:Label ID="Label7" runat="server" Text='<%# Bind("Employer") %>'></asp:Label>
                              <br />
                      &nbsp; <asp:Label ID="Label2" runat="server" Text='<%# Bind("MutualFriendName") %>'></asp:Label> is a mutual friend
                      &nbsp; Total <asp:Label ID="Label5" runat="server" Text='<%# Bind("MutualFriendsCount") %>'></asp:Label> mutual friends 
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:buttonfield buttontype="Link" Text="View mutual friends" commandname="viewmutual" />
                     <asp:buttonfield buttontype="Link" Text="Add Friend" commandname="add" />

                                                 
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerSettings FirstPageText="First" LastPageText="Last" 
                        Mode="NextPreviousFirstLast" NextPageText="Next" Position="TopAndBottom" 
                        PreviousPageText="Prev" />
                    <PagerStyle CssClass="GridRowStyle" />
                    <RowStyle CssClass="GridRowStyle"/>
                     <AlternatingRowStyle CssClass="GridAlternatingRowStyle"/>
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                </ContentTemplate>
        <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridViewFriendsList" EventName="PageIndexChanging" />
                         <asp:AsyncPostBackTrigger ControlID="SearchButton" EventName="Click" />
                       
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            
        </tr>
        </table>
</asp:Content>