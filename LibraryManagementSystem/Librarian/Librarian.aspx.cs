using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryManagementSystem.BusinessLogic;
using LibraryManagementSystem.bean;
using System.Data;

namespace LibraryManagementSystem
{

    /*
        BY: Adrian Angara - 991538458
    */
    public partial class Librarian : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlAction.Items.Add(new ListItem("Select an Action", "-1"));
                ddlAction.Items.Add(new ListItem("Requests", "Requests"));
                ddlAction.Items.Add(new ListItem("Reports", "Reports"));
                ddlAction.Items.Add(new ListItem("Search for Book", "Search for Book"));
                ddlAction.Items.Add(new ListItem("Fines", "Fines"));

                MemberLogic ml = new MemberLogic();
                User user = ml.GetMemberInfo((int)Session["User_Id"]);

                Label1.Text = user.HomeAddress;
                Label2.Text = user.PhoneNum;
                Label3.Text = user.Email;

                Image1.ImageUrl = "../images/" + user.Filepath;
            }
        }

        //**Actions
        protected void ddlAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            if (ddlAction.SelectedValue.Equals("Requests"))
            {
                PlaceHolderDefault.Visible = false;
                PlaceHolder1.Visible = true;
                PlaceHolder2.Visible = false;
                PlaceHolder3.Visible = false;

            } else if (ddlAction.SelectedValue.Equals("Reports"))
            {
                PlaceHolderDefault.Visible = false;
                PlaceHolder1.Visible = false;
                PlaceHolder2.Visible = true;
                PlaceHolder3.Visible = false;

            } else if (ddlAction.SelectedValue.Equals("Search for Book"))
            {
                PlaceHolderDefault.Visible = false;
                PlaceHolder1.Visible = false;
                PlaceHolder2.Visible = false;
                PlaceHolder3.Visible = true;

                ddlSearch.Items.Add(new ListItem("ID", "BookCopy_Id"));
                ddlSearch.Items.Add(new ListItem("Book Title", "Book_title"));
                ddlSearch.Items.Add(new ListItem("Author", "Author"));
                ddlSearch.Items.Add(new ListItem("Genre", "Genre"));
                ddlSearch.Items.Add(new ListItem("Publisher", "Publisher"));

            } else if (ddlAction.SelectedValue.Equals("-1"))
            {
                PlaceHolderDefault.Visible = true;
                PlaceHolder1.Visible = false;
                PlaceHolder2.Visible = false;
                PlaceHolder3.Visible = false;
            }
        }

        //**Tabs
        protected void btnRequest1_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            PlaceHolderLoanId.Visible = true;
            btnApprove.Visible = true;
            btnReject.Visible = true;
            btnExtension.Visible = false;
            btnReturned.Visible = false;

            LibrarianLogic ll = new LibrarianLogic();

            DataTable tblIssueRequests = ll.GetIssueRequests();

            if(tblIssueRequests.Rows.Count == 0)
            {
                lblMessage.Text = "No Issue Requests Pending.";
                return;
            }

            GridView1.DataSource = tblIssueRequests;
            GridView1.DataBind();
        }

        protected void btnRequest2_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            PlaceHolderLoanId.Visible = true;
            btnApprove.Visible = false;
            btnReject.Visible = false;
            btnExtension.Visible = false;
            btnReturned.Visible = true;

            LibrarianLogic ll = new LibrarianLogic();
            DataTable tblReturn = ll.GetReturnRequests();

            if (tblReturn.Rows.Count == 0)
            {
                lblMessage.Text = "No Return Requests Pending.";
                return;
            }

            GridView1.DataSource = tblReturn;
            GridView1.DataBind();
        }

        protected void btnRequest3_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            PlaceHolderLoanId.Visible = true;
            btnApprove.Visible = false;
            btnReject.Visible = false;
            btnExtension.Visible = true;
            btnReturned.Visible = false;

            LibrarianLogic ll = new LibrarianLogic();

            DataTable tblExtensionRequests = ll.GetExtensionRequests();

            if (tblExtensionRequests.Rows.Count == 0)
            {
                lblMessage.Text = "No Extension Requests Pending.";
                return;
            }

            GridView1.DataSource = tblExtensionRequests;
            GridView1.DataBind();
        }

        protected void btnReport1_Click(object sender, EventArgs e)
        {
            btnRefreshOverdues.Visible = false;

            //Book Information
            MemberLogic ml = new MemberLogic();
            DataTable tblBooks;

            tblBooks = ml.GetBooksTable();
            
            GridView1.DataSource = tblBooks;
            GridView1.DataBind();
        }

        protected void btnReport2_Click(object sender, EventArgs e)
        {
            btnRefreshOverdues.Visible = false;

            //ALL LOANS
            LibrarianLogic ll = new LibrarianLogic();
            DataTable tblLoan = ll.GetLoanInformation();

            GridView1.DataSource = tblLoan;
            GridView1.DataBind();
        }

        protected void btnReport3_Click(object sender, EventArgs e)
        {
            btnRefreshOverdues.Visible = true;

            //All Overdue Books
            LibrarianLogic ll = new LibrarianLogic();
            DataTable tblOverdues = ll.GetOverdueInformation();

            GridView1.DataSource = tblOverdues;
            GridView1.DataBind();
        }

        //**Librarian Responses
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            LibrarianLogic ll = new LibrarianLogic();

            ll.UpdateLoanTable(int.Parse(txtLoanId.Text), 2);

            DataTable tblIssueRequests = ll.GetIssueRequests();

            GridView1.DataSource = tblIssueRequests;
            GridView1.DataBind();
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            LibrarianLogic ll = new LibrarianLogic();

            int num = ll.UpdateLoanTableDelete(int.Parse(txtLoanId.Text), 4);

            DataTable tblIssueRequests = ll.GetIssueRequests();

            GridView1.DataSource = tblIssueRequests;
            GridView1.DataBind();


        }

        protected void btnReturned_Click(object sender, EventArgs e)
        {
            LibrarianLogic ll = new LibrarianLogic();

            int num = ll.UpdateLoanTableReturn(int.Parse(txtLoanId.Text), 4);

            DataTable tblReturnRequests = ll.GetReturnRequests();

            GridView1.DataSource = tblReturnRequests;
            GridView1.DataBind();
        }

        protected void btnExtend_Click(object sender, EventArgs e)
        {
            LibrarianLogic ll = new LibrarianLogic();

            ll.UpdateLoanTableDueDate(int.Parse(txtLoanId.Text), 2);

            DataTable tblExtensionRequests = ll.GetExtensionRequests();

            GridView1.DataSource = tblExtensionRequests;
            GridView1.DataBind();
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

        protected void btnRefreshOverdues_Click(object sender, EventArgs e)
        {
            //All Overdue Books
            LibrarianLogic ll = new LibrarianLogic();
            ll.CreateOverdueLoan();
            DataTable tblOverdues = ll.GetOverdueInformation();

            GridView1.DataSource = tblOverdues;
            GridView1.DataBind();
        }
    }
}