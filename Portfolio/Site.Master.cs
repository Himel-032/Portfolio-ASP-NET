using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Portfolio
{
    public partial class SiteMaster : MasterPage
    {
        protected global::System.Web.UI.WebControls.LinkButton lnkLogout;
       


        protected void Page_Load(object sender, EventArgs e)
        {
           
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);

            //  checking session and cookies,
            if (Session["AdminID"] != null)
            {
                lblAdmin.Visible = true;
                lnkLogout.Visible = true;
                lblAdmin.Text = "Welcome, " + Session["AdminEmail"].ToString();
            }
            else if (Request.Cookies["AdminCookie"] != null)
            {
                // Restore session from cookie
                Session["AdminID"] = Request.Cookies["AdminCookie"]["AdminID"];
                Session["AdminEmail"] = Request.Cookies["AdminCookie"]["AdminEmail"];
                lblAdmin.Visible = true;
                lnkLogout.Visible = true;
                lblAdmin.Text = "Welcome, " + Session["AdminEmail"].ToString();
            }
            else
            {
                
                Response.Redirect("~/AdminLogin.aspx");
            }

           
            string currentPage = Request.Path.Trim('/').ToLower();

                string baseClass = "nav-link";

                AdminLink.Attributes["class"] = (currentPage == "admin") ? baseClass + " active" : baseClass;
                ServicesLink.Attributes["class"] = (currentPage == "services") ? baseClass + " active" : baseClass;
                ResumeLink.Attributes["class"] = (currentPage == "resume") ? baseClass + " active" : baseClass;
                CertificatesLink.Attributes["class"] = (currentPage == "certificates") ? baseClass + " active" : baseClass;
                ProjectsLink.Attributes["class"] = (currentPage == "project") ? baseClass + " active" : baseClass;
                BlogsLink.Attributes["class"] = (currentPage == "blog") ? baseClass + " active" : baseClass;
                ContactLink.Attributes["class"] = (currentPage == "contact") ? baseClass + " active" : baseClass;
                NpmLink.Attributes["class"] = (currentPage == "npm") ? baseClass + " active" : baseClass;
            
           
        }


        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            // Clear session
            Session.Clear();
            Session.Abandon();

            // Delete cookie
            if (Request.Cookies["AdminCookie"] != null)
            {
                HttpCookie cookie = new HttpCookie("AdminCookie");
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

            Response.Redirect("~/AdminLogin.aspx");
        }





    }
}