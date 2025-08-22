<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NpmSection.aspx.cs" Inherits="Portfolio.Sections.NpmSection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>My NPM Packages</h1>

    <asp:Repeater ID="rptPackages" runat="server">
        <ItemTemplate>
            <div class="package-card">
                <h3>
                    <a href='<%# Eval("NpmUrl") %>' target="_blank"><%# Eval("NpmName") %></a>
                </h3>
                <pre>npm install <%# Eval("NpmName") %></pre>
                <a href='<%# Eval("GitHubUrl") %>' target="_blank">GitHub</a><br/>
                <img src='https://img.shields.io/npm/v/<%# Eval("NpmName") %>?color=blue' alt='npm version'/>
                <img src='https://img.shields.io/npm/dw/<%# Eval("NpmName") %>' alt='npm downloads'/>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
