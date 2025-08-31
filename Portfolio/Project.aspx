<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="Portfolio.Project"  MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="main-content">
        <h2>Manage Projects</h2>

        <!-- Add Project Form -->
        <div class="content-panel">
            <h3>Add New Project</h3>
            <br />
            <asp:Label ID="lblName" runat="server" Text="Project Name:" AssociatedControlID="txtName" CssClass="npm-label"></asp:Label><br />
            <asp:TextBox ID="txtName" runat="server" CssClass="npm-input" Placeholder="Project Name"></asp:TextBox><br />
            <br />

            <asp:Label ID="lblCategory" runat="server" Text="Category:" AssociatedControlID="ddlCategory" CssClass="npm-label"></asp:Label><br />
            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="npm-input">
                <asp:ListItem Text="Select Category" />
                <asp:ListItem>Web Design</asp:ListItem>
                <asp:ListItem>Applications</asp:ListItem>
                <asp:ListItem>Web Development</asp:ListItem>
            </asp:DropDownList><br />
            <br />

            <!-- File Upload for Image -->
            <asp:Label ID="lblImage" runat="server" Text="Project Image:" AssociatedControlID="fileUploadImage" CssClass="npm-label"></asp:Label><br />
            <asp:FileUpload ID="fileUploadImage" runat="server" CssClass="npm-input" />
            <asp:RegularExpressionValidator
                ID="revFileType"
                runat="server"
                ControlToValidate="fileUploadImage"
                ErrorMessage="Only jpg, jpeg, png files allowed!"
                ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|png|PNG)$"
                ForeColor="Red"
                Display="Dynamic" />
            <br />
            <br />
            <asp:Label ID="lblGithub" runat="server" Text="GitHub Repository URL:" AssociatedControlID="txtGithub" CssClass="npm-label"></asp:Label><br />
            <asp:TextBox ID="txtGithub" runat="server" CssClass="npm-input" Placeholder="Enter github repo link."></asp:TextBox>
            <br />
            <br />


            <asp:Button ID="btnAdd" runat="server" Text="Add Project" CssClass="npm-button" OnClick="btnAdd_Click" />
            <br />
            <asp:Label ID="lblMessage" runat="server" CssClass="npm-message"></asp:Label>
        </div>

        <!-- Projects Table -->
        <div class="content-panel" style="margin-top: 20px;">
            <h3>All Projects</h3>
        <div class="table-responsive">
            <asp:GridView ID="gvProjects" runat="server" AutoGenerateColumns="False" CssClass="npm-table"
        DataKeyNames="id, image_name"
        OnRowEditing="gvProjects_RowEditing"
        OnRowCancelingEdit="gvProjects_RowCancelingEdit"
        OnRowUpdating="gvProjects_RowUpdating"
        OnRowDeleting="gvProjects_RowDeleting"
        OnRowDataBound="gvProjects_RowDataBound">
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
                    <asp:DropDownList ID="ddlEditCategory" runat="server" CssClass="npm-input">
                        <asp:ListItem Text="Web Design" Value="Web Design" />
                        <asp:ListItem Text="Applications" Value="Applications" />
                        <asp:ListItem Text="Web Development" Value="Web Development" />
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <img src='<%# ResolveUrl("~/images/projects/" + Eval("image_name")) %>' alt="Project Image" width="80" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:FileUpload ID="fileUploadEditImage" runat="server" CssClass="npm-input" />
                    <br />
                    Current: <%# Eval("image_name") %>
                    
                    <%-- This is the crucial part! The HiddenField must be here. --%>
                    <asp:HiddenField ID="hfOldImage" runat="server" Value='<%# Eval("image_name") %>' />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="GitHub Repo">
                <ItemTemplate>
                    <a href='<%# Eval("git_repo_url") %>' target="_blank"><%# Eval("git_repo_url") %></a>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditGithub" runat="server" Text='<%# Bind("git_repo_url") %>' CssClass="npm-input" Placeholder="https://github.com/username/repo" />
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
    </div>




</asp:Content>
