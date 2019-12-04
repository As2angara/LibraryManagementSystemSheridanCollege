using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LibraryManagementSystem.DAOLogic;

namespace LibraryManagementSystem.BusinessLogic
{

    /*
        BY: Adrian Angara - 991538458
    */

    public class LibrarianLogic
    {
        private DAO dao;


        //**CREATE
        public void CreateOverdueLoan()
        {
            dao = new DAO("Select * from Loan");
            DataTable tblLoan = dao.ReadLoanTable();

            dao = new DAO("Select * from Overdues");

            foreach (DataRow row in tblLoan.Rows)
            {
                if (DateTime.Compare(DateTime.Now, (DateTime)row["due_date"]) > 0)
                {
                    if (!dao.ReadDoesOverdueExist((int)row["Loan_Id"]))
                    {
                        dao.CreateOverdueLoan((int)row["Loan_Id"]);
                    }
                }
            }
        }

        //**READ
        public DataTable GetIssueRequests()
        {
            dao = new DAO("select l.Loan_Id, bc.BookCopy_Id, b.Book_Title, u.username " +
                "from Book b " +
                "inner join Book_Copy bc " +
                "on b.Book_Id = bc.Book_Id " +
                "inner join Loan l " +
                "on bc.BookCopy_Id = l.BookCopy_Id " +
                "inner join LibUsers u " +
                "on l.User_Id = u.User_Id " +
                "where l.issue_date is null"
                );

            return dao.ReadIssueRequests();
        }

        public DataTable GetReturnRequests()
        {
            dao = new DAO("select l.Loan_Id, bc.BookCopy_Id, b.Book_Title, u.username, l.issue_date, l.due_date " +
                "from Book b " +
                "inner join Book_Copy bc " +
                "on b.Book_Id = bc.Book_Id " +
                "inner join Loan l " +
                "on bc.BookCopy_Id = l.BookCopy_Id " +
                "inner join LibUsers u " +
                "on l.User_Id = u.User_Id " +
                "where bc.Availability like 'Return Request'"
                );

            return dao.ReadIssueRequests();
        }

        public DataTable GetExtensionRequests()
        {
            dao = new DAO("select l.Loan_Id, bc.BookCopy_Id, b.Book_Title, u.username, l.issue_date, l.due_date " +
                "from Book b " +
                "inner join Book_Copy bc " +
                "on b.Book_Id = bc.Book_Id " +
                "inner join Loan l " +
                "on bc.BookCopy_Id = l.BookCopy_Id " +
                "inner join LibUsers u " +
                "on l.User_Id = u.User_Id " +
                "where bc.Availability like 'Extension Request'"
                );

            return dao.ReadIssueRequests();
        }

        public DataTable GetLoanInformation()
        {
            dao = new DAO("select l.Loan_Id, bc.BookCopy_Id, b.Book_Title, u.username, l.issue_date, l.due_date, l.return_date " +
                "from Book b " +
                "inner join Book_Copy bc " +
                "on b.Book_Id = bc.Book_Id " +
                "inner join Loan l " +
                "on bc.BookCopy_Id = l.BookCopy_Id " +
                "inner join LibUsers u " +
                "on l.User_Id = u.User_Id ");

            return dao.ReadIssueRequests();
        }

        public DataTable GetOverdueInformation()
        {
            dao = new DAO("Select * from Overdues");

            return dao.ReadIssueRequests();
        }

        //**UPDATE
        public void UpdateLoanTable(int loanId, int sit)
        {
            dao = new DAO("select * from Loan");

            dao.UpdateLoanTable(loanId);
            int copyId = dao.ReadCopyIdFromLoan(loanId);
            dao = new DAO("select * from Book_Copy");
            dao.UpdateBookCopyTable(copyId, sit);
        }

        public int UpdateLoanTableDelete(int loanId, int sit)
        {
            dao = new DAO("select * from Loan");
            int copyId = dao.ReadCopyIdFromLoan(loanId);
            dao.DeleteRejectedLoan(loanId);


            dao = new DAO("select * from Book_Copy");

            return dao.UpdateBookCopyTable(copyId, sit); ;
        }

        public int UpdateLoanTableReturn(int loanId, int sit)
        {
            dao = new DAO("select * from Loan");
            int copyId = dao.ReadCopyIdFromLoan(loanId);
            dao.UpdateReturnDate(copyId);

            dao = new DAO("select * from Book_Copy");
            dao.UpdateBookCopyTable(copyId, sit);

            return copyId;
        }

        public int UpdateLoanTableDueDate(int loanId, int sit)
        {
            dao = new DAO("select * from Loan");
            int copyId = dao.ReadCopyIdFromLoan(loanId);
            dao.UpdateDueDate(copyId);

            dao = new DAO("select * from Book_Copy");
            dao.UpdateBookCopyTable(copyId, sit);

            return copyId;
        }
        
        //**DELETE






    }


}