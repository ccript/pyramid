<%@ Page Title="" Language="C#" MasterPageFile="~/UI/User/MasterPage.master" AutoEventWireup="true" CodeFile="Photos.aspx.cs" Inherits="User_Photos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="../../Resources/clock/js/jquery.js" type="text/javascript"></script>
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
                 <a href="TriggerUpload.aspx?popupwindow" class="popupwindow" rel="windowCenter">Upload Photos</a>
                  |&nbsp;

            <a href="AddAlbum.aspx">Add Album</a>
                
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
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                <asp:DataList ID="DataList1" runat="server" 
                    HorizontalAlign="Center" RepeatColumns="3" RepeatDirection="Horizontal"  Width="600px">
                    <ItemTemplate>

                       <asp:ImageButton ID="Image1" runat="server" Height="128px" ImageAlign="Middle" 
                                     ImageUrl='<%# DataBinder.Eval(Container.DataItem, "CoverPictureId", "../../Resources/UserPhotos/{0}.jpg") %>' 
                                    PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "_id", "ViewPhotoAlbum.aspx?AlbumId={0}") %>' 
                                    Style="position: relative" Width="128px" BorderColor="Silver" 
                            BorderStyle="Solid" BorderWidth="2px" />
                        
                        <br />
                
                        <br />
                      
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        <br />
                   
                        <asp:Label ID="DescriptionLabel" runat="server" 
                            Text='<%# Eval("Description") %>' />
                        <br />
                        <br />
<br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    SelectMethod="getMediaAlbumTop5" TypeName="BuinessLayer.MediaAlbumBLL">
                    <SelectParameters>
                        <asp:SessionParameter Name="UserId" SessionField="UserId" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
<br />
 <asp:LinkButton ID="lbtnMore" runat="server" onclick="MoreAlbum_Click">More albums ...</asp:LinkButton>

                       </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lbtnMore" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
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
            <asp:Label ID="tagphoto_Label" runat="server" Text="Tags Photos:"></asp:Label>
                    <asp:DataList ID="DataListTagPhotos" runat="server" 
                    HorizontalAlign="Center" RepeatColumns="3" RepeatDirection="Horizontal" 
                    Width="600px">
                    <ItemStyle BorderStyle="Dashed" BorderWidth="1px" HorizontalAlign="Center" 
                        BorderColor="#CCCCCC" />
                    <ItemTemplate>

                     <asp:HiddenField runat="server" ID="HiddenField1" Value='<%#Eval("_id")%>'></asp:HiddenField>
                 
                      

                 <asp:ImageButton ID="Image1" runat="server" Height="128px" ImageAlign="Middle" 
                                    ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Atid", "../../Resources/UserPhotos/{0}.jpg") %>' 
                                    PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "Atid", "ViewPhoto.aspx?PhotoId={0}") %>' 
                                    Style="position: relative" Width="128px" BorderColor="Silver" 
                            BorderStyle="Solid" BorderWidth="2px" />

                            
<br />
                    </ItemTemplate>
                </asp:DataList></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                
             <asp:Label ID="Tags_Album_label" runat="server" Text="Tags Albums:"></asp:Label>
                    <asp:DataList ID="DataListTagAlbums" runat="server" 
                    HorizontalAlign="Center" RepeatColumns="3" RepeatDirection="Horizontal" 
                    Width="600px">
                    <ItemStyle BorderStyle="Dashed" BorderWidth="1px" HorizontalAlign="Center" 
                        BorderColor="#CCCCCC" />
                    <ItemTemplate>

                     <asp:HiddenField runat="server" ID="HiddenField1" Value='<%#Eval("_id")%>'></asp:HiddenField>
                 
                      

                 <asp:ImageButton ID="Image1" runat="server" Height="128px" ImageAlign="Middle" 
                                 ImageUrl='~/Resources/Images/Icon/DefaultAlbum.png' 
                                    PostBackUrl='<%# DataBinder.Eval(Container.DataItem,"Atid", "ViewPhotoAlbum.aspx?AlbumId={0}") %>'
                                    Style="position: relative" Width="128px" BorderColor="Silver" 
                            BorderStyle="Solid" BorderWidth="2px" />

                            
<br />
                    </ItemTemplate>
                </asp:DataList></td>
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
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

