using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string fullname = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string message = txtMessage.Text.Trim();

            // Check if any field is empty
            if (string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(message))
            {
                lblMsg.Text = "Please fill up all fields!";
                return;
            }

            // Insert into database
            string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO contacts (fullname, email, message) VALUES (@fullname, @email, @message)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fullname", fullname);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@message", message);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            lblMsg.Text = "Message sent successfully!";
                            txtFullName.Text = "";
                            txtEmail.Text = "";
                            txtMessage.Text = "";
                        }
                        else
                        {
                            lblMsg.Text = "Failed to send message!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMsg.Text = "Error: " + ex.Message;
                }
            }
        }
    }
}