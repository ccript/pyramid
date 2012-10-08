<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/User/MasterPage.master" CodeFile="SeeFriend.aspx.cs" Inherits="UI_User_SeeFriend" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


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
        function OnTagUserSelected(source, eventArgs) {
            var idx = source._selectIndex;
            var employees = source.get_completionList().childNodes;
            var value = employees[idx]._value;
            var text = employees[idx].firstChild.nodeValue;
            source.get_element().value = text;
            $get('<%= HiddenFieldTagId.ClientID %>').value = value;
        }
        function TagUser_Populated(sender, e) {
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
        function Location_Populated(sender, e) {
            var item = sender.get_completionList().childNodes;
            for (var i = 0; i < item.length; i++) {
                var div = document.createElement("DIV");
                div.innerHTML = +item[i]._value + " were here </br>";

                item[i].appendChild(div);

            }
        }
        function OnLocationSelected(source, eventArgs) {
            var idx = source._selectIndex;
            var employees = source.get_completionList().childNodes;
            var value = employees[idx]._value;
            var text = employees[idx].firstChild.nodeValue;
            source.get_element().value = text;

        }
</script>

</asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <table>
        <tr>
            <td>
                </td>
            <td>
                <asp:Label ID="lblName" runat="server" 
                    style="font-size: x-large; font-weight: 700" ></asp:Label>
                &nbsp;<asp:Label ID="Label2" runat="server" Text="and"
                    style="font-size: x-large; font-weight: 700" ></asp:Label>&nbsp;
                <asp:Label ID="lblFriendName" runat="server" 
                    style="font-size: x-large; font-weight: 700" ></asp:Label>
                <br />
                <asp:Button ID="btnSuggestFriends" runat="server" 
                    onclick="btnSuggestFriends_Click" Text="Suggest Friends" Visible="False" />
                <br />
                <asp:Button ID="btnCancelRequest" runat="server" Enabled="False" 
                    onclick="btnCancelRequest_Click" style="position: relative" 
                    Text="Cancel Request" Visible="False" />
                <asp:Button ID="btnAddAsFriend" Visible="false" runat="server" onclick="btnAddAsFriend_Click" 
                    Text="Add As Friend" />
                <asp:Label ID="lblFriendRequestSent" runat="server" Text="Friend Request Sent" 
                    Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
            <tr>
      
            <td>
                &nbsp;</td>
            <td>
                <b>
                <img  src="../../Resources/Images/MenuIcon/location.png" />Location: </b><asp:Label ID="lblCurrentCity" runat="server" Text=""></asp:Label>
            &nbsp;
                <b>
                <img  src="../../Resources/Images/MenuIcon/town.png" />Origin:&nbsp; </b>
                         <asp:Label ID="lblHomeTown" runat="server" Text=""></asp:Label>
            &nbsp;<b> 
                <img  
                    src="../../Resources/Images/MenuIcon/realtionship.png" />Relationship Status:</b>&nbsp;
                         <asp:Label ID="lblRelationshipStatus" runat="server" Text=""></asp:Label>
            
                &nbsp;<b>
            
                <img src="../../Resources/Images/MenuIcon/gender.png" />Gender:</b>&nbsp; <asp:Label ID="lblGender" runat="server" Text=""></asp:Label>
            &nbsp;&nbsp; <b>
                <img alt="" src="../../Resources/Images/MenuIcon/Birthday.png" />BirthDay:</b>&nbsp;<asp:Label ID="lblBirthDay" runat="server" ></asp:Label>
        &nbsp;<br />
                <b>
                <img   src="../../Resources/Images/MenuIcon/Language.png" />Languages: </b>&nbsp;<asp:DataList ID="DListLanguage" runat="server" DataKeyField="_Id" RepeatColumns="5" 
                    
                 >
                    <ItemTemplate>
                      
                        <asp:Label ID="LanguageNameLabel" runat="server" 
                            Text='<%# Eval("Name") %>' />
                      
                       
                    </ItemTemplate>
                </asp:DataList>
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
        </tr>
     
         <asp:LinkButton ID="lbtnAddPhotos" runat="server" onclick="lbtnAddPhotos_Click">Add Photos</asp:LinkButton>
          </table>
            <table>
            <tr>
      
            <td>
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
  </table>
 
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:PostBackTrigger ControlID="UploadButton" />
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="GridViewWall" 
                            EventName="pageindexchanging" />
                        <asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click" />
                    </Triggers>
                    <ContentTemplate>
                          
    <table>
            <tr>
      
            <td>
                &nbsp;</td>
            <td colspan="2">
                &nbsp; &nbsp;&nbsp;
</td>
            <td>
                <asp:HyperLink ID="btncam0" runat="server" NavigateUrl="#" 
                    style="font-weight: 700; font-size: medium;">Mutual Posts</asp:HyperLink>
                </td>
        </tr>
            <tr>
      
            <td>
                &nbsp;</td>
            <td colspan="2">
&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
          </table>
       
            <table>
            <tr>
      
            <td>
                &nbsp;</td>
            <td colspan="2">
                  
                <asp:GridView ID="GridViewWall" runat="server"   AutoGenerateColumns="False" DataKeyNames="_id" 
                    onrowcommand="GridViewWall_RowCommand" onpageindexchanging="GridViewWall_PageIndexChanging"
                    GridLines="None" ShowHeader="False" Width="100%" AllowPaging="True">
                    <Columns>
                       
                     
                        <asp:TemplateField>
                           
                            <ItemTemplate>
                                <asp:ImageButton ID="Image1" runat="server" Height="32px" ImageAlign="Middle" 
                                    ImageUrl='<%# DataBinder.Eval(Container.DataItem, "PostedByUserId", "../../Resources/ProfilePictures/{0}.jpg") %>' 
                                    PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "PostedByUserId", "ViewProfile.aspx?UserId={0}") %>' 
                                    Style="position: relative" Width="32px" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                       
                     
                       <asp:TemplateField>
                            <ItemTemplate>
                              
                               
                                  
                      
                             <asp:HiddenField runat="server" ID="HiddenFieldId" Value='<%#Eval("_id")%>'></asp:HiddenField>
                             &nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" 
                              Text=' <%# Eval("FirstName","") + " " + Eval("LastName","") %>'
                              PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "PostedByUserId", "ViewProfile.aspx?UserId={0}") %>' 
                              ></asp:LinkButton>
                           <asp:Literal ID="LiteralPost"  Text='<%# Bind("Post") %>' runat="server"></asp:Literal>
                              <br />
                               <br /> <asp:Label ID="Label1" runat="server"  Text='<%# Eval("AddedDate") %>' />
                       <br />
                                
                       <!-------------     LIKE MODULE     ------------------------->

                     <asp:LinkButton ID="lbtnLike" runat="server" onclick="lbtnLike_Click" Font-Bold="False">Like</asp:LinkButton>
            &nbsp;<asp:Label ID="lblLike" runat="server" Text="" Font-Bold="False"></asp:Label>
          
           <!-------------     SHARE MODULE     ------------------------->
           <asp:LinkButton ID="ShareLinkButton" runat="server" onclick="ShareLinkButton_Click" Font-Bold="False">Share</asp:LinkButton>
            &nbsp;<asp:Label ID="ShareLabel" runat="server" Text="" Font-Bold="False"></asp:Label>
           
            <asp:LinkButton ID="lbtnUser" runat="server" onclick="lbtnUser_Click" Font-Bold="False">User</asp:LinkButton>
                        
                        <br />
                        <br />
                        <asp:LinkButton ID="lbtnViewComments" runat="server" onclick="lbtnViewComments_Click" 
                                    Font-Bold="False">View All Comments</asp:LinkButton>
                        <asp:Panel ID="PanelLikeUser" CssClass="popupControl" runat="server"> 
   <asp:UpdatePanel ID="UpdatePanel1" runat="server"> 
      <ContentTemplate>
                                <asp:GridView ID="GridViewLikesUser" runat="server" 
                    AutoGenerateColumns="False" DataKeyNames="_id" 
                    
                    GridLines="None" ShowHeader="False" Width="180" PageSize="2">
                    <Columns>
                         
                        <asp:TemplateField>
                            <ItemTemplate>
                             &nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" 
                              Text=' <%# Eval("FirstName","") + " " + Eval("LastName","") %>'
                              PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "UserId", "ViewProfile.aspx?UserId={0}") %>' 
                              ></asp:LinkButton>
                              
                            </ItemTemplate>
                            
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            
                        </asp:TemplateField>            

                   
                   
                         
                    </Columns>
                </asp:GridView>
                     
