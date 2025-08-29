using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Xml.Linq;

namespace Portfolio
{
    public partial class Admin : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProfile();
            }
        }

        private void LoadProfile()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Profile ORDER BY Id DESC", conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtName.Text = dr["Name"].ToString();
                    txtEmail.Text = dr["Email"].ToString();
                    txtPhone.Text = dr["Phone"].ToString();
                    txtLocation.Text = dr["Location"].ToString();
                    txtBirthDate.Text = dr["BirthDate"].ToString();
                    txtFacebook.Text = dr["Facebook"].ToString();
                    txtTwitter.Text = dr["Twitter"].ToString();
                    txtInstagram.Text = dr["Instagram"].ToString();

                    string imgPath = dr["ImagePath"].ToString();
                    if (!string.IsNullOrEmpty(imgPath))
                        imgPreview.ImageUrl = imgPath;
                }
                dr.Close();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
            {
                lblMessage.Text = "Name and Email required!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string phone = txtPhone.Text.Trim();
            string location = txtLocation.Text.Trim();
            string birthDate = txtBirthDate.Text.Trim();
            string fb = txtFacebook.Text.Trim();
            string tw = txtTwitter.Text.Trim();
            string ig = txtInstagram.Text.Trim();

            string fileName = null;
            if (fuImage.HasFile)
            {
                string ext = Path.GetExtension(fuImage.FileName);
                fileName = "~/images/profile/hero_" + DateTime.Now.Ticks + ext;
                fuImage.SaveAs(Server.MapPath(fileName));
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM Profile", conn);
                int count = (int)cmdCheck.ExecuteScalar();

                SqlCommand cmd;
                if (count == 0)
                {
                    cmd = new SqlCommand(@"INSERT INTO Profile 
                        (Name, Email, Phone, Location, BirthDate, Facebook, Twitter, Instagram, ImagePath)
                        VALUES (@Name,@Email,@Phone,@Location,@BirthDate,@Facebook,@Twitter,@Instagram,@Image)", conn);
                }
                else
                {
                    // get existing Id
                    SqlCommand cmdId = new SqlCommand("SELECT TOP 1 Id, ImagePath FROM Profile ORDER BY Id DESC", conn);
                    SqlDataReader dr = cmdId.ExecuteReader();
                    dr.Read();
                    int id = Convert.ToInt32(dr["Id"]);
                    string oldImage = dr["ImagePath"].ToString();
                    dr.Close();

                    if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(oldImage) && File.Exists(Server.MapPath(oldImage)))
                        File.Delete(Server.MapPath(oldImage));

                    cmd = new SqlCommand(@"UPDATE Profile SET 
                        Name=@Name, Email=@Email, Phone=@Phone, Location=@Location, BirthDate=@BirthDate,
                        Facebook=@Facebook, Twitter=@Twitter, Instagram=@Instagram, ImagePath=@Image
                        WHERE Id=@Id", conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                }

                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Location", location);
                cmd.Parameters.AddWithValue("@BirthDate", birthDate);
                cmd.Parameters.AddWithValue("@Facebook", fb);
                cmd.Parameters.AddWithValue("@Twitter", tw);
                cmd.Parameters.AddWithValue("@Instagram", ig);
                cmd.Parameters.AddWithValue("@Image", fileName ?? imgPreview.ImageUrl);

                cmd.ExecuteNonQuery();
            }

            lblMessage.Text = "Profile saved/updated!";
            lblMessage.ForeColor = System.Drawing.Color.Green;
            LoadProfile();
        }
    }
}
