<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserProfile/MasterPage.master" AutoEventWireup="true" CodeFile="Sports.aspx.cs" Inherits="Sports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
                   color: #666666;
            font-weight: bold;
            font-family: Verdana;
            font-size: 9pt;
            vertical-align: top;
        }
  
    </style>
  
   

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <table class="style1" >
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
            <td width="10">
                &nbsp;</td>
            <td width="100" class="style5">
                Sports:</td>
            <td bgcolor="White" width="300">

          
     
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
              <asp:Panel ID="Panel3" runat="server" BorderColor="#BDC7D8" BorderWidth="1" BorderStyle="Solid">
   
                <asp:TextBox ID="txtSports" runat="server" 
                    Width="400px" Tooltip="What sports do you like?"  
                       BackColor="White" BorderColor="White" 
                      BorderStyle="Solid" AutoComplete="Off" MaxLength="45"></asp:TextBox>
                          <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtenderSports" runat="server" WatermarkCssClass="water" TargetControlID="txtSports" WatermarkText="What sports do you like?">
                   </ajax:TextBoxWatermarkExtender>

                   <ajax:AutoCompleteExtender ID="AutoCompleteExtenderSports" runat="server" TargetControlID="txtSports" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetSport"
CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight"  >
</ajax:AutoCompleteExtender> 
                      <hr style="border-style: dashed; border-color: #CCCCCC; border-width: 1px 0 0 0; height:0; line-height:0px; font-size:0; margin:0; padding:0;">
                <br />
                <asp:DataList ID="DListSports" runat="server" 
                       DataKeyField="_Id" OnSelectedIndexChanged="DListSports_SelectedIndexChanged" RepeatColumns="5" Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                            BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                          ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image", "../../Resources/images/ProfileIcons/{0}") %>' 
                            style="text-align: center" Width="64px" />
                        <br />
                           <asp:LinkButton ID="lnkSelect" runat="server" CommandName="select" 
                            style="font-size: 7pt">Delete</asp:LinkButton>
                            <br />
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                       
                       
                        <br />
                      
                    </ItemTemplate>
                </asp:DataList>
             
                 
                   </asp:Panel>
                 </ContentTemplate>
              </asp:UpdatePanel> 
           
            </td>
            <td>
                &nbsp;</td>
        </tr>

        
                    <tr>
            <td width="10">
                &nbsp;</td>
            <td width="100" class="style5">
                &nbsp;</td>
            <td bgcolor="White" width="300">

          
     
                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" 
                    ControlToValidate="txtSports" ErrorMessage="Only alphabets required in sports" 
                    ValidationExpression="[a-zA-Z ]+"></asp:RegularExpressionValidator>
           
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
            <td width="10">
                &nbsp;</td>
            <td width="100" class="style5">
                Team:</td>
            <td bgcolor="White" width="300">

          
     
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
          <ContentTemplate>
              <asp:Panel ID="Panel1" runat="server" BorderColor="#BDC7D8" BorderWidth="1" BorderStyle="Solid">
   
                <asp:TextBox ID="txtTeam" runat="server" 
                    Width="400px" Tooltip="What team do you like?"  
                       BackColor="White" BorderColor="White" 
                      BorderStyle="Solid" AutoComplete="Off" MaxLength="45"></asp:TextBox>
                          <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" WatermarkCssClass="water" TargetControlID="txtTeam" WatermarkText="What team do you like?">
                   </ajax:TextBoxWatermarkExtender>

                   <ajax:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="txtTeam" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetTeam" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight" >
</ajax:AutoCompleteExtender> 
                      <hr style="border-style: dashed; border-color: #CCCCCC; border-width: 1px 0 0 0; height:0; line-height:0px; font-size:0; margin:0; padding:0;">
                <br />
                <asp:DataList ID="DListTeam" runat="server" 
                       DataKeyField="_Id" OnSelectedIndexChanged="DListTeam_SelectedIndexChanged" RepeatColumns="5" Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                            BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                            ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image", "../../Resources/images/ProfileIcons/{0}") %>' 
                            style="text-align: center" Width="64px" />
                        <br />
                           <asp:LinkButton ID="lnkSelect" runat="server" CommandName="select" 
                            style="font-size: 7pt">Delete</asp:LinkButton>
                            <br />
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                       
                       
                        <br />
                      
                    </ItemTemplate>
                </asp:DataList>
             
                 
                   </asp:Panel>
                 </ContentTemplate>
              </asp:UpdatePanel> 
           
            </td>
            <td>
                &nbsp;</td>
        </tr>

              <tr>
            <td width="10">
                &nbsp;</td>
            <td width="100" class="style5">
                &nbsp;</td>
            <td bgcolor="White" width="300">

          
     
                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" 
                    runat="server" ControlToValidate="txtTeam" 
                    ErrorMessage="Only alphabets required in team" ValidationExpression="[a-zA-Z ]+"></asp:RegularExpressionValidator>
           
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
            <td width="10">
                &nbsp;</td>
            <td width="100" class="style5">
                Athelete:</td>
            <td bgcolor="White" width="300">

          
     
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
          <ContentTemplate>
              <asp:Panel ID="Panel2" runat="server" BorderColor="#BDC7D8" BorderWidth="1" BorderStyle="Solid">
   
                <asp:TextBox ID="txtAthelete" runat="server" 
                    Width="400px" Tooltip="What athelete do you like?"  
                       BackColor="White" BorderColor="White" 
                      BorderStyle="Solid" AutoComplete="Off" MaxLength="45"></asp:TextBox>
                          <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkCssClass="water" TargetControlID="txtAthelete" WatermarkText="What athelete do you like?">
                   </ajax:TextBoxWatermarkExtender>

                   <ajax:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtAthelete" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetAthelete"
CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight"  >
</ajax:AutoCompleteExtender> 
                      <hr style="border-style: dashed; border-color: #CCCCCC; border-width: 1px 0 0 0; height:0; line-height:0px; font-size:0; margin:0; padding:0;">
                <br />
                <asp:DataList ID="DListAthelete" runat="server" 
                       DataKeyField="_Id" OnSelectedIndexChanged="DListAthelete_SelectedIndexChanged" RepeatColumns="5" Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                            BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                             ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image", "../../Resources/images/ProfileIcons/{0}") %>' 
                            style="text-align: center" Width="64px" />
                        <br />
                           <asp:LinkButton ID="lnkSelect" runat="server" CommandName="select" 
                            style="font-size: 7pt">Delete</asp:LinkButton>
                            <br />
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                       
                       
                        <br />
                      
                    </ItemTemplate>
                </asp:DataList>
             
                 
                   </asp:Panel>
                 </ContentTemplate>
              </asp:UpdatePanel> 
           
            </td>
            <td>
                &nbsp;</td>
        </tr>

                    <tr>
            <td width="10">
                &nbsp;</td>
            <td width="100" class="style5">
                &nbsp;</td>
            <td bgcolor="White" width="300">

          
     
                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" 
                    runat="server" ControlToValidate="txtAthelete" 
                    ErrorMessage="Only alphabets required in athelete" 
                    ValidationExpression="[a-zA-Z ]+"></asp:RegularExpressionValidator>
           
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
                    <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save Changes" 
                    onclick="btnSave_Click" /></td>
            <td>
           &nbsp;
                <asp:Image ID="imgSave" runat="server" ImageUrl="~/Resources/images/Icon/check.png" 
                    Visible="False" />
                <asp:Label ID="lblSave" runat="server" Text="Save changes is successful" 
                    ForeColor="#006600" Visible="False"></asp:Label>
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
    </table>
</asp:Content>

