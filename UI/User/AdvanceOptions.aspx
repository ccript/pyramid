<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/User/MasterPage.master" CodeFile="AdvanceOptions.aspx.cs" Inherits="User_AdvanceOptions" %>

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
    <style type="text/css">
        .hideFromScreen {display:none;}
        .style1
        {
            font-size: medium;
        }
        .style5
        {
            color: #666666;
            font-weight: bold;
            font-family: Verdana;
            font-size: 10pt;
            vertical-align: top;
        }
        .style8
        {
            color: #990000;
        }
        .style980
        {
            width: 100%;
        }
        .style981
        {
            width: 322px;
        }
        .style982
        {
            width: 301px;
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
    <asp:Panel ID="Panel1" runat="server">
    <div>
    
       
    
    </div>
    
    <div>
        
        
        &nbsp;<table class="style980">
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="3">
                    <h2 class="style5">
                        You can add your friends easily to any default list</h2>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style982">
                    <asp:Button ID="Button1" runat="server" CssClass="button" 
                        onclick="Button1_Click" Text="Select All" />
                    <asp:Button ID="Button2" runat="server" CssClass="button" 
                        onclick="Button2_Click" Text="Un-Select All" />
                </td>
                <td>
                    <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="SearchButton" runat="server" CssClass="button" 
                        onclick="SearchButton_Click" Text="Search" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style982">
                    <h2 class="style5">Add Selected Friends to this list:</h2></td>
                <td>
        <asp:DropDownList ID="ListDropDownList" runat="server" Height="16px" Width="180px">
    </asp:DropDownList>
                </td>
                <td>
    <asp:Button ID="AddButton" CssClass="button" runat="server" Text="Add" onclick="AddButton_Click" 
        Width="55px" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style982">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>

    <div>
   
    </asp:Panel>
        
       

   <center>

                           <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkCssClass="water" 
                    TargetControlID="SearchTextBox" WatermarkText="Search User">
                    </asp:TextBoxWatermarkExtender>
        </center>        <br /><br />

        <br />
        
         
   </div>
   
   
   
   
   
   
    <div>
   
        
        <asp:GridView ID="MultiSelectGrid" runat="server" AutoGenerateColumns="False" 
            GridLines="None" Width="100%" ShowHeader="False" CellPadding="4" 
            ForeColor="#333333" AllowPaging="True" 
                    onpageindexchanging="GridViewFriendsList_PageIndexChanging" PageSize="5">
          
            <Columns>
            <asp:TemplateField HeaderText="Select"> 
<ItemTemplate>
<asp:CheckBox ID="chkSelect" runat="server" />
</ItemTemplate>
</asp:TemplateField>

                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" ItemStyle-CssClass="hideFromScreen" ItemStyle-Font-Size="XX-Small" ItemStyle-ForeColor="White" Visible="true" 
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
            <PagerSettings FirstPageText="First" LastPageText="Last" 
                        Mode="NextPreviousFirstLast" NextPageText="Next" Position="TopAndBottom" 
                        PreviousPageText="Prev" />
                    <PagerStyle CssClass="GridRowStyle" />
                    
               <RowStyle CssClass="GridRowStyle"/>
                    <AlternatingRowStyle CssClass="GridAlternatingRowStyle" />
        </asp:GridView>
        <br />
        <asp:Label ID="lblSelectedName" runat="server"></asp:Label>
        <br />
        <br />
    </div>
    </asp:Content>