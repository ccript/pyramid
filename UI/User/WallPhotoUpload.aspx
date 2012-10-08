<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserProfile/MasterPage.master" AutoEventWireup="true" CodeFile="WallPhotoUpload.aspx.cs" Inherits="UserProfile_ProfilePictures" %>

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
                    Height="128px" Width="128px" BorderColor="#662D3D" 
                    BorderStyle="Solid" BorderWidth="2px" />
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />

        <asp:RegularExpressionValidator runat="server" ID="valUpTest" ControlToValidate="FileUpload1"
                               ErrorMessage="Image Files Only (jpg,jpeg,gif,png)" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$" /></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:LinkButton ID="lbtnremove" runat="server" onclick="lbtnremove_Click">Remove</asp:LinkButton>
            &nbsp;&nbsp;
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
                <asp:Button ID="btnSaveUpload" CssClass="button" runat="server" Text="Save" 
                    onclick="btnSaveUpload_Click" />

                        <asp:Button ID="Button1" CssClass="button" runat="server" Text="Edit" 
                    OnClientClick="javascript:return openCalendar();" 
                 />
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

