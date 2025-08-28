using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;


namespace Portfolio
{
    public partial class Certificates : Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadCertificates();
        }

        private void LoadCertificates()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Certificates ORDER BY id DESC", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvCertificates.DataSource = dt;
                gvCertificates.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string desc = txtDescription.Text.Trim();
            string date = txtDate.Text.Trim();
            string fileName = "";

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(date) || !fileUploadImage.HasFile || string.IsNullOrEmpty(desc) )
            {
                lblMessage.Text = "All fields are required!";
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    string insertQuery = "INSERT INTO Certificates (certificate_title, description, image_name, certificate_date) OUTPUT INSERTED.id VALUES (@title,@desc,@image,@date)";
                    int newId;

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@desc", desc);
                        cmd.Parameters.AddWithValue("@image", "");
                        cmd.Parameters.AddWithValue("@date", date);
                        newId = (int)cmd.ExecuteScalar();
                    }

                    // Save image
                    fileName = "certificate_" + DateTime.Now.Ticks + Path.GetExtension(fileUploadImage.FileName);
                    string folder = Server.MapPath("~/images/certificates/");
                    if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                    fileUploadImage.SaveAs(Path.Combine(folder, fileName));

                    string updateQuery = "UPDATE Certificates SET image_name=@image WHERE id=@id";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@image", fileName);
                        cmd.Parameters.AddWithValue("@id", newId);
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    lblMessage.Text = "Certificate added successfully!";
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }

            txtTitle.Text = txtDescription.Text = txtDate.Text = "";
            LoadCertificates();
            Response.Redirect(Request.RawUrl);
        }

        protected void gvCertificates_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCertificates.EditIndex = e.NewEditIndex;
            LoadCertificates();
        }

        protected void gvCertificates_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCertificates.EditIndex = -1;
            LoadCertificates();
        }

        protected void gvCertificates_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvCertificates.DataKeys[e.RowIndex]["id"]);
            string oldImage = gvCertificates.DataKeys[e.RowIndex]["image_name"].ToString();

            TextBox txtTitleEdit = (TextBox)gvCertificates.Rows[e.RowIndex].FindControl("txtEditTitle");
            TextBox txtDescEdit = (TextBox)gvCertificates.Rows[e.RowIndex].FindControl("txtEditDescription");
            TextBox txtDateEdit = (TextBox)gvCertificates.Rows[e.RowIndex].FindControl("txtEditDate");
            FileUpload fileUploadEdit = (FileUpload)gvCertificates.Rows[e.RowIndex].FindControl("fileUploadEditImage");

            string title = txtTitleEdit.Text.Trim();
            string desc = txtDescEdit.Text.Trim();
            string date = txtDateEdit.Text.Trim();
            string newImage = oldImage;

            if (fileUploadEdit.HasFile)
            {
                // Delete old image
                string oldPath = Server.MapPath("~/images/certificates/" + oldImage);
                if (File.Exists(oldPath)) File.Delete(oldPath);

                newImage = "certificate_" + DateTime.Now.Ticks + Path.GetExtension(fileUploadEdit.FileName);
                fileUploadEdit.SaveAs(Server.MapPath("~/images/certificates/" + newImage));
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "UPDATE Certificates SET certificate_title=@title, description=@desc, image_name=@image, certificate_date=@date WHERE id=@id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@desc", desc);
                    cmd.Parameters.AddWithValue("@image", newImage);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }

            gvCertificates.EditIndex = -1;
            LoadCertificates();
        }

        protected void gvCertificates_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvCertificates.DataKeys[e.RowIndex]["id"]);
            string oldImage = gvCertificates.DataKeys[e.RowIndex]["image_name"].ToString();

            if (!string.IsNullOrEmpty(oldImage))
            {
                string oldPath = Server.MapPath("~/images/certificates/" + oldImage);
                if (File.Exists(oldPath)) File.Delete(oldPath);
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "DELETE FROM Certificates WHERE id=@id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadCertificates();
        }
        protected void gvCertificates_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex == gvCertificates.EditIndex)
            {
                // Bind the CalendarExtender for edit row
                TextBox txtDateEdit = (TextBox)e.Row.FindControl("txtEditDate");
                CalendarExtender ceEditDate = (CalendarExtender)e.Row.FindControl("ceEditDate");

                if (txtDateEdit != null && ceEditDate != null)
                {
                    ceEditDate.TargetControlID = txtDateEdit.ID;
                    ceEditDate.Format = "yyyy-MM-dd";
                }
            }
        }

    }
}
