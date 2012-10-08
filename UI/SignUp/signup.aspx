<%@ Page Language="C#" MasterPageFile="~/UI/SignUp/MasterPage.master" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>
<%@ register tagprefix="recaptcha" namespace="Recaptcha" assembly="Recaptcha" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        div.top {
	margin: 0px 0;
	position: relative;
	width: 166px;
	height: 119px;
	border: 1px solid #aaa;
	overflow: hidden;
	}	
 
	div.top div {
		width: 166px;
		height: 119px;
		font-size: 12px;
		padding: 0px;
		position: absolute;
		top: 0;
		left: 0;
		text-align: center;
		background: #fff;
   		-webkit-transition: left 1s ease-in-out;
		}
 
	div.top div.first {
		z-index: 1000;
		}
		div.top div.second {
		text-align: center;
		}			
 
div.top:hover div.first {
	-webkit-transition: left 1s ease-in-out;
	left: -168px;
	}
        .style1
        {
            width: 100%;
        }
        .style2
        {
        }
        .style3
        {
            width: 198px;
        }
              
              .style5
        {
            color: #666666;
            font-weight: bold;
            font-family: Verdana;
            font-size: 10pt;
            vertical-align: top;
        }  
        .wide_content{
        background-color: #FFFFFF;
   background-image: url("../../Resources/Images/signupbg.png");
   background-position: center bottom;
   background-repeat: no-repeat;
   height:703px;
        }
        .style981
        {
            width: 14px;
        }
        .style985
        {
        }
        .style986
        {
            width: 103px;
        }
        .style987
        {
            width: 163px;
        }
    </style>

   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


            &nbsp;&nbsp;&nbsp;&nbsp;<table class="style1">
    <tr>
        <td style="border-right-style: solid; padding-right: 8px; background-color: #C0C0C0;">
            <div class="top">
	<div class="first"><asp:Image ID="Image1" runat="server" Height="119px" 
                ImageUrl="~/Resources/Images/signup_social.jpg" Width="166px" /></div>
    <div class="second" 
                    style="font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #990000; font-weight: normal; font-style: normal; font-variant: normal">Share the real you! Share your individuality with your own customized place on the web</div></div>
        </td>
        <td rowspan="5">
        <asp:Panel ID="Field_Panel" runat="server">
        


            <table class="style1">
                <tr>
                    <td class="style2" colspan="4">
                        <h4>
                            Sign Up ! It&#39;s free.</h4>
                    </td>
                </tr>
                <tr>
                    <td class="style2" colspan="4">
                        &nbsp;</td>
                </tr>
                <tr>
                    
                    <td class="style981">
                        &nbsp;</td>
                    <td class="style986">
                        <asp:Label ID="FirstNameLabel" runat="server" CssClass="style5" 
                            Text="First Name:"></asp:Label>
                    </td>
                    <td class="style3">
                        <asp:TextBox ID="FirstName" runat="server" Width="193px" CssClass="asptextbox"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="FirstName" ErrorMessage="First Name Requried" ForeColor="White"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                            ControlToValidate="FirstName" ErrorMessage="Characters Allowed" 
                            ValidationExpression="^[a-zA-Z''-'\s]{1,20}$" ForeColor="White"></asp:RegularExpressionValidator>

                            <asp:ValidatorCalloutExtender runat="Server" ID="NReqE"
            TargetControlID="RequiredFieldValidator1" />

                                        <asp:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender7"
            TargetControlID="RegularExpressionValidator3" />
                    </td>
                </tr>
                <tr>
                    <td class="style981">
                        &nbsp;</td>
                    <td class="style986">
                        <asp:Label ID="LastNameLabel" runat="server" CssClass="style5" 
                            Text="Last Name:"></asp:Label>
                    </td>
                    <td class="style3">
                        <asp:TextBox ID="LastName" runat="server" Width="193px" CssClass="asptextbox"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="LastName" ErrorMessage="Last Name Requried" ForeColor="White"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                            ControlToValidate="LastName" ErrorMessage="Characters Allowed" 
                            ValidationExpression="^[a-zA-Z''-'\s]{1,20}$" ForeColor="White" ></asp:RegularExpressionValidator>

                         <asp:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
            TargetControlID="RequiredFieldValidator2" />

                                     <asp:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender8"
            TargetControlID="RegularExpressionValidator4" />
                    </td>
                </tr>
                <tr>
                    <td class="style981">
                        &nbsp;</td>
                    <td class="style986">
                        <asp:Label ID="EmailLabel" runat="server" Text="Email:" CssClass="style5"></asp:Label>
                    </td>
                    <td class="style3">
                        <asp:TextBox ID="Email" runat="server" Width="193px" CssClass="asptextbox"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="Email" ErrorMessage="Email Required" ForeColor="White"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="Email" ErrorMessage="InValid Email Address" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="White" ></asp:RegularExpressionValidator>
                     <br />   <asp:Label ID="Already_Email_Error" runat="server" ForeColor="Red" Text="" 
                            Visible="false"></asp:Label>

                 <asp:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
            TargetControlID="RequiredFieldValidator3" />

             <asp:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3"
            TargetControlID="RegularExpressionValidator1" />


                    </td>
                </tr>
                <tr>
                    <td class="style981">
                        &nbsp;</td>
                    <td class="style986">
                        <asp:Label ID="ReEnterEmailLabel" runat="server" Text="Re-Enter Email:" 
                            CssClass="style5"></asp:Label>
                    </td>
                    <td class="style3">
                        <asp:TextBox ID="ReEnterEmail" runat="server" Width="193px" CssClass="asptextbox"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="ReEnterEmail" ErrorMessage="ReEnter Email Requried" ForeColor="White"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="ReEnterEmail" ErrorMessage="InValid Email Address" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="White"></asp:RegularExpressionValidator>
                        
                        <br /><asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToCompare="Email" ControlToValidate="ReEnterEmail" 
                            ErrorMessage="Email DoesNot Match"></asp:CompareValidator>

          <asp:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender4"
            TargetControlID="CompareValidator1" />
          
                    </td>
                </tr>
                <tr>
                    <td class="style981">
                        &nbsp;</td>
                    <td class="style986">
                        <asp:Label ID="PasswordLabel" runat="server" Text="Password:" CssClass="style5"></asp:Label>
                    </td>
                    <td class="style3">
                        <asp:TextBox ID="ePassword" runat="server" TextMode="Password" Width="193px" 
                            MaxLength="10" CssClass="asptextbox"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="ePassword" ErrorMessage="*"></asp:RequiredFieldValidator>

                            <asp:PasswordStrength ID="PasswordStrength1" runat="server" TargetControlID="ePassword"
            DisplayPosition="RightSide"
            StrengthIndicatorType="Text"
            PreferredPasswordLength="10" 
            PrefixText="Strength:"
            HelpStatusLabelID="TextBox1_HelpLabel"
            TextStrengthDescriptions="Very Poor;Weak;Average;Strong;Excellent"
            StrengthStyles="TextIndicator_TextBox1_Strength1;TextIndicator_TextBox1_Strength2;TextIndicator_TextBox1_Strength3;TextIndicator_TextBox1_Strength4;TextIndicator_TextBox1_Strength5"
            MinimumNumericCharacters="0"
            MinimumSymbolCharacters="0"
            RequiresUpperAndLowerCaseCharacters="false" />

                    </td>
                </tr>

                <tr>
                    <td class="style981">
                        &nbsp;</td>
                    <td class="style986">
                        <asp:Label ID="Phone_Label" runat="server" Text="Phone:" CssClass="style5"></asp:Label>
                    </td>
                    <td class="style3">
                        <asp:TextBox ID="Phone_TextBox" runat="server" Width="193px" CssClass="asptextbox"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                            ControlToValidate="Phone_TextBox" ErrorMessage="Requried" ForeColor="White" ></asp:RequiredFieldValidator>
                       <br /> <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                            ControlToValidate="Phone_TextBox" ErrorMessage="Number Allowed" 
                            ValidationExpression="^\d+$" ForeColor="White"></asp:RegularExpressionValidator>

                            <asp:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender5"
            TargetControlID="RequiredFieldValidator10" />

             <asp:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender6"
            TargetControlID="RegularExpressionValidator5" />
             
                    </td>
                </tr>
                

                <tr>
                    <td class="style981">
                        &nbsp;</td>
                    <td class="style986">
                        <asp:Label ID="Gender" runat="server" Text="I AM" CssClass="style5"></asp:Label>
                    </td>
                    <td class="style3">
                        <asp:DropDownList ID="GenderID" runat="server" >
                            <asp:ListItem Selected="True">Gender</asp:ListItem>
                            <asp:ListItem value="Male">Male</asp:ListItem>
                            <asp:ListItem value="Female">Female</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="GenderID" ErrorMessage="*" InitialValue="Gender"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style981">
                        &nbsp;</td>
                    <td class="style986">
                        <asp:Label ID="YearLabel" runat="server" Text="Year" CssClass="style5"></asp:Label>
                    </td>
                    <td class="style3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        <asp:DropDownList ID="YearList" runat="server" AutoPostBack="true" 
                            onselectedindexchanged="YearList_SelectedIndexChanged" >
                            <asp:ListItem Selected="True">Year</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                            ControlToValidate="YearList" ErrorMessage="*" InitialValue="Year"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="MonthList" runat="server" AutoPostBack="true" 
                            onselectedindexchanged="MonthList_SelectedIndexChanged" Visible="false">
                            <asp:ListItem Selected="True">Month</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ControlToValidate="MonthList" ErrorMessage="*" InitialValue="Month"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="DateList" runat="server" Visible="false">
                            <asp:ListItem Selected="True">Date</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                            ControlToValidate="DateList" ErrorMessage="*" InitialValue="Date"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:Label ID="Year_month_label" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="Age_Error" runat="server" ForeColor="Red" Text="" 
                            Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style981">
                        &nbsp;</td>
                    <td class="style986">
                        &nbsp;</td>
                    <td class="style3">
                        <asp:Button ID="Submit" CssClass="button" runat="server" onclick="Submit_Click" Text="Submit" Visible="false" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                </table>

                        <table class="style1">
                <tr>
                    
                    <td class="style981" style="border-left-style: solid">
                        &nbsp;</td>
                    <td class="style985" colspan="2">
                        <recaptcha:RecaptchaControl ID="recaptcha" runat="server" 
                            PrivateKey="6Lcbj84SAAAAAJG3GYn2kuWEGx6uqmT2RvsL4taz" 
                            PublicKey="6Lcbj84SAAAAAJ0_4A3PePElwoevx3Nv9cfC2P8W" Theme="red" />
                    </td>
                </tr>
                <tr>
                
                    <td class="style981" align="right" style="border-left-style: solid">
                        &nbsp;</td>
                    <td align="right" class="style987">
                        <asp:Button ID="Security_Button" runat="server" CssClass="button" 
                            onclick="Security_Button_Click" Text="Sign Up" />
                    </td>
                    <td align="left" class="style985">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="terms.aspx">Terms And Conditions</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="style981" style="border-left-style: solid">
                        &nbsp;
                                                </td>
                    <td class="style985" colspan="2">
                        <asp:Label ID="Email_Sending_Error" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblResult" runat="server" Visible="true" />
                    </td>
                </tr>
                            <tr>
                                <td class="style981" style="border-left-style: solid">
                                    &nbsp;</td>
                                <td class="style985" colspan="2">
                                    &nbsp;</td>
                            </tr>
            </table>

            </asp:Panel>

            </td>
    </tr>
    <tr>
        <td style="border-right-style: solid; padding-right: 8px; background-color: #C0C0C0;">
           <div class="top">
	<div class="first"> <asp:Image ID="Image2" runat="server" Height="119px" 
                ImageUrl="~/Resources/Images/redmanimage.jpg" Width="166px" />
                </div>
    <div class="second" 
                    style="font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #990000; font-weight: normal; font-style: normal; font-variant: normal">Express and Entertain! Share your photos and videos with other members</div></div>
        
        </td>
    </tr>
    <tr>
        <td style="border-right-style: solid; padding-right: 8px; background-color: #C0C0C0;">
            <div class="top">
	<div class="first"> <asp:Image ID="Image3" runat="server" Height="119px" 
                ImageUrl="~/Resources/Images/signup_ppl.jpg" Width="166px" />
             </div>
    <div class="second" 
                    style="font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #990000; font-weight: normal; font-style: normal; font-variant: normal">Online Meeting Point! Stay in touch with the most interactive and fun ways</div></div>
          </td>
    </tr>
    <tr>
        <td style="border-right-style: solid; padding-right: 8px; background-color: #C0C0C0;">
          <div class="top">
	<div class="first">   <asp:Image ID="Image4" runat="server" Height="119px" 
                ImageUrl="~/Resources/Images/smarties.jpg" Width="166px" />
        </div>
    <div class="second" 
                    style="font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #990000; font-weight: normal; font-style: normal; font-variant: normal">Stay in the loop! Keep your friends in the loop regardless of where they are</div></div>
   </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    </table>
&nbsp;<asp:Panel ID="Security_Panel" runat="server" Visible="false">

<%--            <table class="style1">
                <tr>
                    <td class="style6">
                        &nbsp;</td>
                    <td class="style4">
                        <recaptcha:RecaptchaControl ID="recaptcha" runat="server" 
PublicKey="6Lcbj84SAAAAAJ0_4A3PePElwoevx3Nv9cfC2P8W" PrivateKey="6Lcbj84SAAAAAJG3GYn2kuWEGx6uqmT2RvsL4taz" Theme="red" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6">
                        &nbsp;</td>
                    <td class="style4">
                        <asp:Button ID="Security_Button" runat="server" onclick="Security_Button_Click" 
                          CssClass="button"   Text="Confirm" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6">
                        &nbsp;</td>
                    <td class="style4">
                        <asp:Label ID="lblResult" runat="server" Visible="true" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
--%>
            </asp:Panel>

                

       
        

</asp:Content>