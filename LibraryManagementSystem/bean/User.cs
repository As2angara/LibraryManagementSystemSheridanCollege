using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.bean
{
    /*
        BY: Adrian Angara - 991538458
    */

    public class User
    {
        //Properties
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string homeAddress;

        public string HomeAddress
        {
            get { return homeAddress; }
            set { homeAddress = value; }
        }

        private string phoneNum;

        public string PhoneNum
        {
            get { return phoneNum; }
            set { phoneNum = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }


        private string role;

        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        private string filepath;

        public string Filepath
        {
            get { return filepath; }
            set { filepath = value; }
        }


        //Constructor
        public User(int id, string username, string password, string homeAddress, 
                    string phoneNum, string email, string role, string filepath)
        {
            ID = id;
            Username = username;
            Password = password;
            HomeAddress = homeAddress;
            PhoneNum = phoneNum;
            Email = email;
            Role = role;
            Filepath = filepath;
        }

        public User(int id, string username, string password, string role, string filepath)
        {
            ID = id;
            Username = username;
            Password = password;
            Role = role;
            Filepath = filepath;
        }




    }
}