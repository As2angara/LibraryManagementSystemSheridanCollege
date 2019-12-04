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
      BY: Gurmandeep Singh Gill - 991517131 
          Komalpreet Aulakh - 991497738
    */

    public partial class MemberEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MemberLogic ml = new MemberLogic();

                User user = ml.GetMemberInfo((int)Session["User_Id"]);

                txtbUsername.Text = user.Username;
                //txtbPassword.Text = user.Password;

                txtbAddress.Text = user.HomeAddress;
                txtbPhoneNum.Text = user.PhoneNum;
                txtbEmail.Text = user.Email;

                imgMember.ImageUrl = "~/images/" + user.Filepath;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            string password = Encryptor.EncryptText(txtbPassword.Text.Trim());

            User user = new User((int)Session["User_Id"], txtbUsername.Text, password,
                                    txtbAddress.Text, txtbPhoneNum.Text, txtbEmail.Text, 
                                    (string)Session["Role"], "");

            MemberLogic ml = new MemberLogic();
            ml.UpdateUser(user);

            Response.Redirect("~/Member/Member.aspx");
        }

        protected void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            MemberLogic ml = new MemberLogic();
            ml.RequestAccountDelete((int)Session["User_Id"]);

            Response.Redirect("~/Member/Member.aspx");
        }
    }
}