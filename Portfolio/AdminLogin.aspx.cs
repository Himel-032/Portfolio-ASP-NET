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
    public partial class AdminLogin : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            if (!IsPostBack)
            {
                
                if (Request.Cookies["AdminCookie"] != null)
                {
                    txtEmail.Text = Request.Cookies["AdminCookie"]["AdminEmail"];
                    chkRememberMe.Checked = true;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim(); 

            
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                string query = "SELECT id, password FROM Admin WHERE email=@Email";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", email);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string storedPassword = reader["password"].ToString();
                    int adminId = Convert.ToInt32(reader["id"]);

                    if (password == storedPassword) 
                    {
                        
                        Session["AdminID"] = adminId;
                        Session["AdminEmail"] = email;

                       
                        if (chkRememberMe.Checked)
                        {
                            HttpCookie cookie = new HttpCookie("AdminCookie");
                            cookie["AdminID"] = adminId.ToString();
                            cookie["AdminEmail"] = email;
                            cookie.Expires = DateTime.Now.AddDays(30);
                            Response.Cookies.Add(cookie);
                        }
                        else
                        {
                           
                            if (Request.Cookies["AdminCookie"] != null)
                            {
                                HttpCookie cookie = new HttpCookie("AdminCookie");
                                cookie.Expires = DateTime.Now.AddDays(-1);
                                Response.Cookies.Add(cookie);
                            }
                        }

                        Response.Redirect("Admin.aspx"); // Redirect to dashboard
                    }
                    else
                    {
                        lblMessage.Text = "Invalid password!";
                    }
                }
                else
                {
                    lblMessage.Text = "Email not found!";
                }
            }
        }
    }
}