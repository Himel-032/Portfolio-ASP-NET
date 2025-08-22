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
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        //string currentPage = System.IO.Path.GetFileName(Request.Path).ToLower();
        //        //System.Diagnostics.Debug.WriteLine("Current page: " + currentPage);
        //        string currentPage = Request.Path; // should be like "/Admin.aspx"
        //        Response.Write("Current page: " + currentPage);


        //        // Base class
        //        string baseClass = "nav-link";

        //        // Assign active based on page
        //        if (currentPage == "admin.aspx")
        //            AdminLink.Attributes["class"] = baseClass + " active";
        //        else
        //            AdminLink.Attributes["class"] = baseClass;

        //        if (currentPage == "projects.aspx")
        //            ProjectsLink.Attributes["class"] = baseClass + " active";
        //        else
        //            ProjectsLink.Attributes["class"] = baseClass;

        //        if (currentPage == "contact.aspx")
        //            ContactLink.Attributes["class"] = baseClass + " active";
        //        else
        //            ContactLink.Attributes["class"] = baseClass;

        //        if (currentPage == "npm.aspx")
        //            NpmLink.Attributes["class"] = baseClass + " active";
        //        else
        //            NpmLink.Attributes["class"] = baseClass;
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get the last part of the path (without leading slash)
                string currentPage = Request.Path.Trim('/').ToLower();

                string baseClass = "nav-link";

                AdminLink.Attributes["class"] = (currentPage == "admin") ? baseClass + " active" : baseClass;
                ProjectsLink.Attributes["class"] = (currentPage == "projects") ? baseClass + " active" : baseClass;
                ContactLink.Attributes["class"] = (currentPage == "contact") ? baseClass + " active" : baseClass;
                NpmLink.Attributes["class"] = (currentPage == "npm") ? baseClass + " active" : baseClass;
            }
        }





    }
}