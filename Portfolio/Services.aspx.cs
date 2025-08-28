using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio
{
    public partial class Services : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadServices();
            }
        }

        private void LoadServices()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, ServiceTitle, ServiceDescription, IconPath FROM Services", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvServices.DataSource = dt;
                gvServices.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // Trim and get input values
            string title = txtTitle.Text.Trim();
            string desc = txtDescription.Text.Trim();

            // Check if any field is empty or no file uploaded
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(desc) || !fuIcon.HasFile)
            {
                lblMessage.Text = "All fields are required!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Validate file extension
            string ext = Path.GetExtension(fuIcon.FileName).ToLower();
            if (ext != ".svg")
            {
                lblMessage.Text = "Only .svg files are allowed!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string fileName = "~/images/services/" + Path.GetFileNameWithoutExtension(fuIcon.FileName) + "_" + DateTime.Now.Ticks + ext;
            fuIcon.SaveAs(Server.MapPath(fileName));

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Services (ServiceTitle, ServiceDescription, IconPath) VALUES (@Title, @Desc, @Icon)", conn);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Desc", desc);
                cmd.Parameters.AddWithValue("@Icon", fileName);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            // Clear fields and reload GridView
            txtTitle.Text = "";
            txtDescription.Text = "";
            lblMessage.Text = "Service added successfully!";
            lblMessage.ForeColor = System.Drawing.Color.Green;
            LoadServices();
            Response.Redirect(Request.RawUrl);
        }

        protected void gvServices_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvServices.EditIndex = e.NewEditIndex;
            LoadServices();
        }

        protected void gvServices_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvServices.EditIndex = -1;
            LoadServices();
        }

        protected void gvServices_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvServices.Rows[e.RowIndex];
            int id = Convert.ToInt32(gvServices.DataKeys[e.RowIndex].Value);

            string title = ((TextBox)row.FindControl("txtEditTitle")).Text;
            string desc = ((TextBox)row.FindControl("txtEditDescription")).Text;
            FileUpload fuEdit = (FileUpload)row.FindControl("fuEditIcon");

            string fileName = null;
            if (fuEdit.HasFile)
            {
                string ext = Path.GetExtension(fuEdit.FileName);
                if (ext.ToLower() == ".svg")
                {
                    fileName = "~/images/services/" + Path.GetFileNameWithoutExtension(fuEdit.FileName) + "_" + DateTime.Now.Ticks + ext;
                    fuEdit.SaveAs(Server.MapPath(fileName));

                    // Delete old file
                    string oldFile = GetOldIconPath(id);
                    if (!string.IsNullOrEmpty(oldFile) && File.Exists(Server.MapPath(oldFile)))
                        File.Delete(Server.MapPath(oldFile));
                }
            }
            else
            {
                fileName = GetOldIconPath(id); // keep old icon if not updated
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Services SET ServiceTitle=@Title, ServiceDescription=@Desc, IconPath=@Icon WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Desc", desc);
                cmd.Parameters.AddWithValue("@Icon", fileName);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            gvServices.EditIndex = -1;
            LoadServices();
        }

        protected void gvServices_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvServices.DataKeys[e.RowIndex].Value);

            // Delete old file
            string oldFile = GetOldIconPath(id);
            if (!string.IsNullOrEmpty(oldFile) && File.Exists(Server.MapPath(oldFile)))
                File.Delete(Server.MapPath(oldFile));

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Services WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadServices();
        }

        private string GetOldIconPath(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT IconPath FROM Services WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }
    }
}