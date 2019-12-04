using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryManagementSystem.DAOLogic;
using System.Data;
using LibraryManagementSystem.BusinessLogic;
using LibraryManagementSystem.bean;


namespace LibraryManagementSystem
{
    /*
      BY: Gurmandeep Singh Gill - 991517131 
          Komalpreet Aulakh - 991497738
    */

    public partial class Member : System.Web.UI.Page
    {
        /*Page Load*/
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                MemberLogic ml = new MemberLogic();
                User user = ml.GetMemberInfo((int)Session["User_Id"]);

                Label1.Text = user.HomeAddress;
                Label2.Text = user.PhoneNum;
                Label3.Text = user.Email;

                imgMember.ImageUrl = "../images/" + user.Filepath;
               
                ddlSearch.Items.Add(new ListItem("ID", "BookCopy_Id"));
                ddlSearch.Items.Add(new ListItem("Book Title", "Book_title"));
                ddlSearch.Items.Add(new ListItem("Author", "Author"));
                ddlSearch.Items.Add(new ListItem("Genre", "Genre"));
                ddlSearch.Items.Add(new ListItem("Publisher", "Publisher"));

                ddlOverdues.Items.Add(new ListItem("Select an Action", "-1"));
                ddlOverdues.Items.Add(new ListItem("View Unpaid Overdues", "Unpaid"));
                ddlOverdues.Items.Add(new ListItem("View History of Overdues", "History"));
            }
        }

        /*Main Section Tabs*/
        protected void btnLoanBook_Click(object sender, EventArgs e)
        {
            PlaceHolder1.Visible = true;
            PlaceHolder2.Visible = false;
            PlaceHolder3.Visible = false;
            MemberLogic ml = new MemberLogic();
            DataTable tblBooks = ml.GetAvailableBooksTable();

            GridView1.DataSource = tblBooks;
            GridView1.DataBind();

            btnRequestLoan.Visible = true;
            btnRequestReturn.Visible = false;
            btnRequestExtension.Visible = false;
        }

        protected void btnReturnBook_Click(object sender, EventArgs e)
        {
            PlaceHolder1.Visible = true;
            PlaceHolder2.Visible = false;
            PlaceHolder3.Visible = false;
            MemberLogic ml = new MemberLogic();
            DataTable tblLoan = ml.GetLoanTable((int)Session["User_Id"]);

            GridView1.DataSource = tblLoan;
            GridView1.DataBind();

            btnRequestLoan.Visible = false;
            btnRequestReturn.Visible = true;
            btnRequestExtension.Visible = true;
        }

        protected void btnHistory_Click(object sender, EventArgs e)
        {
            PlaceHolder1.Visible = false;
            PlaceHolder2.Visible = false;
            PlaceHolder3.Visible = false;
            MemberLogic ml = new MemberLogic();
            DataTable tblLoanHistory;

            tblLoanHistory = ml.GetLoanHistoryTable((int)Session["User_Id"]);

            GridView1.DataSource = tblLoanHistory;
            GridView1.DataBind();
        }

        protected void BtnSearchForBook_Click(object sender, EventArgs e)
        {
            PlaceHolder1.Visible = false;
            PlaceHolder2.Visible = false;
            PlaceHolder3.Visible = true;

            GridView1.DataSource = null;
            GridView1.DataBind();
        }

        /*Main Section Tab Actions*/
        protected void btnLoad_Click(object sender, EventArgs e)
        {
            MemberLogic ml = new MemberLogic();
            DataTable tblBooks = ml.GetBooksTable();

            foreach (DataRow row in tblBooks.Rows)
            {
                if((int)row["BookCopy_Id"] == int.Parse(txtCopyId.Text))
                {
                    txtBookName.Text = row["Book_title"].ToString();
                }
            }
        }

        protected void btnRequestLoan_Click(object sender, EventArgs e)
        {
            MemberLogic ml = new MemberLogic();
            int num = ml.RequestBookLoan((int)Session["User_Id"], int.Parse(txtCopyId.Text));

            if (num == 1)
            {
                lblMessage.Text = "Request Sent";
                DataTable tblBooks = ml.GetAvailableBooksTable();

                GridView1.DataSource = tblBooks;
                GridView1.DataBind();
            }
        }

        protected void btnRequestReturn_Click(object sender, EventArgs e)
        {
            MemberLogic ml = new MemberLogic();
            int rowsAffected = ml.RequestBookReturn(int.Parse(txtCopyId.Text));

            if(rowsAffected == 1)
            {
                DataTable dt = ml.GetLoanTable((int)Session["User_Id"]);
                GridView1.DataSource = dt;
                GridView1.DataBind();

                lblMessage.Text = "Return Request Pending";
                return;
            }

            lblMessage.Text = "Returned failed.";
        }

        protected void btnRequestExtension_Click(object sender, EventArgs e)
        {
            MemberLogic ml = new MemberLogic();
            int rowsAffected = ml.RequestBookExtension(int.Parse(txtCopyId.Text));

            if (rowsAffected == 1)
            {
                DataTable dt = ml.GetLoanTable((int)Session["User_Id"]);
                GridView1.DataSource = dt;
                GridView1.DataBind();

                lblMessage.Text = "Return Request Pending";
                return;
            }

            lblMessage.Text = "Returned failed.";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            MemberLogic ml = new MemberLogic();
            DataTable tblBooks;

            if (ddlSearch.SelectedValue.Equals("BookCopy_Id"))
            {
                tblBooks = ml.GetBooksTable(int.Parse(txtSearch.Text));
            }
            else
            {
                tblBooks = ml.GetBooksTable(ddlSearch.SelectedValue, txtSearch.Text);
            }

            GridView1.DataSource = tblBooks;
            GridView1.DataBind();

        }

        
        /*Over Due Actions*/
        protected void btnOverdueAction_Click(object sender, EventArgs e)
        {
            PlaceHolder1.Visible = false;
            PlaceHolder2.Visible = false;
            PlaceHolder3.Visible = false;

            MemberLogic ml = new MemberLogic();
            DataTable tblOverdues = null;

            if (ddlOverdues.SelectedValue.Equals("Unpaid"))
            {
                PlaceHolder2.Visible = true;
                tblOverdues = ml.GetUnpaidOverdues((int)Session["User_Id"]);
            }
            else if (ddlOverdues.SelectedValue.Equals("History"))
            {
                PlaceHolder2.Visible = false;
                tblOverdues = ml.GetAllOverdues((int)Session["User_Id"]);
            }

            GridView1.DataSource = tblOverdues;
            GridView1.DataBind();

        }

        protected void btnMakePayment_Click(object sender, EventArgs e)
        {
            MemberLogic ml = new MemberLogic();
            DataTable tblOverdues = null;

            ml.PayForUnpaidOverdues(int.Parse(txtLoanId.Text), double.Parse(txtPaymentAmount.Text));
            
            
            tblOverdues = ml.GetUnpaidOverdues((int)Session["User_Id"]);
            GridView1.DataSource = tblOverdues;
            GridView1.DataBind();
        }

        /*Edit Profile*/
        protected void btnViewProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Member/MemberEdit.aspx");
        }
    }
}