</ContentTemplate> 
   </asp:UpdatePanel> 
</asp:Panel>
<asp:PopupControlExtender ID="PopupControlExtender1" runat="server" 
   TargetControlID="lbtnUser" 
   PopupControlID="PanelLikeUser" 
   Position="Right" 
   
   OffsetX="3"> 
</asp:PopupControlExtender>
                <!--------------------- LIKE MODULE END ----------------->

                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                <asp:GridView ID="GridViewComments" AutoGenerateColumns="False" runat="server" 
                       GridLines="Horizontal"     CellPadding="4" ForeColor="#333333" 
                    Width="300px" ShowHeader="False" BorderColor="White" BorderStyle="Solid" 
                            BorderWidth="0px">

                  <RowStyle CssClass="GridRowStyle"/>
                   
                     <Columns>
                       <asp:TemplateField>
                    <ItemTemplate>
                          <asp:ImageButton ID="Image1" runat="server" Height="24px" ImageAlign="Middle" 
                                    ImageUrl='<%# DataBinder.Eval(Container.DataItem, "UserId", "../../Resources/ProfilePictures/{0}.jpg") %>' 
                                    PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "UserId", "ViewProfile.aspx?UserId={0}") %>' 
                                    Style="position: relative" Width="24px" />

                           </ItemTemplate>
                           <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:TemplateField>
                      <asp:TemplateField>
                    <ItemTemplate>
                        &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" 
                              Text=' <%# Eval("FirstName","") + " " + Eval("LastName","") %>'
                              PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "UserId", "ViewProfile.aspx?UserId={0}") %>' 
                              ></asp:LinkButton>
                          <asp:Label ID="NameLabel" runat="server"  Text='<%# Eval("MyComments") %>' />
                         <br /> <asp:Label ID="Label1" runat="server"  Text='<%# Eval("AddedDate") %>' />
                       
                        <br />

                        <!-------------     Comment Like + Show Like user     -------->

                    <asp:HiddenField runat="server" ID="HiddenFieldId" Value='<%#Eval("_id")%>'></asp:HiddenField>
                     <asp:HiddenField runat="server" ID="HiddenFieldCommentUserId" Value='<%#Eval("UserId")%>'></asp:HiddenField>
                   <asp:LinkButton ID="lbtnCommentLike" runat="server" onclick="lbtnCommentLike_Click" Font-Bold="False">Like</asp:LinkButton>
                            <asp:Label ID="lblCommentLike" runat="server" Text="" Font-Bold="False"></asp:Label>   
            <asp:LinkButton ID="lbtnCommentLikeUser" runat="server" OnClick="lbtnCommentLikeUser_Click" Font-Bold="False">User</asp:LinkButton>
            <br />
            <asp:LinkButton ID="lbtnDeleteComment" runat="server" OnClick="lbtnDeleteComment_Click" Visible="false" Font-Bold="False">Delete</asp:LinkButton>
                     <asp:Panel ID="PanelLikeUser" CssClass="popupControl" runat="server"> 
   <asp:UpdatePanel ID="UpdatePanelLikesCommentUser" runat="server"> 
      <ContentTemplate>
                    <asp:GridView ID="GridViewLikesCommentUser" runat="server" 
                    AutoGenerateColumns="False" DataKeyNames="_id" 
                    
                    GridLines="None" ShowHeader="False" Width="180" PageSize="2">
                    <Columns>
                         
                        <asp:TemplateField>
                            <ItemTemplate>
                             &nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" 
                              Text=' <%# Eval("FirstName","") + " " + Eval("LastName","") %>'
                              PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "UserId", "ViewProfile.aspx?UserId={0}") %>' 
                              ></asp:LinkButton>
                              
                            </ItemTemplate>
                            
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            
                        </asp:TemplateField>            
 
                    </Columns>
                </asp:GridView>
