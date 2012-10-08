<%@ Page Title="" Language="C#" MasterPageFile="~/UI/User/MasterPage.master" AutoEventWireup="true" CodeFile="ViewPhotoAlbum.aspx.cs" Inherits="UI_User_ManagePhotos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link href="../../Resources/adipoli-v2/adipoli.css" rel="stylesheet" type="text/css"/>
<script src="../../Resources/adipoli-v2/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="../../Resources/adipoli-v2/jquery.adipoli.min.js" type="text/javascript"></script>


   <script type="text/javascript">

       $(function () {
           $('.row1').adipoli({
               'startEffect': 'normal',
               'hoverEffect': 'popout'
           });
           $('.row2').adipoli({
               'startEffect': 'overlay',
               'hoverEffect': 'sliceDown'
           });
           $('.row3').adipoli({
               'startEffect': 'transparent',
               'hoverEffect': 'boxRandom'
           });
           $('.row4').adipoli({
               'startEffect': 'overlay',
               'hoverEffect': 'foldLeft'
           });
           $('.row5').adipoli({
               'startEffect': 'grayscale',
               'hoverEffect': 'boxRainGrowReverse'
           });
           $('.row62').adipoli({
               'startEffect': 'grayscale',
               'hoverEffect': 'normal'
           });
       });
            
        </script>

    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>

     <style type="text/css">  
    
  /* Body */  
  Body  
  {  
   background-color:Gray;  
   }  
    
    
  /** for view Large Image */   
  #ImagePreview  
  {  
   position:absolute;  
   border:1px solid #ccc;  
   background:#333;  
   padding:1px;  
   display:none;  
   color:#fff;  
   }  
   
 /* Rounded Corner for Panel*/  
 .RoundedCorner  
 {  
  background-color:White;  
  width:170px;  
  }  
    
  .RoundedContent   
   {              
    text-align:center;  
    padding:10px;                         
    }  
     
  
 </style>  
  
 <script language="javascript" src="Scripts/LargeImagePreview.js" type="text/javascript"></script>  
  
 <script language="javascript" type="text/javascript">

     $(document).ready(function () {

         // Start the Script on Page Load  
         LargeImagePreview();
     }
   );  
  
 </script>


      <script type = "text/javascript">
          function FUser_Populated(sender, e) {
              var item = sender.get_completionList().childNodes;
              for (var i = 0; i < item.length; i++) {
                  var div = document.createElement("DIV");
                  div.innerHTML = "<img style = 'height:24px;width:24px' src = '../../Resources/ProfilePictures/"
                  + item[i]._value + ".jpg' /><br />";
                  item[i].appendChild(div);

              }
          }
          function OnFUserSelected(source, eventArgs) {
              var idx = source._selectIndex;
              var employees = source.get_completionList().childNodes;
              var value = employees[idx]._value;
              var text = employees[idx].firstChild.nodeValue;
              source.get_element().value = text;
              $get('<%= HiddenField1.ClientID %>').value = value;
          }
</script>
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
           
           
             <a href="ManagePhotos.aspx">Manage Album</a> |&nbsp;
        

           <a href="ClassicUpload.aspx">Classic Upload</a>
           |&nbsp;
           <a href="WebPhoto.aspx">WebCam Photo</a>
           <asp:LinkButton
               ID="lnkDelete" runat="server" onclick="lnkDelete_Click">|&nbsp;Delete Album</asp:LinkButton>
 <img src="../../Resources/Images/MenuIcon/slide.png" /> <asp:LinkButton
               ID="lbtnViewSlideShow" runat="server" onclick="lbtnViewSlideShow_Click" >|&nbsp; Slide Show</asp:LinkButton>
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
               </td>
            <td>
              Title:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label> 
               <br />
               <br />
                Description: <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label> 
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
             &nbsp; </td>
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
         
                      <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>         
                <asp:DataList ID="DataList1" runat="server" 
                     HorizontalAlign="Center" RepeatColumns="3" RepeatDirection="Horizontal" 
                    Width="600px">
                    <ItemStyle BorderStyle="None" BorderWidth="2px" HorizontalAlign="Center" 
                        BorderColor="#CCCCCC" />
                    <ItemTemplate>
               
                     <asp:HiddenField runat="server" ID="HiddenField1" Value='<%#Eval("_id")%>'></asp:HiddenField>
                 

              <%--   <asp:ImageButton ID="Image1" runat="server" Height="128px" ImageAlign="Middle" 
                                    ImageUrl='<%# DataBinder.Eval(Container.DataItem, "_id", "../../Resources/ThumbnailPhotos/{0}.jpg") %>' 
                                    PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "_id", "ViewPhoto.aspx?PhotoId={0}") %>' 
                                    Style="position: relative" Width="128px" BorderColor="Silver" 
                            BorderStyle="Solid" BorderWidth="2px" />--%>

                      <a href='<%# DataBinder.Eval(Container.DataItem, "_id", "ViewPhoto.aspx?PhotoId={0}") %>'>
           
                        <img class="img-style row1" src='<%# DataBinder.Eval(Container.DataItem, "_id", "../../Resources/ThumbnailPhotos/{0}.jpg") %>'   alt="" style="border-style: solid; border-color: #C0C0C0"/>
                             </a>

       
                      
                        <br />
                 <asp:Label ID="Label1" runat="server" Text='<%# Eval("Caption") %>' />
                  <br />
                  <asp:Label ID="Label2" runat="server" Text='<%# Eval("Location") %>' />
                    
                    
                     
