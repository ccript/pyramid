<%@ Page Title="" Language="C#" MasterPageFile="~/UI/User/MasterPage.master" AutoEventWireup="true" CodeFile="ManagePhotos.aspx.cs" Inherits="UI_User_ManagePhotos" %>

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
           
           

           <a href="TriggerUpload.aspx?popupwindow" class="popupwindow" rel="windowCenter">Add Photos</a>&nbsp; 
                                |&nbsp; 

           <a href="ClassicUpload.aspx">Classic Upload</a>
           |&nbsp;

           <a href="WebPhoto.aspx">WebCam Photo</a>
           

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
                <asp:Panel ID="PanelDefault" runat="server" Visible="false">
                    <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
                </asp:Panel>
                 <asp:Panel ID="PanelOthers" runat="server" Visible="false">
                   Title:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
               <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
               <br />
                Description:  <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                </asp:Panel>
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
                <asp:DataList ID="DataList1" runat="server" 
                    HorizontalAlign="Center" RepeatColumns="2" RepeatDirection="Horizontal" 
                    Width="600px">
                    <ItemStyle BorderStyle="Dashed" BorderWidth="1px" HorizontalAlign="Center" 
                        BorderColor="#CCCCCC" />
                    <ItemTemplate>

                     <asp:HiddenField runat="server" ID="HiddenField1" Value='<%#Eval("_id")%>'></asp:HiddenField>
                 
                      

                 <asp:ImageButton ID="Image1" runat="server" Height="128px" ImageAlign="Middle" 
                                    ImageUrl='<%# DataBinder.Eval(Container.DataItem, "_id", "../../Resources/ThumbnailPhotos/{0}.jpg") %>' 
                                    PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "_id", "ViewPhoto.aspx?PhotoId={0}") %>' 
                                    Style="position: relative" Width="128px" />

                        <br />
                
                    
                        <asp:TextBox ID="txtCaption" runat="server" Text='<%# Eval("Caption") %>' 
                            Width="128px" ></asp:TextBox>
                                <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" runat="server" WatermarkCssClass="water" TargetControlID="txtCaption" WatermarkText="Add caption Here">
                   </ajax:TextBoxWatermarkExtender>
                        <br />
                      
                      
               
                        <asp:TextBox ID="txtLocation" Width="128px"  runat="server" Text='<%# Eval("Location") %>'></asp:TextBox>

               <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" WatermarkCssClass="water" TargetControlID="txtLocation" WatermarkText="Location of Photo?">
                   </ajax:TextBoxWatermarkExtender>

                   <ajax:AutoCompleteExtender ID="AutoCompleteExtender6" runat="server" TargetControlID="txtLocation" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetLocation" 
CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight" >
</ajax:AutoCompleteExtender> 
                        <br />
                        &nbsp;<asp:Label ID="AddedDateLabel" runat="server" Text='<%# Eval("AddedDate") %>' />
                        <br />
                        <cc1:GMDatePicker ID="GMDatePicker1" runat="server" Date='<%# Bind("AddedDate") %>' />
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