</ContentTemplate> 
   </asp:UpdatePanel> 
</asp:Panel>
<asp:PopupControlExtender ID="PopupControlExtenderCommentUser" runat="server" 
   TargetControlID="lbtnCommentLikeUser" 
   PopupControlID="PanelLikeUser" 
   Position="Right" 
   
   OffsetX="3"> 
</asp:PopupControlExtender>
                <!----------- END Comment Like ------->

                    </ItemTemplate>
                          <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:TemplateField>
                     </Columns>
                </asp:GridView>
                 </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtComments" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>


                    <br />
                    <asp:ImageButton ID="imgCommentsUser" runat="server"  Height="24px" ImageAlign="Middle" 
         
                                     Style="position: relative" Width="24px" />
                 <asp:TextBox ID="txtComments" runat="server" Width="259px" EnableViewState="true" AutoPostBack="true" ontextchanged="txtComments_TextChanged"
                        ></asp:TextBox>

                          <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" WatermarkCssClass="water" TargetControlID="txtComments" WatermarkText="Write a comment...">
                   </asp:TextBoxWatermarkExtender>
                         <br />
                               <br />
                            </ItemTemplate>
                            
                          
                      
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                            
                     
                      
                        </asp:TemplateField>            

                   
                   
                         
                    </Columns>
                       <PagerStyle CssClass="GridPagerStyle" ForeColor="White"   />
                    <PagerSettings Mode="NextPrevious" FirstPageText="First Post" 
                        LastPageText="Last Post" NextPageText="More Post " 
                        PreviousPageText="Previous Post  | " />
                
                </asp:GridView>
             
                   
                <br />
                
                <!-------------     2nd Grid     ------------------------->

                <br />

                   
                </td>
            <td>
                &nbsp;</td>
        </tr>
            <tr>
      
            <td>
                &nbsp;</td>
                <br />
                
            <td colspan="2" style="text-align: center">
           
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="#" 
                    style="font-weight: 700; font-size: medium;">Mutual Friends</asp:HyperLink>
                <br />
                <asp:GridView ID="GridViewFriendsList" runat="server" 
                    AutoGenerateColumns="False" DataKeyNames="Id" GridLines="None" PageSize="2" 
                    ShowHeader="False" Width="307px">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" 
                            SortExpression="Id" Visible="false" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="Image2" runat="server" Height="32px" ImageAlign="Middle" 
                                    ImageUrl='<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "../../Resources/ProfilePictures/{0}.jpg") %>' 
                                    PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "ViewProfile.aspx?UserId={0}") %>' 
                                    Style="position: relative" Width="32px" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                &nbsp;&nbsp;<asp:LinkButton ID="LinkButton2" runat="server" 
                                    PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "UserId", "ViewProfile.aspx?UserId={0}") %>' 
                                    Text=' <%# Eval("FirstName","") + " " + Eval("LastName","") %>'></asp:LinkButton>
                                <br />
                                <br />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
               </td>
            <td class="style5">
                &nbsp;</td>
            <td>
