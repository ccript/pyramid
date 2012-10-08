<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserProfile/MasterPage.master" AutoEventWireup="true" CodeFile="Entertainment.aspx.cs" Inherits="Entertainment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
            color: #666666;
            font-weight: bold;
            font-family: Verdana;
            font-size: 10pt;
            vertical-align: top;
        }
         .style1
        {
           
          
        }
   
    </style>
  
 <script type = "text/javascript">
     function Employees_Populated(sender, e) {
         var item = sender.get_completionList().childNodes;
         for (var i = 0; i < item.length; i++) {
             var div = document.createElement("DIV");
             div.innerHTML = "<img style = 'height:24px;width:24px' src = '../Resources/images/Entertainment/Books/DefaultBooks.png'/>";
             item[i].appendChild(div);
         }
     }
     function OnEmployeeSelected(source, eventArgs) {
         var idx = source._selectIndex;
         var employees = source.get_completionList().childNodes;
         var value = employees[idx]._value;
         var text = employees[idx].firstChild.nodeValue;
         source.get_element().value = text;
     }
</script>
   
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
                Books:</td>
            <td bgcolor="White" width="300">

         
     
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
              <asp:Panel ID="PanelBooks" runat="server" BorderColor="#BDC7D8" BorderWidth="1" BorderStyle="Solid">
   
                <asp:TextBox ID="txtBooks" runat="server" 
                    Width="400px" Tooltip="What books do you like?"  
                     BackColor="White" BorderColor="White" 
                      BorderStyle="Solid" AutoComplete="Off" MaxLength="45"></asp:TextBox>
                      
                             <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" WatermarkCssClass="water" TargetControlID="txtBooks" WatermarkText="What books do you like?">
                   </ajax:TextBoxWatermarkExtender>
<ajax:AutoCompleteExtender  BehaviorID="AutoCompleteEx" ID="AutoCompleteExtender2" runat="server" TargetControlID="txtBooks" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetBooks"     
CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight" OnClientPopulated ="Employees_Populated"
    OnClientItemSelected = " OnEmployeeSelected" >
 <Animations>
  <OnShow>
  <Sequence>
  <%-- Make the completion list transparent and then show it --%>
  <OpacityAction Opacity="0" />
  <HideAction Visible="true" />

  <%--Cache the original size of the completion list the first time
    the animation is played and then set it to zero --%>
  <ScriptAction Script="// Cache the size and setup the initial size
                                var behavior = $find('AutoCompleteEx');
                                if (!behavior._height) {
                                    var target = behavior.get_completionList();
                                    behavior._height = target.offsetHeight - 2;
                                    target.style.height = '0px';
                                }" />
  <%-- Expand from 0px to the appropriate size while fading in --%>
  <Parallel Duration=".4">
  <FadeIn />
  <Length PropertyKey="height" StartValue="0" 
	EndValueScript="$find('AutoCompleteEx')._height" />
  </Parallel>
  </Sequence>
  </OnShow>
  <OnHide>
  <%-- Collapse down to 0px and fade out --%>
  <Parallel Duration=".4">
  <FadeOut />
  <Length PropertyKey="height" StartValueScript=
	"$find('AutoCompleteEx')._height" EndValue="0" />
  </Parallel>
  </OnHide>
  </Animations>


</ajax:AutoCompleteExtender> 
                  
                      <hr style="border-style: dashed; border-color: #CCCCCC; border-width: 1px 0 0 0; height:0; line-height:0px; font-size:0; margin:0; padding:0;">
                <br />
                <asp:DataList ID="DListBooks" runat="server" 
                       DataKeyField="_Id" OnSelectedIndexChanged="DListBooks_SelectedIndexChanged"  RepeatColumns="5" Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                            BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                               ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image", "../../Resources/images/ProfileIcons/{0}") %>'  
                            style="text-align: center" Width="64px" />
                       
                            <asp:LinkButton ID="lnkSelect" runat="server" CommandName="select" 
                            style="font-size: 7pt">Delete</asp:LinkButton>

                        <br />
                        
                        
                        &nbsp;<asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                       
                       
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
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                   <asp:LinqDataSource ID="LinqDataSourceBooks" runat="server" 
            ContextTypeName="DataClassesDataContext" EntityTypeName="" 
                    TableName="c_Book" 
                    Where="UserId == @UserId">
                       <WhereParameters>
                           <asp:SessionParameter DefaultValue="1" Name="UserId" 
                               SessionField="UserId" Type="Int32" />
                           <asp:Parameter DefaultValue=Global.BOOKS Name="Type" Type="String" />
                       </WhereParameters>
        </asp:LinqDataSource>
            </td>
            <td>
                &nbsp;</td>
         <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                       ControlToValidate="txtBooks" ErrorMessage="Only alphabets required in books" 
                       ValidationExpression="[a-zA-Z ]+"></asp:RegularExpressionValidator>
            </td>
            <td>
                &nbsp;</td>
         <tr>
            <td>
                &nbsp;</td>
            <td colspan="2">
                <hr /></td>
            <td>
                &nbsp;</td>
        </tr>
        </tr>

              <tr>
            <td width="10">
                &nbsp;</td>
            <td width="100" class="style5">
                Music:</td>
            <td bgcolor="White" width="300">

          
     
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
          <ContentTemplate>
              <asp:Panel ID="Panel1" runat="server" BorderColor="#BDC7D8" BorderWidth="1" BorderStyle="Solid">
   
                <asp:TextBox ID="txtMusic" runat="server" 
                    Width="400px" Tooltip="What music do you like?"  
                       BackColor="White" BorderColor="White" 
                      BorderStyle="Solid" AutoComplete="Off" MaxLength="45"></asp:TextBox>
                          <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" WatermarkCssClass="water" TargetControlID="txtMusic" WatermarkText="What music do you like?">
                   </ajax:TextBoxWatermarkExtender>

                   <ajax:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="txtMusic" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetMusic" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight" >
