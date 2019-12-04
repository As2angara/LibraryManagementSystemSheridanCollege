using LibraryManagementSystem.bean;
using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.DAOLogic
{
    /*
        BY: Adrian Angara - 991538458
    */

    public class DAO
    {
        //Declare query as a string property
        private string query;

        public string Query
        {
            set { query = value; }
        }


        //Get connection String
        string cs = Data.GetConnectionString("LibraryDatabase");

        // Declare some SQL objects
        SqlConnection conn;
        SqlDataAdapter adapter;
        DataSet ds;
        SqlCommandBuilder cmdBuilder;
        

        //Constructor
        public DAO(string query)
        {
            Query = query;
            conn = new SqlConnection(cs);
            adapter = new SqlDataAdapter(query, conn);
            ds = new DataSet();
            cmdBuilder = new SqlCommandBuilder(adapter);
        }

        //Methods


        ///----------------------------------------------------------------------------------///
        //** Authentication
        public User AuthenticateUser(string username, string password)
        {
            //Create needed objects
            DataTable tblUsers;
            User user = null;

            //Extract table info
            adapter.Fill(ds);
            ds.Tables[0].TableName = "Users";
            tblUsers = ds.Tables["Users"];

            //Find if User exists 
            bool isFound = false;
            DataTable users = new DataTable();
            DataRow userRow = users.NewRow();
            foreach (DataRow row in tblUsers.Rows)
            {
                if (row["username"].ToString().Equals(username) && row["password"].ToString().Equals(password))
                {
                    userRow = row;
                    isFound = true;
                }
            }

            if (isFound)
            {
                user = new User((int)userRow["User_Id"], username, "", userRow["Role_Name"].ToString(), "");
            }
             

            return user;
        }

        public User GetUserByName(string username)
        {
            //Create needed objects
            DataTable tblUsers;
            User user = null;

            //Extract table info
            adapter.Fill(ds);
            ds.Tables[0].TableName = "Users";
            tblUsers = ds.Tables["Users"];

            //Find if User exists 
            bool isFound = false;
            DataTable users = new DataTable();
            DataRow userRow = users.NewRow();
            foreach (DataRow row in tblUsers.Rows)
            {
                if (row["username"].ToString().Equals(username))
                {
                    userRow = row;
                    isFound = true;
                }
            }

            if (isFound)
            {
                user = new User((int)userRow["User_Id"], username, "", userRow["Role_Name"].ToString(), "");
            }

            return user;
        }

        public int CreateUser(User user)
        {
            //Create data table
            DataTable tblUsers;

            //Extract table info
            adapter.Fill(ds);
            ds.Tables[0].TableName = "Users";
            tblUsers = ds.Tables["Users"];

            //Add row for the new entry
            DataRow row = tblUsers.NewRow();

            row[0] = 0;
            row[1] = user.Username;
            row[2] = user.Password;
            row[3] = user.Role;
            row[4] = user.Filepath;

            tblUsers.Rows.Add(row);

            adapter.InsertCommand = cmdBuilder.GetInsertCommand();
            int rowsAffected = adapter.Update(tblUsers);

            return rowsAffected;
        }

        public void UpdateUser(User user)
        {
            //Create needed objects
            DataTable tblUsers;

            //Extract table info
            adapter.Fill(ds);
            ds.Tables[0].TableName = "LibUsers";
            tblUsers = ds.Tables["LibUsers"];

            //Find row and update return date
            foreach (DataRow row in tblUsers.Rows)
            {
                if ((int)row["User_Id"] == user.ID)
                {
                    row["password"] = user.Password;
                    row["home_address"] = user.HomeAddress;
                    row["phone_num"] = user.PhoneNum;
                    row["email"] = user.Email;
                }
            }

            adapter.UpdateCommand = cmdBuilder.GetUpdateCommand();

            // Update() method saves the changes from the dataset to the database
            adapter.Update(tblUsers);

        }

        ///----------------------------------------------------------------------------------///

        //** CREATE
        public int CreateBookLoan(int userId, int copyId)
        {
            //Create needed objects
            DataTable tblLoan;

            //Extract table info
            adapter.Fill(ds);
            ds.Tables[0].TableName = "Loan";
            tblLoan = ds.Tables["Loan"];

            //Add row for the new entry
            DataRow row = tblLoan.NewRow();
            row[0] = 0;
            row[1] = userId;
            row[5] = copyId;

            tblLoan.Rows.Add(row);

            adapter.InsertCommand = cmdBuilder.GetInsertCommand();
            int rowsAffected = adapter.Update(tblLoan);

            return rowsAffected;

        }

        public void CreateOverdueLoan(int loanId)
        {
            //Create needed objects
            DataTable tblOverdue;

            //Extract table info
            adapter.Fill(ds);
            ds.Tables[0].TableName = "Overdues";
            tblOverdue = ds.Tables["Overdues"];

            //Add row for the new entry
            DataRow row = tblOverdue.NewRow();
            row[1] = loanId;
            row[2] = 0.50;

            tblOverdue.Rows.Add(row);

            adapter.InsertCommand = cmdBuilder.GetInsertCommand();
            int rowsAffected = adapter.Update(tblOverdue);
        }


        //** READ
        public DataTable ReadBookTable()
        {
            //Create needed objects
            DataTable tblBooks;

            //Extract table info
            adapter.Fill(ds);
            ds.Tables[0].TableName = "Book";
            tblBooks = ds.Tables["Book"];

            return tblBooks;
        }

        public DataTable ReadLoanTable()
        {
            //Create needed objects
            DataTable tblLoan;

            //Extract table info
            adapter.Fill(ds);
            ds.Tables[0].TableName = "Loan";
            tblLoan = ds.Tables["Loan"];

            return tblLoan;
        }

        public DataTable ReadIssueRequests()
        {

            //Extract table info
            adapter.Fill(ds);

            return ds.Tables[0];
        }

        public int ReadCopyIdFromLoan(int loanId)
        {
            //Create needed objects
            DataTable tblLoan;

            //Extract table info
            adapter.Fill(ds);
            ds.Tables[0].TableName = "Loan";
            tblLoan = ds.Tables["Loan"];

            DataColumn[] pk = new DataColumn[1];
            pk[0] = tblLoan.Columns["Loan_Id"];
            tblLoan.PrimaryKey = pk;

            DataRow row = tblLoan.Rows.Find(loanId);

            if (row != null)
            {
                return (int)row["BookCopy_Id"];
            }

            return -1;
        }

        public bool ReadDoesOverdueExist(int loanId)
        {
            //Create needed objects
            DataTable tblOverdue;

            //Extract table info
            adapter.Fill(ds);
            ds.Tables[0].TableName = "Overdues";
            tblOverdue = ds.Tables["Overdues"];

            //check if the overdues exists
            foreach (DataRow row in tblOverdue.Rows)
            {
                if ((int)row["Loan_Id"] == loanId)
                {
                    return true;
                }
            }

            return false;
        }

        public User ReadMemberInfo(int userId)
        {
            //Create needed objects
            DataTable tblUsers;
            User user = null;

            //Extract table info
            adapter.Fill(ds);
            ds.Tables[0].TableName = "LibUsers";
            tblUsers = ds.Tables["LibUsers"];

            //check if the overdues exists
            foreach (DataRow row in tblUsers.Rows)
            {
                if ((int)row["User_Id"] == userId)
                {
                    user = new User(userId, (string)row["username"], (string)row["password"],
                                    (string)row["home_address"], (string)row["phone_num"], (string)row["email"],
                                    (string)row["Role_Name"], (string)row["filepath"]);          
                }
            }

            return user;
        }

        //** UPDATE
        public int UpdateBookCopyTable(int copyId, int sit)
        {
            //Create needed objects
            DataTable tblBookCopy;

            //Extract table info
            adapter.Fill(ds);
            ds.Tables[0].TableName = "Book_Copy";
            tblBookCopy = ds.Tables["Book_Copy"];

            //Determine Primary key
            DataColumn[] pk = new DataColumn[1];
            pk[0] = tblBookCopy.Columns["BookCopy_Id"];
            tblBookCopy.PrimaryKey = pk;

            DataRow row = tblBookCopy.Rows.Find(copyId);

            switch (sit)
            {
                case 1:
                    row["Availability"] = "Issue Request";
                    break;
                case 2:
                    row["Availability"] = "Unavailable";
                    break;
                case 3:
                    row["Availability"] = "Extension Request";
                    break;
                case 4:
                    row["Availability"] = "Available";
                    break;
                case 5:
                    row["Availability"] = "Return Request";
                    break;
            }


            adapter.UpdateCommand = cmdBuilder.GetUpdateCommand();

            // Update() method saves the changes from the dataset to the database
            int rowsaffected = adapter.Update(tblBookCopy);

            return rowsaffected;
        }

        public void UpdateLoanTable(int loanId)
        {
            //Create needed objects
            DataTable tblLoan;

            //Extract table info
            adapter.Fill(ds);
            ds.Tables[0].TableName = "Loan";
            tblLoan = ds.Tables["Loan"];

            //Determine Primary key
            DataColumn[] pk = new DataColumn[1];
            pk[0] = tblLoan.Columns["Loan_Id"];
            tblLoan.PrimaryKey = pk;

            DataRow row = tblLoan.Rows.Find(loanId);
            row["issue_date"] = DateTime.Now.AddDays(-14);
            row["due_date"] = DateTime.Now.AddDays(-3);

            adapter.UpdateCommand = cmdBuilder.GetUpdateCommand();

            // Update() method saves the changes from the dataset to the database
            adapter.Update(tblLoan);
        }

        public int UpdateReturnDate(int copyId)
        {
            //Create needed objects
            DataTable tblLoan;

            //Extract table info
            adapter.Fill(ds);
            ds.Tables[0].TableName = "Loan";
            tblLoan = ds.Tables["Loan"];

            //Determine Primary key
            DataColumn[] pk = new DataColumn[1];
            pk[0] = tblLoan.Columns["Loan_Id"];
            tblLoan.PrimaryKey = pk;

            //Find row and update return date
            foreach (DataRow row in tblLoan.Rows)
            {
                if ((int)row["BookCopy_Id"] == copyId)
                {
                    row["return_date"] = DateTime.Now;
                }
            }

            adapter.UpdateCommand = cmdBuilder.GetUpdateCommand();

            // Update() method saves the changes from the dataset to the database
            int rowsAffected = adapter.Update(tblLoan);


            return rowsAffected;
        }

        public int UpdateDueDate(int copyId)
        {
            //Create needed objects
            DataTable tblLoan;

            //Extract table info
            adapter.Fill(ds);
            ds.Tables[0].TableName = "Loan";
            tblLoan = ds.Tables["Loan"];

            //Determine Primary key
            DataColumn[] pk = new DataColumn[1];
            pk[0] = tblLoan.Columns["Loan_Id"];
            tblLoan.PrimaryKey = pk;

            //Find row and update return date
            foreach (DataRow row in tblLoan.Rows)
            {
                if ((int)row["BookCopy_Id"] == copyId)
                {
                    DateTime dt = (DateTime)row["due_date"];
                    row["due_date"] = dt.AddDays(7);
                }
            }

            adapter.UpdateCommand = cmdBuilder.GetUpdateCommand();

            // Update() method saves the changes from the dataset to the database
            int rowsAffected = adapter.Update(tblLoan);


            return rowsAffected;
        }

        public void UpdateOverduesTable(int loanId, double amountPaid)
        {
            //Create needed objects
            DataTable tblOverdues;

            //Extract table info
            adapter.Fill(ds);
            ds.Tables[0].TableName = "Overdues";
            tblOverdues = ds.Tables["Overdues"];

            //Find row and update return date
            foreach (DataRow row in tblOverdues.Rows)
            {
                if ((int)row["Loan_Id"] == loanId)
                {
                    row["amount_paid"] = amountPaid;
                }
            }

            adapter.UpdateCommand = cmdBuilder.GetUpdateCommand();

            // Update() method saves the changes from the dataset to the database
            adapter.Update(tblOverdues);

        }

        public void UpdateUserRequestDelete(int userId)
        {
            //Create needed objects
            DataTable tblUsers;

            //Extract table info
            adapter.Fill(ds);
            ds.Tables[0].TableName = "LibUsers";
            tblUsers = ds.Tables["LibUsers"];

            //Find row and update return date
            foreach (DataRow row in tblUsers.Rows)
            {
                if ((int)row["User_Id"] == userId)
                {
                    row["isRequestDelete"] = "true";
                }
            }

            adapter.UpdateCommand = cmdBuilder.GetUpdateCommand();

            // Update() method saves the changes from the dataset to the database
            adapter.Update(tblUsers);
        }

        //** DELETE
        public void DeleteRejectedLoan(int loanId)
        {
            //Create needed objects
            DataTable tblLoan;

            //Extract table info
            adapter.Fill(ds);
            ds.Tables[0].TableName = "Loan";
            tblLoan = ds.Tables["Loan"];

            //Determine Primary key
            DataColumn[] pk = new DataColumn[1];
            pk[0] = tblLoan.Columns["Loan_Id"];
            tblLoan.PrimaryKey = pk;

            DataRow row = tblLoan.Rows.Find(loanId);

            // delete the row
            row.Delete();
            adapter.DeleteCommand = cmdBuilder.GetDeleteCommand();
            int rowsAffected = adapter.Update(tblLoan);

        }

       

       

       

      
  

    }
       
}