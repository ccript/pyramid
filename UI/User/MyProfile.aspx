<%@ Page Title="" Language="C#" MasterPageFile="~/UI/User/MasterPage.master" AutoEventWireup="true" CodeFile="MyProfile.aspx.cs" Inherits="MyProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
  .style5
        {
            color: #666666;
            font-weight: bold;
            font-family: Verdana;
            font-size: 8pt;
            vertical-align: top;
        }
         .style1
        {
          font-size: 8pt;
           text-align:left;
           width:100%;
        }
        
          .Tableheading
        {
         
          background-color: #662C3C;
          color: #FFFFFF;
           font-weight: bold;
            font-family: Verdana;
            font-size: 10pt;
        }
         </style>
</asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <table class="style1" >
        <tr class="Tableheading">
            <td colspan="4" >
                Work &amp; Education</td>
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
                Employer:</td>
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
                            ImageUrl='~/Resources/images/Employer/DefaultEmployer.png' 
                            style="text-align: center" Width="64px" />
                       
                      

                        <br />
                        
                        
                        &nbsp;<asp:Label ID="ProjectLabel" runat="server" Text='<%# Eval("Organization") %>' />
                       
                       
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
            <td colspan="2">
                <hr /></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                Projects:</td>
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
                            ImageUrl='~/Resources/images/Project/DefaultProject.png' 
                            style="text-align: center" Width="64px" />
                    

                        <br />
                        
                        
                        &nbsp;<asp:Label ID="ProjectLabel" runat="server" Text='<%# Eval("ProjectName") %>' />
                       
                       
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
            <td colspan="2">
                <hr /></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                University:</td>
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
                            ImageUrl='~/Resources/images/University/DefaultUniversity.png' 
                            style="text-align: center" Width="64px" />
                       
                  

                        <br />
                        
                        
                        &nbsp;<asp:Label ID="UniversityNameLabel" runat="server" Text='<%# Eval("UniversityName") %>' />
                       
                       
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
            <td colspan="2">
                <hr /></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                School:</td>
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
                            ImageUrl='~/Resources/images/School/DefaultSchool.png' 
                            style="text-align: center" Width="64px" />
                       
                   

                        <br />
                        
                        
                        &nbsp;<asp:Label ID="SchoolNameLabel" runat="server" Text='<%# Eval("Name") %>' />
                       
                       
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
        </table>




         <table class="style1" >
        <tr class="Tableheading">
            <td colspan="4" >
                Art & Entertainmnet</td>
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
                Books:</td>
            <td>
                <asp:DataList ID="DListBooks" runat="server" 
                       DataKeyField="_Id"   RepeatColumns="5" Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                            BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                            ImageUrl='~/Resources/images/Entertainment/Books/DefaultBooks.png' 
                            style="text-align: center" Width="64px" />
                       
                     

                        <br />
                        
                        
                        &nbsp;<asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                       
                       
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
            <td colspan="2">
                <hr /></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                Music:</td>
            <td>
                <asp:DataList ID="DListMusic" runat="server" 
                       DataKeyField="_Id"  RepeatColumns="5" Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                            BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                            ImageUrl='~/Resources/images/Entertainment/Music/DefaultMusic.png' 
                            style="text-align: center" Width="64px" />
                        <br />
                          
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                       
                       
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
            <td colspan="2">
                <hr /></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                Movies:</td>
            <td>
                <asp:DataList ID="DListMovie" runat="server" 
                       DataKeyField="_Id"  RepeatColumns="5" Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                            BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                            ImageUrl='~/Resources/images/Entertainment/Movie/DefaultMovie.png' 
                            style="text-align: center" Width="64px" />
                        <br />
                       
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                       
                       
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
            <td colspan="2">
                <hr /></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                Television:</td>
            <td>
                <asp:DataList ID="DListTelevision" runat="server" 
                       DataKeyField="_Id"  RepeatColumns="5" Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                            BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                            ImageUrl='~/Resources/images/Entertainment/Television/DefaultTelevision.png' 
                            style="text-align: center" Width="64px" />
                        <br />
                        
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                       
                       
                        <br />
                      
                    </ItemTemplate>
                </asp:DataList>
             
                 
                <br />
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
            <td class="style5">
                Game:</td>
            <td>
                <asp:DataList ID="DListGame" runat="server" 
                       DataKeyField="_Id"  RepeatColumns="5" Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                            BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                            ImageUrl='~/Resources/images/Entertainment/Game/DefaultGame.png' 
                            style="text-align: center" Width="64px" />
                        <br />
                        
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                       
                       
                        <br />
                      
                    </ItemTemplate>
                </asp:DataList>
             
                 
                <br />
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
        </table>

        



         <table class="style1" >
        <tr class="Tableheading">
            <td colspan="4" >
                Activities & Interests</td>
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
                Activities:</td>
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
                            ImageUrl="~/Resources/images/Entertainment/Activities/DefaultActivities.png" 
                            style="text-align: center" Width="64px" />
                

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
            <td colspan="2">
                <hr /></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                Interests:</td>
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
                            ImageUrl="~/Resources/images/Entertainment/Interests/DefaultInterests.png" 
                            style="text-align: center" Width="64px" />
                       
                       

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
        </table>

     <table class="style1"  >
        <tr class="Tableheading">
            <td colspan="4" >
                Contact Information</td>
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
                Primary Email:</td>
            <td>
                <br />
            </td>
            <td>
                &nbsp;</td>
        </tr>

      <tr>
            <td>
               </td>
            <td class="style5">
                Others&nbsp;
                Emails:</td>
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
                                &nbsp;
                            </ItemTemplate>
                            <ItemStyle Width="200px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
            </td>
            <td>
                &nbsp;</td>
        </tr>
         <tr>
            <td>
                </td>
            <td colspan="2">
                <hr /></td>
            <td>
                &nbsp;</td>
        </tr>

      <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                Phone Numbers:
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
                                &nbsp;
                            </ItemTemplate>
                            <ItemStyle Width="300px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>

      <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
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
            <td >
                </td>
            <td class="style5">
                Mobile Alert:</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                Address:</td>
            <td class="style2"> 
                <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
         <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                Town/Ciy:</td>
            <td class="style2">
                <asp:Label ID="lblTownCity" runat="server" Text=""></asp:Label></td>
            <td>
                &nbsp;</td>
        </tr>
          <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                Zip Code:</td>
            <td class="style2">
                <asp:Label ID="lblZipCode" runat="server" Text=""></asp:Label></td>
            <td>
                &nbsp;</td>
        </tr>
          <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                Neighbourhood:</td>
            <td class="style2">
                   <asp:Label ID="lblNeighbourhood" runat="server" Text=""></asp:Label></td>
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
            <td class="style5">
                Websites:</td>
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
                                &nbsp;
                            </ItemTemplate>
                            <ItemStyle Width="200px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
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
    </table>



        <table class="style1"  >
        <tr class="Tableheading">
            <td colspan="4" >
                Basic Information</td>
        </tr>
        <tr>
            <td>
                </td>
            <td>
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
                Current City:</td>
            <td>
                <asp:Label ID="lblCurrentCity" runat="server" Text=""></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
              </td>
            <td class="style5">
                Home Town:</td>
            <td>
                         <asp:Label ID="lblHomeTown" runat="server" Text=""></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>

          <tr>
            <td>
                </td>
            <td colspan="2">
                <hr /></td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
            <td>
               </td>
            <td class="style5">
                BirthDay</td>
            <td>
                             <table>
        </table></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
               </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>

          <tr>
            <td>
                </td>
            <td colspan="2">
                <hr /></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
               </td>
            <td class="style5">
                Languages</td>
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
</asp:Content>

