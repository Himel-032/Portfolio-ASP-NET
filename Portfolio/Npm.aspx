<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Npm.aspx.cs" Inherits="Portfolio.Npm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-panel">
        <h2>Submit NPM URL</h2>
        <asp:TextBox ID="txtNpmUrl" runat="server" CssClass="npm-input" Placeholder="Enter NPM URL"></asp:TextBox>
        <br />
       
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="npm-button" OnClick="btnSubmit_Click" />

        <asp:Label ID="lblMessage" runat="server" CssClass="npm-message"></asp:Label>
    </div>

    <div class="content-panel">
        <h2>All NPM URLs</h2>
        <asp:GridView ID="gvNpmUrls" runat="server" AutoGenerateColumns="False" CssClass="npm-table" OnRowCommand="gvNpmUrls_RowCommand">
    <Columns>
        <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" />
        <asp:BoundField DataField="npm_url" HeaderText="NPM URL" />
        <asp:BoundField DataField="created_at" HeaderText="Submitted At" DataFormatString="{0:yyyy-MM-dd HH:mm}" />

   
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="EditRow" CommandArgument='<%# Eval("id") %>' CssClass="npm-button"/>
            </ItemTemplate>
        </asp:TemplateField>

  
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteRow" CommandArgument='<%# Eval("id") %>' CssClass="npm-button"/>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>

    </div>
</asp:Content>



