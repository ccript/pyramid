<%@ Page Title="" Language="C#" MasterPageFile="~/UI/User/MasterPage.master" AutoEventWireup="true" CodeFile="ViewVideoAlbum.aspx.cs" Inherits="UI_User_ViewVideoAlbum" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <script src="../../Resources/lightbox/js/jquery.js" type="text/javascript"></script>

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
           
           
             <a href="ManageVideo.aspx">Edit Video</a> |&nbsp;
           <a href="TriggerUploadVideo.aspx?popupwindow" class="popupwindow" rel="windowCenter">Add Video</a>&nbsp; 
                |&nbsp;<a href="WebPhoto.aspx">WebCam </a>

      
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
                                    Style="position: relative" Width="128px" BorderColor="Silver" 
                            BorderStyle="Solid" BorderWidth="2px" />

              
  

    
                        <br />
                 <asp:Label ID="Label1" runat="server" Text='<%# Eval("Caption") %>' />
                  <br />
                  <asp:Label ID="Label2" runat="server" Text='<%# Eval("Location") %>' />
                    
                    
                     
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
    </table>
</asp:Content>

