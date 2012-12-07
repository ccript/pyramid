<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/User/MasterPage.master" CodeFile="MultiSelect.aspx.cs" Inherits="MultiSelect" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="jquery-1.4.3.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('input[id*=hdnIsItemSelected][value=true]').parent().parent().addClass('RowHighlight');
        });

        $(function () {
            $('#MultiSelectGrid tr').mouseover(function () {
                $('#MultiSelectGrid tr').removeClass('RowHover');
                $(this).addClass('RowHover');
            });
        });

        $(function () {
            $('#MultiSelectGrid tr td').click(function () {
                if ($(this).parent()[0].className == 'RowHover') {
                    $(this).parent().addClass('RowHighlight');
                    $('input[id*=hdnIsItemSelected]')[$(this).parent()[0].rowIndex - 1].value = 'true';
                }
                else {
                    $(this).parent().removeClass('RowHighlight');
                    $('input[id*=hdnIsItemSelected]')[$(this).parent()[0].rowIndex - 1].value = 'false';
                }
            });
        });
    </script>

    <script type="text/javascript" language="javascript">
        $(function () {

            // add multiple select / deselect functionality
            $("#selectall").click(function () {
                $('.case').attr('checked', this.checked);
            });

            // if all checkbox are selected, check the selectall checkbox
            // and viceversa
            $(".case").click(function () {

                if ($(".case").length == $(".case:checked").length) {
                    $("#selectall").attr("checked", "checked");
                } else {
                    $("#selectall").removeAttr("checked");
                }

            });
        });
    </script>

    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>

        <asp:Button ID="Button1" runat="server" Text="Select All" onclick="SelectButton_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Un-Select All" onclick="UnSelectButton_Click" />
        <asp:GridView ID="MultiSelectGrid" runat="server" AutoGenerateColumns="false">
            <RowStyle Height="20px" />
            <Columns>
            <asp:TemplateField HeaderText="Select"> 
<ItemTemplate>
<asp:CheckBox ID="chkSelect" runat="server" />
</ItemTemplate>
</asp:TemplateField>
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" 
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
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="lblSelectedName" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnPostback" runat="server" OnClick="btnPostback_Click" CssClass="buttonStyle"
            Text="Postback" />
    </div>
    </asp:Content>