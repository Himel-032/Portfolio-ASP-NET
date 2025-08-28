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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get the last part of the path (without leading slash)
                string currentPage = Request.Path.Trim('/').ToLower();

                string baseClass = "nav-link";

                AdminLink.Attributes["class"] = (currentPage == "admin") ? baseClass + " active" : baseClass;
                ResumeLink.Attributes["class"] = (currentPage == "resume") ? baseClass + " active" : baseClass;
                ProjectsLink.Attributes["class"] = (currentPage == "projects") ? baseClass + " active" : baseClass;
                BlogsLink.Attributes["class"] = (currentPage == "blogs") ? baseClass + " active" : baseClass;
                ContactLink.Attributes["class"] = (currentPage == "contact") ? baseClass + " active" : baseClass;
                NpmLink.Attributes["class"] = (currentPage == "npm") ? baseClass + " active" : baseClass;
            }
        }





    }
}