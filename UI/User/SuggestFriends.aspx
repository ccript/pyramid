<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/UI/User/MasterPage.master" CodeFile="SuggestFriends.aspx.cs" Inherits="UI_User_SuggestFriends" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 385px;
        }
        .style5
        {
            width: 3px;
        }
        .style6
        {
            width: 522px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <table class="main_middlecontent" frame="void">
        <tr>
            <td class="style6">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <td class="style2">
                   
                <br />
                Find Friends
                <asp:TextBox ID="FindFriendsTextBox" runat="server"></asp:TextBox>
                     Filter by List&nbsp; <asp:DropDownList ID="ddl_FilterByList" runat="server" 
                    AutoPostBack="True" Height="23px" 
                    onselectedindexchanged="ddl_FilterByList_SelectedIndexChanged" 
                    Width="112px">
                </asp:DropDownList>
                     <br />
                     <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkCssClass="water" 
                    TargetControlID="FindFriendsTextBox" WatermarkText="Enter a Friend Name">
                    </asp:TextBoxWatermarkExtender>
                    
                <asp:Button ID="SearchButton" runat="server" Text="Search"  CssClass="button"
                    onclick="SearchButton_Click" />
                    <asp:Button ID="btnAll" runat="server" Text="All"  CssClass="button"
                    onclick="btnAll_Click" />
                </td>
        <tr>
                <td class="style6">
                 
                
            <asp:DataList ID="RecSuggestionsDataList" runat="server"
            RepeatColumns="3" RepeatDirection="Horizontal"   DataKeyField="FriendUserID"
            OnItemCommand="RecSuggestionsDataList_ItemCommand"  AutoGenerateColumns="False" 
           CellPadding="2" CausesValidation="False" Width="350px" BackColor="#CC6699" >
            <HeaderTemplate>

            Recommended Suggestions

         </HeaderTemplate>
                      <ItemTemplate>
                      <table cellpadding="2" cellspacing="2">
                    <tr>
                        <td valign="middle" align="center" 
            style="background-color:#cccccc;border:1px solid gray;
            ">
                          
  <asp:CheckBox ID="CheckBox2" runat="server"/>
                           
                            <img  alt="" src="<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "../../Resources/ProfilePictures/{0}.jpg") %>" height=60 width=60/>
                           
                                    <br />
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstName") %>' Font-Bold="True" Font-Size="Small" ForeColor="#993366"></asp:Label>
                                 &nbsp; <asp:Label ID="Label3" runat="server" Text='<%# Bind("LastName") %>' Font-Bold="True" Font-Size="Small" ForeColor="#993366"></asp:Label>
                               </td>
                               </tr>
                </table>
                            </ItemTemplate>

                        <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" 
                          BorderColor="#0000CC" BorderWidth="4px" />           
          
        </asp:DataList>
                
            <br />
           <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
            
            <asp:DataList ID="AllSuggestionsDataList" runat="server"
            RepeatColumns="3" RepeatDirection="Horizontal" DataKeyField="FriendUserID"
            OnItemCommand="AllSuggestionsDataList_ItemCommand"  AutoGenerateColumns="False" 
           CellPadding="2" CausesValidation="False" BackColor="#CC99FF" >
           <HeaderTemplate>

            All Suggestions

         </HeaderTemplate>
                      <ItemTemplate>
                      <table cellpadding="2" cellspacing="2">
                    <tr>
                        <td valign="middle" align="center" 
            style="background-color:#cccccc;border:1px solid gray;
            ">
                              <asp:CheckBox ID="CheckBox2" runat="server"/>
                            <img  alt="" src="<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "../../Resources/ProfilePictures/{0}.jpg") %>" height=60 width=60/>
                           
                                    <br />
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstName") %>' Font-Bold="True" Font-Size="Small" ForeColor="#993366"></asp:Label>
                                 &nbsp; <asp:Label ID="Label3" runat="server" Text='<%# Bind("LastName") %>' Font-Bold="True" Font-Size="Small" ForeColor="#993366"></asp:Label>
                               </td>
                               </tr>
                </table>
                            </ItemTemplate>

                        <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" 
                          BorderColor="#0000CC" BorderWidth="4px" />           
          
        </asp:DataList>
        <asp:label id="lblCurrentPage" runat="server"></asp:label>
            <asp:button id="cmdPrev" runat="server" text=" << " onclick="cmdPrev_Click"></asp:button>

&nbsp;<asp:button id="cmdNext" runat="server" text=" >> " onclick="cmdNext_Click"></asp:button>
          </ContentTemplate>
        <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cmdNext" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="cmdPrev" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
        <br />
          
            <asp:DataList ID="MutualDataList" runat="server"
            RepeatColumns="3" RepeatDirection="Horizontal" DataKeyNames="FriendUserId"
              AutoGenerateColumns="False" 
           CellPadding="2" CausesValidation="False" BackColor="#CC99FF" >
           <HeaderTemplate>

            Mutual Friends

         </HeaderTemplate>
                      <ItemTemplate>
                      <table cellpadding="2" cellspacing="2">
                    <tr>
                        <td valign="middle" align="center" 
            style="background-color:#cccccc;border:1px solid gray;
            ">
                            <img  alt="" src="<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "../../Resources/ProfilePictures/{0}.jpg") %>" height=60 width=60/>
                           
                                    <br />
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstName") %>' Font-Bold="True" Font-Size="Small" ForeColor="#993366"></asp:Label>
                                 &nbsp; <asp:Label ID="Label3" runat="server" Text='<%# Bind("LastName") %>' Font-Bold="True" Font-Size="Small" ForeColor="#993366"></asp:Label>
                               </td>
                               </tr>
                </table>
                            </ItemTemplate>

                        <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" 
                          BorderColor="#0000CC" BorderWidth="4px" />           
          
        </asp:DataList>
                <asp:Button ID="btnSendSuggestions" runat="server" Text="Send Suggestions" 
                    onclick="btnSendSuggestions_Click"/><br />
            
                <asp:GridView ID="GridViewFriendsList" runat="server" 
                    AutoGenerateColumns="False" DataKeyNames="FriendUserId" 
                     onrowcommand="GridViewFriendsList_RowCommand" 
                    GridLines="None" ShowHeader="False" Width="100%" CellPadding="4" 
                    ForeColor="#333333" style="margin-right: 36px"
                    >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                       
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" 
                            SortExpression="Id" Visible="false" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="Image1" runat="server" Height="64px" ImageAlign="Middle" 
                                    ImageUrl='<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "../../Resources/ProfilePictures/{0}.jpg") %>' 
                                    PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "UserData.aspx?UserId={0}") %>' 
                                    Style="position: relative" Width="64px" />
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstName") %>' Font-Bold="True" Font-Size="Medium" ForeColor="#993366"></asp:Label>
                                 &nbsp; <asp:Label ID="Label3" runat="server" Text='<%# Bind("LastName") %>' Font-Bold="True" Font-Size="Medium" ForeColor="#993366"></asp:Label>
                               
                            </ItemTemplate>

                        </asp:TemplateField>
                        

                                                 
                    </Columns>
                    <RowStyle CssClass="GridRowStyle"/>
                    <AlternatingRowStyle CssClass="GridAlternatingRowStyle" />
                </asp:GridView>
            </td>
            
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
