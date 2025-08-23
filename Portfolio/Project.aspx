<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="Portfolio.Project" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main-content">
        <h2>Manage Projects</h2>

        <!-- Add Project Form -->
        <div class="content-panel">
            <h3>Add New Project</h3>
            <asp:TextBox ID="txtName" runat="server" CssClass="npm-input" Placeholder="Project Name"></asp:TextBox><br />
            <br />
            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="npm-input">
                <asp:ListItem  Text="Select Category" />
                <asp:ListItem>Web Design</asp:ListItem>
                <asp:ListItem>Applications</asp:ListItem>
                <asp:ListItem>Web Development</asp:ListItem>
            </asp:DropDownList><br />
            <br />
          <!--  <asp:TextBox ID="txtImage" runat="server" CssClass="npm-input" Placeholder="Image Name"></asp:TextBox><br /> <br /> -->
            
            <asp:Button ID="btnAdd" runat="server" Text="Add Project" CssClass="npm-button" OnClick="btnAdd_Click" />
        </div>

        <!-- Projects Table -->
        <div class="content-panel" style="margin-top: 20px;">
            <h3>All Projects</h3>
            <asp:GridView ID="gvProjects" runat="server" AutoGenerateColumns="False" CssClass="npm-table"
                DataKeyNames="id"
                OnRowEditing="gvProjects_RowEditing"
                OnRowCancelingEdit="gvProjects_RowCancelingEdit"
                OnRowUpdating="gvProjects_RowUpdating"
                OnRowDeleting="gvProjects_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="Project Name">
                        <ItemTemplate>
                            <%# Eval("name") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditName" runat="server" Text='<%# Bind("name") %>' CssClass="npm-input" />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Category">
                        <ItemTemplate>
                            <%# Eval("category") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditCategory" runat="server" Text='<%# Bind("category") %>' CssClass="npm-input" />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Image Name">
                        <ItemTemplate>
                            <%# Eval("image_name") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditImage" runat="server" Text='<%# Bind("image_name") %>' CssClass="npm-input" />
                        </EditItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" CssClass="npm-button">Edit</asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <div style="display: flex; gap: 6px; flex-wrap: wrap;">
                                <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" CssClass="npm-button">Update</asp:LinkButton>
                                <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel" CssClass="npm-button">Cancel</asp:LinkButton>
                            </div>
                        </EditItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CssClass="npm-button"
                                OnClientClick="return confirm('Are you sure you want to delete this project?');">
                    Delete
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>


</asp:Content>
