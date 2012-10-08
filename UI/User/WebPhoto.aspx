<%@ Page Title="" Language="C#" MasterPageFile="~/UI/User/MasterPage.master" AutoEventWireup="true" CodeFile="WebPhoto.aspx.cs" Inherits="User_WebPhotos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript">
        function openCalendar() {
            window.open('CropPicture.aspx?ctlid=<%=Session["UserId"] %>', 'Crop Picture', 'scrollbars=no,resizable=no,width=400,height=400');
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

<br />    
         <object height="190" width="405" __designer:mapid="8cc">
                         <param name="movie" value="../../Resources/PhotoCam/save_picture.swf" 
                             __designer:mapid="8cd">
                         <embed height="190" src="../../Resources/PhotoCam/save_picture.swf" 
                             width="405"></embed>
                         </param></object>

<br /><br /><br /><br />
   
             <asp:Button ID="btnCamSave" cssClass="button" runat="server" Text="Save Image" 
                    onclick="btnCamSave_Click" />
        
</asp:Content>

