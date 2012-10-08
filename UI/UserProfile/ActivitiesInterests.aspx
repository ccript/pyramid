<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserProfile/MasterPage.master" AutoEventWireup="true" CodeFile="ActivitiesInterests.aspx.cs" Inherits="ActivitiesInterests" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
            color: #666666;
            font-weight: bold;
            font-family: Verdana;
            font-size: 10pt;
            vertical-align: top;
        }
         .style1
        {
           

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
         <table class="style1" >
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
            <td class="style5">
                Activities:</td>
            <td>
                <asp:TextBox ID="txtActivities" runat="server" Width="300px" Tooltip="Whats your activities?"  AutoComplete="Off"></asp:TextBox>
                 <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" WatermarkCssClass="water" TargetControlID="txtActivities" WatermarkText="Whats your activities?">
                   </ajax:TextBoxWatermarkExtender>
<ajax:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtActivities" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetActivity"     
CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight" >
</ajax:AutoCompleteExtender>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                <table class="style6">
                    <tr>
                        <td>
                            Description:</td>
                        <td>
                            <asp:TextBox ID="txtActivitiesDescription" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            People:</td>
                        <td>
                                      <asp:DropDownList ID="lstActivitiesFriend" runat="server" 
                    AppendDataBoundItems="True" 
                    DataTextField="FirstName" DataValueField="Id" 
                    DataSourceID="ObjectDataSource1">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                        </td>
                    </tr>
                    </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                <asp:DataList ID="DListActivities" runat="server" 
                       DataKeyField="_Id" 
                    OnSelectedIndexChanged="DListActivities_SelectedIndexChanged"  RepeatColumns="5" 
                    Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                            BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                            ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image", "../../Resources/images/ProfileIcons/{0}") %>'  
                            style="text-align: center" Width="64px" />
                       
                            <asp:LinkButton ID="lnkSelect" runat="server" CommandName="select" 
                            style="font-size: 7pt">Delete</asp:LinkButton>

                        <br />
                        
                        
                        &nbsp;<asp:Label ID="ActivityNameLabel" runat="server" Text='<%# Eval("Name") %>' />
                       
                       
                        <br />
                      
                    </ItemTemplate>
                </asp:DataList>
            </td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtActivities" 
                    ErrorMessage="Only alphabets required activities" 
                    ValidationExpression="[a-zA-Z ]+"></asp:RegularExpressionValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>

          <tr>
            <td>
                &nbsp;</td>
            <td colspan="2">
                <br />
                <hr /></td>
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
            <td class="style5">
                Interests:</td>
            <td>
                <asp:TextBox ID="txtInterests" runat="server" Width="300px" Tooltip="Whats is your interests?"></asp:TextBox>
                  <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkCssClass="water" TargetControlID="txtInterests" WatermarkText="Whats is your interests?">
                   </ajax:TextBoxWatermarkExtender>
                   <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtInterests" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetInterests"     
CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight" >
</ajax:AutoCompleteExtender>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                <table class="style6">
                    <tr>
                        <td>
                            Description:</td>
                        <td>
                            <asp:TextBox ID="txtInterestsDescription" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            People</td>
                        <td>
                             <asp:DropDownList ID="lstInterestsFriend" runat="server" 
                    AppendDataBoundItems="True" 
                    DataTextField="FirstName" DataValueField="Id" 
                    DataSourceID="ObjectDataSource1">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    SelectMethod="getAllFriendsListName" TypeName="BuinessLayer.FriendsBLL">
                    <SelectParameters>
                        <asp:SessionParameter Name="UserId" SessionField="UserId" Type="String" />
                        <asp:Parameter DefaultValue=Global.CONFIRMED Name="status" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                        </td>
                    </tr>
                    </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                <asp:DataList ID="DListInterests" runat="server" 
                       DataKeyField="_Id" 
                    OnSelectedIndexChanged="DListInterests_SelectedIndexChanged"  RepeatColumns="5" 
                    Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                            BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                         ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image", "../../Resources/images/ProfileIcons/{0}") %>' 
                            style="text-align: center" Width="64px" />
                       
                            <asp:LinkButton ID="lnkSelect" runat="server" CommandName="select" 
                            style="font-size: 7pt">Delete</asp:LinkButton>

                        <br />
                        
                        
                        &nbsp;<asp:Label ID="InterestsNameLabel" runat="server" Text='<%# Eval("Name") %>' />
                       
                       
                        <br />
                      
                    </ItemTemplate>
                </asp:DataList>
            </td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="txtInterests" 
                    ErrorMessage="Only alphabets required in interests" 
                    ValidationExpression="[a-zA-Z ]+"></asp:RegularExpressionValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>

          <tr>
            <td>
                &nbsp;</td>
            <td colspan="2">
                <hr /></td>
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
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save Changes" 
                    onclick="btnSave_Click" />
            </td>
            <td>
                <asp:Image ID="imgSave" runat="server" ImageUrl="~/Resources/images/Icon/check.png" 
                    Visible="False" />
                <asp:Label ID="lblSave" runat="server" Text="Save changes is successful" 
                    ForeColor="#006600" Visible="False"></asp:Label>
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
    </table>
</asp:Content>

