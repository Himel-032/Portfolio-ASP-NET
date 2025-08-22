using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace Portfolio
{
    public partial class Npm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadNpmUrls();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string npmUrl = txtNpmUrl.Text.Trim();
            if (string.IsNullOrEmpty(npmUrl))
            {
                lblMessage.Text = "Please enter a URL.";
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            if (ViewState["EditID"] != null)
            {
                // Update mode
                int id = (int)ViewState["EditID"];
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "UPDATE npm_packages SET npm_url=@npmUrl WHERE id=@id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@npmUrl", npmUrl);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                lblMessage.Text = "Updated successfully!";
                ViewState["EditID"] = null;
                btnSubmit.Text = "Submit";
            }
            else
            {
                // Insert mode
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "INSERT INTO npm_packages (npm_url) VALUES (@npmUrl)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@npmUrl", npmUrl);
                        cmd.ExecuteNonQuery();
                    }
                }
                lblMessage.Text = "URL saved successfully!";
            }

            txtNpmUrl.Text = "";
            LoadNpmUrls();
        }


        private void LoadNpmUrls()
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT id, npm_url, created_at FROM npm_packages ORDER BY id DESC";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        gvNpmUrls.DataSource = dt;
                        gvNpmUrls.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error loading URLs: " + ex.Message;
            }
        }

        protected void gvNpmUrls_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "DeleteRow")
            {
                try
                {
                    string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        conn.Open();
                        string query = "DELETE FROM npm_packages WHERE id=@id";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    lblMessage.Text = "Deleted successfully!";
                    LoadNpmUrls();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error deleting URL: " + ex.Message;
                }
            }
            else if (e.CommandName == "EditRow")
            {
                // Load URL into textbox for editing
                string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT npm_url FROM npm_packages WHERE id=@id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            txtNpmUrl.Text = result.ToString();
                            btnSubmit.Text = "Update";
                            ViewState["EditID"] = id;
                        }
                    }
                }
            }
        }

        protected void btnSubmit_Click_Update(object sender, EventArgs e)
        {
            if (ViewState["EditID"] != null)
            {
                int id = (int)ViewState["EditID"];
                string npmUrl = txtNpmUrl.Text.Trim();
                if (!string.IsNullOrEmpty(npmUrl))
                {
                    string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        conn.Open();
                        string query = "UPDATE npm_packages SET npm_url=@npmUrl WHERE id=@id";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@npmUrl", npmUrl);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    lblMessage.Text = "Updated successfully!";
                    txtNpmUrl.Text = "";
                    btnSubmit.Text = "Submit";
                    ViewState["EditID"] = null;
                    LoadNpmUrls();
                }
            }
        }
    }
}
