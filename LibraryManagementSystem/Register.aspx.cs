using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryManagementSystem.BusinessLogic;
using LibraryManagementSystem.bean;

namespace LibraryManagementSystem
{
    /*
      BY: Komalpreet Aulakh - 991497738 
    */

    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // read values from the text fields
            string username = txtUsername.Text.Trim();
            string password = Encryptor.EncryptText(txtPassword.Text.Trim());
            string passwordCon = Encryptor.EncryptText(txtConfirmPassword.Text.Trim());

            if(!password.Equals(passwordCon))
            {
                lblMessage.Text = "Passwords do not match. Please try again.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            AuthenticationLogic al = new AuthenticationLogic();

            User user = al.GetUserByName(username);

            if(user != null)
            {
                lblMessage.Text = "Username is taken. Please try again.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (al.CreateUser(new User(0, username, password, "Member", "")) == 1)
            {
                lblMessage.Text = "Registration Complete!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                return;
            }

        }

       
    }
}