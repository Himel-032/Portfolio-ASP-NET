using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace Portfolio
{
    public partial class NpmSection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadNpmPackages();
            }
        }

        private void LoadNpmPackages()
        {
            string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "SELECT id, npm_url FROM npm_packages ORDER BY id DESC";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        var list = new List<NpmItem>();
                        while (reader.Read())
                        {
                            string url = reader["npm_url"].ToString();
                            string name = GetPackageNameFromUrl(url);
                            string github = GetGitHubUrlFromNpmUrl(url);

                            list.Add(new NpmItem
                            {
                                NpmUrl = url,
                                NpmName = name,
                                GitHubUrl = github
                            });
                        }
                        //rptPackages.DataSource = list;
                        //rptPackages.DataBind();
                    }
                }
            }
        }

        private string GetPackageNameFromUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) return "";
            var parts = url.TrimEnd('/').Split('/');
            return parts[parts.Length - 1];
        }

        private string GetGitHubUrlFromNpmUrl(string npmUrl)
        {
            if (string.IsNullOrEmpty(npmUrl)) return "#";
            string name = GetPackageNameFromUrl(npmUrl);
            return $"https://github.com/{name}";
        }
    }

    public class NpmItem
    {
        public string NpmUrl { get; set; }
        public string NpmName { get; set; }
        public string GitHubUrl { get; set; }
    }
}
