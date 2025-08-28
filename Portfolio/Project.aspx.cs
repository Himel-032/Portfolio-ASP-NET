
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio
{
    public partial class Project : Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProjects();
            }
        }
      
        protected void gvProjects_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Check if the row is in edit mode
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex == gvProjects.EditIndex)
            {
                // Get the current data item
                DataRowView drv = e.Row.DataItem as DataRowView;

                // Find the DropDownList and set its selected value
                DropDownList ddlEditCategory = (DropDownList)e.Row.FindControl("ddlEditCategory");
                if (ddlEditCategory != null && drv != null)
                {
                    string category = drv["category"].ToString();
                    ddlEditCategory.SelectedValue = category;
                }

                // Find the HiddenField and set its value
                HiddenField hfOldImage = (HiddenField)e.Row.FindControl("hfOldImage");
                if (hfOldImage != null && drv != null)
                {
                    // Set the HiddenField value to the current image_name from the database
                    hfOldImage.Value = drv["image_name"].ToString();
                }
            }
        }


        private void LoadProjects()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM projects ORDER BY id DESC", conn);
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
            string githubLink = txtGithub.Text.Trim();
            string fileName = "";
            int newProjectId = -1; // Initialize with a default value

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(category) || !fileUploadImage.HasFile)
            {
                lblMessage.Text = "All fields are required!";
                return;
            }

            // Use a transaction to ensure atomicity of the operation
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Step 1: Insert project and get the new ID
                        string insertQuery = "INSERT INTO projects (name, category, image_name, git_repo_url) OUTPUT INSERTED.id VALUES (@name, @category, @image, @github)";

                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@category", category);
                            cmd.Parameters.AddWithValue("@image", ""); // Temporary placeholder
                            cmd.Parameters.AddWithValue("@github", githubLink);
                            newProjectId = (int)cmd.ExecuteScalar();
                        }

                        // Step 2: Save uploaded file to ~/images/projects/ using the new ID
                        fileName = "project_" + newProjectId + Path.GetExtension(fileUploadImage.FileName);
                        string folderPath = Server.MapPath("~/images/projects/");
                        string savePath = Path.Combine(folderPath, fileName);
                        fileUploadImage.SaveAs(savePath);

                        // Step 3: Update project record with the actual image name
                        string updateQuery = "UPDATE projects SET image_name = @image WHERE id = @id";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@image", fileName);
                            cmd.Parameters.AddWithValue("@id", newProjectId);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        lblMessage.Text = "Project added successfully!";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        lblMessage.Text = "Error adding project: " + ex.Message;
                        // Optional: Clean up the file if it was saved before the error
                        if (!string.IsNullOrEmpty(fileName))
                        {
                            string filePath = Server.MapPath("~/images/projects/" + fileName);
                            if (File.Exists(filePath)) File.Delete(filePath);
                        }
                    }
                }
            }

            // Clear form fields and refresh grid
            txtName.Text = "";
            ddlCategory.SelectedIndex = 0;
            txtGithub.Text = "";
            LoadProjects();
            // At the end of btnAdd_Click, after clearing controls:
            Response.Redirect(Request.RawUrl);

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
            // Retrieve the 'id' and 'image_name' directly from the DataKeys collection
            int id = Convert.ToInt32(gvProjects.DataKeys[e.RowIndex]["id"]);
            string oldImage = gvProjects.DataKeys[e.RowIndex]["image_name"].ToString();

            // The rest of your code is correct
            TextBox txtEditName = (TextBox)gvProjects.Rows[e.RowIndex].FindControl("txtEditName");
            DropDownList ddlEditCategory = (DropDownList)gvProjects.Rows[e.RowIndex].FindControl("ddlEditCategory");
            TextBox txtEditGithub = (TextBox)gvProjects.Rows[e.RowIndex].FindControl("txtEditGithub");
            FileUpload fileUploadEdit = (FileUpload)gvProjects.Rows[e.RowIndex].FindControl("fileUploadEditImage");

            string name = txtEditName.Text.Trim();
            string category = ddlEditCategory.SelectedValue;
            string githubLink = txtEditGithub.Text.Trim();
            string newImageName = oldImage; // Default to old image name

            // Check if a new file was uploaded
            
            if (fileUploadEdit.HasFile)
            {
                // Delete the old file if it exists
                if (!string.IsNullOrEmpty(oldImage))
                {
                    string oldPath = Server.MapPath("~/images/projects/" + oldImage);
                    if (File.Exists(oldPath))
                    {
                        File.Delete(oldPath);
                    }
                }

                // Save the new file with a NEW name
                string extension = Path.GetExtension(fileUploadEdit.FileName);
                newImageName = "project_" + id + "_" + DateTime.Now.Ticks + extension; // unique name
                fileUploadEdit.SaveAs(Server.MapPath("~/images/projects/" + newImageName));
            }


            // Update the database record
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "UPDATE projects SET name=@name, category=@category, image_name=@image, git_repo_url=@github WHERE id=@id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@image", newImageName);
                    cmd.Parameters.AddWithValue("@github", githubLink);
                    cmd.ExecuteNonQuery();
                }
            }

            // Exit edit mode and refresh the grid
            gvProjects.EditIndex = -1;
            LoadProjects();
        }


        protected void gvProjects_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvProjects.DataKeys[e.RowIndex].Value);

            // Delete file from server if exists
            string fileName = "";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string selectQuery = "SELECT image_name FROM projects WHERE id=@id";
                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    object result = cmd.ExecuteScalar();
                    if (result != null) fileName = result.ToString();
                }

                if (!string.IsNullOrEmpty(fileName))
                {
                    string path = Server.MapPath("~/images/projects/" + fileName);
                    if (File.Exists(path)) File.Delete(path);
                }

                // Delete record from DB
                string deleteQuery = "DELETE FROM projects WHERE id=@id";
                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadProjects();
        }
    }
}
