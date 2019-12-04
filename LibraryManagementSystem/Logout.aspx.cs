using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace LibraryManagementSystem
{
    /*
        Taken from in class sourcecodes  
    */

    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // clear the sessions
            Session["Username"] = null;
            Session["Role"] = null;

            // and logout
            FormsAuthentication.SignOut();
            Response.Redirect("~/");
        }
    }
}