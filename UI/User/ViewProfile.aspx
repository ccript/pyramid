<%@ Page Title=""  enableEventValidation="false"  Language="C#" MasterPageFile="~/UI/User/MasterPage.master" AutoEventWireup="true" CodeFile="ViewProfile.aspx.cs" Inherits="ViewProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript" src="jquery.js"></script>
<script type="text/javascript">
    $(document).ready(function () {

        //hide message_body after the first one
        $(".message_list .message_body:gt(0)").hide();

        //hide message li after the 5th
        $(".message_list li:gt(4)").hide();


        //toggle message_body
        $(".message_head").click(function () {
            $(this).next(".message_body").slideToggle(500)
            return false;
        });

        //collapse all messages
        $(".collpase_all_message").click(function () {
            $(".message_body").slideUp(500)
            return false;
        });

        //show all messages
        $(".show_all_message").click(function () {
            $(this).hide()
            $(".show_recent_only").show()
            $(".message_list li:gt(4)").slideDown()
            return false;
        });

        //show recent messages only
        $(".show_recent_only").click(function () {
            $(this).hide()
            $(".show_all_message").show()
            $(".message_list li:gt(4)").slideUp()
            return false;
        });

    });
</script>
    <style type="text/css">
  .style5
        {
            color: #666666;
            font-weight: bold;
            font-family: Verdana;
            font-size: 8pt;
            vertical-align: top;
        }
                 
          .Tableheading
        {
         
          background-color: #0373A6;
          color: #FFFFFF;
           font-weight: bold;
            font-family: Verdana;
            font-size: 10pt;
        }
        
        /* message display page */
.message_list {
	list-style: none;
	margin: 0;
	padding: 0;
	
}

.message_head {
	padding: 5px 10px;
	cursor: pointer;
	position: relative;
	    background-color: #A10D0D;
          color: #FFFFFF;
           font-weight: bold;
            font-family: Verdana;
            font-size: 10pt;
          width: 670px;
	-moz-border-radius: 5px 5px / 5px 5px;
            border-radius: 5px 5px / 5px 5px;
-webkit-border-radius: 5px 5px / 5px 5px; 
background: rgb(125,126,125); /* Old browsers */
background: -moz-linear-gradient(top,  rgba(125,126,125,1) 0%, rgba(14,14,14,1) 100%); /* FF3.6+ */
background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(125,126,125,1)), color-stop(100%,rgba(14,14,14,1))); /* Chrome,Safari4+ */
background: -webkit-linear-gradient(top,  rgba(125,126,125,1) 0%,rgba(14,14,14,1) 100%); /* Chrome10+,Safari5.1+ */
background: -o-linear-gradient(top,  rgba(125,126,125,1) 0%,rgba(14,14,14,1) 100%); /* Opera 11.10+ */
background: -ms-linear-gradient(top,  rgba(125,126,125,1) 0%,rgba(14,14,14,1) 100%); /* IE10+ */
background: linear-gradient(top,  rgba(125,126,125,1) 0%,rgba(14,14,14,1) 100%); /* W3C */
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#7d7e7d', endColorstr='#0e0e0e',GradientType=0 ); /* IE6-9 */




}

.message_body {
	padding: 5px 10px 15px;
	  font-size: 8pt;
           text-align:left;
            width: 600px;
}

         </style>
</asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <table  >
        <tr>
            <td>
                </td>
            <td>
                <asp:Image ID="imgProfile" runat="server" 
                    Height="128px" ImageAlign="Middle" Width="128px" BorderColor="white" 
                    BorderStyle="Solid" BorderWidth="2px" /></td>
            <td>
                <asp:Label ID="lblName" runat="server" 
                    style="font-size: x-large; font-weight: 700" ></asp:Label>
                <br />
                <asp:Button ID="btnSuggestFriends" runat="server" 
                    onclick="btnSuggestFriends_Click" CssClass="button"  Text="Suggest Friends !" Visible="False" />
                <br />
                <asp:Button  ID="btnCancelRequest" CssClass="button"  runat="server" Enabled="False" 
                    onclick="btnCancelRequest_Click" 
                    Text="Cancel Request !" Visible="False" />
                <asp:Button  ID="btnAddAsFriend"  CssClass="button"  runat="server" onclick="btnAddAsFriend_Click" 
                    Text="Add As Friend !"  />
                <asp:Label ID="lblFriendRequestSent"  CssClass="button"  runat="server" Text="" 
                    Visible="False"></asp:Label>
 <br/>

               
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="lblsub" EventName="Click"></asp:AsyncPostBackTrigger>
                </Triggers>
                 <ContentTemplate>
                 <asp:Button ID="lblsub" runat="server" Text="Subscription Settings" 
                    CssClass="button" />
                    <asp:Panel ID="SubPanel" CssClass="popupControl" runat="server">
              
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
                    style="margin-left: 0px" TextAlign="Right">
                   
                    <asp:ListItem Value="Status">Status Updates</asp:ListItem>
                    <asp:ListItem Value="Photos">Photos</asp:ListItem>
                    <asp:ListItem Value="Videos">Videos</asp:ListItem>
                    <asp:ListItem Value="Links">Links</asp:ListItem>
                    <asp:ListItem Value="VideoLinks">Video Links</asp:ListItem>
                </asp:CheckBoxList>
                <asp:Button ID="btnSubSave" runat="server" cssClass="button" Text="Save" 
                    onclick="btnSubSave_Click" />
                </asp:Panel>
                <asp:HoverMenuExtender ID="hme2" runat="Server"
    TargetControlID="lblsub"
    PopupControlID="SubPanel"
    
    PopupPosition="Right"
    OffsetX="0"
    OffsetY="0"
    PopDelay="50" />
                  </ContentTemplate>
                </asp:UpdatePanel>
                 
            </td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
               </td>
            <td class="style5">
                Location:</td>
            <td>
                <asp:Label ID="lblCurrentCity" runat="server" Text=""></asp:Label>
            </td>
            <td rowspan="10">
                &nbsp;&nbsp;</td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
              </td>
            <td class="style5">
                Origin:</td>
            <td>
                         <asp:Label ID="lblHomeTown" runat="server" Text=""></asp:Label>
            </td>
            <td>
                </td>
        </tr>

        <tr>
            <td>
                </td>
            <td class="style5">
                Relationship Status</td>
            <td>
                         <asp:Label ID="lblRelationshipStatus" runat="server" Text=""></asp:Label>
            </td>
            <td>
                </td>
        </tr>

        <tr>
            <td>
                </td>
            <td class="style5">
                Gender</td>
            <td>
                         <asp:Label ID="lblGender" runat="server" Text=""></asp:Label>
            </td>
            <td>
                </td>
        </tr>

          <tr>
            <td>
                </td>
            <td colspan="2">
                 </td>
            <td>
                </td>
        </tr>

        <tr>
            <td>
               </td>
            <td class="style5">
                BirthDay</td>
            <td>
                             <table>
                                 <asp:Label ID="lblBirthDay" runat="server" ></asp:Label>
        </table></td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
               </td>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
        </tr>

          <tr>
            <td>
                </td>
            <td colspan="2">
                 </td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
               </td>
            <td class="style5">
                     <asp:Label ID="lblLanguages" runat="server" Text="Label"> Languages:</asp:Label>  </td>
            <td>
                <asp:DataList ID="DListLanguage" runat="server" DataKeyField="_Id" Width="400px" 
                    
                 >
                    <ItemTemplate>
                      
                        <asp:Label ID="LanguageNameLabel" runat="server" 
                            Text='<%# Eval("Name") %>' />
                      
                       
                    </ItemTemplate>
                </asp:DataList>
            </td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
            <td class="style5">
                </td>
            <td>
                </td>
            <td>
                </td>
        </tr>
        </table>
<div class="message_list">




