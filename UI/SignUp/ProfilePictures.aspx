<%@ Page Title="" Language="C#" MasterPageFile="~/UI/SignUp/MasterPage.master" AutoEventWireup="true" CodeFile="ProfilePictures.aspx.cs" Inherits="UserProfile_ProfilePictures" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script type="text/javascript">
          function openCalendar() {
              window.open('CropPicture.aspx?ctlid=<%=Session["UserId"] %>', 'Crop Picture', 'scrollbars=no,resizable=no,width=550,height=400,screenX=400,screenY=200');
              return false;
          }
    </script>
    


    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
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
            <td style="text-align: center">
                <asp:Image ID="imgProfile" runat="server" style="text-align: center" 
                    Height="128px" ImageAlign="Middle" Width="128px" BorderColor="#662D3D" 
                    BorderStyle="Solid" BorderWidth="2px" />
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />

                                <asp:Button ID="btnSaveUpload" CssClass="button" runat="server" Text="Upload" 
                    onclick="btnSaveUpload_Click" />

        <asp:RegularExpressionValidator runat="server" ID="valUpTest" ControlToValidate="FileUpload1"
                               ErrorMessage="Image Files Only (jpg,jpeg,gif,png)" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$" /></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:LinkButton ID="lbtnremove" runat="server" onclick="lbtnremove_Click" Visible="false">Remove</asp:LinkButton>
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
                &nbsp;</td>
            <td>

            &nbsp;<asp:Button ID="Button1" CssClass="button" runat="server" Text="Edit This Image" 
                    OnClientClick="javascript:return openCalendar();" 
                 />
                <asp:Button ID="btnNext"  CssClass="button" OnClick="btnNext_Click" runat="server" Text="Next Step"  />

                       <asp:confirmbuttonextender id="Post_ConfirmButtonExtender" 
		runat="server" targetcontrolid="btnNext" enabled="True" 
		displaymodalpopupid="Post_ModalPopupExtender">
        </asp:confirmbuttonextender>
          <asp:modalpopupextender 
		id="Post_ModalPopupExtender" runat="server" 
		 okcontrolid="ButtonPostOkay" 
		targetcontrolid="btnNext" popupcontrolid="DivPostConfirmation" >
          
        </asp:modalpopupextender>
       
        <asp:panel class="popupConfirmation" id="DivPostConfirmation" 
	style="display: none" runat="server">
    <div class="popup_Container">
        <div class="popup_Titlebar" id="PopupHeader">
            <div class="TitlebarLeft">
                Signup Completed</div>
            <div  onclick="$get('ButtonDeleteCancel').click();">
            </div>
        </div>
        <div class="popup_Body">
            <p>
             <img src="../../Resources/Images/MenuIcon/success_alert.gif" />  Sign up Completed. Check your Email for activation Link
            </p>
        </div>
        <div class="popup_Buttons">
           <asp:Button ID="ButtonPostOkay" OnClick="btnNext_Click" runat="server" Text="Ok" />
       
  
        </div>
    </div>
</asp:panel>

        <br />



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
                <asp:Label ID="lblMsg" runat="server" Text="Label" ForeColor="Red" 
                    Visible="False"></asp:Label>
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
                      <object height="190" width="405" __designer:mapid="8cc">
                         <param name="movie" value="../../Resources/PhotoCam/save_picture.swf" 
                             __designer:mapid="8cd">
                           
                         <embed height="190" src="../../Resources/PhotoCam/save_picture.swf" 
                             width="405"></embed>
                         &nbsp;&nbsp;&nbsp;&nbsp;</param></object>
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
                <asp:Button ID="btnCamSave"  cssClass="button" runat="server" Text="Save Image" 
                    onclick="btnCamSave_Click" />
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
    </table>

    
</asp:Content>