<br />
 
           </ItemTemplate>
                </asp:DataList>

              </ContentTemplate>

</asp:UpdatePanel>

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
                      <asp:Label ID="Label1" runat="server" ></asp:Label>
                  <asp:HiddenField ID="HiddenField1" runat="server" />  &nbsp;
                <asp:TextBox ID="txtFriendSearch" runat="server" AutoComplete="Off"  
                    Width="330" AutoPostBack="True" ontextchanged="txtFriendSearch_TextChanged"></asp:TextBox>


   <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" WatermarkCssClass="water" TargetControlID="txtFriendSearch" WatermarkText="Tags friends here">
                   </ajax:TextBoxWatermarkExtender>
                <ajax:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="txtFriendSearch" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetFriendsName" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight" 
OnClientPopulated ="FUser_Populated"
    OnClientItemSelected = " OnFUserSelected" >
 


</ajax:AutoCompleteExtender> 


               <br/>
               Tags: <asp:DataList ID="DListTags" runat="server" 
                       DataKeyField="_Id" OnSelectedIndexChanged="DListTags_SelectedIndexChanged"  RepeatColumns="5" Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top"  />
                    <ItemTemplate>
                       
                       
                            

                        <br />
                        
                         <asp:Label ID="Label2" runat="server" Text='<%# Eval("FriendFName") %>' />
                        &nbsp;<asp:Label ID="NameLabel" runat="server" Text='<%# Eval("FriendLName") %>' />  &nbsp;<asp:LinkButton ID="lnkSelect" runat="server" CommandName="select" 
                            style="font-size: 7pt">Remove</asp:LinkButton>
                       
                       
                        <br />
                      
                    </ItemTemplate>
                </asp:DataList>
                    <br />
                 <asp:LinkButton ID="lbtnFollow" runat="server" onclick="lbtnFollow_Click">Follow Post</asp:LinkButton>
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
                <asp:LinkButton ID="lbtnLike" runat="server" onclick="lbtnLike_Click">Like</asp:LinkButton>
            &nbsp;<asp:Label ID="lblLike" runat="server" Text=""></asp:Label>
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
              <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                <asp:DataList ID="DataListComments" runat="server" CellPadding="4" ForeColor="#333333" 
                    Width="300px">

                      <AlternatingItemStyle CssClass="DataListAlternatingItemStyle " />
             
                    <ItemStyle CssClass="DataListItemStyle" />

                    <ItemTemplate>
                          <asp:ImageButton ID="Image1" runat="server" Height="32px" ImageAlign="Middle" 
                                    ImageUrl='<%# DataBinder.Eval(Container.DataItem, "UserId", "../../Resources/ProfilePictures/{0}.jpg") %>' 
                                    PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "UserId", "UserData.aspx?UserId={0}") %>' 
                                    Style="position: relative" Width="32px" />

                          
                        &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" 
                              Text=' <%# Eval("FirstName","") + " " + Eval("LastName","") %>'
                              PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "UserId", "UserData.aspx?UserId={0}") %>' 
                              ></asp:LinkButton>
                          <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("MyComments") %>' />
                       
                       
                        <br />
                      
                    </ItemTemplate>
                    <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                </asp:DataList>
                 </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtComments" EventName="TextChanged" />
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
                <asp:ImageButton ID="imgBtnComments" runat="server" 
                    onclick="imgBtnComments_Click" Width="32px" Height="32px" ImageAlign="Middle" />
             
                    <asp:TextBox ID="txtComments" runat="server" Width="259px" AutoPostBack="True" 
                        ontextchanged="txtComments_TextChanged"></asp:TextBox>

                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                    SelectMethod="getAllFriendsListName" TypeName="BuinessLayer.FriendsBLL">
                    <SelectParameters>
                        <asp:SessionParameter Name="UserId" SessionField="UserId" Type="String" />
                        <asp:Parameter DefaultValue="C" Name="status" Type="String" />
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
                    <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save Changes" 
                    /></td>
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