<h3 class="message_head" > Work &amp; Education </h3>

 <table class="message_body" >
        <tr >
            <td colspan="4" >
               </td>
        </tr>
        <tr>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
            <td class="style5">
                 <asp:Label ID="lblEmployer" runat="server" Text="Label"> Employer:</asp:Label>  </td>
            <td>
                <asp:DataList ID="DListEmployer" runat="server" 
                       DataKeyField="_Id" 
                 RepeatColumns="5" 
                    Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                            BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                             ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image", "../../Resources/images/ProfileIcons/{0}") %>' 
                             
                            style="text-align: center" Width="64px" />
                       
                      

                        <br />
                        
                        
                        <asp:Label ID="ProjectLabel" runat="server" Text='<%# Eval("Organization") %>' />
                       
                       
                        <br />
                      
                    </ItemTemplate>
                </asp:DataList>
            </td>
            <td>
                </td>
        </tr>
          <tr>
            <td>
                </td>
            <td colspan="2">
                 </td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
            <td class="style5">
                     <asp:Label ID="lblProjects" runat="server" Text="Label"> Projects:</asp:Label> </td>
            <td>
                <asp:DataList ID="DListProject" runat="server" 
                       DataKeyField="_Id" 
                      RepeatColumns="5" 
                    Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                            BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                               ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image", "../../Resources/images/ProfileIcons/{0}") %>' 
                            style="text-align: center" Width="64px" />
                    

                        <br />
                        
                        
                        <asp:Label ID="ProjectLabel" runat="server" Text='<%# Eval("ProjectName") %>' />
                       
                       
                        <br />
                      
                    </ItemTemplate>
                </asp:DataList>
            </td>
            <td>
                </td>
        </tr>
          <tr>
            <td>
                </td>
            <td colspan="2">
                 </td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
            <td class="style5">
                <asp:Label ID="lblUniversity" runat="server" Text="Label"> University:</asp:Label>    </td>
            <td>
                <asp:DataList ID="DListUniversity" runat="server" 
                       DataKeyField="_Id" 
                      RepeatColumns="5" 
                    Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                            BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                         
                               ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image", "../../Resources/images/ProfileIcons/{0}") %>' 
                            style="text-align: center" Width="64px" />
                       
                  

                        <br />
                        
                        
                        <asp:Label ID="UniversityNameLabel" runat="server" Text='<%# Eval("UniversityName") %>' />
                       
                       
                        <br />
                      
                    </ItemTemplate>
                </asp:DataList>
            </td>
            <td>
                </td>
        </tr>
          <tr>
            <td>
                </td>
            <td colspan="2">
                 </td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
            <td class="style5">
                 <asp:Label ID="lblSchool" runat="server" Text="Label"> School:</asp:Label>  </td>
            <td>
                <br />
                <asp:DataList ID="DListSchool" runat="server" 
                       DataKeyField="_Id" 
                      RepeatColumns="5" 
                    Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                            BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                             ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image", "../../Resources/images/ProfileIcons/{0}") %>' 
                            style="text-align: center" Width="64px" />
                       
                   

                        <br />
                        
                        
                        <asp:Label ID="SchoolNameLabel" runat="server" Text='<%# Eval("Name") %>' />
                       
                       
                        <br />
                      
                    </ItemTemplate>
                </asp:DataList>
            </td>
            <td>
                </td>
        </tr>

          <tr>
            <td>
                </td>
            <td colspan="2">
                 </td>
            <td>
                </td>
        </tr>

        <tr>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
        </tr>
        </table>

