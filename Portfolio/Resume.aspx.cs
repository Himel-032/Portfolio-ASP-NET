using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Portfolio
{
    public partial class Resume : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEducation();
                LoadExperience();
                LoadSkills();
                LoadProgramming();
                LoadLanguages();
            }
        }

        //------------------- EDUCATION -------------------
        private void LoadEducation()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Education", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvEducation.DataSource = dt;
                gvEducation.DataBind();
            }
        }

        protected void btnAddEducation_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEduTitle.Text) || string.IsNullOrWhiteSpace(txtEduDuration.Text) || string.IsNullOrWhiteSpace(txtEduDesc.Text))
            {
                lblEduMessage.Text = "Please fill all fields!";
                lblEduMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Education (Title, Duration, Description) VALUES (@t, @d, @desc)", con);
                cmd.Parameters.AddWithValue("@t", txtEduTitle.Text);
                cmd.Parameters.AddWithValue("@d", txtEduDuration.Text);
                cmd.Parameters.AddWithValue("@desc", txtEduDesc.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            txtEduTitle.Text = "";
            txtEduDuration.Text = "";
            txtEduDesc.Text = "";
            lblEduMessage.Text = "Inserted successfully!";
            lblEduMessage.ForeColor = System.Drawing.Color.Green;
            LoadEducation();
        }

        protected void gvEducation_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEducation.EditIndex = e.NewEditIndex;
            LoadEducation();
        }

        protected void gvEducation_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvEducation.DataKeys[e.RowIndex].Value);
            string title = ((TextBox)gvEducation.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
            string duration = ((TextBox)gvEducation.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string desc = ((TextBox)gvEducation.Rows[e.RowIndex].Cells[2].Controls[0]).Text;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Education SET Title=@t, Duration=@d, Description=@desc WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@t", title);
                cmd.Parameters.AddWithValue("@d", duration);
                cmd.Parameters.AddWithValue("@desc", desc);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            gvEducation.EditIndex = -1;
            LoadEducation();
        }

        protected void gvEducation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEducation.EditIndex = -1;
            LoadEducation();
        }

        protected void gvEducation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvEducation.DataKeys[e.RowIndex].Value);
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Education WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            LoadEducation();
        }

        //------------------- EXPERIENCE -------------------
        private void LoadExperience()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Experience", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvExperience.DataSource = dt;
                gvExperience.DataBind();
            }
        }

        protected void btnAddExperience_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtExpTitle.Text) || string.IsNullOrWhiteSpace(txtExpDuration.Text) || string.IsNullOrWhiteSpace(txtExpDesc.Text))
            {
                lblExpMsg.Text = "Please fill all fields!";
                lblExpMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Experience (Title, Duration, Description) VALUES (@t, @d, @desc)", con);
                cmd.Parameters.AddWithValue("@t", txtExpTitle.Text);
                cmd.Parameters.AddWithValue("@d", txtExpDuration.Text);
                cmd.Parameters.AddWithValue("@desc", txtExpDesc.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            txtExpTitle.Text = "";
            txtExpDuration.Text = "";
            txtExpDesc.Text = "";

            lblExpMsg.Text = "Inserted successfully!";
            lblExpMsg.ForeColor = System.Drawing.Color.Green;
            LoadExperience();
        }

        protected void gvExperience_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvExperience.EditIndex = e.NewEditIndex;
            LoadExperience();
        }

        protected void gvExperience_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvExperience.DataKeys[e.RowIndex].Value);
            string title = ((TextBox)gvExperience.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
            string duration = ((TextBox)gvExperience.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string desc = ((TextBox)gvExperience.Rows[e.RowIndex].Cells[2].Controls[0]).Text;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Experience SET Title=@t, Duration=@d, Description=@desc WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@t", title);
                cmd.Parameters.AddWithValue("@d", duration);
                cmd.Parameters.AddWithValue("@desc", desc);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            gvExperience.EditIndex = -1;
            LoadExperience();
        }

        protected void gvExperience_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvExperience.EditIndex = -1;
            LoadExperience();
        }

        protected void gvExperience_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvExperience.DataKeys[e.RowIndex].Value);
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Experience WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            LoadExperience();
        }

        //------------------- SKILLS -------------------
        private void LoadSkills()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Skills", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvSkills.DataSource = dt;
                gvSkills.DataBind();
            }
        }

        protected void btnAddSkill_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSkillName.Text) || string.IsNullOrWhiteSpace(txtSkillPercent.Text) )
            {
                lblSkillMsg.Text = "Please fill all fields!";
                lblSkillMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Skills (Name, Percentage) VALUES (@n, @p)", con);
                cmd.Parameters.AddWithValue("@n", txtSkillName.Text);
                cmd.Parameters.AddWithValue("@p", Convert.ToInt32(txtSkillPercent.Text));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            txtSkillName.Text = "";
            txtSkillPercent.Text = "";
            lblSkillMsg.Text = "Inserted successfully!";
            lblSkillMsg.ForeColor = System.Drawing.Color.Green;

            LoadSkills();
        }

        protected void gvSkills_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSkills.EditIndex = e.NewEditIndex;
            LoadSkills();
        }

        protected void gvSkills_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvSkills.DataKeys[e.RowIndex].Value);
            string name = ((TextBox)gvSkills.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
            int percent = Convert.ToInt32(((TextBox)gvSkills.Rows[e.RowIndex].Cells[1].Controls[0]).Text);

            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Skills SET Name=@n, Percentage=@p WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@p", percent);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            gvSkills.EditIndex = -1;
            LoadSkills();
        }

        protected void gvSkills_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSkills.EditIndex = -1;
            LoadSkills();
        }

        protected void gvSkills_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvSkills.DataKeys[e.RowIndex].Value);
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Skills WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            LoadSkills();
        }

        // ================= Programming Languages Section ===================
        protected void btnAddProgramming_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProgName.Text) || string.IsNullOrWhiteSpace(txtProgPercent.Text) )
            {
                lblProgMsg.Text = "Please fill all fields!";
                lblProgMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "INSERT INTO ProgrammingLanguages (Name, Percentage) VALUES (@Name, @Percentage)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", txtProgName.Text.Trim());
                cmd.Parameters.AddWithValue("@Percentage", txtProgPercent.Text.Trim());
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            txtProgName.Text = "";
            txtProgPercent.Text = "";
            lblProgMsg.Text = "Inserted successfully!";
            lblProgMsg.ForeColor = System.Drawing.Color.Green;
            LoadProgramming();
        }

        protected void gvProgramming_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProgramming.EditIndex = e.NewEditIndex;
            LoadProgramming();
        }

        protected void gvProgramming_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProgramming.EditIndex = -1;   // exit edit mode
            LoadProgramming();
        }

        protected void gvProgramming_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvProgramming.DataKeys[e.RowIndex].Value);

            TextBox txtName = (TextBox)gvProgramming.Rows[e.RowIndex].Cells[1].Controls[0];
            TextBox txtPercentage = (TextBox)gvProgramming.Rows[e.RowIndex].Cells[2].Controls[0];

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "UPDATE ProgrammingLanguages SET Name=@Name, Percentage=@Percentage WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@Percentage", txtPercentage.Text.Trim());
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            gvProgramming.EditIndex = -1;
            LoadProgramming();
        }

        protected void gvProgramming_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvProgramming.DataKeys[e.RowIndex].Value);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "DELETE FROM ProgrammingLanguages WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadProgramming();
        }
        private void LoadProgramming()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM ProgrammingLanguages";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvProgramming.DataSource = dt;
                gvProgramming.DataBind();
            }
        }


        // ================= Languages Section =================
        protected void btnAddLanguage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLangName.Text) || string.IsNullOrWhiteSpace(txtLangPercent.Text))
            {
                lblLangMsg.Text = "Please fill all fields!";
                lblLangMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "INSERT INTO Languages (Name, Percentage) VALUES (@Name, @Percentage)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", txtLangName.Text.Trim());
                cmd.Parameters.AddWithValue("@Percentage", Convert.ToInt32(txtLangPercent.Text.Trim()));

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            txtLangName.Text = "";
            txtLangPercent.Text = "";


            lblLangMsg.Text = "Inserted successfully!";
            lblLangMsg.ForeColor = System.Drawing.Color.Green;
            LoadLanguages();
        }

        private void LoadLanguages()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM Languages";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvLanguages.DataSource = dt;
                gvLanguages.DataBind();
            }
        }

        protected void gvLanguages_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvLanguages.EditIndex = e.NewEditIndex;
            LoadLanguages();
        }

        protected void gvLanguages_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvLanguages.EditIndex = -1;
            LoadLanguages();
        }

        protected void gvLanguages_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvLanguages.Rows[e.RowIndex];
            int id = Convert.ToInt32(gvLanguages.DataKeys[e.RowIndex].Value);

            string name = (row.Cells[1].Controls[0] as TextBox).Text.Trim();
            int percentage = Convert.ToInt32((row.Cells[2].Controls[0] as TextBox).Text.Trim());

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "UPDATE Languages SET Name=@Name, Percentage=@Percentage WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Percentage", percentage);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            gvLanguages.EditIndex = -1;
            LoadLanguages();
        }

        protected void gvLanguages_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvLanguages.DataKeys[e.RowIndex].Value);

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "DELETE FROM Languages WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            LoadLanguages();
        }

    }
}

