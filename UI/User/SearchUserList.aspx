<%@ Page Title="" Language="C#" MasterPageFile="~/UI/User/MasterPage.master" AutoEventWireup="true" CodeFile="SearchUserList.aspx.cs" Inherits="FriendsList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 399px;
        }
    </style>

    <link rel="stylesheet" href="../../Resources/Script/jqtransformplugin/fieldsJQuery.css" type="text/css" media="all" />
	<link rel="stylesheet" href="../../Resources/Script/demo.css" type="text/css" media="all" />
	
	<script type="text/javascript" src="../../Resources/Script/requiered/jquery.js" ></script>
	<script type="text/javascript" src="../../Resources/Script/jqtransformplugin/jquery.jqtransform.js" ></script>
	<script language="javascript">
	    $(function () {
	        $('form').jqTransform({ imgPath: 'jqtransformplugin/img/' });
	    });
	</script>
</asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  

    <br />

      
    <table>
          
        <tr>
            <td>
                &nbsp;</td>
            <td>
                  <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                <table class="style1" >
                    <tr valign="top">
                        <td>
                             <asp:DropDownList ID="lstSearchBy" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="lstSearchBy_SelectedIndexChanged" Height="30px" >
                    <asp:ListItem>Name</asp:ListItem>
                    <asp:ListItem>Location</asp:ListItem>
                    <asp:ListItem>Education</asp:ListItem>
                    <asp:ListItem>Workplace</asp:ListItem>
                    <asp:ListItem>Location & Work</asp:ListItem>
                    <asp:ListItem>Education & Work</asp:ListItem>
                     <asp:ListItem>Education & Location</asp:ListItem>
                    <asp:ListItem>All</asp:ListItem>
                </asp:DropDownList></td>
                        <td>
                            <asp:Panel ID="Panel1" runat="server">
                            <asp:TextBox ID="txtSearchBy" runat="server" Height="23px" Width="345px"></asp:TextBox>
                            
                               
                     <asp:DropDownList ID="lstClassYear" runat="server" Visible="False" Height="30px">
                                <asp:ListItem>1990</asp:ListItem>
                                <asp:ListItem>1991</asp:ListItem>
                            </asp:DropDownList>
                <br />
                <asp:TextBox ID="txtSearchBy2" runat="server" Height="23px" Width="345px" 
                    Visible="False"></asp:TextBox>
                     <br />
                <asp:TextBox ID="txtSearchBy3" runat="server" Height="23px" Width="345px" 
                    Visible="False"></asp:TextBox>

                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkCssClass="water" 
                    TargetControlID="txtSearchBy" WatermarkText="Search By Name">
                    </asp:TextBoxWatermarkExtender>
                  
                       <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" WatermarkCssClass="water" 
                    TargetControlID="txtSearchBy2" WatermarkText="Search ">
                    </asp:TextBoxWatermarkExtender>
                
                       <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" WatermarkCssClass="water" 
                    TargetControlID="txtSearchBy3" WatermarkText="Search ">

                   </asp:TextBoxWatermarkExtender>
                    </td>
                        <td>
                                     <asp:ImageButton
               ID="imgBtnSearchFriends" runat="server" 
                ImageUrl="~/Resources/images/MenuIcon/SearchFriends.png" ImageAlign="Bottom" 
                onclick="imgBtnSearchFriends_Click" style="width: 24px" /> </asp:Panel> </td>
                    </tr>
                </table>
                     </ContentTemplate>
                      <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lstSearchBy" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>

            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
            
        <tr>
            <td>
                &nbsp;</td>
            <td>

              <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                <asp:GridView ID="GridViewSearchUser" runat="server" AutoGenerateColumns="False" 
                     DataKeyNames="_Id" 
                            onrowcommand="GridViewSearchUser_RowCommand" 
                           
                            CellPadding="4" 
                    ForeColor="#333333" GridLines="None" ShowHeader="False" Width="100%">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                    
                        
                    
                        <asp:TemplateField>
                          <ItemTemplate>
                        <asp:ImageButton ID="Image2" runat="server" ImageAlign="Middle" 
                  ImageUrl='<%# DataBinder.Eval(Container.DataItem, "_Id", "../../Resources/ProfilePictures/{0}.jpg") %>' 
                   PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "_Id", "ViewProfile.aspx?UserId={0}") %>'
                            Style="position: relative" Height="64px" Width="64px" />
                              <asp:Label ID="Label3"  Font-Bold="true" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                          &nbsp; <asp:Label ID="Label4" Font-Bold="true" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                            <asp:HiddenField runat="server" ID="HiddenField1" Value='<%#Eval("_Id")%>'></asp:HiddenField>
                             
                              <br />
                     
                    </ItemTemplate>
                        
                        </asp:TemplateField>
            <asp:buttonfield buttontype="Link" ControlStyle-BorderStyle="Ridge" Text="Add Friend" commandname="add" />
            
                        
                    </Columns>
                      <RowStyle CssClass="GridRowStyle"/>
                    <AlternatingRowStyle CssClass="GridAlternatingRowStyle" />
                </asp:GridView>



            

                        <br />
                        <asp:LinkButton ID="lbtnMore" runat="server" onclick="lbtnMore_Click">More results ...</asp:LinkButton>



            

                       </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="imgBtnSearchFriends" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>

            </td>
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

