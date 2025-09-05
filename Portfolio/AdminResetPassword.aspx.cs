using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio
{
    public partial class AdminResetPassword : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (Session["ResetAdminID"] == null)
            {
               
                Response.Redirect("AdminForgetPassword.aspx");
            }
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            // Validation
            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                lblMessage.Text = "Both password fields are required!";
                lblMessage.CssClass = "message error";
                return;
            }

            if (newPassword.Length < 4)
            {
                lblMessage.Text = "Password must be at least 4 characters long!";
                lblMessage.CssClass = "message error";
                return;
            }

            if (newPassword != confirmPassword)
            {
                lblMessage.Text = "Passwords do not match!";
                lblMessage.CssClass = "message error";
                return;
            }

          
            int adminId = Convert.ToInt32(Session["ResetAdminID"]);
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                string query = "UPDATE Admin SET password=@Password WHERE id=@AdminID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Password", newPassword);
                cmd.Parameters.AddWithValue("@AdminID", adminId);
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    lblMessage.Text = "Password has been reset successfully!";
                    lblMessage.CssClass = "message success";

                    
                    Session.Remove("ResetAdminID");
                    Session.Remove("ResetAdminEmail");

                    
                    Response.AddHeader("REFRESH", "3;URL=AdminLogin.aspx");
                }
                else
                {
                    lblMessage.Text = "Something went wrong. Try again!";
                    lblMessage.CssClass = "message error";
                }
            }
        }
    }
}