<%@ Page Title=""  enableEventValidation="false"  Language="C#" MasterPageFile="~/UI/User/MasterPage.master" AutoEventWireup="true" CodeFile="SharePost.aspx.cs" Inherits="Wall" %>

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
</script>

    <style type="text/css">
        .style1
        {
            font-size: x-large;
            font-weight: 700;
        }
        .style2
        {
            font-size: large;
            font-weight: 700;
        }
    </style>

</asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <table>
        <tr>
            <td>
                </td>
            <td>
                <asp:Label ID="lblName" runat="server" 
                    style="font-size: x-large; font-weight: 700" ></asp:Label>
                <br />
                <br />
            </td>
            <td>
                <br />
                <br />
            </td>
        </tr>
            </table>
 
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">

                    <ContentTemplate>
                          
    <table>
            <tr>
      
            <td>
                &nbsp;</td>
            <td colspan="2">
                <strong><span class="style2">Preview:</span><span class="style1"><br />
                <asp:LinkButton ID="PostPreviewLinkButton" runat="server"></asp:LinkButton>
                <br />
                    <asp:Image ID="ImagePreview" runat="server" Visible="false"/>
                </span></strong></td>
            <td>
                &nbsp;</td>
        </tr>
            <tr>
      
            <td>
                &nbsp;</td>
            <td colspan="2">
                <asp:TextBox ID="txtUpdatePost" runat="server" Height="47px" TextMode="MultiLine" 
                    Width="458px"></asp:TextBox>
&nbsp;<asp:Button ID="btnPost" runat="server" CssClass="button" Text="Share" onclick="btnPost_Click" />
 
                <br />
 
                <br />
                      <span id="AppendTexts">
                 <asp:Label ID="lblLocation" runat="server" Text=""></asp:Label>
                <asp:Literal ID="lblFriendsWith" runat="server"></asp:Literal>
                <asp:Literal ID="SharingWithLiteral" runat="server"></asp:Literal>
               <asp:Literal ID="lblFriendsTag" runat="server"></asp:Literal>
                <br /><img  src="../../Resources/Images/MenuIcon/location.png" />
                        <asp:TextBox ID="txtLocation" Width="300px"  runat="server" 
                    Text='<%# Eval("Location") %>' AutoPostBack="True" ontextchanged="txtLocation_TextChanged"></asp:TextBox>

               <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" WatermarkCssClass="water" TargetControlID="txtLocation" WatermarkText="Where are you?">
                   </asp:TextBoxWatermarkExtender>
                   
                   
                   
                   <asp:AutoCompleteExtender ID="AutoCompleteExtender6" runat="server" TargetControlID="txtLocation" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetLocationwithCount" 
CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight" 
OnClientPopulated ="Location_Populated"
    OnClientItemSelected = " OnLocationSelected" >
</asp:AutoCompleteExtender> 
                        <br />

                         <asp:HiddenField ID="HiddenField1" runat="server" />  
                            <img src="../../Resources/Images/MenuIcon/AddFriends.png" />   <asp:TextBox ID="txtFriendWith" runat="server" AutoComplete="Off"  
                    Width="300" AutoPostBack="True" ontextchanged="txtFriendWith_TextChanged"></asp:TextBox>


   <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" WatermarkCssClass="water" TargetControlID="txtFriendWith" WatermarkText="Tag your friends...">
                   </asp:TextBoxWatermarkExtender>
                <asp:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="txtFriendWith" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetFriendsName" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight" 
OnClientPopulated ="FUser_Populated"
    OnClientItemSelected = " OnFUserSelected" >
    </asp:AutoCompleteExtender> 

    <br />

                         <asp:HiddenField ID="HiddenFieldTagId" runat="server" />  
                            <img src="../../Resources/Images/MenuIcon/AddFriends.png" />   <asp:TextBox ID="txtFriendTag" runat="server" AutoComplete="Off"  
                    Width="300" AutoPostBack="True" ontextchanged="txtFriendTag_TextChanged"></asp:TextBox>


   <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkCssClass="water" TargetControlID="txtFriendTag" WatermarkText="Share with...">
                   </asp:TextBoxWatermarkExtender>
                <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtFriendTag" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetFriendsName" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight" 
OnClientPopulated ="TagUser_Populated"
    OnClientItemSelected = " OnTagUserSelected" >
    </asp:AutoCompleteExtender> 

                &nbsp; 
                <br />&nbsp; &nbsp; &nbsp; 

                <asp:ImageButton ID="UpdateImageButton" 
                    ImageUrl="~/Resources/Images/Update.png" runat="server" 
                    onclick="UpdateImageButton_Click"/>
                <br />
    </span>
                
                
                
                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" />
                Unfollow</td>
            <td>
                &nbsp;</td>
        </tr>
          </table>
       
           <div>
               <strong><span class="style1">&nbsp;<br />
               </span></strong>
               <strong>
               <br />
               <br />
               </strong></span>
           <br />

           </div>
           </ContentTemplate>
                    <Triggers>
                          <asp:AsyncPostBackTrigger ControlID="UpdateImageButton" EventName="Click" />
                          <asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
</asp:Content>

