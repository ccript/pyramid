<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserProfile/MasterPage.master" AutoEventWireup="true" CodeFile="BasicInfo.aspx.cs" Inherits="BasicInfoPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
         .style1
        {
         
           text-align:left;
  
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
            <td>
                &nbsp;</td>
            <td class="style5">
                Current City:</td>
            <td>
                <asp:TextBox ID="txtCurrentCity" cssClass="asptextbox" runat="server" Width="300px" 
                    MaxLength="45"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                Home Town:</td>
            <td>
                <asp:TextBox ID="txtHometown" class="txtboxes" runat="server" Width="300px" 
                    MaxLength="45"></asp:TextBox>
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
            <td class="style5">
                BirthDay</td>
            <td>
                             <table>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="lstMonth" runat="server" AutoPostBack="true" DataTextField="MonthName"
                            DataValueField="MonthNumber" OnSelectedIndexChanged="lstMonth_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="lstDay" runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lstMonth" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:DropDownList ID="lstYear" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
    </table></td>
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
                <hr /></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                Languages</td>
            <td>
                <asp:DropDownList ID="lstLanguages" runat="server">
       <asp:ListItem>English	</asp:ListItem>          
<asp:ListItem>Spanish	</asp:ListItem>
<asp:ListItem>	Chinese	</asp:ListItem>
<asp:ListItem>	Russian	</asp:ListItem>
<asp:ListItem>	Arabic	</asp:ListItem>
<asp:ListItem>	Portuguese	</asp:ListItem>
<asp:ListItem>	French	</asp:ListItem>
<asp:ListItem>	Japanese	</asp:ListItem>
<asp:ListItem>	Turkish	</asp:ListItem>
<asp:ListItem>	German	</asp:ListItem>
<asp:ListItem>	Urdu	</asp:ListItem>
<asp:ListItem>	Hindi	</asp:ListItem>
<asp:ListItem>	Others	</asp:ListItem>

                </asp:DropDownList>
                <asp:LinkButton ID="lbtnAddLanguage" runat="server" style="font-size: xx-small" 
                    onclick="lbtnAddLanguage_Click">Add Language</asp:LinkButton>
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
                <asp:DataList ID="DListLanguage" runat="server" DataKeyField="_Id" 
                    
                    onselectedindexchanged="DListLanguage_SelectedIndexChanged">
                    <ItemTemplate>
                      
                        <asp:Label ID="LanguageNameLabel" runat="server" 
                            Text='<%# Eval("Name") %>' />
                      
                        &nbsp;
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="select" >Delete</asp:LinkButton>
                      
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
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtCurrentCity" Display="None" 
                    ErrorMessage="Only alphabets required current city " 
                    ValidationExpression="[a-zA-Z ]+"></asp:RegularExpressionValidator>
                <asp:CustomValidator ID="CustomValidator1" runat="server" 
                    ControlToValidate="lstYear" Display="None" ErrorMessage="Age Bellow 13"></asp:CustomValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="txtHometown" Display="None" 
                    ErrorMessage="Only alphabets required in home town " 
                    ValidationExpression="[a-zA-Z ]+"></asp:RegularExpressionValidator>
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
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
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
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save Changes" 
                    onclick="btnSave_Click"  />
            </td>
            <td>
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
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

