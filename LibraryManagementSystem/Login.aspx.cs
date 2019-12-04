using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using LibraryManagementSystem.BusinessLogic;
using LibraryManagementSystem.bean;


namespace LibraryManagementSystem
{
    /*
      BY: Gurmandeep Singh Gill - 991517131 
          
    */

    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //Retrieve User and Password
            string username = txtUsername.Text.Trim();
            string password = Encryptor.EncryptText(txtPassword.Text.Trim());

            //Pass to Business layer
            AuthenticationLogic al = new AuthenticationLogic();
            User user = al.AuthenticateUser(username, password);

            if (user != null) 
            {
                // initialize FormsAuthentication
                FormsAuthentication.Initialize();

                // create a new ticket used for authentication
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1,                              // ticket version
                    username,                       // username associated with ticket
                    DateTime.Now,                   // date/time issued
                    DateTime.Now.AddMinutes(30),    // date/time to expire
                    false,          // "true" for a persistent user cookie
                    user.Role,       // user-data, in this case the roles
                    FormsAuthentication.FormsCookiePath);   // path cookie is valid for

                // encrypt the ticket using the machine key for secure transport
                string hashedTicket = FormsAuthentication.Encrypt(ticket);

                // create cookie
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashedTicket);

                // set the cookie's expiration time to the ticket's expiration time
                if (ticket.IsPersistent)
                    cookie.Expires = ticket.Expiration;

                // add the cookie to the list for outgoing response
                Response.Cookies.Add(cookie);

                // redirect to requested URL, or to the role's homepage
                string returnUrl = Request.QueryString["ReturnUrl"];

                if (returnUrl == null)
                {
                    if (user.Role.Equals("Admin"))
                        returnUrl = "~/Admin/Admin.aspx";
                    else if (user.Role.Equals("Member"))
                        returnUrl = "~/Member/Member.aspx";
                    else if (user.Role.Equals("Librarian"))
                        returnUrl = "~/Librarian/Librarian.aspx";
                    else
                        returnUrl = "~/";

                }

                Session["Username"] = username;
                Session["User_Id"] = user.ID;
                Session["Role"] = user.Role;

                Response.Redirect(returnUrl);
            } else
            {
                lblMessage.Text = "Incorrect username and/or password.";
            }

        }
    }
}