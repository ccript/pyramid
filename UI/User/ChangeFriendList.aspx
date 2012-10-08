<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeFriendList.aspx.cs" MasterPageFile="~/UI/User/MasterPage.master" Inherits="User_ChangeFriendList" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Select List Name for this User:
    <asp:DropDownList ID="ListDropDownList" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="AddButton" runat="server" Text="Add" onclick="AddButton_Click" 
        Width="55px" />
    <br />
    <br />
    <asp:HyperLink runat="server" ID="hl1" NavigateUrl="~/UI/User/AdvanceOptions.aspx">
        <strong>Advance Options</strong>
    </asp:HyperLink>
</asp:Content>