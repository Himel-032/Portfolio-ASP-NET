<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminForgetPassword.aspx.cs" Inherits="Portfolio.AdminForgetPassword" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
    <link href="~/Admin_Panel/css/adminforgetpassword.css?v=1.0" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="forgot-container">
            <h2>Forgot Password</h2>
            <p>Enter your email to reset password.</p>
            
            <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email" TextMode="Email"></asp:TextBox>
            <asp:Button ID="btnSendReset" runat="server" Text="Send Reset Link" OnClick="btnSendReset_Click" />
            
            <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
            
            <div class="back-link">
                <a href="AdminLogin.aspx">Back to Login</a>
            </div>
        </div>
    </form>
</body>
</html>