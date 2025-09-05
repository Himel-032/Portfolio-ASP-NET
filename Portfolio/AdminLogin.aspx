<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Portfolio.AdminLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
     <link href="Admin_Panel/css/adminlogin.css?v=1.0" runat="server" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <div class="login-header">
                <h2>Admin Portal</h2>
                <p>Welcome back! Please sign in to continue</p>
            </div>
            
            <div class="form-group">
                <div class="input-wrapper">
                    <span class="input-icon">📧</span>
                    <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email"></asp:TextBox>
                </div>
            </div>
            
            <div class="form-group">
                <div class="input-wrapper">
                    <span class="input-icon">🔒</span>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Password"></asp:TextBox>
                </div>
            </div>
            
            <div class="checkbox-wrapper">
                <asp:CheckBox ID="chkRememberMe" runat="server" Text="Remember Me" />
            </div>
            
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            
            <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
            
            <div class="forgot-password">
                <a href="AdminForgetPassword.aspx">Forgot your password?</a>
            </div>
        </div>
    </form>
</body>
</html>