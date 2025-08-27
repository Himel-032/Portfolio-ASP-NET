<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="Portfolio.Blog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div class="main-content">
    <h2>Manage Blogs</h2>

    <!-- Add Blog Form -->
    <div class="content-panel">
        <h3>Add New Blog</h3>
        <br />

        <asp:Label ID="lblBlogTitle" runat="server" Text="Blog Title:" AssociatedControlID="txtBlogTitle" CssClass="npm-label"></asp:Label><br />
        <asp:TextBox ID="txtBlogTitle" runat="server" CssClass="npm-input" Placeholder="Enter blog title"></asp:TextBox><br />
        <br />

        <asp:Label ID="lblBlogDesc" runat="server" Text="Blog Description:" AssociatedControlID="txtBlogDesc" CssClass="npm-label"></asp:Label><br />
        <asp:TextBox ID="txtBlogDesc" runat="server" CssClass="npm-input" TextMode="MultiLine" Rows="4" Placeholder="Enter blog description"></asp:TextBox><br />
        <br />

        <asp:Label ID="lblBlogCategory" runat="server" Text="Category:" AssociatedControlID="ddlBlogCategory" CssClass="npm-label"></asp:Label><br />
        <asp:DropDownList ID="ddlBlogCategory" runat="server" CssClass="npm-input">
            <asp:ListItem Text="Select Category" />
            <asp:ListItem>Softare development</asp:ListItem>
            <asp:ListItem>Programming</asp:ListItem>
            <asp:ListItem>Machine Learning</asp:ListItem>
            <asp:ListItem>Web Development</asp:ListItem>
        </asp:DropDownList><br />
        <br />

        <asp:Label ID="lblBlogDate" runat="server" Text="Creation Date:" AssociatedControlID="txtBlogDate" CssClass="npm-label"></asp:Label><br />
        <asp:TextBox ID="txtBlogDate" runat="server" CssClass="npm-input" Placeholder="e.g. March 17, 2025"></asp:TextBox><br />
        <br />

        <asp:Label ID="lblBlogImage" runat="server" Text="Blog Image:" AssociatedControlID="fileBlogImage" CssClass="npm-label"></asp:Label><br />
        <asp:FileUpload ID="fileBlogImage" runat="server" CssClass="npm-input" />
        <asp:RegularExpressionValidator
            ID="revBlogFileType"
            runat="server"
            ControlToValidate="fileBlogImage"
            ErrorMessage="Only jpg, jpeg, png files allowed!"
            ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|png|PNG)$"
            ForeColor="Red"
            Display="Dynamic" />
        <br /><br />

        <asp:Label ID="lblBlogLink" runat="server" Text="Blog Link:" AssociatedControlID="txtBlogLink" CssClass="npm-label"></asp:Label><br />
        <asp:TextBox ID="txtBlogLink" runat="server" CssClass="npm-input" Placeholder="https://example.com/blog/post"></asp:TextBox><br />
        <br />

        <asp:Button ID="btnAddBlog" runat="server" Text="Add Blog" CssClass="npm-button" OnClick="btnAddBlog_Click" /><br />
        <asp:Label ID="lblBlogMessage" runat="server" CssClass="npm-message"></asp:Label>
    </div>

    <!-- Blogs Table -->
    <div class="content-panel" style="margin-top: 20px;">
        <h3>All Blogs</h3>
        <div class="table-responsive">
            <asp:GridView ID="gvBlogs" runat="server" AutoGenerateColumns="False" CssClass="npm-table"
                DataKeyNames="id, blog_photo"
                OnRowEditing="gvBlogs_RowEditing"
                OnRowCancelingEdit="gvBlogs_RowCancelingEdit"
                OnRowUpdating="gvBlogs_RowUpdating"
                OnRowDeleting="gvBlogs_RowDeleting"
                OnRowDataBound="gvBlogs_RowDataBound">

                <Columns>
                    <asp:TemplateField HeaderText="Title">
                        <ItemTemplate><%# Eval("blog_title") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditBlogTitle" runat="server" Text='<%# Bind("blog_title") %>' CssClass="npm-input" />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate><%# Eval("blog_description") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditBlogDesc" runat="server" Text='<%# Bind("blog_description") %>' TextMode="MultiLine" CssClass="npm-input" />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Category">
                        <ItemTemplate><%# Eval("blog_category") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlEditBlogCategory" runat="server" CssClass="npm-input">
                                <asp:ListItem>Programming</asp:ListItem>
                                <asp:ListItem>Machine Learning</asp:ListItem>
                                <asp:ListItem>Web development</asp:ListItem>
                                <asp:ListItem>Softare development</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date">
                        <ItemTemplate><%# Eval("blog_creation_date") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditBlogDate" runat="server" Text='<%# Bind("blog_creation_date") %>' CssClass="npm-input" />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <img src='<%# ResolveUrl("~/images/blogs/" + Eval("blog_photo")) %>' alt="Blog Image" width="80" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:FileUpload ID="fileUploadEditBlogImage" runat="server" CssClass="npm-input" />
                            <br />Current: <%# Eval("blog_photo") %>
                            <asp:HiddenField ID="hfOldBlogImage" runat="server" Value='<%# Eval("blog_photo") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Link">
                        <ItemTemplate>
                            <a href='<%# Eval("blog_link") %>' target="_blank"><%# Eval("blog_link") %></a>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditBlogLink" runat="server" Text='<%# Bind("blog_link") %>' CssClass="npm-input" />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEditBlog" runat="server" CommandName="Edit" CssClass="npm-button">Edit</asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <div style="display: flex; gap: 6px; flex-wrap: wrap;">
                                <asp:LinkButton ID="lnkUpdateBlog" runat="server" CommandName="Update" CssClass="npm-button">Update</asp:LinkButton>
                                <asp:LinkButton ID="lnkCancelBlog" runat="server" CommandName="Cancel" CssClass="npm-button">Cancel</asp:LinkButton>
                            </div>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDeleteBlog" runat="server" CommandName="Delete" CssClass="npm-button"
                                OnClientClick="return confirm('Are you sure you want to delete this blog?');">
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