<h3 class="message_head" > Art & Entertainmnet </h3>

   
        <tr>

         <table class="message_body" >
       
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
            <td class="style5">
                <asp:Label ID="lblBooks" runat="server" Text="Label"> Books:</asp:Label>  </td>
            <td>
                <asp:DataList ID="DListBooks" runat="server" 
                       DataKeyField="_Id"   RepeatColumns="5" Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                            BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                             ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image", "../../Resources/images/ProfileIcons/{0}") %>' 
                            style="text-align: center" Width="64px" />
                       
                     

                        <br />
                        
                        
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                       
                       
                        <br />
                      
                    </ItemTemplate>
                </asp:DataList>
            </td>
            <td>
                </td>
        </tr>
          <tr>
            <td>
                </td>
            <td colspan="2">
                 </td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
            <td class="style5">
              <asp:Label ID="lblMusic" runat="server" Text="Label"> Music:</asp:Label>    </td>
            <td>
                <asp:DataList ID="DListMusic" runat="server" 
                       DataKeyField="_Id"  RepeatColumns="5" Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                            BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                            ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image", "../../Resources/images/ProfileIcons/{0}") %>' 
                            style="text-align: center" Width="64px" />
                        <br />
                          
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                       
                       
                        <br />
                      
                    </ItemTemplate>
                </asp:DataList>
             
                 
            </td>
            <td>
                </td>
        </tr>
          <tr>
            <td>
                </td>
            <td colspan="2">
                 </td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
            <td class="style5">
               <asp:Label ID="lblMovies" runat="server" Text="Label"> Movies:</asp:Label>  </td>
            <td>
                <asp:DataList ID="DListMovie" runat="server" 
                       DataKeyField="_Id"  RepeatColumns="5" Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                            BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                             ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image", "../../Resources/images/ProfileIcons/{0}") %>' 
                            style="text-align: center" Width="64px" />
                        <br />
                       
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                       
                       
                        <br />
                      
                    </ItemTemplate>
                </asp:DataList>
             
                 
            </td>
            <td>
                </td>
        </tr>
          <tr>
            <td>
                </td>
            <td colspan="2">
                 </td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
            <td class="style5">
                 <asp:Label ID="lblTelevision" runat="server" Text="Label">Television:</asp:Label>  </td>
            <td>
                <asp:DataList ID="DListTelevision" runat="server" 
                       DataKeyField="_Id"  RepeatColumns="5" Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                            BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                           ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image", "../../Resources/images/ProfileIcons/{0}") %>' 
                            style="text-align: center" Width="64px" />
                        <br />
                        
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                       
                       
                        <br />
                      
                    </ItemTemplate>
                </asp:DataList>
             
                 
                <br />
            </td>
            <td>
                </td>
        </tr>

          <tr>
            <td>
                </td>
            <td colspan="2">
                 </td>
            <td>
                </td>
        </tr>


               <tr>
      
            <td>
                </td>
            <td class="style5">
                         <asp:Label ID="lblGame" runat="server" Text="Label">Game:</asp:Label>    </td>
            <td>
                <asp:DataList ID="DListGame" runat="server" 
                       DataKeyField="_Id"  RepeatColumns="5" Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                            BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                            ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image", "../../Resources/images/ProfileIcons/{0}") %>' 
                            style="text-align: center" Width="64px" />
                        <br />
                        
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                       
                       
                        <br />
                      
                    </ItemTemplate>
                </asp:DataList>
             
                 
                <br />
            </td>
            <td>
                </td>
        </tr>
      
          <tr>
            <td>
                </td>
            <td colspan="2">
                 </td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
        </tr>
        </table>

 <h3 class="message_head" > Sports </h3>       
     <table class="message_body" >
        <tr>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
        </tr>

        
                    <tr>
            <td width="10">
                </td>
            <td width="100" class="style5">
                   <asp:Label ID="lblSports" runat="server" Text="Label">Sports:</asp:Label> </td>
            <td bgcolor="White" width="300">

          

              <asp:Panel ID="Panel3" runat="server" >
   
                  <br />
                  <asp:DataList ID="DListSports" runat="server" DataKeyField="_Id" 
                      RepeatColumns="5" 
                      Width="400px">
                      <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                          VerticalAlign="Top" Width="70px" />
                      <ItemTemplate>
                          <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                              BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                              ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image", "../../Resources/images/ProfileIcons/{0}") %>' 
                              style="text-align: center" Width="64px" />
                        
                          <br />
                          <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                          <br />
                      </ItemTemplate>
                  </asp:DataList>
                </asp:Panel>
      
           
            </td>
            <td>
                </td>
        </tr>

        
                    <tr>
            <td width="10">
                </td>
            <td width="100" class="style5">
                </td>
            <td bgcolor="White" width="300">

          
     
                </td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
            <td colspan="2">
                 </td>
            <td>
                </td>
        </tr>

              <tr>
            <td width="10">
                </td>
            <td width="100" class="style5">
                   <asp:Label ID="lblTeam" runat="server" Text="Label">Team:</asp:Label> </td>
            <td bgcolor="White" width="300">

          
 
              <asp:Panel ID="Panel1" runat="server" >
   
                  <br />
                  <asp:DataList ID="DListTeam" runat="server" DataKeyField="_Id" 
                      RepeatColumns="5" 
                      Width="400px">
                      <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                          VerticalAlign="Top" Width="70px" />
                      <ItemTemplate>
                          <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                              BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                               ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image", "../../Resources/images/ProfileIcons/{0}") %>' 
                              style="text-align: center" Width="64px" />
                         
                          <br />
                          <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                          <br />
                      </ItemTemplate>
                  </asp:DataList>
                </asp:Panel>
   
           
            </td>
            <td>
                </td>
        </tr>

              <tr>
            <td width="10">
                </td>
            <td width="100" class="style5">
                </td>
            <td bgcolor="White" width="300">

          
     
                </td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
            <td colspan="2">
                 </td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
        </tr>

                    <tr>
            <td width="10">
                </td>
            <td width="100" class="style5">
                   <asp:Label ID="lblAthelete" runat="server" Text="Label">Athelete:</asp:Label> </td>
            <td bgcolor="White" width="300">

          
     

              <asp:Panel ID="Panel2" runat="server" >
   
                  <br />
                  <asp:DataList ID="DListAthelete" runat="server" DataKeyField="_Id" 
                     RepeatColumns="5" 
                      Width="400px">
                      <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                          VerticalAlign="Top" Width="70px" />
                      <ItemTemplate>
                          <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                              BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                              ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image", "../../Resources/images/ProfileIcons/{0}") %>' 
                              style="text-align: center" Width="64px" />
                       
                          <br />
                          <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                          <br />
                      </ItemTemplate>
                  </asp:DataList>
                </asp:Panel>
     
           
            </td>
            <td>
                </td>
        </tr>

                    <tr>
            <td width="10">
                </td>
            <td width="100" class="style5">
                </td>
            <td bgcolor="White" width="300">

          
     
                </td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
            <td colspan="2">
                 </td>
            <td>
                </td>
        </tr>


        </table>
