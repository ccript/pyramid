<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserProfile/MasterPage.master" AutoEventWireup="true" CodeFile="EducationWork.aspx.cs" Inherits="EducationWork" %>

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
                Employer:</td>
            <td>
                <asp:TextBox ID="txtEmployer" runat="server" Width="300px" 
                    Tooltip="Where have you worked?"  AutoComplete="Off" MaxLength="45"></asp:TextBox>
                 <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" WatermarkCssClass="water" TargetControlID="txtEmployer" WatermarkText="Where have you worked?">
                   </ajax:TextBoxWatermarkExtender>
                   <ajax:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtEmployer" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetEmployer"     
CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight" >
</ajax:AutoCompleteExtender> 
                  
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
                <table class="style6">
                    <tr>
                        <td>
                            Position:</td>
                        <td>
                            <asp:TextBox ID="txtEmployerPosition" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Town</td>
                        <td>
                            <asp:TextBox ID="txtEmployerTown" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Description:</td>
                        <td>
                            <asp:TextBox ID="txtEmployerDescription" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Are you Currently Work:</td>
                        <td>
                            <asp:CheckBox ID="chkEmployerCurrentlyWork" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Star Duration:</td>
                        <td>
                         <table>
        <tr>
            <td>
                <asp:UpdatePanel ID="updpnlMonth" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="lstStartMonth" runat="server" AutoPostBack="true" DataTextField="MonthName"
                            DataValueField="MonthNumber" OnSelectedIndexChanged="lstStartMonth_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="updpnlDay" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="lstStartDay" runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lstStartMonth" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:DropDownList ID="lstStartYear" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
                        
                        
                        </td>
                    </tr>
                      <tr>
                        <td>
                            Star End:</td>
                        <td>
                         <table>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="lstEndMonth" runat="server" AutoPostBack="true" DataTextField="MonthName"
                            DataValueField="MonthNumber" OnSelectedIndexChanged="lstEndMonth_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="lstEndDay" runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lstEndMonth" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:DropDownList ID="lstEndYear" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
                        
                        
                        </td>
                    </tr>
                </table>
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
                <asp:DataList ID="DListEmployer" runat="server" 
                       DataKeyField="_Id" 
                    OnSelectedIndexChanged="DListEmployer_SelectedIndexChanged"  RepeatColumns="5" 
                    Width="400px">
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
            <td class="style5">
                &nbsp;</td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="txtEmployer" 
                    ErrorMessage="Only alphabets required in employer" 
                    ValidationExpression="[a-zA-Z ]+"></asp:RegularExpressionValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>

          <tr>
            <td>
                &nbsp;</td>
            <td colspan="2">
                <br />
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
                Project:</td>
            <td>
                <asp:TextBox ID="txtProject" runat="server" Width="300px" 
                    Tooltip="In which project?" MaxLength="45"></asp:TextBox>
                  <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkCssClass="water" TargetControlID="txtProject" WatermarkText="In which project?">
                   </ajax:TextBoxWatermarkExtender>
                           <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtProject" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetProject"     
CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight" >
</ajax:AutoCompleteExtender> 
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
                <table class="style6">
                    <tr>
                        <td>
                            Description:</td>
                        <td>
                            <asp:TextBox ID="txtProjectDescription" runat="server" MaxLength="45"></asp:TextBox>
                        </td>
                    </tr>
                      <tr>
                        <td>
                            Star Duration:</td>
                        <td>
                         <table>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="lstPStartMonth" runat="server" AutoPostBack="true" DataTextField="MonthName"
                            DataValueField="MonthNumber" OnSelectedIndexChanged="lstPStartMonth_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="lstPStartDay" runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lstPStartMonth" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:DropDownList ID="lstPStartYear" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
                        
                        
                        </td>
                    </tr>
                      <tr>
                        <td>
                            Star End:</td>
                        <td>
                         <table>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="lstPEndMonth" runat="server" AutoPostBack="true" DataTextField="MonthName"
                            DataValueField="MonthNumber" OnSelectedIndexChanged="lstPEndMonth_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="lstPEndDay" runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lstPEndMonth" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:DropDownList ID="lstPEndYear" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
                        
                        
                        </td>
                    </tr>
                    <tr>
                        <td>
                            People </td>
                        <td>
                                  <asp:DropDownList ID="lstProjectFriend" runat="server" 
                    AppendDataBoundItems="True" 
                    DataTextField="FirstName" DataValueField="Id" 
                    DataSourceID="ObjectDataSource1">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                            </td>
                    </tr>
                </table>
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
                <asp:DataList ID="DListProject" runat="server" 
                       DataKeyField="_Id" 
                    OnSelectedIndexChanged="DListProject_SelectedIndexChanged"  RepeatColumns="5" 
                    Width="400px">
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
            <td class="style5">
                &nbsp;</td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="txtProject" 
                    ErrorMessage="Only alphabets required in project" 
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
            <td class="style5">
                University:</td>
            <td>
                <asp:TextBox ID="txtUniversity" runat="server" Width="300px" 
                    Tooltip="Where did you go to college/university?" MaxLength="45"></asp:TextBox>
                  <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" WatermarkCssClass="water" TargetControlID="txtUniversity" WatermarkText="Where did you go to college/university?">
                   </ajax:TextBoxWatermarkExtender>
                                              <ajax:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="txtUniversity" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetUniversities"     
CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight" >
</ajax:AutoCompleteExtender> 
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
                <table class="style6">
                    <tr>
                        <td>
                            Class Year:</td>
                        <td>
                            <asp:DropDownList ID="lstClassYear" runat="server">
                                <asp:ListItem>1990</asp:ListItem>
                                <asp:ListItem>1991</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Purpose:</td>
                        <td>
                            <asp:TextBox ID="txtPurpose" runat="server" MaxLength="45"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Degree</td>
                        <td>
                            <asp:TextBox ID="txtDegree" runat="server" MaxLength="45"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            People</td>
                        <td>
                             <asp:DropDownList ID="lstUniversityFriend" runat="server" 
                    AppendDataBoundItems="True" 
                    DataTextField="FirstName" DataValueField="Id" 
                    DataSourceID="ObjectDataSource1">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    SelectMethod="getAllFriendsListName" TypeName="BuinessLayer.FriendsBLL">
                    <SelectParameters>
                        <asp:SessionParameter Name="UserId" SessionField="UserId" Type="String" />
                        <asp:Parameter DefaultValue=Global.CONFIRMED Name="status" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Attend For</td>
                        <td>
                            <asp:TextBox ID="txtAttendFor" runat="server" MaxLength="45"></asp:TextBox>
                        </td>
                    </tr>
                </table>
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
                <asp:DataList ID="DListUniversity" runat="server" 
                       DataKeyField="_Id" 
                    OnSelectedIndexChanged="DListUniversity_SelectedIndexChanged"  RepeatColumns="5" 
                    Width="400px">
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
            <td class="style5">
                &nbsp;</td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                    ControlToValidate="txtUniversity" 
                    ErrorMessage="Only alphabets required in university" 
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
            <td class="style5">
                School:</td>
            <td>
                <asp:TextBox ID="txtSchool" runat="server" Width="300px" 
                    Tooltip="Where did you go to school?" MaxLength="45"></asp:TextBox>
                  <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" WatermarkCssClass="water" TargetControlID="txtSchool" WatermarkText="Where did you go to school?">
                   </ajax:TextBoxWatermarkExtender>
                                                                 <ajax:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtSchool" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetSchool"     
CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"  CompletionListHighlightedItemCssClass ="AutoExtenderHighlight" >
           </ajax:AutoCompleteExtender> 
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
                <table class="style6">
                    <tr>
                        <td>
                            Description:</td>
                        <td>
                            <asp:TextBox ID="txtSchoolDescription" runat="server" MaxLength="45"></asp:TextBox>
                        </td>
                    </tr>
                    </table>
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
                <asp:DataList ID="DListSchool" runat="server" 
                       DataKeyField="_Id" 
                    OnSelectedIndexChanged="DListSchool_SelectedIndexChanged"  RepeatColumns="5" 
                    Width="400px">
                    <ItemStyle Font-Names="Verdana" Font-Size="10pt" HorizontalAlign="Center" 
                        VerticalAlign="Top" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" 
                            BorderStyle="Dashed" BorderWidth="1px" Height="64px" 
                            ImageUrl='~/Resources/images/School/DefaultSchool.png' 
                            style="text-align: center" Width="64px" />
                       
                            <asp:LinkButton ID="lnkSelect" runat="server" CommandName="select" 
                            style="font-size: 7pt">Delete</asp:LinkButton>

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
            <td class="style5">
                &nbsp;</td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                    ControlToValidate="txtSchool" ErrorMessage="Only alphabets required in school" 
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
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

