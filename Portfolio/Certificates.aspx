<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Certificates.aspx.cs" Inherits="Portfolio.Certificates" MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="main-content">
        <h2>Manage Certificates</h2>

        <!-- Add Certificate -->
        <div class="content-panel">
            <h3>Add New Certificate</h3>
            <br />
            <asp:Label ID="lblTitle" runat="server" Text="Certificate Title:" CssClass="npm-label"></asp:Label><br />
            <asp:TextBox ID="txtTitle" runat="server" CssClass="npm-input" Placeholder="Enter title"></asp:TextBox><br /><br />

            <asp:Label ID="lblDescription" runat="server" Text="Description:" CssClass="npm-label"></asp:Label><br />
            <asp:TextBox ID="txtDescription" runat="server" CssClass="npm-input" TextMode="MultiLine" Rows="3"></asp:TextBox><br /><br />

            <asp:Label ID="lblDate" runat="server" Text="Certificate Date:" CssClass="npm-label"></asp:Label><br />
            <asp:TextBox ID="txtDate" runat="server" CssClass="npm-input" Placeholder="Select Date"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="ceDate" runat="server" TargetControlID="txtDate" Format="yyyy-MM-dd"></ajaxToolkit:CalendarExtender>
            <br /><br />

            <asp:Label ID="lblImage" runat="server" Text="Certificate Image:" CssClass="npm-label"></asp:Label><br />
            <asp:FileUpload ID="fileUploadImage" runat="server" CssClass="npm-input" /><br /><br />

            <asp:Button ID="btnAdd" runat="server" Text="Add Certificate" CssClass="npm-button" OnClick="btnAdd_Click" /><br />
            <asp:Label ID="lblMessage" runat="server" CssClass="npm-message"></asp:Label>
        </div>

        <!-- Certificates Table -->
        <div class="content-panel" style="margin-top:20px;">
            <h3>All Certificates</h3>
            <asp:GridView ID="gvCertificates" runat="server" AutoGenerateColumns="False" CssClass="npm-table"
                DataKeyNames="id,image_name"
                OnRowEditing="gvCertificates_RowEditing"
                OnRowCancelingEdit="gvCertificates_RowCancelingEdit"
                OnRowUpdating="gvCertificates_RowUpdating"
                OnRowDeleting="gvCertificates_RowDeleting"
                OnRowDataBound="gvCertificates_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Title">
                        <ItemTemplate>
                            <%# Eval("certificate_title") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditTitle" runat="server" Text='<%# Bind("certificate_title") %>' CssClass="npm-input" />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <%# Eval("description") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditDescription" runat="server" Text='<%# Bind("description") %>' CssClass="npm-input" TextMode="MultiLine" Rows="2" />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <%# Eval("certificate_date", "{0:yyyy-MM-dd}") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditDate" runat="server" Text='<%# Bind("certificate_date","{0:yyyy-MM-dd}") %>' CssClass="npm-input" />
                            <ajaxToolkit:CalendarExtender ID="ceEditDate" runat="server" TargetControlID="txtEditDate" Format="yyyy-MM-dd"></ajaxToolkit:CalendarExtender>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <img src='<%# ResolveUrl("~/images/certificates/" + Eval("image_name")) %>' alt="Certificate Image" width="80" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:FileUpload ID="fileUploadEditImage" runat="server" CssClass="npm-input" /><br />
                            Current: <%# Eval("image_name") %>
                            <asp:HiddenField ID="hfOldImage" runat="server" Value='<%# Eval("image_name") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" CssClass="npm-button">Edit</asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <div style="display: flex; gap: 10px; flex-wrap: wrap;" >
                            <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" CssClass="npm-button">Update</asp:LinkButton>
                            <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel" CssClass="npm-button">Cancel</asp:LinkButton>
                                </div>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CssClass="npm-button" OnClientClick="return confirm('Are you sure?');">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
