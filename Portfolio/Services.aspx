<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Services.aspx.cs" Inherits="Portfolio.Services" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="main-content">
           <h2>Manage Services</h2>

    <!-- Add New Service -->
    <div class="content-panel">
        <h3>Add New Service</h3><br /><br />
        <asp:Label Text="Service Title: " runat="server" CssClass="npm-label" /><br />
        <asp:TextBox ID="txtTitle" runat="server" CssClass="npm-input" Placeholder="Service Title"></asp:TextBox><br />
         <asp:Label Text="Service Description: " runat="server" CssClass="npm-label" /><br />
        <asp:TextBox ID="txtDescription" runat="server" CssClass="npm-input" TextMode="MultiLine" Rows="3" Placeholder="Service Description"></asp:TextBox><br />
         <asp:Label Text="Service Logo: " runat="server" CssClass="npm-label" /><br />
        <asp:FileUpload ID="fuIcon" runat="server" CssClass="npm-input" /><br /><br />
        <asp:Button ID="btnAdd" runat="server" CssClass="npm-button" Text="Add Service" OnClick="btnAdd_Click" /><br />
        <asp:Label ID="lblMessage" runat="server" CssClass="npm-message"></asp:Label>
    </div>

    <hr />

    <!-- GridView for Services -->
    <asp:GridView ID="gvServices" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        OnRowEditing="gvServices_RowEditing"
        OnRowCancelingEdit="gvServices_RowCancelingEdit"
        OnRowUpdating="gvServices_RowUpdating"
        OnRowDeleting="gvServices_RowDeleting"
        CssClass="npm-table">
        
        <Columns>
         
            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                    <%# Eval("ServiceTitle") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditTitle" runat="server" CssClass="npm-input" Text='<%# Bind("ServiceTitle") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

          
            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <%# Eval("ServiceDescription") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditDescription" runat="server" CssClass="npm-input" TextMode="MultiLine" Rows="3" Text='<%# Bind("ServiceDescription") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

           
            <asp:TemplateField HeaderText="Icon">
                <ItemTemplate>
                    <img src='<%# ResolveUrl(Eval("IconPath").ToString()) %>' alt="icon" width="40" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:FileUpload ID="fuEditIcon" runat="server" CssClass="npm-input" />
                </EditItemTemplate>
            </asp:TemplateField>

           
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" 
                              EditText="Edit" CancelText="Cancel" UpdateText="Update"
                              ControlStyle-CssClass="npm-button" />
        </Columns>
    </asp:GridView>
        </div>
</asp:Content>
