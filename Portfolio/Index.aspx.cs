using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio
{
    public partial class Index : System.Web.UI.Page
    {
        //string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        string connStr = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProjects();
                LoadBlogList();
                LoadPackages();
                LoadEducationTimeline();
                LoadExperienceTimeline();
                LoadSkills();
                LoadProgrammingLanguages();
                LoadLanguages();
                LoadCertificates();
                LoadServices();

            }
        }
        private void LoadServices()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT Id, ServiceTitle, ServiceDescription, IconPath FROM Services ORDER BY Id DESC";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rptServices.DataSource = dt;
                rptServices.DataBind();
            }
        }
        private void LoadCertificates()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT TOP (1000) id, certificate_title, description, image_name, certificate_date FROM Certificates ORDER BY certificate_date DESC", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rptCertificates.DataSource = dt;
                rptCertificates.DataBind();
            }
        }
        private void LoadLanguages()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT TOP (1000) [Id], [Name], [Percentage] FROM [portfolio].[dbo].[Languages] ORDER BY [Id] ASC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    rptLanguages.DataSource = dt;
                    rptLanguages.DataBind();
                }
            }
        }

        private void LoadProgrammingLanguages()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT TOP (1000) [Id], [Name], [Percentage] FROM [portfolio].[dbo].[ProgrammingLanguages] ORDER BY [Id] ASC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    rptProgLanguages.DataSource = dt;
                    rptProgLanguages.DataBind();
                }
            }
        }
        private void LoadSkills()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT TOP (1000) [Id], [Name], [Percentage] FROM [portfolio].[dbo].[Skills] ORDER BY [Id] ASC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    rptSkills.DataSource = dt;
                    rptSkills.DataBind();
                }
            }
        }
        private void LoadExperienceTimeline()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT TOP (1000) [Id], [Title], [Duration], [Description] FROM [portfolio].[dbo].[Experience] ORDER BY [Id] DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    rptExperience.DataSource = dt;
                    rptExperience.DataBind();
                }
            }
        }
        private void LoadEducationTimeline()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT TOP (1000) [Id], [Title], [Duration], [Description] FROM [portfolio].[dbo].[Education] ORDER BY [Id] DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    rptEducation.DataSource = dt;
                    rptEducation.DataBind();
                }
            }
        }
        private void LoadBlogList()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM blogs ORDER BY id DESC", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rptBlogs.DataSource = dt;
                rptBlogs.DataBind();
            }
        }

        private void LoadProjects()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT name, category, image_name, git_repo_url FROM projects";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    rptProjects.DataSource = dr;
                    rptProjects.DataBind();
                }
            }
        }






        private void LoadPackages()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT npm_url FROM npm_packages ORDER BY id DESC";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rptPackages.DataSource = dt;
                rptPackages.DataBind();
            }
        }

        // Extract package name from NPM URL
        public string GetPackageName(object packageLink)
        {
            if (packageLink == null) return "";
            string link = packageLink.ToString();
            if (!link.Contains("npmjs.com")) return "";
            string[] parts = link.Split('/');
            return parts[parts.Length - 1];
        }

        // Fetch package description from NPM registry
        public string GetPackageDescription(object packageLink)
        {
            string packageName = GetPackageName(packageLink);
            if (string.IsNullOrEmpty(packageName)) return "Description not available.";

            try
            {
                string apiUrl = $"https://registry.npmjs.org/{packageName}";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
                request.Method = "GET";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string json = reader.ReadToEnd();
                    var serializer = new JavaScriptSerializer();
                    dynamic data = serializer.Deserialize<object>(json);

                    string latest = data["dist-tags"]["latest"];
                    string description = data["versions"][latest]["description"];
                    return description ?? "Description not available.";
                }
            }
            catch
            {
                return "Description not available.";
            }
        }

        // Fetch GitHub repository link from NPM registry
        public string GetGithubRepoFromNpm(object packageLink)
        {
            string packageName = GetPackageName(packageLink);
            if (string.IsNullOrEmpty(packageName)) return "#";

            try
            {
                string apiUrl = $"https://registry.npmjs.org/{packageName}";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
                request.Method = "GET";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string json = reader.ReadToEnd();
                    var serializer = new JavaScriptSerializer();
                    dynamic data = serializer.Deserialize<object>(json);

                    string repoUrl = data["repository"]?["url"];
                    if (string.IsNullOrEmpty(repoUrl)) return "#";

                    // Remove git+ prefix and .git suffix
                    repoUrl = repoUrl.Replace("git+", "").Replace(".git", "");
                    return repoUrl;
                }
            }
            catch
            {
                return "#";
            }
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string fullname = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string message = txtMessage.Text.Trim();

            // Check if any field is empty
            if (string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(message))
            {
                lblMsg.Text = "Please fill up all fields!";
                return;
            }

            // Use SQL Server connection string
            string connStr = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO contacts (fullname, email, message) VALUES (@fullname, @email, @message)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fullname", fullname);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@message", message);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            lblMsg.Text = "Message sent successfully!";
                            txtFullName.Text = "";
                            txtEmail.Text = "";
                            txtMessage.Text = "";
                        }
                        else
                        {
                            lblMsg.Text = "Failed to send message!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMsg.Text = "Error: " + ex.Message;
                }
            }
        }
    }
}