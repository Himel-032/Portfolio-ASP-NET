using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPackages();
            }
        }

        
        

        private void LoadPackages()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT npm_url FROM npm_packages ORDER BY id DESC";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
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

            // Insert into database
            string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO contacts (fullname, email, message) VALUES (@fullname, @email, @message)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
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