using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio
{
    public partial class Project : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProjects();
            }
        }

        private void LoadProjects()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM projects ORDER BY id DESC", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvProjects.DataSource = dt;
                gvProjects.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string category = ddlCategory.SelectedValue;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(category))
            {
                return;
            }

            // Determine image name based on category
            string imageName = "";

            if (category == "Web Design")
                imageName = "web_design.jpeg";
            else if (category == "Applications")
                imageName = "application.jpeg";
            else if (category == "Web Development")
                imageName = "web_development.jpeg";
            else
                imageName = "project_default.jpeg";


            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO projects (name, category, image_name) VALUES (@name, @category, @imageName)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@category", ddlCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@imageName", imageName);
                cmd.ExecuteNonQuery();
            }
            txtName.Text = "";
            txtImage.Text = "";
            LoadProjects();
        }

        protected void gvProjects_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProjects.EditIndex = e.NewEditIndex;
            LoadProjects();
        }

        protected void gvProjects_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProjects.EditIndex = -1;
            LoadProjects();
        }

        protected void gvProjects_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvProjects.DataKeys[e.RowIndex].Value);

            string name = ((TextBox)gvProjects.Rows[e.RowIndex].FindControl("txtEditName")).Text;
            string category = ((TextBox)gvProjects.Rows[e.RowIndex].FindControl("txtEditCategory")).Text;
            string image = ((TextBox)gvProjects.Rows[e.RowIndex].FindControl("txtEditImage")).Text;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "UPDATE projects SET name=@name, category=@category, image_name=@image WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@image", image);
                cmd.ExecuteNonQuery();
            }

            gvProjects.EditIndex = -1;
            LoadProjects();
        }

        protected void gvProjects_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvProjects.DataKeys[e.RowIndex].Value);

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "DELETE FROM projects WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            LoadProjects();
        }
    }
}