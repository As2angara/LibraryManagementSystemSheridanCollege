using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Data;
using System.IO;
using LibraryManagementSystem.DAOLogic;
using LibraryManagementSystem.bean;

namespace LibraryManagementSystem.BusinessLogic
{
    /*
        BY: Adrian Angara - 991538458
    */

    public class AuthenticationLogic
    {
        private DAO dao;

        //Methods
        public User AuthenticateUser(string username, string password)
        {
            dao = new DAO("select * from LibUsers");
            return dao.AuthenticateUser(username, password);    
        }

        public User GetUserByName(string username)
        {
            dao = new DAO("select * from LibUsers");
            return dao.GetUserByName(username);
        }

        public int CreateUser(User user)
        {
            dao = new DAO("select * from LibUsers");
            return dao.CreateUser(user);
        }


    }
}