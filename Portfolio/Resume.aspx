<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Resume.aspx.cs" Inherits="Portfolio.Resume" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">




    <!-- ScriptManager for partial postback -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main-content">
    <!-- Navbar -->
    <div class="resume-navbar">
        <a href="#education">Education</a>
        <a href="#experience">Experience</a>
        <a href="#skills">Skills</a>
        <a href="#programming">Programming Languages</a>
        <a href="#languages">Languages</a>
    </div>

    <!-- Education Section -->
        <h2>Manage Resume</h2>
        <div class="content-panel">
        
        <br />
    <asp:UpdatePanel ID="upEducation" runat="server">
        <ContentTemplate>
            <div id="education" class="section">
                <h2>Education</h2>
                <asp:TextBox ID="txtEduTitle" runat="server" CssClass="npm-input" Placeholder="Enter Education Title"></asp:TextBox><br /><br />
                <asp:TextBox ID="txtEduDuration" runat="server" CssClass="npm-input" Placeholder="Enter Duration"></asp:TextBox><br /><br />
                <asp:TextBox ID="txtEduDesc" runat="server" CssClass="npm-input" TextMode="MultiLine" Placeholder="Enter Description"></asp:TextBox><br /><br />
                <asp:Button ID="btnAddEducation" runat="server" Text="Add Education" CssClass="npm-button" OnClick="btnAddEducation_Click" /><br />
                <asp:Label ID="lblEduMessage" runat="server" CssClass="npm-message"></asp:Label><br /><br />

                <asp:GridView ID="gvEducation" runat="server" AutoGenerateColumns="False" CssClass="npm-table"
                    DataKeyNames="Id" OnRowEditing="gvEducation_RowEditing"
                    OnRowUpdating="gvEducation_RowUpdating" OnRowCancelingEdit="gvEducation_RowCancelingEdit"
                    OnRowDeleting="gvEducation_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="Title" />
                        <asp:BoundField DataField="Duration" HeaderText="Duration" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <br />

    <!-- Experience Section -->
    <asp:UpdatePanel ID="upExperience" runat="server">
        <ContentTemplate>
            <div id="experience" class="section">
                <h2>Experience</h2>
                <asp:TextBox ID="txtExpTitle" runat="server" CssClass="npm-input" Placeholder="Enter Experience Title"></asp:TextBox><br /><br />
                <asp:TextBox ID="txtExpDuration" runat="server" CssClass="npm-input" Placeholder="Enter Duration"></asp:TextBox><br /><br />
                <asp:TextBox ID="txtExpDesc" runat="server" CssClass="npm-input" TextMode="MultiLine" Placeholder="Enter Description"></asp:TextBox><br /><br />
                <asp:Button ID="btnAddExperience" runat="server" Text="Add Experience" CssClass="npm-button" OnClick="btnAddExperience_Click" /><br />
                 <asp:Label ID="lblExpMsg" runat="server" CssClass="npm-message"></asp:Label><br /><br />

                <asp:GridView ID="gvExperience" runat="server" AutoGenerateColumns="False" CssClass="npm-table"
                    DataKeyNames="Id" OnRowEditing="gvExperience_RowEditing"
                    OnRowUpdating="gvExperience_RowUpdating" OnRowCancelingEdit="gvExperience_RowCancelingEdit"
                    OnRowDeleting="gvExperience_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="Title" />
                        <asp:BoundField DataField="Duration" HeaderText="Duration" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <br />

    <!-- Skills Section -->
    <asp:UpdatePanel ID="upSkills" runat="server">
        <ContentTemplate>
            <div id="skills" class="section">
                <h2>Skills</h2>
                <asp:TextBox ID="txtSkillName" runat="server" CssClass="npm-input" Placeholder="Enter Skill Name"></asp:TextBox><br /><br />
                <asp:TextBox ID="txtSkillPercent" runat="server" CssClass="npm-input" Placeholder="Enter Skill Percentage"></asp:TextBox><br /><br />
                <asp:Button ID="btnAddSkill" runat="server" Text="Add Skill" CssClass="npm-button" OnClick="btnAddSkill_Click" /><br />
                <asp:Label ID="lblSkillMsg" runat="server" CssClass="npm-message"></asp:Label><br /><br />

                <asp:GridView ID="gvSkills" runat="server" AutoGenerateColumns="False" CssClass="npm-table"
                    DataKeyNames="Id" OnRowEditing="gvSkills_RowEditing"
                    OnRowUpdating="gvSkills_RowUpdating" OnRowCancelingEdit="gvSkills_RowCancelingEdit"
                    OnRowDeleting="gvSkills_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Skill" />
                        <asp:BoundField DataField="Percentage" HeaderText="Percentage" />
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <br />

    <!-- Programming Languages Section -->
    <asp:UpdatePanel ID="upProgramming" runat="server">
        <ContentTemplate>
            <div id="programming" class="section">
                <h2>Programming Languages</h2>
                <asp:TextBox ID="txtProgName" runat="server" CssClass="npm-input" Placeholder="Enter Language Name"></asp:TextBox><br /><br />
                <asp:TextBox ID="txtProgPercent" runat="server" CssClass="npm-input" Placeholder="Enter Percentage"></asp:TextBox><br /><br />
                <asp:Button ID="btnAddProgramming" runat="server" Text="Add Programming Language" CssClass="npm-button" OnClick="btnAddProgramming_Click" /><br />
                 <asp:Label ID="lblProgMsg" runat="server" CssClass="npm-message"></asp:Label><br /><br />

                <asp:GridView ID="gvProgramming" runat="server" AutoGenerateColumns="False" CssClass="npm-table"
                    DataKeyNames="Id" OnRowEditing="gvProgramming_RowEditing"
                    OnRowUpdating="gvProgramming_RowUpdating" OnRowCancelingEdit="gvProgramming_RowCancelingEdit"
                    OnRowDeleting="gvProgramming_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Language" />
                        <asp:BoundField DataField="Percentage" HeaderText="Percentage" />
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <br />

    <!-- Languages Section -->
    <asp:UpdatePanel ID="upLanguages" runat="server">
        <ContentTemplate>
            <div id="languages" class="section">
                <h2>Languages</h2>
                <asp:TextBox ID="txtLangName" runat="server" CssClass="npm-input" Placeholder="Enter Language Name"></asp:TextBox><br /><br />
                <asp:TextBox ID="txtLangPercent" runat="server" CssClass="npm-input" Placeholder="Enter Percentage"></asp:TextBox><br /><br />
                <asp:Button ID="btnAddLanguage" runat="server" Text="Add Language" CssClass="npm-button" OnClick="btnAddLanguage_Click" /><br />
                <asp:Label ID="lblLangMsg" runat="server" CssClass="npm-message"></asp:Label><br /><br />

                <asp:GridView ID="gvLanguages" runat="server" AutoGenerateColumns="False" CssClass="npm-table"
                    DataKeyNames="Id" OnRowEditing="gvLanguages_RowEditing"
                    OnRowUpdating="gvLanguages_RowUpdating" OnRowCancelingEdit="gvLanguages_RowCancelingEdit"
                    OnRowDeleting="gvLanguages_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Language" />
                        <asp:BoundField DataField="Percentage" HeaderText="Percentage" />
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

        </div>
    </div>

</asp:Content>
