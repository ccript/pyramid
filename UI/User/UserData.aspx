<%@ Page Title=""  enableEventValidation="false"  Language="C#" MasterPageFile="~/UI/User/MasterPage.master" AutoEventWireup="true" CodeFile="UserData.aspx.cs" Inherits="Wall" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


  <script type="text/javascript" src="../../Resources/fancyzoom/jquery.js"></script>
<script type="text/javascript" src="../../Resources/fancyzoom/jquery.dimension.js"></script>
<link href="../../Resources/adipoli-v2/adipoli.css" rel="stylesheet" type="text/css"/>
<script src="../../Resources/adipoli-v2/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="../../Resources/adipoli-v2/jquery.adipoli.min.js" type="text/javascript"></script>

<script type="text/javascript" src="../../Resources/fancyzoom/jquery.shadow.js"></script>
<script type="text/javascript" src="../../Resources/fancyzoom/jquery.ifixpng.js"></script>

 
<script type="text/javascript" src="../../Resources/fancyzoom/jquery.fancyzoom.js"></script>
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
               'startEffect': 'overlay',
               'hoverEffect': 'boxRainGrowReverse'
           });
           $('.row62').adipoli({
               'startEffect': 'grayscale',
               'hoverEffect': 'normal'
           });
       });
            
        </script>

<script type="text/javascript">
    $(function () {
        //Set the default directory to find the images needed
        //by the plugin (closebtn.png, blank.gif, loading images ....)
        $.fn.fancyzoom.defaultsOptions.imgDir = '../../Resources/fancyzoom/ressources/'; //very important must finish with a /

        // Select all links in object with gallery ID using the defaults options
        $('#gallery a').fancyzoom();

        // Select all links with tozoom class, set the open animation time to 1000
        $('a.tozoom').fancyzoom({ Speed: 1000 });

        // Select all links set the overlay opacity to 80%
        $('a').fancyzoom({ overlay: 0.8 });

        //new rev > 1.2
        //apply fancyzoom effect on all image whose class is fancyzoom !!
        $('img.fancyzoom').fancyzoom();


    });
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
               div.innerHTML =  + item[i]._value + " were here </br>";
 
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

       // tag freinds in posting
       function OnWallTagUserSelected(source, eventArgs) {
           var idx = source._selectIndex;
           var employees = source.get_completionList().childNodes;
           var value = employees[idx]._value;
           var text = employees[idx].firstChild.nodeValue;
           source.get_element().value = text;
           $get('<%= HiddenFieldWallTagId.ClientID %>').value = value;
          
       }

       // tag freinds in posting
       function WallTagUser_Populated(sender, e) {
           var item = sender.get_completionList().childNodes;
           for (var i = 0; i < item.length; i++) {
               var div = document.createElement("DIV");
               div.innerHTML = "<img style = 'height:24px;width:24px' src = '../../Resources/ProfilePictures/"
                  + item[i]._value + ".jpg' /><br />";
               item[i].appendChild(div);

           }
       }

</script>
<script type="text/javascript">
    function ShowSuccess(message) {
        $alert = $('#MBWrapper1');

        $alert.removeClass().addClass('MessageBoxInterface');
        $alert.children('p').remove();
        $alert.append('<p>' + message + '</p>').addClass('successMsg').show().delay(8000).slideUp(300);
    }

    function ShowError(message) {
        $alert = $('#MBWrapper2');

        $alert.removeClass().addClass('MessageBoxInterface');
        $alert.children('p').remove();
        $alert.append('<p>' + message + '</p>').addClass('errorMsg').show().delay(8000).slideUp(300);
    }
    </script>
    <style type="text/css">
        .style1
        {
            color: #808080;
        }
                  
         
        .HoverCSS  
        {  
            
            
            text-decoration: underline; 
            }  
            
        .PopUp

