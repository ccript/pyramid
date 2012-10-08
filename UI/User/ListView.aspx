<%@ Page Language="C#" MasterPageFile="~/UI/User/MasterPage.master" AutoEventWireup="true" CodeFile="ListView.aspx.cs" Inherits="User_ListView" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            font-size: medium;
        }
    </style>
    </asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<br />

<center>
<asp:GridView ID="ListViewGrid" runat="server" AutoGenerateColumns="False"
                     DataKeyNames="ListName" AllowPaging="True" PageSize="15" 
                             
                           
                            style="margin-right: 67px" Width="437px" 
        CellPadding="4" ForeColor="#333333" GridLines="None" ShowHeader="False">
                   
                    <Columns>
                    
                        <asp:TemplateField HeaderText="ListName">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" 
                                    NavigateUrl='<%# Eval("ListName", "~/UI/User/DetailListView.aspx?ListName={0}") %>' 
                                    Text='<%# Eval("ListName", "{0:c}") %>'></asp:HyperLink>

                                     ( <asp:Label ID="Label1" runat="server" Text='<%# Bind("Counting") %>'></asp:Label>)
                           
                           <br/>
                             <br/>
                            </ItemTemplate>
                        </asp:TemplateField>
                      
                    
                    <asp:HyperLinkField HeaderText="Click to Manage List" datatextformatstring="{0:c}"
            datanavigateurlfields="ListName"
            datanavigateurlformatstring="ManageList.aspx?ListName={0}" Text="Manage List" 
              />

                    </Columns>
                       <RowStyle CssClass="GridRowStyle"/>
                    <AlternatingRowStyle CssClass="GridAlternatingRowStyle" />
                </asp:GridView>
               <span class="style1">&nbsp;</span><asp:TextBox ID="txtListName" 
        runat="server" Visible="False"></asp:TextBox>
&nbsp;
    <asp:Button ID="btnAddListName" runat="server" Text="Add List Name" 
        CssClass="button" onclick="btnAddListName_Click" Visible="False" />
               <br />
    <br />
    <br />
               <asp:HyperLink runat="server" ID="hl1" NavigateUrl="~/UI/User/AddRemoveFriends.aspx">
               Remove Friends
                </asp:HyperLink>
                </center>

                 
    <br />


                 
<br />

</asp:Content>
