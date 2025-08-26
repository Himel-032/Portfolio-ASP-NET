//using MySql.Data.MySqlClient;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace Portfolio
//{
//    public partial class Contact : Page
//    {
//        string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                LoadMessages();
//            }
//        }

//        private void LoadMessages()
//        {
//            using (MySqlConnection conn = new MySqlConnection(connStr))
//            {
//                string query = "SELECT id, fullname, email, message FROM contacts ORDER BY id DESC";
//                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
//                DataTable dt = new DataTable();
//                da.Fill(dt);

//                gvMessages.DataSource = dt;
//                gvMessages.DataBind();
//            }
//        }

//        protected void gvMessages_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
//        {
//            if (e.CommandName == "DeleteRow")
//            {
//                int id = Convert.ToInt32(e.CommandArgument);

//                using (MySqlConnection conn = new MySqlConnection(connStr))
//                {
//                    conn.Open();
//                    string query = "DELETE FROM contacts WHERE id = @id";
//                    MySqlCommand cmd = new MySqlCommand(query, conn);
//                    cmd.Parameters.AddWithValue("@id", id);
//                    cmd.ExecuteNonQuery();
//                }

//                LoadMessages(); // refresh grid
//            }

//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio
{
    public partial class Contact : Page
    {
        // Change to your SQL Server connection string in Web.config
        string connStr = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMessages();
            }
        }

        private void LoadMessages()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT id, fullname, email, message FROM contacts ORDER BY id DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvMessages.DataSource = dt;
                gvMessages.DataBind();
            }
        }

        protected void gvMessages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "DELETE FROM contacts WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                LoadMessages(); // refresh grid
            }
        }
    }
}