</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
              </td>
            <td class="style5">
                &nbsp;</td>
            <td>
                         <asp:TextBox ID="txtUpdatePost" runat="server" Height="47px" 
                             TextMode="MultiLine" Visible="false" Width="458px"></asp:TextBox>
                         &nbsp;<asp:Button ID="btnPost" runat="server" CssClass="button" 
                             onclick="btnPost_Click" Text="Post" Visible="false" />
                         <br />
                         <asp:Label ID="PhotoLabel" runat="server" Text="Add Description" 
                             Visible="false"></asp:Label>
                         <br />
                         <asp:TextBox ID="ShareDescriptionTextBox" runat="server" Height="43px" 
                             TextMode="MultiLine" Visible="false" Width="453px"></asp:TextBox>
                         <br />
                         <asp:FileUpload ID="FileUpload1" runat="server" Visible="false" />
                         &nbsp;<asp:Button ID="UploadButton" runat="server" CssClass="button" 
                             onclick="UploadPhotos_Click" Text="Upload Photos" Visible="false" />
                         <br />
                         <asp:HyperLink ID="btncam" Text="" runat="server" NavigateUrl="#" 
                             style="font-weight: 700; font-size: medium;"></asp:HyperLink>
                         <br />
                         <asp:Button ID="btnCamSave" runat="server" cssClass="button" 
                             onclick="btnCamSave_Click" Text="Save Image" Visible="false" />
                         <br />
                         <asp:Label ID="lblLocation" runat="server" Text="" Visible="false"></asp:Label>
                         <asp:Literal ID="lblFriendsWith" runat="server" Visible="false"></asp:Literal>
                         <asp:Literal ID="lblFriendsTag" runat="server" Visible="false"></asp:Literal>
                         <br />
                         &nbsp;<asp:TextBox ID="txtLocation" runat="server" AutoPostBack="True" 
                             ontextchanged="txtLocation_TextChanged" Text='<%# Eval("Location") %>' 
                             Visible="false" Width="300px"></asp:TextBox>
                         <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" 
                             TargetControlID="txtLocation" WatermarkCssClass="water" 
                             WatermarkText="Where are you?">
                         </asp:TextBoxWatermarkExtender>
                         <asp:AutoCompleteExtender ID="AutoCompleteExtender6" runat="server" 
                             CompletionInterval="1000" CompletionListCssClass="AutoExtender" 
                             CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                             CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="1" 
                             EnableCaching="true" MinimumPrefixLength="1" 
                             OnClientItemSelected=" OnLocationSelected" 
                             OnClientPopulated="Location_Populated" ServiceMethod="GetLocationwithCount" 
                             ServicePath="WebService.asmx" TargetControlID="txtLocation">
                         </asp:AutoCompleteExtender>
                         <br />
                         <asp:HiddenField ID="HiddenField1" runat="server" />
                         &nbsp;<asp:TextBox ID="txtFriendWith" runat="server" AutoComplete="Off" 
                             AutoPostBack="True" ontextchanged="txtFriendWith_TextChanged" Visible="false" 
                             Width="300"></asp:TextBox>
                         <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" runat="server" 
                             TargetControlID="txtFriendWith" WatermarkCssClass="water" 
                             WatermarkText="Who are with you?">
                         </asp:TextBoxWatermarkExtender>
                         <asp:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" 
                             CompletionInterval="1000" CompletionListCssClass="AutoExtender" 
                             CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                             CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="1" 
                             EnableCaching="true" MinimumPrefixLength="1" 
                             OnClientItemSelected=" OnFUserSelected" OnClientPopulated="FUser_Populated" 
                             ServiceMethod="GetFriendsName" ServicePath="WebService.asmx" 
                             TargetControlID="txtFriendWith">
                         </asp:AutoCompleteExtender>
                         <br />
                         <asp:HiddenField ID="HiddenFieldTagId" runat="server" />
                         &nbsp;<asp:TextBox ID="txtFriendTag" runat="server" AutoComplete="Off" 
                             AutoPostBack="True" ontextchanged="txtFriendTag_TextChanged" Visible="false" 
                             Width="300"></asp:TextBox>
                         <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" 
                             TargetControlID="txtFriendTag" WatermarkCssClass="water" 
                             WatermarkText="Tag friend here...">
                         </asp:TextBoxWatermarkExtender>
                         <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                             CompletionInterval="1000" CompletionListCssClass="AutoExtender" 
                             CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                             CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="1" 
                             EnableCaching="true" MinimumPrefixLength="1" 
                             OnClientItemSelected=" OnTagUserSelected" OnClientPopulated="TagUser_Populated" 
                             ServiceMethod="GetFriendsName" ServicePath="WebService.asmx" 
                             TargetControlID="txtFriendTag">
                         </asp:AutoCompleteExtender>
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
                         <asp:DataList ID="DataListTagPhotos" runat="server" HorizontalAlign="Center" 
                             RepeatColumns="5" RepeatDirection="Horizontal" Visible="false" Width="100%">
                             <ItemTemplate>
                                 <asp:HiddenField ID="HiddenField2" runat="server" Value='<%#Eval("_id")%>' />
                                 <asp:ImageButton ID="Image3" runat="server" BorderColor="Silver" 
                                     BorderStyle="Solid" BorderWidth="2px" Height="100px" ImageAlign="Middle" 
                                     ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Atid", "../../Resources/UserPhotos/{0}.jpg") %>' 
                                     PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "Atid", "ViewPhoto.aspx?PhotoId={0}") %>' 
                                     Style="position: relative" Width="100px" />
                                 <img src='<%# DataBinder.Eval(Container.DataItem, "Atid", "../../Resources/UserPhotos/{0}.jpg") %>' style="display: none;visibility: hidden;" />
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
                         <asp:LinkButton ID="lbtnUpdatePost0" runat="server" Visible="false">Update Post</asp:LinkButton>
                         <asp:LinkButton ID="lbtnAddPhoto0" runat="server" onclick="lbtnAddPhoto_Click" 
                             Visible="false">Add Photos</asp:LinkButton>
                         <asp:LinkButton ID="lbtnAddVideos0" runat="server" Visible="false">Add Videos</asp:LinkButton>
            </td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
            <td>
               </td>
            <td class="style5">
                &nbsp;</td>
            <td>
                          </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
               </td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                </td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
           </ContentTemplate>
                </asp:UpdatePanel>
</asp:Content>