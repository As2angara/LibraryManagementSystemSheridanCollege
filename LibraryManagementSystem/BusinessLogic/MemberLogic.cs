using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LibraryManagementSystem.DAOLogic;
using LibraryManagementSystem.bean;

namespace LibraryManagementSystem.BusinessLogic
{

    /*
      BY: Gurmandeep Singh Gill - 991517131 
          Komalpreet Aulakh - 991497738
    */

    public class MemberLogic
    {
        //Constructor
        public MemberLogic()
        {

        }

        private DAO dao;


        //**CREATE
        public int RequestBookLoan(int userId, int copyId)
        {
            dao = new DAO("select * from Loan");
            int rowsaffected = dao.CreateBookLoan(userId, copyId);

            dao = new DAO("select * from Book_Copy");
            dao.UpdateBookCopyTable(copyId, 1);

            return rowsaffected;
        }


        //**READ
        public DataTable GetAvailableBooksTable()
        {
            dao = new DAO(
                "Select bc.BookCopy_Id, b.Book_title, b.Genre, b.Author, b.Publisher " +
                "from Book_Copy bc " +
                "inner join Book b " +
                "on b.Book_Id = bc.Book_Id " +
                "where bc.Availability like 'Available'");




            return dao.ReadBookTable();
        }

        public DataTable GetBooksTable()
        {
            dao = new DAO("Select bc.BookCopy_Id, b.Book_title, b.Genre, b.Author, b.Publisher from Book_Copy bc " +
                "inner join Book b on b.Book_Id = bc.Book_Id;");


            return dao.ReadBookTable();
        }

        public DataTable GetBooksTable(string filter, string search)
        {
            dao = new DAO("Select bc.BookCopy_Id, b.Book_title, b.Genre, b.Author, b.Publisher " +
                "from Book_Copy bc " +
                "inner join Book b " +
                "on b.Book_Id = bc.Book_Id " +
                "where b." + filter + " Like '" + search + "' " 
                );


            return dao.ReadBookTable();
        }

        public DataTable GetBooksTable(int id)
        {
            dao = new DAO("Select bc.BookCopy_Id, b.Book_title, b.Genre, b.Author, b.Publisher " +
                "from Book_Copy bc " +
                "inner join Book b " +
                "on b.Book_Id = bc.Book_Id " +
                "where bc.BookCopy_Id = " + id 
                );

            return dao.ReadIssueRequests();
        }

        public DataTable GetLoanTable(int userId)
        {
            dao = new DAO("Select l.BookCopy_Id, b.Book_title, b.Author, l.issue_date, l.due_date " +
                "from Loan l " +
                "inner join Book_Copy bc " +
                "on bc.BookCopy_Id = l.BookCopy_Id " +
                "inner join Book b " +
                "on b.Book_Id = bc.Book_Id " +
                "where l.User_Id = " + userId + " and " +
                "l.issue_date is not null and " +
                "l.return_date is null");

            return dao.ReadLoanTable();
        }

        public DataTable GetLoanHistoryTable(int userId)
        {
            dao = new DAO("Select l.BookCopy_Id, b.Book_title, b.Author, l.issue_date, l.due_date, l.return_date " +
                "from Loan l " +
                "inner join Book_Copy bc " +
                "on bc.BookCopy_Id = l.BookCopy_Id " +
                "inner join Book b " +
                "on b.Book_Id = bc.Book_Id " +
                "where l.User_Id = " + userId);

            return dao.ReadLoanTable();
        }

        public DataTable GetAllOverdues(int userId)
        {
            dao = new DAO("Select o.Overdue_Id, l.BookCopy_Id, l.due_date, o.amount_due, o.date_paid " +
                "from Overdues o " +
                "inner join Loan l " +
                "on l.Loan_Id = o.Loan_Id " +
                "where l.User_Id = " + userId);

            return dao.ReadIssueRequests(); 
        }

        public DataTable GetUnpaidOverdues(int userId)
        {
            dao = new DAO("Select o.loan_Id, l.BookCopy_Id, l.due_date, o.amount_due " +
                "from Overdues o " +
                "inner join Loan l " +
                "on l.Loan_Id = o.Loan_Id " +
                "where l.User_Id = " + userId + " and " +
                "o.date_paid is null");

            return dao.ReadIssueRequests();
        }

        public User GetMemberInfo(int userId)
        {
            dao = new DAO("Select * from LibUsers");

            return dao.ReadMemberInfo(userId);
        }

        //**UPDATE
        public int ReturnBook(int userId, int copyId)
        {
            dao = new DAO("select * from Loan where User_Id = " + userId);

            int rowsaffected = dao.UpdateReturnDate(copyId);

            return rowsaffected;
        }

        public int RequestBookReturn(int copyId)
        {
            dao = new DAO("select * from Book_Copy");
            return dao.UpdateBookCopyTable(copyId, 5);
        }

        public int RequestBookExtension(int copyId)
        {
            dao = new DAO("select * from Book_Copy");
            return dao.UpdateBookCopyTable(copyId, 3);
        }

        public void PayForUnpaidOverdues(int loanId, double amountPaid)
        {
            dao = new DAO("select * from Overdues");

            dao.UpdateOverduesTable(loanId, amountPaid);
        }

        public void UpdateUser(User user)
        {
            dao = new DAO("Select * from LibUsers");

            dao.UpdateUser(user);
        }

        public void RequestAccountDelete(int userId)
        {
            dao = new DAO("Select * from LibUsers");

            dao.UpdateUserRequestDelete(userId);
        }

        //**DELETE







    }
}