<h3 class="message_head" > Activities & Interests </h3>

         <table class="message_body" >
       
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
            <td class="style5">
                 <asp:Label ID="lblActivities" runat="server" Text="Label">Activities:</asp:Label>  </td>
            <td>
                <asp:DataList ID="DListActivities" runat="server" 
                       DataKeyField="_Id" 
                    RepeatColumns="5" 
                    Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                            BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                             ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image", "../../Resources/images/ProfileIcons/{0}") %>' 
                            style="text-align: center" Width="64px" />
                

                        <br />
                        
                        
                        <asp:Label ID="ActivityNameLabel" runat="server" Text='<%# Eval("Name") %>' />
                       
                       
                        <br />
                      
                    </ItemTemplate>
                </asp:DataList>
            </td>
            <td>
                </td>
        </tr>
          <tr>
            <td>
                </td>
            <td colspan="2">
                 </td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
            <td class="style5">
                   <asp:Label ID="lblInterests" runat="server" Text="Label">Interests:</asp:Label> </td>
            <td>
                <asp:DataList ID="DListInterests" runat="server" 
                       DataKeyField="_Id" 
                   RepeatColumns="5" 
                    Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                            BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                             ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image", "../../Resources/images/ProfileIcons/{0}") %>' 
                            style="text-align: center" Width="64px" />
                       
                       

                        <br />
                        
                        
                        <asp:Label ID="InterestsNameLabel" runat="server" Text='<%# Eval("Name") %>' />
                       
                       
                        <br />
                      
                    </ItemTemplate>
                </asp:DataList>
             
                 
            </td>
            <td>
                </td>
        </tr>
          <tr>
            <td>
                </td>
            <td colspan="2">
                 </td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
        </tr>
        </table>
