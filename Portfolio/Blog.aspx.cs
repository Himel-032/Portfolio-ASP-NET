using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio
{
    public partial class Blog : System.Web.UI.Page
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadBlogs();
        }

        private void LoadBlogs()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM blogs ORDER BY id DESC", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvBlogs.DataSource = dt;
                gvBlogs.DataBind();
            }
        }

        private bool ValidateInsert()
        {
            if (string.IsNullOrWhiteSpace(txtBlogTitle.Text) ||
                string.IsNullOrWhiteSpace(txtBlogDesc.Text) ||
                ddlBlogCategory.SelectedIndex == 0 ||
                string.IsNullOrWhiteSpace(txtBlogDate.Text) ||
                string.IsNullOrWhiteSpace(txtBlogLink.Text) ||
                !fileBlogImage.HasFile)
            {
                lblBlogMessage.Text = "⚠ All fields including image are required.";
                lblBlogMessage.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            return true;
        }

        protected void btnAddBlog_Click(object sender, EventArgs e)
        {
            if (!ValidateInsert()) return;

            string fileName = "blog" + DateTime.Now.Ticks + Path.GetExtension(fileBlogImage.FileName);
            string savePath = Server.MapPath("~/images/blogs/") + fileName;
            fileBlogImage.SaveAs(savePath);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "INSERT INTO blogs (blog_title, blog_category, blog_photo, blog_description, blog_creation_date, blog_link) " +
                               "VALUES (@title, @category, @photo, @desc, @date, @link)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", txtBlogTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@category", ddlBlogCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@photo", fileName);
                cmd.Parameters.AddWithValue("@desc", txtBlogDesc.Text.Trim());
                cmd.Parameters.AddWithValue("@date", txtBlogDate.Text.Trim());
                cmd.Parameters.AddWithValue("@link", txtBlogLink.Text.Trim());

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            lblBlogMessage.Text = "✅ Blog added successfully!";
            lblBlogMessage.ForeColor = System.Drawing.Color.Green;

            // Clear input fields
            txtBlogTitle.Text = "";
            txtBlogDesc.Text = "";
            ddlBlogCategory.SelectedIndex = 0;
            txtBlogDate.Text = "";
            txtBlogLink.Text = "";
            fileBlogImage.Dispose(); // Clears the file upload selection

            LoadBlogs();
           
        }

        protected void gvBlogs_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBlogs.EditIndex = e.NewEditIndex;
            LoadBlogs();
        }

        protected void gvBlogs_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBlogs.EditIndex = -1;
            LoadBlogs();
        }

        protected void gvBlogs_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvBlogs.Rows[e.RowIndex];
            int id = Convert.ToInt32(gvBlogs.DataKeys[e.RowIndex].Values["id"]);
            string oldPhoto = gvBlogs.DataKeys[e.RowIndex].Values["blog_photo"].ToString();

            string title = ((TextBox)row.FindControl("txtEditBlogTitle")).Text.Trim();
            string desc = ((TextBox)row.FindControl("txtEditBlogDesc")).Text.Trim();
            string date = ((TextBox)row.FindControl("txtEditBlogDate")).Text.Trim();
            string link = ((TextBox)row.FindControl("txtEditBlogLink")).Text.Trim();
            DropDownList ddl = (DropDownList)row.FindControl("ddlEditBlogCategory");
            string category = ddl.SelectedValue;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(desc) ||
                string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(link))
            {
                lblBlogMessage.Text = "⚠ Please fill all fields.";
                lblBlogMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            FileUpload fileUpload = (FileUpload)row.FindControl("fileUploadEditBlogImage");
            string newFileName = oldPhoto;

            if (fileUpload.HasFile)
            {
                newFileName = "blog" + DateTime.Now.Ticks + Path.GetExtension(fileUpload.FileName);
                string savePath = Server.MapPath("~/images/blogs/") + newFileName;
                fileUpload.SaveAs(savePath);

                // delete old file
                string oldPath = Server.MapPath("~/images/blogs/") + oldPhoto;
                if (File.Exists(oldPath)) File.Delete(oldPath);
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "UPDATE blogs SET blog_title=@title, blog_category=@cat, blog_photo=@photo, " +
                               "blog_description=@desc, blog_creation_date=@date, blog_link=@link WHERE id=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@cat", category);
                cmd.Parameters.AddWithValue("@photo", newFileName);
                cmd.Parameters.AddWithValue("@desc", desc);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@link", link);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            gvBlogs.EditIndex = -1;
            LoadBlogs();
            lblBlogMessage.Text = "✅ Blog updated successfully!";
            lblBlogMessage.ForeColor = System.Drawing.Color.Green;
        }

        protected void gvBlogs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvBlogs.DataKeys[e.RowIndex].Values["id"]);
            string photo = gvBlogs.DataKeys[e.RowIndex].Values["blog_photo"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM blogs WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            // delete file
            string filePath = Server.MapPath("~/images/blogs/") + photo;
            if (File.Exists(filePath)) File.Delete(filePath);

            LoadBlogs();
            lblBlogMessage.Text = "🗑 Blog deleted successfully!";
            lblBlogMessage.ForeColor = System.Drawing.Color.Green;
        }

        protected void gvBlogs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState.HasFlag(DataControlRowState.Edit))
            {
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddlEditBlogCategory");
                string currentCat = DataBinder.Eval(e.Row.DataItem, "blog_category").ToString();
                if (ddl.Items.FindByText(currentCat) != null)
                    ddl.SelectedValue = currentCat;
            }
        }
    }
}