</ajax:AutoCompleteExtender> 
                      <hr style="border-style: dashed; border-color: #CCCCCC; border-width: 1px 0 0 0; height:0; line-height:0px; font-size:0; margin:0; padding:0;">
                <br />
                <asp:DataList ID="DListMusic" runat="server" 
                       DataKeyField="_Id" OnSelectedIndexChanged="DListMusic_SelectedIndexChanged" RepeatColumns="5" Width="400px">
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

          
     
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                    ControlToValidate="txtMusic" ErrorMessage="Only alphabets required in music" 
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
            <td width="10">
                &nbsp;</td>
            <td width="100" class="style5">
                Movie:</td>
            <td bgcolor="White" width="300">

          
     
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
          <ContentTemplate>
              <asp:Panel ID="Panel2" runat="server" BorderColor="#BDC7D8" BorderWidth="1" BorderStyle="Solid">
   
                <asp:TextBox ID="txtMovie" runat="server" 
                    Width="400px" Tooltip="What movie do you like?"  
                       BackColor="White" BorderColor="White" 
                      BorderStyle="Solid" AutoComplete="Off" MaxLength="45"></asp:TextBox>
                          <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkCssClass="water" TargetControlID="txtMovie" WatermarkText="What movie do you like?">
                   </ajax:TextBoxWatermarkExtender>

                   <ajax:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtMovie" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetMovie"
CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight"  >
</ajax:AutoCompleteExtender> 
                      <hr style="border-style: dashed; border-color: #CCCCCC; border-width: 1px 0 0 0; height:0; line-height:0px; font-size:0; margin:0; padding:0;">
                <br />
                <asp:DataList ID="DListMovie" runat="server" 
                       DataKeyField="_Id" OnSelectedIndexChanged="DListMovie_SelectedIndexChanged" RepeatColumns="5" Width="400px">
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

          
     
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                    ControlToValidate="txtMovie" ErrorMessage="Only alphabets required in movie" 
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
                Television:</td>
            <td bgcolor="White" width="300">

          
     
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
          <ContentTemplate>
              <asp:Panel ID="Panel3" runat="server" BorderColor="#BDC7D8" BorderWidth="1" BorderStyle="Solid">
   
                <asp:TextBox ID="txtTelevision" runat="server" 
                    Width="400px" Tooltip="What television do you like?"  
                       BackColor="White" BorderColor="White" 
                      BorderStyle="Solid" AutoComplete="Off" MaxLength="45"></asp:TextBox>
                          <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" WatermarkCssClass="water" TargetControlID="txtTelevision" WatermarkText="What television do you like?">
                   </ajax:TextBoxWatermarkExtender>

                   <ajax:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server" TargetControlID="txtTelevision" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetTelevision" 
CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight" >
</ajax:AutoCompleteExtender> 
                      <hr style="border-style: dashed; border-color: #CCCCCC; border-width: 1px 0 0 0; height:0; line-height:0px; font-size:0; margin:0; padding:0;">
                <br />
                <asp:DataList ID="DListTelevision" runat="server" 
                       DataKeyField="_Id" OnSelectedIndexChanged="DListTelevision_SelectedIndexChanged" RepeatColumns="5" Width="400px">
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

          
     
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" 
                    ControlToValidate="txtTelevision" 
                    ErrorMessage="Only alphabets required in televison" 
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
            <td width="10">
                &nbsp;</td>
            <td width="100" class="style5">
                Game:</td>
            <td bgcolor="White" width="300">

          
     
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
          <ContentTemplate>
              <asp:Panel ID="Panel4" runat="server" BorderColor="#BDC7D8" BorderWidth="1" BorderStyle="Solid">
   
                <asp:TextBox ID="txtGame" runat="server" 
                    Width="400px" Tooltip="What game do you like?"  
                       BackColor="White" BorderColor="White" 
                      BorderStyle="Solid" AutoComplete="Off" MaxLength="45"></asp:TextBox>
                          <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" WatermarkCssClass="water" TargetControlID="txtGame" WatermarkText="What game do you like?">
                   </ajax:TextBoxWatermarkExtender>

                   <ajax:AutoCompleteExtender ID="AutoCompleteExtender6" runat="server" TargetControlID="txtGame" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetGame" 
CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight" >
</ajax:AutoCompleteExtender> 
                      <hr style="border-style: dashed; border-color: #CCCCCC; border-width: 1px 0 0 0; height:0; line-height:0px; font-size:0; margin:0; padding:0;">
                <br />
                <asp:DataList ID="DListGame" runat="server" 
                       DataKeyField="_Id" OnSelectedIndexChanged="DListGame_SelectedIndexChanged" RepeatColumns="5" Width="400px">
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
                    ControlToValidate="txtGame" ErrorMessage="Only alphabets required in game" 
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
                    <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save Changes" 
                    onclick="btnSave_Click"  /></td>
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

