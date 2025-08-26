<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Portfolio.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-panel">
        <h2>Contact Messages</h2>
        <div class="table-responsive">
        <asp:GridView ID="gvMessages" runat="server" AutoGenerateColumns="False" 
    CssClass="npm-table" OnRowCommand="gvMessages_RowCommand">

    <Columns>
        <asp:BoundField DataField="id" HeaderText="ID" />
        <asp:BoundField DataField="fullname" HeaderText="Full Name" />
        <asp:BoundField DataField="email" HeaderText="Email" />
        <asp:BoundField DataField="message" HeaderText="Message" />

        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" 
                    CommandName="DeleteRow" CommandArgument='<%# Eval("id") %>' 
                    CssClass="npm-button" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
 </div>

        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>

