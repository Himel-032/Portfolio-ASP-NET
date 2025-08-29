<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Portfolio.Admin" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="main-content">
        <h2>Manage Profile</h2>

        <div class="content-panel">
            <asp:Label ID="lblMessage" runat="server" CssClass="npm-message"></asp:Label><br />

            <asp:Label ID="lblName" runat="server" Text="Name:" CssClass="npm-label"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" CssClass="npm-input"></asp:TextBox><br /><br />

            <asp:Label ID="lblEmail" runat="server" Text="Email:" CssClass="npm-label"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="npm-input"></asp:TextBox><br /><br />

            <asp:Label ID="lblPhone" runat="server" Text="Phone:" CssClass="npm-label"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="npm-input"></asp:TextBox><br /><br />

            <asp:Label ID="lblLocation" runat="server" Text="Location:" CssClass="npm-label"></asp:Label>
            <asp:TextBox ID="txtLocation" runat="server" CssClass="npm-input"></asp:TextBox><br /><br />

            <asp:Label ID="lblBirthDate" runat="server" Text="Birth Date:" CssClass="npm-label"></asp:Label>
            <asp:TextBox ID="txtBirthDate" runat="server" CssClass="npm-input"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="ceBirthDate" runat="server" TargetControlID="txtBirthDate" Format="yyyy-MM-dd" /><br /><br />

            <asp:Label ID="lblFacebook" runat="server" Text="Facebook:" CssClass="npm-label"></asp:Label>
            <asp:TextBox ID="txtFacebook" runat="server" CssClass="npm-input"></asp:TextBox><br /><br />

            <asp:Label ID="lblTwitter" runat="server" Text="Twitter:" CssClass="npm-label"></asp:Label>
            <asp:TextBox ID="txtTwitter" runat="server" CssClass="npm-input"></asp:TextBox><br /><br />

            <asp:Label ID="lblInstagram" runat="server" Text="Instagram:" CssClass="npm-label"></asp:Label>
            <asp:TextBox ID="txtInstagram" runat="server" CssClass="npm-input"></asp:TextBox><br /><br />

            <!-- Profile Image Upload -->
            <asp:Label ID="lblImage" runat="server" Text="Profile Image:" CssClass="npm-label"></asp:Label>
            <asp:FileUpload ID="fuImage" runat="server" CssClass="npm-input" /><br /><br />
            <asp:Image ID="imgPreview" runat="server" Width="150" /><br /><br />

            <!-- PDF Upload -->
            <asp:Label ID="lblPdf" runat="server" Text="Resume / PDF:" CssClass="npm-label"></asp:Label>
            <asp:FileUpload ID="fuPdf" runat="server" CssClass="npm-input" /><br /><br />
            <asp:HyperLink ID="hlPdf" runat="server" Text="Download PDF" Target="_blank" Visible="false" CssClass="npm-link"></asp:HyperLink><br /><br />

            <asp:Button ID="btnSave" runat="server" Text="Save / Update" CssClass="npm-button" OnClick="btnSave_Click" /><br /><br />
        </div>
    </div>
</asp:Content>
