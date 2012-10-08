<%@ Page Title="" Language="C#" MasterPageFile="~/UI/User/MasterPage.master" AutoEventWireup="true" CodeFile="ManageVideo.aspx.cs" Inherits="UI_User_ManageVideo" %>

<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
   
 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                &nbsp;</td>
            <td>
                &nbsp;&nbsp;&nbsp;
           
           

           <a href="TriggerUploadVideo.aspx?popupwindow" class="popupwindow" rel="windowCenter">Add Video</a>&nbsp; 
           

           
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
                <asp:DataList ID="DataList1" runat="server" 
                    HorizontalAlign="Center" RepeatColumns="2" RepeatDirection="Horizontal" 
                    Width="600px">
                    <ItemStyle BorderStyle="Dashed" BorderWidth="1px" HorizontalAlign="Center" 
                        BorderColor="#CCCCCC" />
                    <ItemTemplate>

                     <asp:HiddenField runat="server" ID="HiddenField1" Value='<%#Eval("_id")%>'></asp:HiddenField>
                 
                      

                 <asp:ImageButton ID="Image1" runat="server" Height="128px" ImageAlign="Middle" 
                                    ImageUrl='~/Resources/Images/Icon/DefaultVideo.png' 
                                    PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "_id", "ViewVideo.aspx?VideoId={0}") %>' 
                                    Style="position: relative" Width="128px" />
 <br />
                      
                
                    
                        <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>' 
                            Width="128px" ></asp:TextBox>
                                <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkCssClass="water" TargetControlID="txtName" WatermarkText="Add title Here">
                   </ajax:TextBoxWatermarkExtender>
                   
                        <br />
                      <br />
                      
                
                    
                        <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("Description") %>' 
                            Width="128px" ></asp:TextBox>
                                <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" WatermarkCssClass="water" TargetControlID="txtDescription" WatermarkText="Add description Here">
                   </ajax:TextBoxWatermarkExtender>
                        <br />
                      
                
                    
                        <asp:TextBox ID="txtCaption" runat="server" Text='<%# Eval("Caption") %>' 
                            Width="128px" ></asp:TextBox>
                                <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" runat="server" WatermarkCssClass="water" TargetControlID="txtCaption" WatermarkText="Add caption Here">
                   </ajax:TextBoxWatermarkExtender>
                        <br />
                       
                      
               
                        <asp:TextBox ID="txtLocation" Width="128px"  runat="server" Text='<%# Eval("Location") %>'></asp:TextBox>
                         <br />
                      
                        

               <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" WatermarkCssClass="water" TargetControlID="txtLocation" WatermarkText="Location of Photo?">
                   </ajax:TextBoxWatermarkExtender>

                   <ajax:AutoCompleteExtender ID="AutoCompleteExtender6" runat="server" TargetControlID="txtLocation" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetLocation" 
CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight" >
</ajax:AutoCompleteExtender> 
                        <br />
                        &nbsp;<asp:Label ID="AddedDateLabel" runat="server" Text='<%# Eval("AddedDate") %>' />
                        <br />
                        <cc1:GMDatePicker ID="GMDatePicker1" runat="server" Date='<%# Bind("AddedDate") %>'>
                        </cc1:GMDatePicker>
<br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    SelectMethod="getMediaTop5" TypeName="BuinessLayer.MediaBLL">
                    <SelectParameters>
                        <asp:SessionParameter Name="UserId" SessionField="UserId" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
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
                    <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save Changes" 
                    onclick="btnSave_Click"  /></td>
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

