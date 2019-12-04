using System.Configuration;

namespace LibraryManagementSystem
{
    /*
        Taken from in class sourcecodes  
    */

    public class Data
    {
        public static string GetConnectionString(string connectionStringName)
        {
            return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }
    }

}