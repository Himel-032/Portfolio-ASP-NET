<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Portfolio.AdminLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            min-height: 100vh;
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .login-container {
            width: 420px;
            padding: 40px;
            background: rgba(255, 255, 255, 0.95);
            backdrop-filter: blur(20px);
            border-radius: 20px;
            box-shadow: 
                0 20px 40px rgba(0, 0, 0, 0.1),
                0 0 0 1px rgba(255, 255, 255, 0.2);
        }

        .login-header {
            text-align: center;
            margin-bottom: 40px;
        }

        .login-header h2 {
            font-size: 32px;
            font-weight: 700;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            -webkit-background-clip: text;
            -webkit-text-fill-color: transparent;
            background-clip: text;
            margin-bottom: 8px;
        }

        .login-header p {
            color: #666;
            font-size: 14px;
            font-weight: 300;
        }

        .form-group {
            margin-bottom: 25px;
            position: relative;
        }

        .input-wrapper {
            position: relative;
            display: flex;
            align-items: center;
        }

        .input-icon {
            position: absolute;
            left: 15px;
            z-index: 2;
            color: #667eea;
            font-size: 18px;
        }

        .login-container input[type=text],
        .login-container input[type=password] {
            width: 100%;
            padding: 15px 15px 15px 50px;
            border: 2px solid transparent;
            border-radius: 12px;
            background: linear-gradient(135deg, #f8f9ff 0%, #f1f3ff 100%);
            font-size: 16px;
            transition: all 0.3s ease;
            outline: none;
        }

        .login-container input[type=text]:focus,
        .login-container input[type=password]:focus {
            border-color: #667eea;
            transform: translateY(-2px);
            box-shadow: 0 8px 25px rgba(102, 126, 234, 0.2);
        }

        .checkbox-wrapper {
            display: flex;
            align-items: center;
            margin-bottom: 30px;
        }

        .login-container input[type=checkbox] {
            width: 18px;
            height: 18px;
            margin-right: 10px;
            accent-color: #667eea;
        }

        .checkbox-wrapper label {
            color: #555;
            font-size: 14px;
            cursor: pointer;
        }

        .login-container button,
        .login-container input[type="submit"],
        #btnLogin {
            width: 100% !important;
            padding: 15px !important;
            border: none !important;
            border-radius: 12px !important;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%) !important;
            color: white !important;
            font-size: 16px !important;
            font-weight: 600 !important;
            cursor: pointer !important;
            transition: all 0.3s ease !important;
            text-transform: uppercase !important;
            letter-spacing: 1px !important;
        }

        .login-container button:hover,
        .login-container input[type="submit"]:hover,
        #btnLogin:hover {
            transform: translateY(-2px) !important;
            box-shadow: 0 10px 30px rgba(102, 126, 234, 0.4) !important;
        }

        .login-container button:active,
        .login-container input[type="submit"]:active,
        #btnLogin:active {
            transform: translateY(0) !important;
        }

        .message {
            text-align: center;
            margin-top: 20px;
            padding: 12px;
            border-radius: 8px;
            font-size: 14px;
        }

        .message.error {
            background: linear-gradient(135deg, #ff6b6b, #ff8e8e);
            color: white;
        }

        .message.success {
            background: linear-gradient(135deg, #4ecdc4, #44a08d);
            color: white;
        }

        .forgot-password {
            text-align: center;
            margin-top: 20px;
        }

        .forgot-password a {
            color: #667eea;
            text-decoration: none;
            font-size: 14px;
            transition: all 0.3s ease;
        }

        .forgot-password a:hover {
            color: #764ba2;
            text-decoration: underline;
        }

        /* Responsive design */
        @media (max-width: 480px) {
            .login-container {
                width: 90%;
                margin: 20px;
                padding: 30px 20px;
            }
            
            .login-header h2 {
                font-size: 28px;
            }
        }
    </style>
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