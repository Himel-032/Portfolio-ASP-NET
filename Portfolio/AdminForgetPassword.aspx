<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminForgetPassword.aspx.cs" Inherits="Portfolio.AdminForgetPassword" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background: linear-gradient(135deg, #667eea, #764ba2);
            min-height: 100vh;
            display: flex;
            align-items: center;
            justify-content: center;
            margin: 0;
        }

        .forgot-container {
            background: white;
            padding: 40px;
            border-radius: 10px;
            width: 350px;
            box-shadow: 0 5px 15px rgba(0,0,0,0.2);
        }

        .forgot-container h2 {
            text-align: center;
            color: #333;
            margin-bottom: 10px;
        }

        .forgot-container p {
            text-align: center;
            color: #666;
            font-size: 14px;
            margin-bottom: 30px;
        }

        .forgot-container input[type=text],
        .forgot-container input[type=email] {
            width: 100%;
            padding: 12px;
            border: 1px solid #ddd;
            border-radius: 5px;
            margin-bottom: 20px;
            font-size: 16px;
        }

        .forgot-container input[type=text]:focus,
        .forgot-container input[type=email]:focus {
            border-color: #667eea;
            outline: none;
        }

        .forgot-container button,
        #btnSendReset {
            width: 100%;
            padding: 12px;
            background: #667eea;
            color: white;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
        }

        .forgot-container button:hover,
        #btnSendReset:hover {
            background: #5a6fd8;
        }

        .message {
            text-align: center;
            margin-top: 15px;
            padding: 10px;
            border-radius: 5px;
            font-size: 14px;
        }

        .message.error {
            background: #ffe6e6;
            color: #d63031;
            border: 1px solid #fab1a0;
        }

        .message.success {
            background: #e6ffe6;
            color: #00b894;
            border: 1px solid #55efc4;
        }

        .back-link {
            text-align: center;
            margin-top: 20px;
        }

        .back-link a {
            color: #667eea;
            text-decoration: none;
            font-size: 14px;
        }

        .back-link a:hover {
            text-decoration: underline;
        }
    </style>
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