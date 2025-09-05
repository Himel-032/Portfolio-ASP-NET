<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminResetPassword.aspx.cs" Inherits="Portfolio.AdminResetPassword" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reset Password</title>
    <link href="~/Admin_Panel/css/adminresetpassword.css?v=1.0" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="reset-container">
            <h2>Reset Password</h2>
            <p>Enter your new password below</p>
            
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" Placeholder="New Password"></asp:TextBox>
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Placeholder="Confirm Password"></asp:TextBox>

            <div class="requirements">
                <h4>Requirements:</h4>
                <ul>
                    <li>At least 4 characters</li>
                   
                </ul>
            </div>
            
            <asp:Button ID="btnResetPassword" runat="server" Text="Reset Password" OnClick="btnResetPassword_Click" />
            
            <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
            
            <div class="back-link">
                <a href="AdminLogin.aspx">Back to Login</a>
            </div>
        </div>
    </form>
</body>
</html>