{

display: none;
background-color: white;

border-width: 1px;
border-color: black;

border-style: solid; padding: 10px;
}
        a.my_style{ 
        text-decoration: none; 
    } 


    a.my_style:hover { 
        text-decoration: underline; 
    }
    
    
   .bubble{

    border-radius: 5px;
    box-shadow: 0 0 6px #B2B2B2;
    display: inline-block;
    padding: 10px 18px;
    position: relative;
    vertical-align: top;
    background: #ffffff; /* Old browsers */
background: -moz-linear-gradient(top, #ffffff 0%, #f6f6f6 47%, #ededed 100%); /* FF3.6+ */
background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#ffffff), color-stop(47%,#f6f6f6), color-stop(100%,#ededed)); /* Chrome,Safari4+ */
background: -webkit-linear-gradient(top, #ffffff 0%,#f6f6f6 47%,#ededed 100%); /* Chrome10+,Safari5.1+ */
background: -o-linear-gradient(top, #ffffff 0%,#f6f6f6 47%,#ededed 100%); /* Opera 11.10+ */
background: -ms-linear-gradient(top, #ffffff 0%,#f6f6f6 47%,#ededed 100%); /* IE10+ */
background: linear-gradient(top, #ffffff 0%,#f6f6f6 47%,#ededed 100%); /* W3C */
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#ffffff', endColorstr='#ededed',GradientType=0 ); /* IE6-9 */
}

.bubble::before {
    background-color: #FFFFFF;
    content: "\00a0";
    display: block;
    height: 16px;
    position: absolute;
    top: 11px;
    transform:             rotate( 29deg ) skew( -35deg );
        -moz-transform:    rotate( 29deg ) skew( -35deg );
        -ms-transform:     rotate( 29deg ) skew( -35deg );
        -o-transform:      rotate( 29deg ) skew( -35deg );
        -webkit-transform: rotate( 29deg ) skew( -35deg );
    width:  20px;
}

.me {
    float: left;   
    margin: 5px 0px 5px 20px;         
}

.me::before {
    box-shadow: -2px 2px 2px 0 rgba( 178, 178, 178, .4 );
    left: -9px;           
}

  
   .bubble2{

    border-radius: 5px;
    box-shadow: 0 0 6px #B2B2B2;
    display: inline-block;
    padding: 10px 18px;
    position: relative;
    vertical-align: top;
background: #ffffff; /* Old browsers */
background: -moz-linear-gradient(top, #ffffff 29%, #d6dbbf 100%); /* FF3.6+ */
background: -webkit-gradient(linear, left top, left bottom, color-stop(29%,#ffffff), color-stop(100%,#d6dbbf)); /* Chrome,Safari4+ */
background: -webkit-linear-gradient(top, #ffffff 29%,#d6dbbf 100%); /* Chrome10+,Safari5.1+ */
background: -o-linear-gradient(top, #ffffff 29%,#d6dbbf 100%); /* Opera 11.10+ */
background: -ms-linear-gradient(top, #ffffff 29%,#d6dbbf 100%); /* IE10+ */
background: linear-gradient(top, #ffffff 29%,#d6dbbf 100%); /* W3C */
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#ffffff', endColorstr='#d6dbbf',GradientType=0 ); /* IE6-9 */
}

.bubble2::before {
    background-color: #FFFFFF;
    content: "\00a0";
    display: block;
    height: 16px;
    position: absolute;
    top: 11px;
    transform:             rotate( 29deg ) skew( -35deg );
        -moz-transform:    rotate( 29deg ) skew( -35deg );
        -ms-transform:     rotate( 29deg ) skew( -35deg );
        -o-transform:      rotate( 29deg ) skew( -35deg );
        -webkit-transform: rotate( 29deg ) skew( -35deg );
    width:  20px;
}

.me2 {
    float: left;   
    margin: 5px 0px 5px 20px;         
}

.me2::before {
    box-shadow: -2px 2px 2px 0 rgba( 178, 178, 178, .4 );
    left: -9px;           
}
  
        .style981
        {
            width: 100%;
        }
    </style>
</asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <table>
        <tr>
            <td>
                </td>
            <td colspan="2">
                <asp:Label ID="lblName" runat="server" 
                    style="font-size: x-large; font-weight: 700" ></asp:Label>
                <br />
                <asp:Button ID="btnSuggestFriends" CssClass="button"  runat="server" 
                    onclick="btnSuggestFriends_Click" Text="Suggest Friends !" Visible="False" />
                <br />
                <asp:Button ID="btnCancelRequest" CssClass="button"  runat="server" Enabled="False" 
                    onclick="btnCancelRequest_Click" style="position: relative" 
                    Text="Cancel Request !" Visible="False" />
                <asp:Button ID="btnAddAsFriend" CssClass="button"  runat="server" onclick="btnAddAsFriend_Click" 
                    Text="Add As Friend !" />
                <asp:Label ID="lblFriendRequestSent"   runat="server" Text="Friend Request Sent" 
                    Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
            <tr>
      
            <td>
                &nbsp;</td>
            <td>
         <asp:Panel ID="pnlUserInfo" runat="server">
             
                <b>

                <img  src="../../Resources/Images/MenuIcon/location.png" /> &nbsp;Location:</b><asp:Label ID="lblCurrentCity" runat="server" Text=""></asp:Label>
            &nbsp;
                <b>
                <img  src="../../Resources/Images/MenuIcon/town.png" />&nbsp;Origin: </b>
                         <asp:Label ID="lblHomeTown" runat="server" Text=""></asp:Label>
            &nbsp;<b> 
                <img  
                    src="../../Resources/Images/MenuIcon/realtionship.png" />&nbsp;Relationship Status:</b>
                         <asp:Label ID="lblRelationshipStatus" runat="server" Text=""></asp:Label>
            
                &nbsp;<b>
            
                <img src="../../Resources/Images/MenuIcon/gender.png" />&nbsp;Gender:</b><asp:Label ID="lblGender" runat="server" Text=""></asp:Label>
            &nbsp;&nbsp; <b>
                <br/><img   alt="" src="../../Resources/Images/MenuIcon/Birthday.png" />&nbsp;BirthDay:</b><asp:Label ID="lblBirthDay" runat="server" ></asp:Label>
        &nbsp;<br />
                <b>
                    <asp:Panel ID="pnlLanguages" runat="server">
                   
                        <table >
                            <tr>
                                <td>
                                    <b>
                                    <img   src="../../Resources/Images/MenuIcon/Language.png" />
                                    &nbsp;Languages:</b></td>
                                <td>
                                    <b>
                                    <asp:DataList ID="DListLanguage" runat="server" DataKeyField="_Id" 
                                        RepeatColumns="5">
                                        <ItemStyle VerticalAlign="Bottom" />
                                        <ItemTemplate>
                                            <asp:Label ID="LanguageNameLabel" runat="server" Text='<%# Eval("Name") %>' />
                                        </ItemTemplate>
                                    </asp:DataList>
                                    </b>
                                </td>
                            </tr>
                        </table>
                 </asp:Panel>
                    <asp:DataList ID="dlBirthday" runat="server" RepeatColumns="5">
                        <HeaderTemplate>
                            <b>Friends Birthday Alerts: </b>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <img alt=""
src="../../Resources/Images/MenuIcon/Birthday.png" />
                            <asp:LinkButton ID="LinkButton1" runat="server" 
                                PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "FriendUserId", "ViewProfile.aspx?UserId={0}") %>' 
                                Text=' <%# Eval("FirstName","") + " " + Eval("LastName","") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:DataList>
                   
                  </asp:Panel>
                </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
   
     
         
          </table>
            <table>
            <tr>
      
            <td>
                &nbsp;</td>
            <td colspan="2">
            <asp:HiddenField ID="HiddenFieldWallTagId" runat="server" />  

              <asp:DataList ID="DataListTagPhotos" runat="server" 
                    HorizontalAlign="Center" RepeatColumns="3" RepeatDirection="Horizontal" 
                    Width="100%">
                 
                    <ItemTemplate>

                     <asp:HiddenField runat="server" ID="HiddenField1" Value='<%#Eval("_id")%>'></asp:HiddenField>
                 
                      

                    <a href='<%# DataBinder.Eval(Container.DataItem, "Atid", "../../Resources/UserPhotos/{0}.jpg") %>'>
           
                        <img class="img-style row5" src='<%# DataBinder.Eval(Container.DataItem, "Atid", "../../Resources/ThumbnailPhotos/{0}.jpg") %>'   alt=""/>
                             </a>
<br />
                    </ItemTemplate>
                </asp:DataList>
                </td>
            <td>
                &nbsp;</td>
        </tr>
  </table>

 
<%-- 
       <asp:confirmbuttonextender id="Post_ConfirmButtonExtender" 
		runat="server" targetcontrolid="btnPost" enabled="True" 
		displaymodalpopupid="Post_ModalPopupExtender">
        </asp:confirmbuttonextender>
          <asp:modalpopupextender 
		id="Post_ModalPopupExtender" runat="server" 
		 okcontrolid="ButtonPostOkay" 
		targetcontrolid="btnPost" popupcontrolid="DivPostConfirmation" 
		>
          
        </asp:modalpopupextender>
       
        <asp:panel class="popupConfirmation" id="DivPostConfirmation" 
	style="display: none" runat="server">
    <div class="popup_Container">
        <div class="popup_Titlebar" id="PopupHeader">
            <div class="TitlebarLeft">
                Post</div>
            <div  onclick="$get('ButtonDeleteCancel').click();">
            </div>
        </div>
        <div class="popup_Body">
            <p>
             <img src="../../Resources/Images/MenuIcon/success_alert.gif" />  Your message has been successfully posted to your wall !!
            </p>
        </div>
        <div class="popup_Buttons">
           <asp:Button ID="ButtonPostOkay" OnClick="btnPostOkay_Click" runat="server" Text="Ok" />
       
  
        </div>
    </div>
</asp:panel>--%>

 
    <asp:Panel ID="PanelPostContent" runat="server">
            <asp:TabContainer runat="server" ID="Tabs" ActiveTabIndex="-1" Width="480px" >
            <asp:TabPanel runat="server" ID="Panel1" HeaderText="Photos">
                <ContentTemplate>
               
                 <asp:FileUpload ID="FileUploadPhoto" runat="server" />
                   <br /><br />
              <asp:LinkButton ID="lbtnAddPhotos" runat="server" onclick="lbtnAddPhotos_Click">Add Photo</asp:LinkButton>
                   </ContentTemplate>
            </asp:TabPanel>

               <asp:TabPanel runat="server" ID="TabPanel1" HeaderText="Video">
                <ContentTemplate>
           
                 <asp:FileUpload ID="FileUpload1" runat="server" />
                      <br /><br />
                           <asp:LinkButton ID="lbtnAddVideos" runat="server" OnClick="lbtnAddVideos_Click">Add Video</asp:LinkButton>
                   </ContentTemplate>
            </asp:TabPanel>

               <asp:TabPanel runat="server" ID="TabPanel2" HeaderText="Album">
                <ContentTemplate>
                <table class="style1">
       
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Name:</td>
            <td>
                <asp:TextBox ID="txtName" CssClass="asptextbox"  runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Description:</td>
            <td>
                <asp:TextBox ID="txtDescription" CssClass="asptextbox" runat="server"></asp:TextBox></td>
            <td>
                &nbsp;</td>
        </tr>

          <tr>
            <td>
                &nbsp;</td>
            <td>
                </td>
            <td>
             
               <asp:LinkButton ID="lbtnAlbum" runat="server" OnClick="lbtnAlbum_Click">Add Album</asp:LinkButton></td>
            <td>
                &nbsp;</td>
        </tr>
     
    </table>
                   </ContentTemplate>
            </asp:TabPanel>

              <asp:TabPanel runat="server" ID="TabPanel3" HeaderText="WebCam Photo">
                <ContentTemplate>
                <object height="190" width="405">
                         <param name="movie" value="../../Resources/PhotoCam/save_picture.swf">
                         <embed height="190" src="../../Resources/PhotoCam/save_picture.swf" 
                             width="405"></embed>
                         </param></object>
                         
                        
                   </ContentTemplate>
            </asp:TabPanel>

 </asp:TabContainer>     
 <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
     <ContentTemplate>
    <table>
           
            <tr>
      
            <td>
               </td>
            <td>
               <asp:TextBox ID="txtUpdatePost" runat="server" Height="47px" TextMode="MultiLine" 
                AutoPostback="true" CssClass="asptextbox"   ontextchanged="txtUpdatePost_TextChanged" Width="460px"></asp:TextBox></div>


 
                <br /> <asp:Label ID="lblLocation" runat="server" Text=""></asp:Label>
                <asp:Literal ID="lblFriendsWith" runat="server"></asp:Literal>
               <asp:Literal ID="lblFriendsTag" runat="server"></asp:Literal>
                <br /><img  src="../../Resources/Images/MenuIcon/location.png" />
                        <asp:TextBox ID="txtLocation" Width="440px"  runat="server" 
                     AutoPostBack="True" ontextchanged="txtLocation_TextChanged" Text="Where are you?"  CssClass="wm watermark"></asp:TextBox>

         

                   <asp:AutoCompleteExtender ID="AutoCompleteExtender6" runat="server" TargetControlID="txtLocation" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetLocationwithCount" 
CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight" 
OnClientPopulated ="Location_Populated"
    OnClientItemSelected = " OnLocationSelected" >
</asp:AutoCompleteExtender> 
                        <br />

                         <asp:HiddenField ID="HiddenField1" runat="server" />  
                            <img src="../../Resources/Images/MenuIcon/AddFriends.png" />   <asp:TextBox ID="txtFriendWith" runat="server" AutoComplete="Off"  
                    Width="440" AutoPostBack="True" ontextchanged="txtFriendWith_TextChanged" Text="Who are with you?" CssClass="wm watermark"></asp:TextBox>


                <asp:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="txtFriendWith" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetFriendsName" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight" 
OnClientPopulated ="FUser_Populated"
    OnClientItemSelected = " OnFUserSelected" >
    </asp:AutoCompleteExtender> 

    <br />

                         <asp:HiddenField ID="HiddenFieldTagId" runat="server" />  
                            <img src="../../Resources/Images/MenuIcon/AddFriends.png" />   <asp:TextBox ID="txtFriendTag" runat="server" AutoComplete="Off" Text="Tag friend here..."   CssClass="wm watermark"
                    Width="440" AutoPostBack="True" ontextchanged="txtFriendTag_TextChanged"></asp:TextBox>



          
                <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtFriendTag" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetFriendsName" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight" 
OnClientPopulated ="TagUser_Populated"
    OnClientItemSelected = " OnTagUserSelected" >
    </asp:AutoCompleteExtender> 


                </td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
         <td>
                &nbsp;</td>
            <td>
                
                <asp:Literal ID="LiteralUploadPhoto" runat="server"></asp:Literal>  
                  <asp:Literal ID="LiteralUploadVideo" runat="server"></asp:Literal> </td>
            <td>
            
                &nbsp;</td>
        </tr>

            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnPost" runat="server" CssClass="button" 
                        onclick="btnPost_Click" Text="Post" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>

        <tr>
         <td>
                &nbsp;</td>
            <td>
                
         <asp:Panel ID="pnlVideoLink" runat="server" Visible="False" BackColor="#FFFF99" 
                    Height="150px" Width="458px">
                <asp:Button ID="btnClose" runat="server" Text="X" onclick="btnClose_Click" />
             
             <asp:HyperLink ID="hlVideoLink" runat="server" ></asp:HyperLink>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
          
             <asp:DataList ID="dlThumbnail" runat="server" AutoGenerateColumns="False" 
                            ShowFooter="False" HorizontalAlign="Left" RepeatDirection="Horizontal" >
                    
              <ItemTemplate>
               <table cellpadding="2" cellspacing="2">
                    <tr>
                        <td valign="middle" align="center" 
            style="background-color:#cccccc;border:1px solid gray;
            ">

                  
                   <asp:Image ID="Image1" runat="server" 
         ImageUrl='<%# Bind("ImgSrc") %>' />
         
         
                            </td>
                               </tr>
                </table>
                    </ItemTemplate>
                   
             </asp:DataList>
             <br />
                        <br />
                        <br />
                <asp:label id="lblCurrentPage" runat="server"></asp:label>
            <asp:button id="cmdPrev" runat="server" text=" << " onclick="cmdPrev_Click"></asp:button>

<asp:button id="cmdNext" runat="server" text=" >> " onclick="cmdNext_Click"></asp:button>
          

                <asp:CheckBox ID="chkThumbnail" runat="server" Text="No Thumbnail" 
                    oncheckedchanged="chkThumbnail_CheckedChanged" />
          </ContentTemplate>
        <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cmdNext" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="cmdPrev" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="chkThumbnail" EventName="CheckedChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                  </asp:Panel>
             </td>
            <td>
            
                &nbsp;</td>
        </tr>
          </table>
          </ContentTemplate> 
   </asp:UpdatePanel> 
                </asp:Panel>

                   <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
     <Triggers>
 
    <asp:PostBackTrigger ControlID="lbtnTopStories" />

<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
         <asp:AsyncPostBackTrigger ControlID="GridViewWall" 
             EventName="pageindexchanging" />


<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>






 </Triggers>
                    <ContentTemplate>

            <table>
            <tr>
      
            <td>
   
                &nbsp;</td>
            <td colspan="2">
                <asp:Panel ID="PanelSort" runat="server">
           

                  <asp:LinkButton ID="lbtnSortNews" runat="server" CssClass="Sort" 
                        Font-Bold="True" ForeColor="#333333" 
                       >SORT</asp:LinkButton>
                    <asp:Panel ID="PopupMenu" CssClass="popupControl"
        runat="server">
             
        <asp:LinkButton runat ="server"  ID="lbtnTopStories" CssClass="my_style"
             
                            CommandName="Top" Text="Top Stories" 
                            onclick="lbtnTopStories_Click" />
        <br />
                        
        <asp:LinkButton ID="lbtnRecent" runat="server" CssClass="my_style"
            CommandName="Recent" Text="Most Recent" onclick="lbtnRecent_Click"/>
    </asp:Panel>
    <asp:HoverMenuExtender ID="hme2" runat="Server"
    TargetControlID="lbtnSortNews"
    PopupControlID="PopupMenu"
    HoverCssClass="HoverCSS"
    PopupPosition="Left"
    OffsetX="0"
    OffsetY="0"
    PopDelay="50" />

         </asp:Panel>
                <asp:GridView ID="GridViewWall" runat="server"   AutoGenerateColumns="False" DataKeyNames="_id" 
                    onrowcommand="GridViewWall_RowCommand" 
                    OnRowDataBound="GridViewWall_RowDataBound" 

                     OnRowCreated="GridViewWall_RowCreated"
                    onpageindexchanging="GridViewWall_PageIndexChanging" ShowHeader="False" 
                    Width="720px" AllowPaging="True" CellSpacing="0" GridLines="None" 
                  >
                    <Columns>
                       
                     
                        <asp:TemplateField>
                           
                            <ItemTemplate>
                            <asp:HiddenField runat="server" ID="HiddenFieldUserId" Value='<%#Eval("PostedByUserId")%>'></asp:HiddenField>
                                <asp:ImageButton ID="Image1" runat="server" Height="48px" ImageAlign="Middle" 
                                    ImageUrl='<%# DataBinder.Eval(Container.DataItem, "PostedByUserId", "../../Resources/ProfilePictures/{0}.jpg") %>' 
                                    PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "PostedByUserId", "UserData.aspx?UserId={0}") %>' 
                                    Style="position: relative" Width="48px" />&nbsp;

                                     <asp:PopupControlExtender 
   ID="PopupControlExtenderPanelWallUser" 
   runat="server" 
   DynamicServiceMethod="GetDynamicContent"
   DynamicServicePath="WebService.asmx"
   DynamicContextKey='<%# Eval("PostedByUserId") %>'
   DynamicControlID="PanelWallUser"
   TargetControlID="Image1"
   PopupControlID="PanelWallUser"
   Position="left"
   OffsetX="-170"
   >

</asp:PopupControlExtender>
       <asp:Panel ID="PanelWallUser" runat="server" CssClass="popupControl" width="200px"> </asp:Panel>
                            </ItemTemplate>

                                
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="35px" />
                        </asp:TemplateField>
                       
                     
                       <asp:TemplateField>
                            <ItemTemplate>
                      <!--------------------- HIDE STORY MENU ----------------->

                                      <asp:ImageButton ID="postoptions" runat="server" ImageUrl="~/Resources/Images/Icon/bullet_arrow_down.png" style="float:right; margin-left:100px;" 
visible='<%#getVisibilityForPost(Eval("PostedByUserId"))%>'/>
     <asp:Panel ID="PopupMenuPostOpt" CssClass="popupControl" runat="server">
              <asp:LinkButton runat ="server"  ID="lbtnHideStory" CssClass="my_style"
             
                            CommandName="Top" Text="Hide Story" 
                            onclick="lbtnHideStory_Click" />
        <br />
                        
        <asp:LinkButton ID="lbtnReportStory" runat="server" CssClass="my_style"
            CommandName="Recent" Text="Report story or spam" onclick="lbtnReportStory_Click"/>
       
                                 <hr />
                                 
                                 <asp:LinkButton ID="lbtnAllUpdates" runat="server" CssClass="my_style"
            CommandName="Recent" Text="All Updates" onclick="lbtnAllUpdates_Click"/>
            <asp:Image ID="Image3" visible='<%#getcheckmarkVisibilityAll(Eval("PostedByUserId"))%>' runat="server" ImageUrl="~/Resources/Images/Icon/checkmark.png" />
            <br />
         
        <asp:LinkButton ID="lbtnMostUpdates" runat="server" CssClass="my_style"
            CommandName="Recent" Text="Most Updates" onclick="lbtnMostUpdates_Click"/>
        <asp:Image ID="imgcheck" visible='<%#getcheckmarkVisibilityMost(Eval("PostedByUserId"))%>' runat="server" ImageUrl="~/Resources/Images/Icon/checkmark.png" />
        <br />
               
        <asp:LinkButton ID="lbtnOnlyImp" runat="server" CssClass="my_style"
            CommandName="Recent" Text="Only Important" onclick="lbtnOnlyImp_Click"/>
            <asp:Image ID="Image2" visible='<%#getcheckmarkVisibilityImp(Eval("PostedByUserId"))%>' runat="server" ImageUrl="~/Resources/Images/Icon/checkmark.png" />          
            <hr />
             <asp:LinkButton runat ="server"  ID="lbtnUnSubscribeAll" CssClass="my_style"
             
                            CommandName="Top" Text="UnSubscribe to all posts" 
                            onclick="lbtnUnSubscribeAll_Click" OnClientClick="displaymessage();" />
        <br />
                        
        <asp:LinkButton ID="lbtnUnsubscribe" runat="server" CssClass="my_style"
            CommandName="Recent" Text='<%# getTypeName(Eval("Type"))%>' onclick="lbtnUnsubscribe_Click"/>
    </asp:Panel>
    <asp:HoverMenuExtender ID="hme2PO" runat="Server"
    TargetControlID="postoptions"
    PopupControlID="PopupMenuPostOpt"
  HoverCssClass="HoverCSS"
    PopupPosition="Left"
    OffsetX="5"
    OffsetY="10"
    PopDelay="50" />


                               
                                    <asp:HiddenField runat="server" ID="HiddenFieldEmbedPost" Value='<%#Eval("EmbedPost")%>'></asp:HiddenField>
                      <asp:HiddenField runat="server" ID="HiddenFieldType" Value='<%#Eval("Type")%>'></asp:HiddenField>
                             <asp:HiddenField runat="server" ID="HiddenFieldId" Value='<%#Eval("_id")%>'></asp:HiddenField>
                             <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="true"
                              Text=' <%# Eval("FirstName","") + " " + Eval("LastName","") %>'
                              PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "PostedByUserId", "ViewProfile.aspx?UserId={0}") %>' 
                              ></asp:LinkButton>
                              <br />
                           <asp:Literal ID="LiteralPost"  Text='<%# Bind("Post") %>'  runat="server"></asp:Literal>
                              <br />
                           <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='../../Resources/CompressedVideo/play.png' Visible='<%# (((int)Eval("Type")) == Global.VIDEO)||(((int)Eval("Type")) == Global.TAG_VIDEOLINK)||(((int)Eval("Type")) == Global.TAG_VIDEO)||(((int)Eval("Type")) == Global.POST_VIDEOLINK)?true:false %>' CommandName="show" style='<%# "background:url(" +Eval("EmbedPost") + ")" %>'  />
                             <%--<asp:ImageButton ID="imbtnPhoto"   runat="server"    ImageUrl='<%# DataBinder.Eval(Container.DataItem, "EmbedPost", "../../Resources/ThumbnailPhotos/{0}.jpg") %>'  Visible='<%# (((int)Eval("Type")) == Global.PHOTO)||(((int)Eval("Type")) == Global.TAG_PHOTO)?true:false %>'   />
                              --%>   
                              
                               
                               <a href='<%# DataBinder.Eval(Container.DataItem, "EmbedPost", "../../Resources/UserPhotos/{0}.jpg") %>'>

                                
                        <img id="imgphoto"  class="img-style row1" src='<%# DataBinder.Eval(Container.DataItem, "EmbedPost", "../../Resources/ThumbnailPhotos/{0}.jpg") %>'  alt="" onError="var lnk= this.parentNode; lnk.parentNode.replaceChild(document.createTextNode(''), lnk)"  />
                               </a>
                               
                                 <%--  <asp:modalpopupextender 
		id="ModalpopupextenderlargePhoto" runat="server" 
		cancelcontrolid="imgbtnlargePhotoClose" okcontrolid="imgbtnlargePhotoClose" 
		targetcontrolid="imbtnPhoto" popupcontrolid="pnllargephoto" 
		BackgroundCssClass="ModalPopupBG" > 
        </asp:modalpopupextender>
       
        <asp:panel class="popupConfirmation" id="pnllargephoto" 
	style="display: none"   runat="server">
    <div class="popup_Container">
        <div class="popup_Titlebar" id="Div1">
            <div class="TitlebarLeft">
                View Photo</div>
            <div class="TitlebarRight" >
                <asp:ImageButton ID="imgbtnlargePhotoClose" OnClick="btnlargePhoto_Click"  ImageUrl="../../Resources/Images/MenuIcon/close-popup.gif"  runat="server" />
            </div>
        </div>
        <div class="popup_Body">
            <p>
               <asp:ImageButton ID="ImageButton2" runat="server"  width="400" Height="400" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "EmbedPost", "../../Resources/UserPhotos/{0}.jpg") %>'     />
                              
            </p>
        </div>
        <div class="popup_Buttons">
           <asp:Button ID="btnlargePhoto" OnClick="btnlargePhoto_Click" runat="server"  Visible="false" Text="Close" />
         
  
        </div>
    </div>
</asp:panel> --%>
                           
                            <br />  
                              <asp:Label ID="lblAddedDate" runat="server"  Text='<%# Eval("AddedDate") %>' 
                                        CssClass="style1" />
                                
                             <asp:HiddenField runat="server" ID="HiddenFieldAddedDate" Value='<%#Eval("AddedDate")%>'></asp:HiddenField>
                             

                          
                            
                         <br />

                       <!-------------     LIKE MODULE     ------------------------->

                    <asp:LinkButton ID="lbtnLike" runat="server" onclick="lbtnLike_Click" Font-Bold="False">.&nbsp;Like</asp:LinkButton>

             
                      <asp:LinkButton ID="lbtnDelete"  runat="server" OnClick="lbtnDelete_Click"  Font-Bold="False" Visible="false">.&nbsp;Delete</asp:LinkButton>
              
          <asp:confirmbuttonextender id="lnkDelete_ConfirmButtonExtender" 
		runat="server" targetcontrolid="lbtnDelete" enabled="True" 
		displaymodalpopupid="lnkDelete_ModalPopupExtender">
        </asp:confirmbuttonextender>
          <asp:modalpopupextender 
		id="lnkDelete_ModalPopupExtender" runat="server" 
		cancelcontrolid="ButtonDeleteCancel" okcontrolid="ButtonDeleleOkay" 
		targetcontrolid="lbtnDelete" popupcontrolid="DivDeleteConfirmation" 
		>
        </asp:modalpopupextender>

        <asp:panel class="popupConfirmation" id="DivDeleteConfirmation" 
	style="display: none" runat="server">
    <div class="popup_Container">
        <div class="popup_Titlebar" id="PopupHeader">
            <div class="TitlebarLeft">
                Delete Post</div>
            <div  onclick="$get('ButtonDeleteCancel').click();">
          
            </div>
        </div>
        <div class="popup_Body">
            <p>
          <img src="../../Resources/Images/MenuIcon/delete_alert.png" />      Are you sure, you want to delete the Post?
            </p>
        </div>
        <div class="popup_Buttons">
           <asp:Button ID="ButtonDeleleOkay" OnClick="lbtnOK_Click" runat="server" Text="Yes" />
            <asp:Button ID="ButtonDeleteCancel" runat="server" Text="No" />
  
        </div>
    </div>
</asp:panel>
            <asp:LinkButton ID="lbtnSeeFriendShip" runat="server" PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "PostedByUserId", "UserData.aspx?UserId={0}&See=yes") %>'  Font-Bold="False" Visible="false">.&nbsp; See FriendShip</asp:LinkButton>
                      
                    
                       <!-------------     SHARE MODULE     ------------------------->
           <asp:LinkButton ID="ShareLinkButton" runat="server" onclick="ShareLinkButton_Click" Font-Bold="False">.&nbsp;Share</asp:LinkButton>
            <asp:Label ID="ShareLabel" runat="server" Text="" Font-Bold="False"></asp:Label>
             <asp:LinkButton ID="lbtnRemoveTag" runat="server"  onclick="lbtnRemoveTag_Click" Font-Bold="False" Visible='<%# (((int)Eval("Type")) == Global.TAG_PHOTO)||(((int)Eval("Type")) == Global.TAG_PHOTO_ALBUM)||(((int)Eval("Type")) == Global.TAG_VIDEOLINK)||(((int)Eval("Type")) == Global.TAG_VIDEO)?true:false %>'>.&nbsp;Remove_Tag</asp:LinkButton>
              
       <asp:LinkButton ID="TagExsitingPost" runat="server"  Font-Bold="False" onclick="TagExsitingPost_Click" Visible="true">.&nbsp;Tag</asp:LinkButton>
                                       
                           
                             <asp:TextBox ID="txtFriendWallTag" CssClass="asptextbox" runat="server" AutoComplete="Off"  
                    Width="300" AutoPostBack="True" ontextchanged="txtFriendWallTag_TextChanged" Visible="false"></asp:TextBox>
                    <br />
                                         <asp:Label ID="lblLike" runat="server" Text="" Font-Bold="False"></asp:Label>
                      <asp:LinkButton ID="lbtnUser" runat="server" onclick="lbtnUser_Click" Font-Bold="False"></asp:LinkButton>
                      <br/>
                      <asp:LinkButton ID="lbtnShareHistory" runat="server" onclick="lbtnShareHistory_Click" Font-Bold="False"></asp:LinkButton>
   <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkCssClass="water" TargetControlID="txtFriendWallTag" WatermarkText="Tag friend here...">
                   </asp:TextBoxWatermarkExtender>
                <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtFriendWallTag" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetFriendsName" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight" 
OnClientPopulated ="WallTagUser_Populated"
    OnClientItemSelected = " OnWallTagUserSelected" >
    </asp:AutoCompleteExtender> 
                     <br />  
                  
                            

                        





                     <asp:LinkButton ID="lbtnViewComments" runat="server" onclick="lbtnViewComments_Click" 
                                    Font-Bold="False">View All Comments</asp:LinkButton>
                        <asp:Panel ID="PanelLikeUser" CssClass="popupControl" runat="server"> 
   <asp:UpdatePanel ID="UpdatePanel1" runat="server"> 
      <ContentTemplate>
                                <asp:GridView ID="GridViewLikesUser" runat="server" 
                    AutoGenerateColumns="False" DataKeyNames="_id" 
                    
                    GridLines="None" ShowHeader="False" PageSize="2">
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
<asp:Panel ID="ShareHistoryPanel" CssClass="popupControl" runat="server"> 
   <asp:UpdatePanel ID="UpdatePanelShare" runat="server"> 
      <ContentTemplate>
                                <asp:GridView ID="GridViewShareHistory" runat="server" 
                    AutoGenerateColumns="False" DataKeyNames="_id" 
                    
                    GridLines="None" ShowHeader="False" PageSize="2">
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
<asp:PopupControlExtender ID="PopupControlExtender2" runat="server" 
   TargetControlID="lbtnShareHistory" 
   PopupControlID="ShareHistoryPanel" 
   Position="Right" 
   
   OffsetX="3"> 
</asp:PopupControlExtender>
                <!--------------------- LIKE MODULE END ----------------->
         
  
                                <br />
         
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                <asp:GridView ID="GridViewComments" AutoGenerateColumns="False" runat="server" 
                       GridLines="None"    CellPadding="4" ForeColor="#333333" 
                    Width="550px" ShowHeader="False" >

                  
                   
                     <Columns>
                       <asp:TemplateField>
                    <ItemTemplate>
                          <asp:ImageButton ID="Image1" runat="server" Height="24px" ImageAlign="Middle" 
                                    ImageUrl='<%# DataBinder.Eval(Container.DataItem, "UserId", "../../Resources/ProfilePictures/{0}.jpg") %>' 
                                    PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "UserId", "ViewProfile.aspx?UserId={0}") %>' 
                                    Style="position: relative" Width="24px" />

                           </ItemTemplate>
                           <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="30px" />
                    </asp:TemplateField>
                      <asp:TemplateField>
                    <ItemTemplate>
                        &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" 
                              Text=' <%# Eval("FirstName","") + " " + Eval("LastName","") %>'
                              PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "UserId", "ViewProfile.aspx?UserId={0}") %>' 
                              ></asp:LinkButton>
                          <asp:Label ID="NameLabel" runat="server"  Text='<%# Eval("MyComments") %>' />
                         <br /> <asp:Label ID="lblCommentAddedDate" runat="server"  Text='<%# Eval("AddedDate") %>' CssClass="style1" />
                        <asp:HiddenField runat="server" ID="HiddenFieldCommentAddedDate" Value='<%#Eval("AddedDate")%>'></asp:HiddenField>
                             
                        <br />

                        <!-------------     Comment Like + Show Like user     -------->         
                 
                    <asp:HiddenField runat="server" ID="HiddenFieldId" Value='<%#Eval("_id")%>'></asp:HiddenField>
                     <asp:HiddenField runat="server" ID="HiddenFieldCommentUserId" Value='<%#Eval("UserId")%>'></asp:HiddenField>
                           <asp:LinkButton ID="lbtnCommentLike" runat="server" onclick="lbtnCommentLike_Click" Font-Bold="False">Like</asp:LinkButton>
                            <asp:Label ID="lblCommentLike" runat="server" Text="" Font-Bold="False"></asp:Label>   
            
                       <asp:LinkButton ID="lbtnDeleteComment" runat="server" OnClick="lbtnDeleteComment_Click" Visible="false" Font-Bold="False">Delete</asp:LinkButton>
                    <asp:LinkButton ID="lbtnCommentLikeUser" runat="server" OnClick="lbtnCommentLikeUser_Click" Font-Bold="False">User</asp:LinkButton>
           
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
                          <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="bubble2 me2" Width="450px" />
                    </asp:TemplateField>
                     </Columns>
                </asp:GridView>
                 </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtComments" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>


                
                    <asp:ImageButton ID="imgCommentsUser" runat="server"  Height="24px" ImageAlign="Middle" 
         
                                     Style="position: relative" Width="24px" Visible="false" />
                 <asp:TextBox ID="txtComments"  runat="server" Width="530px" EnableViewState="true" AutoPostBack="true" ontextchanged="txtComments_TextChanged" CssClass="wm watermark" Text="Write a comment..."
                        ></asp:TextBox>

                        
                            </ItemTemplate>
                            
                          
                      
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" width="550px"
                                CssClass="bubble me"  />
                            
                     
                      
                        </asp:TemplateField>            

                   
                   
                         
                    </Columns>
                    
                   <PagerSettings FirstPageText="First Page" LastPageText="Last Page" 
                        Mode="NextPrevious" Position="Bottom" NextPageText="More Post" 
                        PreviousPageText="Previous Post " />  
                
                    <PagerStyle BackColor="#C7CBB7" ForeColor="Black" Font-Bold="True" 
                        Font-Size="14pt" />
                
                </asp:GridView>
             
                   
                </td>
            <td>
                &nbsp;</td>
        </tr>
            <tr>
      
            <td>
                &nbsp;</td>
            <td colspan="2" style="text-align: center">
           
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
                &nbsp;</td>
            <td class="style5">
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
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging" />
                          <asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click" />

<asp:PostBackTrigger ControlID="lbtnTopStories"></asp:PostBackTrigger>

<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
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
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridViewWall" EventName="pageindexchanging"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
</asp:Content>