<h3 class="message_head" > Contact Information </h3>
     <table class="message_body"  >
    
            <td>
               </td>
            <td class="style5">
                </td>
            <td>
                </td>
            <td>
                </td>
        </tr>

     <tr>
            <td>
               </td>
            <td class="style5">
                 </td>
            <td>
                <br />
            </td>
            <td>
                </td>
        </tr>

      <tr>
            <td>
               </td>
            <td class="style5">
                   <asp:Label ID="lblOthersEmails" runat="server" Text="Label">Others Emails:</asp:Label>   </td>
            <td class="style2">
            
                <asp:GridView ID="GridViewEmail" runat="server" AutoGenerateColumns="False" 
                    BorderStyle="None" DataKeyNames="_Id" 
                   GridLines="None" ShowHeader="False" Width="400px">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <br />
                                <br />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                
                            </ItemTemplate>
                            <ItemStyle Width="200px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
            </td>
            <td>
                </td>
        </tr>
         <tr>
            <td>
                </td>
            <td colspan="2">
                 </td>
            <td>
                </td>
        </tr>

      <tr>
            <td>
                </td>
            <td class="style5">
                <asp:Label ID="lblPhoneNumbers" runat="server" Text="Label">Phone Numbers:</asp:Label>  
            </td>
            <td class="style2">
             
                <asp:GridView ID="GridViewPhone" runat="server" AutoGenerateColumns="False" 
                    BorderStyle="None" DataKeyNames="_Id" 
                     GridLines="None" ShowHeader="False" 
                    HorizontalAlign="Left">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <br />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                
                            </ItemTemplate>
                            <ItemStyle Width="300px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td>
                </td>
        </tr>

      <tr>
            <td>
                </td>
            <td class="style5">
                </td>
            <td class="style2">
                </td>
            <td>
                </td>
        </tr>
           <tr>
            <td>
                </td>
            <td colspan="2">
                 </td>
            <td>
                </td>
        </tr>


      
        <tr>
            <td>
                </td>
            <td class="style5">
                <asp:Label ID="lblAddressLabel" runat="server" Text="Label">Address:</asp:Label> </td>
            <td class="style2"> 
                <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
            </td>
            <td>
                </td>
        </tr>
         <tr>
            <td>
                </td>
            <td class="style5">
                <asp:Label ID="lblTownCiylabel" runat="server" Text="Label">Town/Ciy:</asp:Label></td>
            <td class="style2">
                <asp:Label ID="lblTownCity" runat="server" Text=""></asp:Label></td>
            <td>
                </td>
        </tr>
          <tr>
            <td>
                </td>
            <td class="style5">
              <asp:Label ID="lblZipCodeLabel" runat="server" Text="Label">Zip Code:</asp:Label>   </td>
            <td class="style2">
                <asp:Label ID="lblZipCode" runat="server" Text=""></asp:Label></td>
            <td>
                </td>
        </tr>
          <tr>
            <td>
                </td>
            <td class="style5">
                <asp:Label ID="lblNeighbourhoodLabel" runat="server" Text="Label">Neighbourhood:</asp:Label>  </td>
            <td class="style2">
                   <asp:Label ID="lblNeighbourhood" runat="server" Text=""></asp:Label></td>
            <td>
                </td>
        </tr>
           <tr>
            <td>
                </td>
            <td colspan="2">
                 </td>
            <td>
                </td>
        </tr>
        


        <tr>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
        </tr>

        <tr>
            <td>
                </td>
            <td class="style5">
               <asp:Label ID="lblWebsitesLabel" runat="server" Text="Label">Websites:</asp:Label>  </td>
            <td class="style2">
                <asp:GridView ID="GridViewWebsites" runat="server" AutoGenerateColumns="False" 
                    BorderStyle="None" DataKeyNames="_Id" 
                   GridLines="None" ShowHeader="False">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <br />
                                <br />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                
                            </ItemTemplate>
                            <ItemStyle Width="200px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td>
                </td>
        </tr>
           <tr>
            <td>
                </td>
            <td colspan="2">
                 </td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
        </tr>
       
        <tr>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
        </tr>
    </table>




</div>
</asp:Content>

